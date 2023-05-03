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
		//correct answer: x[0]=-4, x[1]=1
	static vector test1(vector x){
		vector function = new vector(0,0);
		function[0] = x[0] - 7*x[1] + 11;
		function[1] = 5*x[0] + 2*x[1] + 18;
		return function;
		}
	static vector test2(vector x){
		vector function = new vector("0");
		function[0] = x[0] - 11;
		return function;
	}	
	static vector rosen(vector x){
		vector function = new vector(0,0);
		//derivative with regards to x
		function[0] = -2*(1-x[0])-400*x[0]*x[0]*(x[1]-x[0]*x[0]);
		//derivative with regards to y
		function[1] = 200*(x[1]-x[0]*x[0]);
		return function;
	}
	static vector test3(vector x){
		vector function = new vector(0,0,0);
		function[0] = 2*x[0] +2*x[1] + x[2] -20;
		function[1] = -3*x[0] -x[1] - x[2] +18;
		function[2] = x[0]+x[1]+2*x[2]-16;
		return function;
	}

	public static void Main(string [] arg){
		WriteLine("hello");

		var random = new Random();
		int a = random.Next(1,90);
		int b = random.Next(1,10);
		
		WriteLine("-------------------------------");
		WriteLine($"starting guesses x={a} y={b}");
		vector vectest1 = new vector(a,b);
		vector answer1 = newton(test1, vectest1);
		WriteLine("Solving 2 equations with 2 unknowns  \n x-7y=-11\n 5x+2y=-18	");
		WriteLine($"x={answer1[0]} and y={answer1[1]}");
	
		vector vectest2 = new vector($"{a}");
		vector answer2 = newton(test2, vectest2);
		WriteLine("Solving equation with 1 unknown \n x-11=0");
		WriteLine($"x={answer2[0]}");

		vector rostest = new vector(a,b);
		vector rosanswer = newton(rosen, rostest);
		WriteLine("Solving roots for the derivatives of f(x,y) = (1-x)2+100(y-x2)2");
		WriteLine($"  x={rosanswer[0]}  y={rosanswer[1]}");
		
		vector vectest3 = new vector(a,b,a-b);
		vector answer3 = newton(test3,vectest3);
                WriteLine("Solving 3 equations with 3 unknowns  \n 2x +2y z =20 \n -3x-y-z=-18 \n x+y+2z=16 ");
		WriteLine($"x={answer3[0]} y={answer3[1]} z={answer3[2]}");

	}//Main
}//main
