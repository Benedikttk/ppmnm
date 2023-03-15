using System;
using static System.Console;

public class main{
public static void Main(){
WriteLine("Task A\n");	
	var rnd = new System.Random();	
	
	WriteLine("Constructing a random indexed tall matrix A, where n>m, where n = {1,10} and m={1,10}");
	var n = rnd.Next(2,10);
	var m = rnd.Next(2,n);

	matrix A = new matrix(n,m);

        for(int i=0; i<n;i++){
                for(int j=0; j<m ;j++){
              		 A[i,j] += rnd.NextDouble();
		}
	}

	A.print($"\nHere we have matrix A with dim({n},{m})\n");

	WriteLine("We will now construct a random matrix R, its a 0 matrix.");

	matrix R = new matrix(m,m);
	
	R.print($"\nMatrix R has dim({n},{m})");

	//factorising into QR
	
	matrix Q = A.copy();	
	QRGS.decomp(Q,R);

	R.print("We can now se that R is upper triangular;\n");
	Q.print("Q=");
	
	var QTQ =Q.T*Q;

	QTQ.print("\nWe check that QTQ=1;\n Q^T*Q =");

	WriteLine("We now check that QR=A;\n");

	var QR = Q*R;
	
	QR.print("Q*R=");


	WriteLine($"is QR=A -> {QR.approx(A)}\n");
		
WriteLine("Task B\n");

	





}
}
