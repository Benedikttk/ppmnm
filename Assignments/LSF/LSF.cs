using System;
using static System.Math;

public static class ls{
                public static (vector, matrix, vector) lsfit(Func<double,double>[] fs, vector x, vector y, vector dy){
                        int l = fs.Length;
                        matrix A = new matrix(x.size, l);
                        vector b = y.copy();
                        matrix R = new matrix(l, l);

                        for(int i=0;i<A.size1;i++){
                                for(int j=0;j<A.size2;j++){
                                        A[i,j] = fs[j](x[i])/dy[i];
                                }
                                b[i] = y[i]/dy[i];
                        }

                        matrix A_prod = A.T*A;
                        matrix R2 = new matrix(A_prod.size2, A_prod.size2);

                        var Q=A.copy();
                        QRGS.decomp(Q, R);

                        vector c = QRGS.solve(Q, R, b);
		       	c.print("  c=");
                        ((A)*(c)).print("A*c=");
                        b.print("  b=");

                        QRGS.decomp(A_prod, R2);
                        matrix Cov = QRGS.inverse(A_prod, R2);

                        vector c_errors = new vector(Cov.size2);
                        for(int k=0; k<Cov.size2; k++){
                                c_errors[k] = Math.Sqrt(Cov[k,k]);
                        }

                        return (c, Cov, c_errors);
                }
        }

