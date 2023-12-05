using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BezierGraphics
{
    public struct ET
    {
        public float Ymax;
        public float Xmin;
        public float m;
        public ET((Vector3, Vector3) e)
        {
            Ymax = e.Item1.Y > e.Item2.Y ? e.Item1.Y : e.Item2.Y;
            Xmin = e.Item1.Y < e.Item2.Y ? e.Item1.X : e.Item2.X;

            float dy = e.Item2.Y - e.Item1.Y;
            float dx = e.Item2.X - e.Item1.X;
            if (dy == 0) m = 1;
            //if (dx == 0) m = 0;
            else m = dx / dy;
        }

        public ET(float Y, float X, float m)
        {
            Ymax = Y;
            Xmin = X;
            this.m = m;
        }
    }
    public static class FillPolygon
    {
        public static void FillPolygonMethod(Triangle t)
        {

            // ET list
            List<(Vector3, Vector3)> edges = t.edges;
            (List<ET>[] buckets, int YMIN, int YMAX) = BucketSort(edges);
            List<ET> AET = new List<ET>();
            int scan = YMIN;
            while(scan <= YMAX-1)
            {
                // przenieś listy z kubełka ET[y] do AET 
                if (buckets[scan].Count != 0)
                {
                    for (int i = 0; i < buckets[scan].Count; i++)
                        AET.Add(buckets[scan][i]);
                }

                // wypełnij piksele pomiędzy parami przecięć
                FillScanLine(AET, scan, t);

                //usuń z AET te elementy, dla których y=ymax 
                for (int i = 0; i<AET.Count; i++)
                {
                    if (AET[i].Ymax == scan) AET.RemoveAt(i);
                }

                // zwiększ y o 1 (przejście do następnej scan-linii) 
                scan++;

                // dla każdej krawędzi w AET uaktualnij x dla nowej scanlinii y(x+= 1 / m)
                for(int i = 0; i<AET.Count; i++)
                {
                    AET[i] = new ET(AET[i].Ymax, AET[i].Xmin + AET[i].m, AET[i].m);
                }
            }
        }
        public static (List<ET>[], int, int) BucketSort(List<(Vector3, Vector3)> edges)
        {
            int YMAX = 0, YMIN = 0;
            foreach ((Vector3, Vector3) edge in edges)
            {
                if (edge.Item1.Y > YMAX) YMAX = (int)edge.Item1.Y;
                if (edge.Item2.Y > YMAX) YMAX = (int)edge.Item2.Y;

                if (edge.Item1.Y < YMIN) YMIN = (int)edge.Item1.Y;
                if (edge.Item2.Y < YMIN) YMIN = (int)edge.Item2.Y;
            }
            List<ET>[] buckets = new List<ET>[YMAX-YMIN+1];
            for (int i = 0; i < buckets.Length; i++) buckets[i] = new List<ET>();
            foreach ((Vector3, Vector3) edge in edges)
            {
                // horizontal
                if (edge.Item1.Y == edge.Item2.Y) continue;

                ET et = new ET(edge);
                float min = edge.Item1.Y < edge.Item2.Y ? edge.Item1.Y : edge.Item2.Y;
                buckets[(int)min].Add(et);
            }
            return (buckets, YMIN, YMAX);
        }
        public static void FillScanLine(List<ET> AET, int scan, Triangle t)
        {
            for(int i = 0; i<AET.Count; i+=2)
            {
                ET et1 = AET[i];
                ET et2 = AET[i + 1];

                float min = et1.Xmin < et2.Xmin ? et1.Xmin : et2.Xmin;
                float max = et1.Xmin > et2.Xmin ? et1.Xmin : et2.Xmin;

                for (int x = (int)min; x<(int)max; x++)
                {
                    float x1 = (float)x / LogicFile.bm.Width;
                    float y1 = (float)scan / LogicFile.bm.Height;

                    (float r, float s, float q) = LogicFile.Barycentric(t, new Vector2(x1, y1));

                    Vector3 v1 = t.vertexes[0];
                    Vector3 v2 = t.vertexes[1];
                    Vector3 v3 = t.vertexes[2];

                    float X = (r * v1.X + s * v2.X + q * v3.X)/LogicFile.bm.Width;
                    float Y = (r * v1.Y + s * v2.Y + q * v3.Y)/LogicFile.bm.Height;
                    float Z = r * v1.Z + s * v2.Z + q * v3.Z;


                    Color c;
                    Vector3 N1 = t.normalVectors[0];
                    Vector3 N2 = t.normalVectors[1];
                    Vector3 N3 = t.normalVectors[2];

                    float NX = (r * N1.X + s * N2.X + q * N3.X);
                    float NY = (r * N1.Y + s * N2.Y + q * N3.Y);
                    float NZ = r * N1.Z + s * N2.Z + q * N3.Z;
                    Vector3 norm = new Vector3(NX, NY, NZ);
                    // TOOOOOO
                    norm = Vector3.Normalize(norm);
                    //-----
                    if (LogicFile.isNormalMap)
                    {

                        //Vector3 norm = ColorFile.ComputeNormal(LogicFile.ZControlPoints, X, Y);
                        //norm = Vector3.Normalize(norm);
                        norm = NormalMap.ComputeNewVector(norm, x, scan);
                        //norm = Vector3.Normalize(norm);
                        c = ColorFile.ComputeColor(X, Y, Z, LogicFile.ZControlPoints, norm);
                    }
                    else
                        c = ColorFile.ComputeColor(X, Y, Z, LogicFile.ZControlPoints, norm);

                    if (x >= 900) continue;
                    //LogicFile.bm.SetPixel(x, scan, c);

                    if(!LogicFile.isRotate)
                    {
                        LogicFile.bm.SetPixel(x, scan, c);
                    }
                    else
                    {
                        Vector3 p = new Vector3(x, scan, 100*Z);
                        p = Vector3.Transform(p, LogicFile.M);
                        if (p.X < 0 || p.Y < 0) continue;
                        LogicFile.bm.SetPixel((int)p.X, (int)p.Y, c);
                    }

                    
                }
                
            }
        }
    }
}
