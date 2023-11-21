using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BezierGraphics
{
    public static class LogicFile
    {
        public static TextBox text;
        public static DirectBitmap bm;
        public static Graphics g;
        public static PictureBox pic;
        public static DirectBitmap image;
        public static DirectBitmap BackgroundImage;
        public static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        internal static List<Triangle> triangles;
        public static List<Vector3> NormalVectors;
        //public static List<Color> colors = new List<Color>(); // zmiana

        public static bool isControlPoints = false;
        public static bool isBezierGrid = false;
        public static bool isNormalMap = false;
        public static bool isBackgroundImage = false;
        public static bool isAnimation = false;

        public static int GridSize = 6;
        public static (bool, int) zControlPoint = (false, -1);
        public static float ZAmimatePosition = 2f;

        public static (float, float)[] ControlPoints = {(0f,0f), (1/3f, 0f), (2/3f, 0f), (1f, 0f),
                                                   (0f, 1/3f), (1/3f, 1/3f), (2/3f, 1/3f), (1f, 1/3f),
                                                   (0f, 2/3f), (1/3f, 2/3f), (2/3f, 2/3f), (1f, 2/3f),
                                                   (0f, 1f), (1/3f, 1f), (2/3f, 1f), (1f, 1f)};
        public static float[] ZControlPoints = new float[16];
        public static bool[] isControlPointsBool = new bool[16];

        #region InitRegion
        public static void LogicInit()
        {
            bm = new DirectBitmap(pic.Width, pic.Height);
            g = Graphics.FromImage(bm.Bitmap);
            pic.Image = bm.Bitmap;
            Image j = Image.FromFile("C:/Users/user/Desktop/sem5/GrafikaKomputerowa/BezierGraphics/BezierGraphics/initNormalMap.png");
            image = new DirectBitmap(new Bitmap(j, new Size(900, 900)));

            triangles = new List<Triangle>();
            NormalVectors = new List<Vector3>();

            for(int i = 0; i<16; i++)
            {
                ZControlPoints[i] = 0f;
                isControlPointsBool[i] = false;
            }
            //ZControlPoints[3] = 0.0001f;
            //ZControlPoints[0] = 00000000.1f;
            //-------
            //ComputeZ();
            CalculateBasicTriangles(true);
            InitTriangles();
            FillTriangles();
            //Animate();
            //Draw();
        }
        #endregion
        #region Drawing
        public static void Draw()
        {
            //g.Clear(Color.White);
            //_ = FillTrianglesAsync();
            DrawControlPoints(isControlPoints);
            DrawBezierGrid(isBezierGrid, GridSize);
            pic.Refresh();
        }
        public static void DrawControlPoints(bool isDraw)
        {
            if (!isDraw) return;
            Pen pen = new Pen(Color.Red, 3);
            int radius = 20;
            for (int i = 0; i < ControlPoints.Length; i++)
            {
                PointF p = new PointF(ControlPoints[i].Item1, ControlPoints[i].Item2);
                p.X = p.X * bm.Bitmap.Width;
                p.Y = p.Y * bm.Bitmap.Height;

                if (isControlPointsBool[i]) pen = new Pen(Color.Yellow, 3);
                else pen = new Pen(Color.Red, 3);

                g.DrawEllipse(pen, p.X - radius, p.Y - radius,
                      radius + radius, radius + radius);
            }
        }
        public static void DrawBezierGrid(bool isDraw, int times)
        {
            if (!isDraw) return;
            Pen pen = new Pen(Color.Red, 2);
            // 6 triangles on side
            float w = bm.Width;
            float h = bm.Height;
            float t = (float)times;
            for(int i = 0; i<=times; i++)
            {
                // Horizontal lines
                PointF p1 = new PointF(w * 1f / t * (float)i, 0f);
                PointF p2 = new PointF(w * 1f / t * (float)i, h);
                g.DrawLine(pen, p1, p2);

                // Vertical lines
                p1 = new PointF(0f, h * 1f / t * (float)i);
                p2 = new PointF(w, h * 1f / t * (float)i);
                g.DrawLine(pen, p1, p2);

                // Diagonal lines
                p1 = new PointF(0f, h * 1f / t * (float)i);
                p2 = new PointF(w * 1f/t*(float)i, 0f);
                g.DrawLine(pen, p1, p2);

                p1 = new PointF(w*1f/t*(float)i, h);
                p2 = new PointF(w, h * 1f / t * (float)i);
                g.DrawLine(pen, p1, p2);
            }
        }
        #endregion
        #region Triangles
        public static void CalculateBasicTriangles(bool isBegin)
        {
            //TODO
            //List<Triangle> trianglesTEMP = new List<Triangle>();
            PointF p1, p2, p3, p4;
            Vector3 v1, v2, v3, v4;
            float w = bm.Width;
            float h = bm.Height;
            float GS = GridSize;
            for (int i = 0; i<GridSize; i++)
            {
                for(int j = 0; j<GridSize; j++)
                {
                    p3 = new PointF(w / GS * i, h / GS * j);
                    p1 = new PointF(w / GS * (i + 1), h / GS * j);
                    p2 = new PointF(w / GS * i, h / GS * (j+1));   
                    p4 = new PointF(w / GS * (i + 1), h / GS * (j + 1));

                    //p3.X = p3.X / bm.Width; 
                    //p3.Y = p3.Y / bm.Height;
                    //p1.X = p1.X / bm.Width;
                    //p1.Y = p1.Y / bm.Height;
                    //p2.X = p2.X / bm.Width;
                    //p2.Y = p2.Y / bm.Height;
                    //p4.X = p4.X / bm.Width;
                    //p4.Y = p4.Y / bm.Height;
                    v1 = new Vector3(p1.X, p1.Y, 0f);
                    v2 = new Vector3(p2.X, p2.Y, 0f);
                    v3 = new Vector3(p3.X, p3.Y, 0f);
                    v4 = new Vector3(p4.X, p4.Y, 0f);

                    triangles.Add(new Triangle(v1, v2, v3));
                    triangles.Add(new Triangle(v1, v2, v4));
                }
            }
        }
        public static void InitTriangles()
        {
            foreach(Triangle t in triangles)
            {
                Vector3 v1 = t.vertexes[0];
                Vector3 v2 = t.vertexes[1];
                Vector3 v3 = t.vertexes[2];

                Vector3 N1 = ColorFile.ComputeNormal(ZControlPoints, v1.X/bm.Width, v1.Y/bm.Height);
                N1 = Vector3.Normalize(N1);
                Vector3 N2 = ColorFile.ComputeNormal(ZControlPoints, v2.X/bm.Width, v2.Y/bm.Height);
                N2 = Vector3.Normalize(N2);
                Vector3 N3 = ColorFile.ComputeNormal(ZControlPoints, v3.X/bm.Width, v3.Y/bm.Height);
                N3 = Vector3.Normalize(N3);

                t.normalVectors[0] = N1;
                t.normalVectors[1] = N2;
                t.normalVectors[2] = N3;

                float z1 = Bezier.ComputeZ(v1.X/bm.Width, v1.Y/bm.Height, ZControlPoints);
                float z2 = Bezier.ComputeZ(v2.X/bm.Width, v2.Y/bm.Height, ZControlPoints);
                float z3 = Bezier.ComputeZ(v3.X/bm.Width, v3.Y/bm.Height, ZControlPoints);

                t.SetZ(0, z1);
                t.SetZ(1, z2);
                t.SetZ(2, z3);
            }
        }
        //public static async Task ProcessTriangleAsync(Triangle t)
        //{
        //    await Task.Delay(100);

        //    FillPolygon.FillPolygonMethod(t);
        //}
        public static void FillTriangles()
        {
            //g.Clear(Color.White);
            //List<Task> tasks = new List<Task>();
            //foreach(Triangle t in triangles)
            //{
            //    //FillPolygon.FillPolygonMethod(t.edges, t);
            //    tasks.Add(ProcessTriangleAsync(t));
            //}
            //await Task.WhenAll(tasks);
            //Draw();
            g.Clear(Color.White);
            Parallel.ForEach(triangles, t =>
            {
                FillPolygon.FillPolygonMethod(t);
            });
            Draw();
        }

        #endregion
        #region ComputeZ
        //static public void ComputeZ()
        //{
        //    // for each pixel on bitmap
        //    for (int i = 0; i < bm.Width; i++)
        //    {
        //        for (int j = 0; j < bm.Height; j++)
        //        {
        //            float x = (float)i / bm.Width;
        //            float y = (float)j / bm.Height;
        //            float z = Bezier.ComputeZ(x, y, ZControlPoints);

        //            Color c = ColorFile.ComputeColor(x, y, z, ZControlPoints);

        //            //Vector3 norm = ColorFile.ComputeNormal(ZControlPoints, x, y);
        //            //norm = NormalMap.ComputeNewVector(norm, i, j);

        //            //Color c = ColorFile.ComputeColor(x, y, z, ZControlPoints, norm);

        //            bm.SetPixel(i, j, c);
        //        }
        //    }
        //    //Draw();
        //    pic.Refresh();
        //}
        public static void Debug(int locX, int locY)
        {
            ////text.Text = "locationX: " + locX.ToString() + "locationY: " + locY.ToString();
            //float x = (float)locX / bm.Width;
            //float y = (float)locY / bm.Height;
            //float z = Bezier.ComputeZ(x, y, ZControlPoints);
            ////float z = Bezier.ComputeZ(1f, 0f, ZControlPoints);
            //Vector3 norm = ColorFile.ComputeNormal(ZControlPoints, x, y);
            ////Vector3 norm = ColorFile.ComputeNormal(ZControlPoints, 1f, 1f);
            //norm = Vector3.Normalize(norm);
            //Vector3 light = ColorFile.DefineVectorBetween(new Vector3(x, y, z), ColorFile.lightPosition);
            //light = Vector3.Normalize(light);
            //text.Text = $"{x} {y} {z};";
            ////text.Text = $"{norm.X} {norm.Y} {norm.Z};";
            //Color c = ColorFile.ComputeColor(x, y, z, ZControlPoints);
            ////text.Text = $"{c.R}, {c.G}, {c.B}";
            ////text.Text = $"{light.X}, {light.Y}, {light.Z}, {light.Length()}";
            ///

            float x = (float)locX / bm.Width;
            float y = (float)locY / bm.Height;
            float z = Bezier.ComputeZ(x, y, ZControlPoints);

            Vector3 oldnorm = ColorFile.ComputeNormal(ZControlPoints, x, y);
            oldnorm = Vector3.Normalize(oldnorm);
            Vector3 newnorm = NormalMap.ComputeNewVector(oldnorm, locX, locY);
            //newnorm = Vector3.Normalize(newnorm);
            Color c = ColorFile.ComputeColor(x, y, z, ZControlPoints, newnorm);

            text.Text = $"{newnorm.X} {newnorm.Y} {newnorm.Z};";

        }

        //public static void NormalMapFunction()
        //{
        //    for(int i = 0;i<bm.Width; i++)
        //    {
        //        for(int j = 0; j<bm.Height; j++)
        //        {
        //            float x = (float)i / bm.Width;
        //            float y = (float)j / bm.Height;
        //            float z = Bezier.ComputeZ(x, y, ZControlPoints);

        //            // Color c = ColorFile.ComputeColor(x, y, z, ZControlPoints);

        //            Vector3 norm = ColorFile.ComputeNormal(ZControlPoints, x, y);
        //            norm = Vector3.Normalize(norm);
        //            norm = NormalMap.ComputeNewVector(norm, i, j);

        //            Color c = ColorFile.ComputeColor(x, y, z, ZControlPoints, norm);

        //            bm.SetPixel(i, j, c);
        //        }
        //    }
        //    pic.Refresh();
        //}
        #endregion

        #region Interpolation
        public static float TriangleArea(Vector2 v1, Vector2 v2, Vector2 v3)
        {

            Vector2 vectorAB = new Vector2(v2.X - v1.X, v2.Y - v1.Y);
            Vector2 vectorAC = new Vector2(v3.X - v1.X, v3.Y - v1.Y);

            float crossProductMagnitude = Math.Abs(vectorAB.X * vectorAC.Y - vectorAB.Y * vectorAC.X);

            return 0.5f * crossProductMagnitude;
        }

        public static (float, float, float) Barycentric(Triangle t, Vector2 p)
        {
            Vector2 v1 = new Vector2(t.vertexes[0].X/bm.Width, t.vertexes[0].Y/bm.Height);
            Vector2 v2 = new Vector2(t.vertexes[1].X / bm.Width, t.vertexes[1].Y / bm.Height);
            Vector2 v3 = new Vector2(t.vertexes[2].X / bm.Width, t.vertexes[2].Y / bm.Height);

            float abc = TriangleArea(v1, v2, v3);
            float r = TriangleArea(p, v2, v3) / abc;
            float s = TriangleArea(v1, p, v3) / abc;
            float q = 1f - r - s;

            //float X = r * v1.X + s * v2.X + q * v3.X;
            //float Y = r * v1.Y + s * v2.Y + q * v3.Y;
            //float Z = r * v1.Z + s * v2.Z + q * v3.Z;

            return (r, s, q);
        }
        #endregion
        #region Animation
        public static float angle = 0f;
        public static void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            //myTimer.Start();
            angle += 0.1f;
            // Runs the timer, and raises the event.
            float cosAngle = (float)Math.Cos(angle);
            float sinAngle = (float)Math.Sin(angle);

            // Transform the vector by substituting into the rotated ellipse equation
            float X = 0.5f + 0.2f * ColorFile.lightPosition.X * cosAngle - 0.1f * ColorFile.lightPosition.Y * sinAngle;
            float Y = 0.5f + 0.2f * ColorFile.lightPosition.X * sinAngle + 0.1f * ColorFile.lightPosition.Y * cosAngle;


            //float X = 0.1f * ColorFile.lightPosition.X + 0.5f;
            //float Y = 0.2f * ColorFile.lightPosition.Y + 0.5f;

            ColorFile.lightPosition = new Vector3(X, Y, ColorFile.lightPosition.Z);
            FillTriangles();
            //myTimer.Stop();
        }
        #endregion
    }
}
