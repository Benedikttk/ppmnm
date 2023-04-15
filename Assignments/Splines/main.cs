using System;
using static System.Console;
using static System.Math;

class main{
public static class funcs{
	/*This is part one of A*/
	public static int binsearch(double[] x, double z){ 
		if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
		int i=0, j=x.Length-1;
		while(j-i>1){
			int mid=(i+j)/2;
		if(z>x[mid]) i=mid; else j=mid;
		}
		return i;
	}

	public static double linterp(double[] x, double[] y, double z){
        	int i=binsearch(x,z);
        	double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("uups...");
        	double dy=y[i+1]-y[i];
       		return y[i]+dy/dx*(z-x[i]);
        }
	/*This is part two of A*/
	double linterpInteg(double[] x, double[] y, double z){
	
		double sum_integral = 0;
		int index = binsearch(x,z);
		for(int i=0;i<index;i++){
			//calculate integral of interval
			double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("seems wrong again...");
			double dy=y[i+1]-y[i];
			double a = dy/dx;
			double b = y[i]-a*x[i];
			double integral = (a/2)*(x[i+1]*x[i+1]-x[i]*x[i]) + b*dx;
			sum_integral += integral;
			}
		double last_y = linterp(x, y, z);
		double last_x = z;
		double last_dx = last_x-x[index];
		double last_dy = last_y-y[index];
		double last_a = last_dy/last_dx;
		double last_b = y[index]-last_a*x[index];
		double last_integral = (last_a/2)*(last_x*last_x-x[index]*x[index]) + last_b*last_dx;
		sum_integral += last_integral;
		return sum_integral;
		}
	}

	static void Main(string[] args){

		


	}

}
	

