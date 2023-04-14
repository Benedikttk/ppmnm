using System;
using static System.Math;

public static class ls{
    public static (vector, matrix, vector) lsfit(Func<double,double>[] fs, vector x, vector y, vector dy){
        int n = x.size;
        int m = fs.Length;

        // Check array dimensions
        if (y.size != n || dy.size != n){
            throw new ArgumentException("Dimension mismatch: y and dy must have the same length as x.");
        }
        for (int i = 0; i < m; i++){
            if (fs[i](0) == Double.NaN){
                throw new ArgumentException("Function at index " + i + " returns NaN for argument 0.");
            }
        }

        matrix A = new matrix(n, m);
        vector b = new vector(n);

        for(int i = 0; i < n; i++){
            for(int j = 0; j < m; j++){
                A[i, j] = fs[j](x[i]) / dy[i];
            }
            b[i] = y[i] / dy[i];
        }

        // Check array dimensions
        if (A.size1 != n || A.size2 != m || b.size != n){
            throw new Exception("Unexpected dimension mismatch.");
        }

        matrix Q = A.copy();
        matrix R = new matrix(m,m);

        QRGS.decomp(Q, R);

        vector c = QRGS.solve(Q, R, b); /*Results*/

        // Check array dimensions
        if (c.size != m){
            throw new Exception("Unexpected dimension mismatch.");
        }

        matrix RTR = R.T * R;

        //matrix for covariance
        matrix C = new matrix(m, m);

        for(int i = 0; i < m; i++){
            for(int j = 0; j < m; j++){
                C[i, j] = RTR[i, j];
            }
        }

        matrix Q_exp = C.copy();
        QRGS.decomp(C, Q_exp);

        matrix cov = QRGS.inverse(C, Q_exp);

        vector c_errors = new vector(m);

        for(int k = 0; k < m; k++){
            c_errors[k] = Math.Sqrt(cov[k, k]);
        }

        // Check array dimensions
        if (cov.size1 != m || cov.size2 != m || c_errors.size != m){
            throw new Exception("Unexpected dimension mismatch.");
        }

        return (c, cov, c_errors);
    }
}

