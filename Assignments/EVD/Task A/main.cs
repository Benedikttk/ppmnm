using static System.Console;
using System;
using static System.Math;
using System.Globalization;


public class main{
public static void Main(string[] args){
	WriteLine("TASK A:");

	int n =0;
	foreach(string arg in args){
		var words=arg.Split(':');
		if(words[0]=="-size")n=int.Parse(words[1]);
	}
	
	//Generate a random symetric matrix
	var rnd = new System.Random();	
	//Making random rows and collumns
//	int m = rnd.Next(2,n);
	//construkting matrix A with random number inputs
	matrix square_A = new matrix(n,n);
        for(int i=0; i<n;i++){
                for(int j=i; j<n ;j++){
                        square_A[i,j] = square_A[j,i] = rnd.NextDouble();
                }
        }
	square_A.print($"Matrix A with dimensions {n},{n},\n A=\n");

	//Matrix V
	(var D, var V) = jacobi.cyclic(square_A);

	V.print("V =\n");
	D.print("D= \n");

	var VTAV = V.T*square_A*V;
	VTAV.print("V.T*D*V=\n");

	matrix I = new matrix(n,n);
	for(int i=0; i<n;i++){
		I[i,i]+=1;
	}
	
	var VDVT = V*D*V.T;
	matrix VVT = V*V.T;
	matrix VTV = V.T*V;

	I.print("Let a matrix reperesent a diagonal matrix I\n I=\n");

	WriteLine($"Test1; is V^T*A*V=I? {VTAV.approx(D)}");
	WriteLine($"Test2; is VDV^T = A? {VDVT.approx(square_A)}");	
	WriteLine($"Test3; is VV^T = I? {VVT.approx(I)}");
	WriteLine($"Test4; is V^TV = I? {VTV.approx(I)}");
	WriteLine("mono main.exe -size:n, for an n x n symetrix matrix");	




	}
}
