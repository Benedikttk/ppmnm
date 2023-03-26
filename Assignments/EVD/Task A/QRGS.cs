using System;
using static System.Math;
using static System.Console;

public static class QRGS{

        public static void decomp(matrix A, matrix R){
                int m=R.size1;

                for(int i=0; i<m; i++){
                        R[i,i]=A[i].norm();
                        A[i]/=R[i,i];

                        for(int j=i+1;j<m; j++){
                                R[i,j]=A[i].dot(A[j]);
                                A[j]-=A[i]*R[i,j];
                        }
                }
        }

	public static vector solve(matrix Q, matrix R, vector b){
		vector x = Q.T*b;
		for(int i=x.size-1;i>=0;i--){
			double sum=0;
			for(int k=i+1; k<x.size;k++)
				sum+=R[i,k]*x[k];
				x[i]=(x[i]-sum)/R[i,i];
		}
		return x;
	}


	public static double det(matrix R){
		double sum = 1;
		for(int i=0; i<=R.size1-1; i++){
			sum*=R[i,i];
		}
		return sum;
	}	


	public static matrix inverse(matrix Q, matrix R){
		matrix B = new matrix(Q.size1, R.size2);
		for(int i=0; i<Q.size2;i++){
			vector e = new vector(Q.size2);
			e[i]=1;
			B[i] = QRGS.solve(Q,R,e);
		}
		return B;
	}



}
