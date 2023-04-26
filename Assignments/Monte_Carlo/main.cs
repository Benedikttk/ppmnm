using System;
using static System.Console;
using static System.Math;
using static System.Random;
using System.Linq;
using System.IO;
using static System.IO.TextWriter;

public class main{
	
	static (double,double) plainmc(Func<vector,double> f,vector a,vector b,int N){
        int dim = a.size; 
	double V = 1; 
	for(int i=0;i<dim;i++) V *= b[i] - a[i];
        double sum = 0, sum2 = 0;
	var x = new vector(dim);
	var rnd = new Random();
        for(int i=0;i<N;i++){
                for(int k=0;k<dim;k++) x[k] = a[k] + rnd.NextDouble() * (b[k]-a[k]);
                double fx = f(x); sum += fx; sum2 += fx*fx;
	}
        double mean = sum/N, sigma = Sqrt(sum2/N-mean*mean);
        var result = (mean*V,sigma*V/Sqrt(N));
        return result;
	}


	static double unitcircle(vector coord){
    	double x = coord[0];
    	double y = coord[1];
    	double unitlength = Math.Sqrt(x*x + y*y);
    	if(unitlength > 1) {return 0.0;} 
	else{return Sqrt(1 - x*x - y*y);}
	}


	public static void Main(string[] args){

	vector a = new vector("-1, -1");
	vector b = new vector("1, 1");
	
	int N = 1000;

	(double circ_area, double circ_err) = plainmc(unitcircle, a, b, N);
	


	WriteLine($"{circ_area} ± {circ_err}");

	}//Main
}//main
