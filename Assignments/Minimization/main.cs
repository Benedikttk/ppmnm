using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
public static class main{

	static vector qnewton(Func<vector, matrix>fm, Func<vector, vector>fv, vector x, double eps=1e-2){
	/* The function lets say f(x,y) must be seperated (manualy) into ((d^2f/dx^2, df/dydx), (df/dxdy, d^2f/dy^2)) */
		int n = x.size;
		matrix R = new matrix(n, n);
		vector fx = fv(x);
		matrix B = new matrix(n, n);
		double lambda = 1.0;
		bool update_lambda = false;

		for(int i=0; i<n; i++) B[i,i] = 1;
		
		double loop = 0.0;
		while(fx.norm() > eps){
			loop = loop+1;
			if(loop > 1e7) break;
			update_lambda = true;
			vector dx = -B*fx;
			vector new_x = x + lambda*dx;
				
			vector fx_new = fv(new_x);
		
			if(fx_new.norm() < eps){
					if(n == 2) WriteLine($"Solved (eps satisfied) x = [{new_x[0]}, {new_x[1]}] at loop {loop}");
					if(n == 3) WriteLine($"Solved (eps satisfied) x = [{new_x[0]}, {new_x[1]}, {new_x[2]}] at loop {loop}");
				return fx_new;
			}

			if(fx_new.norm() < fx.norm())
			{
				x = new_x;
				fx = fx_new;
				matrix Q = fm(dx);
				QRGS.decomp(Q, R);
				B = B + QRGS.inverse(Q, R);
				update_lambda = false;
			}
			if(update_lambda) lambda = lambda/2;
			
			if(lambda < 1.0/1024.0){
				x = new_x;
				fx = fx_new;
				lambda = 1.0;
				for(int k=0; k<n; k++){
					for(int j=0; j<n; j++) B[k,j] = 1;
					B[k,k]=0;
				}

			}
		}

		return fx;
	}

	static matrix rosenbrock(vector x){ /*split into df/dx and df/dy */ 
		matrix A = new matrix(2, 2);
		A[0, 0] = 2 - 400*x[1] + 1200*x[0]*x[0];
		A[0, 1] = -400*x[0];
		A[1, 0] = A[0,1];
		A[1, 1] = 200;
		return A;
	}

	static matrix himmelblau(vector x){ /*split into df/dx and df/dy */ 
		matrix A = new matrix(2, 2);
		A[0, 0] = 12*x[0]*x[0] + 4*x[1] - 42;
		A[0, 1] = 4*(x[0] + x[1]);
		A[1, 0] = A[0,1];
		A[1, 1] = 4*x[0] + 12*x[1]*x[1] - 26;
		return A;}

	static vector v_himmelblau(vector x){
		return new vector(2*(2*x[0]*(x[0]*x[0]+x[1]-11)+x[0]+x[1]*x[1]-7), 2*(x[0]*x[0]+2*x[1]*(x[0]+x[1]*x[1]-7)+x[1]-11));}

	static vector v_rosenbrock(vector x){
		return new vector(-2*(1-x[0]*x[0])-400*(x[1]-x[0]*x[0])*x[0], 200*(x[1]-x[0]*x[0]));}	

	static vector vector_breit_func(vector x, vector energy, vector signal, vector signal_unc){ /* x must be 3 */
		vector result = new vector(3);
		int n = energy.size;
		for(int i = 0; i<n; i++){
		double E = energy[i];
		double s = signal[i];
		double k = signal_unc[i];

		result[0] += 2*(x[0]/(Pow(E-x[1], 2) + Pow(x[2], 2)/4)-s)/(Pow(k, 2)*(Pow(E-x[1], 2)+Pow(x[2], 2)/4)); /* df/dA */
		result[1] += 4*x[0]*(E-x[1])*(x[0]/(Pow(E-x[1], 2)+Pow(x[2], 2)/4)-s)/(Pow(k, 2)*Pow(Pow(E-x[1], 2)+Pow(x[2], 2)/4, 2)); 
		/* df/dm */
		result[2] += 16*x[0]*x[2]*(4*x[0]-4*s*Pow(x[1]-E, 2)-s*Pow(x[2], 2))/(Pow(k, 2)*Pow(4*Pow(x[1]-E, 2)+Pow(x[2], 2),3)); 
		/* df/dGamma */
		}
		return result;
	}
	
