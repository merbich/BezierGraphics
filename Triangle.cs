using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BezierGraphics
{
    public class Triangle
    {
        //Vector3 vert1; // (i+1, j)
        //Vector3 vert2; // (i, j+1)
        //Vector3 vert3; // (i+1, j+1)

        public Vector3[] vertexes { get; set; }
        public Vector3[] normalVectors { get; set; }
        public List<(Vector3, Vector3)> edges { get; set; }
        public Triangle(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            vertexes = new Vector3[3];
            normalVectors = new Vector3[3];
            vertexes[0] = v1;
            vertexes[1] = v2;
            vertexes[2] = v3;

            edges = new List<(Vector3, Vector3)>();
            edges.Add((v1, v2));
            edges.Add((v2, v3));
            edges.Add((v1, v3));
        }
        public void SetZ(int index, float z)
        {
            vertexes[index].Z = z;
        }

    }
}
