using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BezierGraphics
{
    public static class NormalMap
    {
        public static Vector3 CreateNormalVectorFromNormalMap(int x, int y)
        {
            Color c = LogicFile.image.GetPixel(x, y);
            float R, G, B;

            R = (float)c.R / 127 - 1;
            G = (float)c.G / 127 - 1;
            //B = (float)c.B / 127 - 1;
            B = (float)c.B / 255;

            return new Vector3(R, G, B);
        }

        public static Vector3 CreateBVector(Vector3 initVector)
        {
            if (initVector.X == 0f && initVector.Y == 0f && initVector.Z == 1f)
                return new Vector3(0f, 1f, 0f);
            return Vector3.Cross(initVector, new Vector3(0f, 0f, 1f));
        }

        public static Vector3 ComputeNewVector(Vector3 init, int x, int y)
        {
            Vector3 B = CreateBVector(init);
            Vector3 Ntexture = CreateNormalVectorFromNormalMap(x, y);
            Vector3 T = Vector3.Cross(B, init);

            float row1 = T.X * Ntexture.X + B.X * Ntexture.Y + init.X * Ntexture.Z;
            float row2 = T.Y * Ntexture.X + B.Y * Ntexture.Y + init.Y * Ntexture.Z;
            float row3 = T.Z * Ntexture.X + B.Z * Ntexture.Y + init.Z * Ntexture.Z;

            return new Vector3(row1, row2, row3);
        }
    }
}