	static matrix matrix_breit_func(vector x, vector energy, vector signal, vector signal_unc){ /* x must be 3 long A = x[0]; */
		matrix A = new matrix(3, 3);
		int n = energy.size;
		for(int i = 0; i<n; i++){
		double E = energy[i];
		double s = signal[i];
		double k = signal_unc[i];
		
		A[0, 0] = 2/(Pow(k, 2)*Pow(Pow(E-x[1], 2) + Pow(x[2], 2)/4, 2));
		A[0, 1] = 64*(x[1] - E)*(s*(4*Pow(x[1]-E, 2) + Pow(x[2], 2)) - 8*x[0])/(Pow(k, 2)*Pow(4*Pow(x[1]-E, 2)+ Pow(x[2], 2), 3));
		A[0, 2] = 16*x[2]*(s*(4*Pow(x[1]-E, 2) + Pow(x[2], 2))-8*x[0])/(Pow(k, 2)*Pow(4*Pow(x[1]-E, 2)+ Pow(x[2], 2), 3));
		A[1, 1] = 64*x[0]*(80*x[0]*Pow(x[1]-E, 2)-48*Pow(x[1]-E, 4)+Pow(x[2],4))/(Pow(k,2)*Pow(4*Pow(x[1]-E, 2)+Pow(x[2], 2),4));
		A[1, 2] = 256*x[0]*x[2]*(x[1]-E)*(6*x[0]-4*s*Pow(x[1]-E, 2)-s*Pow(x[2], 2))/(Pow(k, 2)*Pow(4*Pow(x[1]-E, 2)+Pow(x[2], 2),4));
		A[2, 2] = 16*x[0]*(4*x[0]*(5*Pow(x[2], 2)-4*Pow(x[1]-E, 2))+s*(16*Pow(x[1]-E, 4)-8*Pow(x[2], 2)*Pow(x[1]-E, 2)-3*Pow(x[1]-E, 4)))/(Pow(k, 2)*Pow(4*Pow(x[1]-E, 2)+Pow(x[2], 2),4));
		}
		A[1, 0] = A[0, 1];
		A[2, 0] = A[0, 2];
		A[2, 1] = A[1, 2];
		return A;
	}
	
	static double breit_wigner(double E, double A, double m, double G){
		return A/(Pow(E-m,2)+Pow(G,2)/4);
	}
	

	public static void Main(string[] args){

	foreach(var arg in args){
		if(arg == "Out.txt")
		{
			WriteLine();
			//var rnd = new System.Random();	
			vector guess = new vector(-2, 3);
			WriteLine($"Solving Rosenbrock's valley function, guess x = [{guess[0]}, {guess[1]}]");
			vector result = qnewton(rosenbrock, v_rosenbrock, guess, 1e-8);
			result.print("Rosenbrock last value for fx = ");
			WriteLine();
			vector guesst = new vector(-3, 3);
			WriteLine($"Solving Himmelblau's function, guess x = [{guesst[0]}, {guesst[1]}]");
			vector result_him = qnewton(himmelblau, v_himmelblau, guesst, 1e-8);
			result_him.print("Rosenbrock last value for fx = ");
		}
		if(arg == "higgs.txt")
		{	
			var higgs_data = File.ReadAllText("higgs.data").Split("\n");
			int n = higgs_data.Length-1;
			
			vector energy = new vector(n);
			vector signal = new vector(n);
			vector signal_unc = new vector(n);
			var options = StringSplitOptions.RemoveEmptyEntries;
			var separators = new char[] {' '};
			
			for(int i =0; i<n; i++){
				var xys = higgs_data[i].Split(separators, options);
				
		       	energy[i] = Double.Parse(xys[0]);
				signal[i] = Double.Parse(xys[1]);
				signal_unc[i] = Double.Parse(xys[2]);
			}
			
			Func<vector, vector> v_breit = x => vector_breit_func(x, energy, signal, signal_unc);
			Func<vector, matrix> diff_breit = x => matrix_breit_func(x, energy, signal, signal_unc);
			
			vector higgs_guess = new vector(-3, 3, 3);
			WriteLine($"Solving Breit-Wigner function, guess x = [{higgs_guess[0]}, {higgs_guess[1]}, {higgs_guess[2]}]");
			vector result_breit = qnewton(diff_breit, v_breit, higgs_guess, 1e-8);
			result_breit.print("Breit-Wigner last value for fx = ");
			WriteLine("\n Conclussion: The fit is not as expected, does not fit good. It should be shiftet more to the right.");

		}
		if(arg == "fitsdata.data"){
		vector fit_res = new vector(-25.8815024514201, 454.18953098711, 3979380.50638432);
		
		
		for(double i=99.0; i<161.0; i+=1.0/20.0){
			WriteLine($"{i} {breit_wigner(i, fit_res[0], fit_res[1], fit_res[2])}");
		}
		
		}
		if(arg == "fitdata.data"){
		vector fit_res = new vector(25.0, 125.0, 4.2);
		
		
		for(double i=99.0; i<161.0; i+=1.0/20.0){
			WriteLine($"{i} {breit_wigner(i, fit_res[0], fit_res[1], fit_res[2])}");
		}
		
		}

	}
	
}
}
