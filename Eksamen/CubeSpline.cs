using System;

public class CubeSpline
{
    public static void cspline_build(double[] x, double[] y, double[] b, double[] c, double[] d, double[] A, double[] D, double[] Q, double[] B)
    {
        // We'll be using natural spline for this
        D[0] = 2;
        Q[0] = 1;
        A[0] = 1;
        B[0] = 3 * p(x, y, 0);
        
        for (int i = 0; i < b.Length - 2; i++)
        {
            D[i + 1] = 2 * h(x, i) / h(x, i + 1) + 2;
            Q[i + 1] = h(x, i) / h(x, i + 1);
            B[i + 1] = 3 * (p(x, y, i) + p(x, y, i + 1) * h(x, i) / h(x, i + 1));
            A[i + 1] = 1;
        }
        
        D[D.Length - 1] = 2;
        B[b.Length - 1] = 3 * p(x, y, b.Length - 2);
        
        solveTriDiaSys(b, B, A, D, Q);
        
        for (int i = 0; i < c.Length; i++)
        {
            c[i] = (3 * p(x, y, i) - 2 * b[i] - b[i + 1]) / h(x, i);
            d[i] = (b[i] + b[i + 1] - 2 * p(x, y, i)) / h(x, i) / h(x, i);
        }
    }

    public static double cspline_evaluate(double[] x, double[] y, double[] b, double[] c, double[] d, double z)
    {
        int i = binsearch(x, z);
        return y[i] + b[i] * (z - x[i]) + c[i] * Math.Pow(z - x[i], 2) + d[i] * Math.Pow(z - x[i], 3);
    }

    public static double cspline_diff(double[] x, double[] y, double[] b, double[] c, double[] d, double z)
    {
        int i = binsearch(x, z);
        return b[i] + 2 * c[i] * (z - x[i]) + 3 * d[i] * Math.Pow(z - x[i], 2);
    }

    public static double cspline_integrate(double[] x, double[] y, double[] b, double[] c, double[] d, double z)
    {
        int iMax = binsearch(x, z);
        double Out = 0;
        
        for (int i = 0; i < iMax; i++)
        {
            Out += y[i] * (x[i + 1] - x[i]) + b[i] / 2 * Math.Pow(x[i + 1] - x[i], 2) + c[i] / 3 * Math.Pow(x[i + 1] - x[i], 3) + d[i] / 4 * Math.Pow(x[i + 1] - x[i], 4);
        }
        
        return Out + y[iMax] * (z - x[iMax]) + b[iMax] / 2 * Math.Pow(z - x[iMax], 2) + c[iMax] / 3 * Math.Pow(z - x[iMax], 3) + d[iMax] / 4 * Math.Pow(z - x[iMax], 4);
    }

    public static int binsearch(double[] x, double z)
    {
        if (!(x[0] <= z && z <= x[x.Length - 1]))
            throw new Exception("binsearch: bad z");

        int i = 0;
        int j = x.Length - 1;

        while (j - i > 1)
        {
            int mid = (i + j) / 2;

            if (z > x[mid])
                i = mid;
            else
                j = mid;
        }

        return i;
    }

    private static void solveTriDiaSys(double[] b, double[] B, double[] A, double[] D, double[] Q)
    {
        int n = b.Length;

        for (int i = 1; i < n; i++)
        {
            D[i] -= Q[i - 1] / D[i - 1];
            B[i] -= B[i - 1] / D[i - 1];
        }

        b[n - 1] = B[n - 1] / D[n - 1];

        for (int i = n - 2; i >= 0; i--)
        {
            b[i] = (B[i] - Q[i] * b[i + 1]) / D[i];
        }
    }

    private static double h(double[] x, int i)
    {
        return x[i + 1] - x[i];
    }

    private static double p(double[] x, double[] y, int i)
    {
        return (y[i + 1] - y[i]) / h(x, i);
    }
}

