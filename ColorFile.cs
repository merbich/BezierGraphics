﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BezierGraphics
{
    public static class ColorFile
    {
        public static float ks = 0.5f, kd = 0.5f;
        public static int m = 30;

        public static (float, float)[] ControlPoints = {(0f,0f), (1/3f, 0f), (2/3f, 0f), (1f, 0f),
                                                   (0f, 1/3f), (1/3f, 1/3f), (2/3f, 1/3f), (1f, 1/3f),
                                                   (0f, 2/3f), (1/3f, 2/3f), (2/3f, 2/3f), (1f, 2/3f),
                                                   (0f, 1f), (1/3f, 1f), (2/3f, 1f), (1f, 1f)};

        public static Vector3 lightColor = new Vector3(1f, 1f, 1f); // white
        public static Color lightColorC = Color.FromArgb(255, 255, 255); // white
        public static Vector3 objColor = new Vector3(1f, 1f, 1f); // red
        public static Color objColorC = Color.FromArgb(255, 0, 0); // red
        static Vector3 V = new Vector3(0f, 0f, 1f);

        // !
        public static Vector3 lightPosition = new Vector3(0.5f, 0.5f, 2f);

        public static Vector3 ReflectorRPosition = new Vector3(0f, 0f, 0.5f);
        public static Vector3 ReflectorGPosition = new Vector3(1f, 0f, 0.5f);
        public static Vector3 ReflectorBPosition = new Vector3(0.5f, 1f, 0.5f);
        public static Vector3 constlightPosition = new Vector3(0.5f, 0.5f, 0f);

        public static Vector3 RColor = new Vector3(1f, 0f, 0f);
        public static Vector3 GColor = new Vector3(0f, 1f, 0f);
        public static Vector3 BColor = new Vector3(0f, 0f, 1f);

        public static Vector3 DefineVectorBetween(Vector3 begin, Vector3 end) // zmiana
        { 
            return new Vector3(end.X - begin.X, end.Y - begin.Y, end.Z - begin.Z);
        }

        public static float ComputeCos(Vector3 v1, Vector3 v2)
        {
            float resultCos = v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
            if (resultCos < 0) return 0;
            else return resultCos;
        }

        public static Vector3 ComputeR(Vector3 N, Vector3 L)
        {
            float DotProduct = N.X*L.X + N.Y*L.Y + N.Z*L.Z;
            Vector3 NL = N - L;
            return new Vector3(2 * DotProduct * NL.X, 2 * DotProduct * NL.Y, 2 * DotProduct * NL.Z);
        }

        public static Vector3 ComputeNormal(float[] zControlPoints, float u, float v)
        {
            Vector3 Pu = new Vector3(0f, 0f, 0f);
            for(int i = 0; i<=2; i++)
            {
                for(int j = 0; j<=3; j++)
                {
                    float Bi2 = (float)Bezier.ComputeB(i, 2, u);
                    float Bj3 = (float)Bezier.ComputeB(j, 3, v);

                    // V (i+1, j)
                    Vector3 v1 = new Vector3(ControlPoints[(4 * j) + i+1].Item1,
                        ControlPoints[(4 * j) + i+1].Item2, zControlPoints[(4 * j) + i+1]);
                    // V(i, j)
                    Vector3 v2 = new Vector3(ControlPoints[(4 * j) + i].Item1,
                        ControlPoints[(4 * j) + i].Item2, zControlPoints[(4 * j) + i]);

                    Pu += DefineVectorBetween(v2, v1) * Bi2 * Bj3;
                }
            }
            Pu = 3 * Pu;

            Vector3 Pv = new Vector3(0f, 0f, 0f);
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    float Bi3 = (float)Bezier.ComputeB(i, 3, u);
                    float Bj2 = (float)Bezier.ComputeB(j, 2, v);

                    // V (i, j+1)
                    Vector3 v1 = new Vector3(ControlPoints[(4 * (j+1)) + i].Item1,
                        ControlPoints[(4 * (j+1)) + i].Item2, zControlPoints[(4 * (j+1)) + i]);
                    // V(i, j)
                    Vector3 v2 = new Vector3(ControlPoints[(4 * j) + i].Item1,
                        ControlPoints[(4 * j) + i].Item2, zControlPoints[(4 * j) + i]);

                    Pv += DefineVectorBetween(v2, v1) * Bi3 * Bj2;
                }
            }
            Pv = 3 * Pv;
            return Vector3.Cross(Pu, Pv);
        }


        

        public static Color ComputeColor(float x, float y, float z, float[] zControlPoints)
        {
            Vector3 point = new Vector3(x, y, z);
            Vector3 N = ComputeNormal(zControlPoints, x, y);
            N = Vector3.Normalize(N);

            Vector3 L = DefineVectorBetween(point, lightPosition);
            L = Vector3.Normalize(L);

            float cosNL = ComputeCos(N, L);
            float cosVR = ComputeCos(V, ComputeR(N, L));

            Vector3 I;
            if (!LogicFile.isBackgroundImage)
            {
                I = kd * lightColor * objColor * cosNL + ks * lightColor * objColor * (float)Math.Pow(cosVR, m);
            }
            else
            {
                Vector3 imageColor = ComputeBackgroundImageColor((int)(x * LogicFile.bm.Width), (int)(y * LogicFile.bm.Height));
                I = kd * lightColor * imageColor * cosNL + ks * lightColor * imageColor * (float)Math.Pow(cosVR, m);
            }
            float Redfactor = I.X*255;
            float GreenFactor = I.Y*255;
            float BlueFactor = I.Z*255;

            if (Redfactor > 255) Redfactor = 255;
            if (GreenFactor > 255) GreenFactor = 255;
            if (BlueFactor > 255) BlueFactor = 255;

            Color c = Color.FromArgb((int)(Redfactor), (int)(GreenFactor), (int)(BlueFactor));

            return c;
        }

        public static Vector3 ComputeBackgroundImageColor(int i, int j)
        {
            Color c = LogicFile.BackgroundImage.GetPixel(i, j);
            float X = c.R / 255f;
            float Y = c.G / 255f;
            float Z = c.B / 255f;
            return new Vector3(X, Y, Z);
        }

        public static Color ComputeColor(float x, float y, float z, float[] zControlPoints, Vector3 N)
        {
            Vector3 point = new Vector3(x, y, z);
            //Vector3 N = ComputeNormal(zControlPoints, x, y);
            //N = Vector3.Normalize(N);

            Vector3 L = DefineVectorBetween(point, lightPosition);
            L = Vector3.Normalize(L);

            float cosNL = ComputeCos(N, L);
            float cosVR = ComputeCos(V, ComputeR(N, L));
            Vector3 I = new Vector3(0f, 0f, 0f);
            //Vector3 I = kd * lightColor * objColor * cosNL + ks * lightColor * objColor * (float)Math.Pow(cosVR, m);
            if (!LogicFile.isBackgroundImage)
            {
                if (!LogicFile.isReflections && LogicFile.isLight)
                {
                    //I = new Vector3(0f, 0f, 0f);
                    I = kd * lightColor * objColor * cosNL + ks * lightColor * objColor * (float)Math.Pow(cosVR, m);
                }
                else if (LogicFile.isReflections && !LogicFile.isLight)
                {
                    Vector3 rFactor = ComputeRFactor(point, N);
                    Vector3 gFactor = ComputeGFactor(point, N);
                    Vector3 bFactor = ComputeBFactor(point, N);
                    I = rFactor + gFactor + bFactor;
                }
                else if(LogicFile.isLight && LogicFile.isReflections)
                {
                    //I = new Vector3(0f, 0f, 0f);
                    I = kd * lightColor * objColor * cosNL + ks * lightColor * objColor * (float)Math.Pow(cosVR, m);
                    Vector3 rFactor = ComputeRFactor(point, N);
                    Vector3 gFactor = ComputeGFactor(point, N);
                    Vector3 bFactor = ComputeBFactor(point, N);
                    I = I + rFactor + gFactor + bFactor;
                }
            }
            else
            {
                Vector3 imageColor = ComputeBackgroundImageColor((int)(x * LogicFile.bm.Width), (int)(y * LogicFile.bm.Height));

                if (!LogicFile.isReflections && LogicFile.isLight)
                {
                    //I = new Vector3(0f, 0f, 0f);
                    I = kd * lightColor * imageColor * cosNL + ks * lightColor * imageColor * (float)Math.Pow(cosVR, m);
                    //I = kd * lightColor * objColor * cosNL + ks * lightColor * objColor * (float)Math.Pow(cosVR, m);
                }
                else if (LogicFile.isReflections && !LogicFile.isLight)
                {
                    Vector3 temp = objColor;
                    objColor = imageColor;
                    Vector3 rFactor = ComputeRFactor(point, N);
                    Vector3 gFactor = ComputeGFactor(point, N);
                    Vector3 bFactor = ComputeBFactor(point, N);
                    I = rFactor + gFactor + bFactor;
                    objColor = temp;
                }
                else if (LogicFile.isLight && LogicFile.isReflections)
                {
                    //I = new Vector3(0f, 0f, 0f);
                    I = kd * lightColor * imageColor * cosNL + ks * lightColor * imageColor * (float)Math.Pow(cosVR, m);
                    Vector3 rFactor = ComputeRFactor(point, N);
                    Vector3 gFactor = ComputeGFactor(point, N);
                    Vector3 bFactor = ComputeBFactor(point, N);
                    I = I + rFactor + gFactor + bFactor;
                }


                
            }
            float Redfactor = I.X * 255;
            float GreenFactor = I.Y * 255;
            float BlueFactor = I.Z * 255;

            if (Redfactor > 255) Redfactor = 255;
            if (GreenFactor > 255) GreenFactor = 255;
            if (BlueFactor > 255) BlueFactor = 255;

            Color c = Color.FromArgb((int)(Redfactor), (int)(GreenFactor), (int)(BlueFactor));

            return c;
        }


        public static Vector3 ComputeRFactor(Vector3 point, Vector3 N)
        {
            Vector3 DR = DefineVectorBetween(constlightPosition, ReflectorRPosition); // DR
            DR = Vector3.Normalize(DR);
            Vector3 LR = DefineVectorBetween(point, ReflectorRPosition);
            LR = Vector3.Normalize(LR);
            float cosLDR = ComputeCos(LR, DR);
            Vector3 RR = ComputeR(N, LR);
            //RR = Vector3.Normalize(RR);
            float cosVR = ComputeCos(V, RR);
            float cosNL = ComputeCos(N, LR);

            Vector3 I = kd * RColor * (float)Math.Pow(cosLDR, 10) * objColor * cosNL + ks * RColor * (float)Math.Pow(cosLDR, 10) * objColor * (float)Math.Pow(cosVR, m);
            //I = Vector3.Normalize(I);
            return I;
        }

        public static Vector3 ComputeGFactor(Vector3 point, Vector3 N)
        {
            Vector3 DG = DefineVectorBetween(constlightPosition, ReflectorGPosition); // DR
            DG = Vector3.Normalize(DG);
            Vector3 LG = DefineVectorBetween(point, ReflectorGPosition);
            LG = Vector3.Normalize(LG);
            float cosLDG = ComputeCos(LG, DG);
            Vector3 RR = ComputeR(N, LG);
            //RR = Vector3.Normalize(RR);
            float cosVR = ComputeCos(V, RR);
            float cosNL = ComputeCos(N, LG);

            Vector3 I = kd * GColor * (float)Math.Pow(cosLDG, 10) * objColor * cosNL + ks * GColor * (float)Math.Pow(cosLDG, 10) * objColor * (float)Math.Pow(cosVR, m);
            //I = Vector3.Normalize(I);
            return I;
        }

        public static Vector3 ComputeBFactor(Vector3 point, Vector3 N)
        {
            Vector3 DB = DefineVectorBetween(constlightPosition, ReflectorBPosition); // DR
            DB = Vector3.Normalize(DB);
            Vector3 LB = DefineVectorBetween(point, ReflectorBPosition);
            LB = Vector3.Normalize(LB);
            float cosLDB = ComputeCos(LB, DB);
            Vector3 RR = ComputeR(N, LB);
            //RR = Vector3.Normalize(RR);
            float cosVR = ComputeCos(V, RR);
            float cosNL = ComputeCos(N, LB);

            Vector3 I = kd * BColor * (float)Math.Pow(cosLDB, 10) * objColor * cosNL + ks * BColor * (float)Math.Pow(cosLDB, 10) * objColor * (float)Math.Pow(cosVR, m);
            //I = Vector3.Normalize(I);
            return I;
        }
    }
}
