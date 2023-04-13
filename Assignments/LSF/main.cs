using System;
using static System.Console;
using System.Diagnostics;
using static System.Math;


public class main{
static void Main(string[] args){

/*Begining of deebuging for QR*/	
	foreach(var arg in args){
			if(arg == "QRdeebug"){
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
// we make a copy of A called Q that we will decomp on with R	
	matrix Q = A.copy();	
	QRGS.decomp(Q,R);

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

	matrix id = new matrix(n,n);
	for(int i=0;i<n;i++){
		id[i,i]=1;
	}
	WriteLine($"A*B=I is {mat_id_AB.approx(id)}");

	}		

/*End of deebuging for QR*/
	}
/*Getting data to fit*/


	var fs = new Func<double,double>[] {z => 1, z => z};
		vector t = new vector("1,2,3,4,6,9,10,13,15");
		vector y = new vector("117,100,88,72,53,29.5,25.2,15.2,11.1");
		vector dy = new vector("5,5,5,4,4,3,3,2,2");
		vector ln_y = y.copy();
		vector ln_dy = dy.copy();
		for(int i=0;i<y.size;i++){
			ln_y[i] = Log(y[i]);
			ln_dy[i] = dy[i]/y[i];
		}
		var fit_params = ls.lsfit(fs, t, ln_y, ln_dy);
		vector bf = fit_params.Item1;
		vector c_errors = fit_params.Item3;

		double c_a = Math.Exp(bf[0]);
		double c_lamda = -bf[1];

		foreach(var arg in args){
			if(arg == "fit"){
				//generate data for plotting the fit 
				for(double x=0.01+1.0/128;x<=15;x+=1.0/64){
					WriteLine($"{x} {c_a*Math.Exp(-c_lamda*x)}");
				}
			}



		
		}
}}
