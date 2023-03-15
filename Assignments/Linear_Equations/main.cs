using System;
using static System.Console;

public class main{
public static void Main(){

WriteLine("Task A\n");	

	var rnd = new System.Random();	
//Making random rows and collumns
	int n = rnd.Next(2,10);
	int m = rnd.Next(2,n);
//construkting matrix A with random number inputs
	matrix A = new matrix(n,m);
        for(int i=0; i<n;i++){
                for(int j=0; j<m ;j++){
              		 A[i,j] += rnd.NextDouble();
		}
	}
//empty matrix R = 0
	matrix R = new matrix(m,m);
	
//The vector b has to have the same dimensions as n rows of A
        vector b = new vector(n);
        for(int i=0; i<n;i++)
                b[i]+=rnd.NextDouble();

	A.print("Here we have a random matrix A, \nA =\n");
	R.print("Here we have a 0 matrix R, \nR =\n");	

// we make a copy of A called Q that we will decomp on with R	
	matrix Q = A.copy();	
	QRGS.decomp(Q,R);

	Q.print("Here we have matrix A ''Q'' after decomposition,\n Q=\n");
	R.print("Here we have matrix R after decomposition, it is triangulare\n R=");

	var QTQ =Q.T*Q;
	var QR = Q*R;
	
	QTQ.print("Q^T*Q =");
        WriteLine($"\n Is QR=A; {QR.approx(A)}");

//testing if solve works
//Random square matrix A
	
	matrix square_A = new matrix(n,n);
        for(int i=0; i<n;i++){
                for(int j=0; j<n ;j++){
                        square_A[i,j] += rnd.NextDouble();
                }
        }
	matrix new_R = new matrix(n,n);

	square_A.print("n x n Matrix");
	matrix square_Q = square_A.copy();
	QRGS.decomp(square_Q,new_R);
//construct x solution to linear equations

	vector x = QRGS.solve(square_Q,new_R,b);
	x.print("The solution to QRx=b is \n x=");
	var Ax = square_A*x;
	Ax.print($"Ax=b is {Ax.approx(b)},\n where Ax=");

WriteLine("Task B");	

	matrix B = QRGS.inverse(square_Q,new_R);
	B.print("This is the inverse of square matrix n x n a, \n B=");

	matrix mat_id_AB = square_A*B;
	mat_id_AB.print("A*B=\n ");

	matrix mat_id_BA = B*square_A;
	mat_id_BA.print("B*A=\n");
}
}
