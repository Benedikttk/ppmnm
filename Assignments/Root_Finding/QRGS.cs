using System;
using static System.Math;
using static System.Console;

public static class QRGS
{
    public static void decomp(matrix A, matrix R)
    {
        int m = A.size2;
        int n = A.size1;
//	A.print("A=");
//	R.print("R=");

        if (m > n)
        {
            throw new ArgumentException("Matrix A must have more rows than columns.");
        }

        for (int i = 0; i < m; i++)
        {
            R[i, i] = A[i].norm();
            A[i] /= R[i, i];

            for (int j = i + 1; j < m; j++)
            {
                R[i, j] = A[i].dot(A[j]);
                A[j] -= A[i] * R[i, j];
            }
        }
    }

    public static vector solve(matrix Q, matrix R, vector b)
    {
        int m = R.size1;

	/*
        if (R.size2 != n || Q.size1 != n || Q.size2 != n || b.size != n)
        {
            throw new ArgumentException("Matrix and vector dimensions must agree.");
        }
	*/

        vector x = Q.T * b;

        for (int i = m - 1; i >= 0; i--)
        {
            double sum = 0;

            for (int k = i + 1; k < m; k++)
            {
                sum += R[i, k] * x[k];
            }

            if (R[i, i] == 0)
            {
                throw new DivideByZeroException("Matrix R is singular or nearly singular.");
            }

            x[i] = (x[i] - sum) / R[i, i];
        }

        return x;
    }

    public static matrix inverse(matrix Q, matrix R)
    {
        int n = R.size1;

        if (Q.size1 != n || Q.size2 != n || R.size2 != n)
        {
            throw new ArgumentException("Matrix dimensions must be square and agree.");
        }

        matrix B = new matrix(n, n);

        for (int i = 0; i < n; i++)
        {
            vector e = new vector(n);
            e[i] = 1;
            B[i] = QRGS.solve(Q, R, e);
        }

        return B;
    }

    public static double det(matrix R)
    {
        int n = R.size1;

        if (n != R.size2)
        {
            throw new ArgumentException("Matrix must be square.");
        }

        double sum = 1;

        for (int i = 0; i < n; i++)
        {
            sum *= R[i, i];
        }

        return sum;
    }
}
