using System;
using static System.Console;
using static System.Math;
using static System.Random;

public static class main{
	//Least square class for fitting with errors	
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

			QRGS.decomp(A, R);
			vector c = QRGS.solve(A, R, b);

			QRGS.decomp(A_prod, R2);
			matrix Cov = QRGS.inverse(A_prod, R2);

			vector c_errors = new vector(Cov.size2);
			for(int k=0; k<Cov.size2; k++){
				c_errors[k] = Math.Sqrt(Cov[k,k]);
			}

			return (c, Cov, c_errors);
		}
	}

	static void Main(string[] args){
	
	/*Task A*/	
	//Producing a Tall, a quadratic matrix and radnom vector
	
		var random = new Random();
		int size_n = random.Next(2,7);
		int size_m = random.Next(2,size_n);

		matrix Tall_A = new matrix(size_n,size_m);		
		for(int i=0;i<size_n;i++){
			for(int j=0;j<size_m;j++){
				Tall_A[i,j] = random.NextDouble();
			}
		}

		int size_s = random.Next(2,7);
		
		matrix Quad = new matrix(size_s, size_s);
		for(int i=0;i<size_s;i++){
			for(int j=0;j<size_s;j++){
				Quad[i,j] = random.NextDouble();
			}
		}

		vector random_v = new vector(size_s);
		for(int i=0;i<size_s;i++){
			random_v[i] = random.NextDouble();
		}
	
/*--------------------------------------------Actual fitting--------------------------------------------------------------*/

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
			if(arg == "plot"){
				// data for the fit 
				for(double x=0.01+1.0/128;x<=15;x+=1.0/64){
					WriteLine($"{x} {c_a*Math.Exp(-c_lamda*x)}");
				}
			}
		}	


		

	}
}
