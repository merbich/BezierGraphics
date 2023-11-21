using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BezierGraphics
{
    public static class Bezier
    {
        //static (double, double)[] ControlPoints = {(0,0), (1/3, 0), (2/3, 0), (1, 0),
        //                                           (0, 1/3), (1/3, 1/3), (2/3, 1/3), (1, 1/3),
        //                                           (0, 2/3), (1/3, 2/3), (2/3, 2/3), (1, 2/3),
        //                                           (0, 1), (1/3, 1), (2/3, 1), (1, 1)};
        //static (double, double)[] ZPoints;
        static double[] ControlPointsX = { 0, 1 / 3, 2 / 3, 1 };
        static double[] ControlPointsY = { 0, 1 / 3, 2 / 3, 1 };
        public static double ComputeB(int i, int n, float t)
        {
            long r = 1;
            long d;
            int ntemp = n;
            for(d = 1; d<=i; d++)
            {
                r *= ntemp--;
                r /= d;
            }
            //if(n-i<0)
            //{
            //    if (1 - t == 0) return 0;
            //    return r * Math.Pow(t, i) * (1 / Math.Pow(1 - t, i - n));
            //}
            return r * Math.Pow(t, i) * Math.Pow(1 - t, n - i);
        }

        public static float ComputeZ(float x, float y, float[] z)
        {
            float sum = 0;
            for(int i = 0; i<=3; i++)
            {
                for(int j = 0; j<=3; j++)
                {
                    //(double, double) ControlPoint = (ControlPointsX[i], ControlPointsY[j]);
                    float Bi3 = (float)ComputeB(i, 3, x);
                    float Bj3 = (float)ComputeB(j, 3, y);
                    //double z[(4*j)+1] = 1; //!!
                    sum += z[(4 * j) + i] * Bi3 * Bj3;
                }
            }
            return sum;
        }
    }
}
