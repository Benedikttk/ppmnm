using System;
using static System.Console;
using static System.Math;
using static System.Random;
using System.Linq;
using System.IO;

public class main{


	//function to calculate the Jacobian of a vector function f and coordinate vector x
	public static matrix jacobi(Func<vector,vector>f, vector x){
		vector current = f(x);
                matrix jacobian = new matrix(current.size, x.size);
                for(int i=0;i<x.size;i++){
                        vector alter_x = x.copy();
                        double step = Math.Abs(alter_x[i])*Pow(2, -26);
                        alter_x[i] += step;
                        vector altered = f(alter_x);
                        vector new_col = (altered-current)/step;
                        for(int j=0;j<new_col.size;j++){
                                jacobian[j,i] = new_col[j];
                        }
                }
		return jacobian;	
	}


	//implementation of Newton's method
	static vector newton(Func<vector,vector>f, vector x, double eps=1e-2){
	while(f(x).norm() >= eps){

		matrix jacobian = jacobi(f, x);
		vector current = f(x);

		//solve liniar set of equations
		matrix R = new matrix(jacobian.size2, jacobian.size2);
		QRGS.decomp(jacobian, R);
		vector x_step = QRGS.solve(jacobian, R, -current);

		//backtracking line search
		double lambda = 1.0;
		while(f(x+(x_step*lambda)).norm() > (1-lambda*0.5)*f(x).norm() & lambda > 1.0/1024.0){
			lambda = lambda*0.5;
		}

		//updating x
		x = x + (lambda*x_step);
	}
		return x; 
	}


	public static void Main(string [] arg){
		WriteLine("hello");

		




	}



}//main
