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

	
	//easy function like area of unitcircle
	static double unitcircle(vector coord){
    	double x = coord[0];
    	double y = coord[1];
    	double unitlength = Math.Sqrt(x*x + y*y);
    	if(unitlength > 1) {return 0.0;} 
	else{return Sqrt(1 - x*x - y*y);}
	}
	

	//difficult function from task description
	static double difficult(vector cordi){
		double x = cordi[0];
		double y = cordi[1];
		double z = cordi[2];
		return 1/(1-Cos(x)*Cos(y)*Cos(z))/(PI*PI*PI);
	}


	public static void Main(string[] args){


//calculates volume of half unit sphere
	foreach(var arg in args){
		vector a = new vector("-1, -1");
                vector b = new vector("1, 1");
                int N = 3000;
                double act_vol = (4.0/3.0)*PI*0.5; /*Actual half volume of sphere*/

		if(arg == "Out"){
			WriteLine("--------------------------------------");
			WriteLine("Half unit sphere");
			WriteLine($"Actual value:	{(4.0/3.0)*PI*0.5}");
			int number = 100000;
			var result = plainmc(unitcircle, a, b, number);
			WriteLine($"Calculated value with {number} points:	{result.Item1} ± {result.Item2}");
		
			WriteLine("---------------------------------------");
			WriteLine("Difficult integral from task description");
			WriteLine("Actual value:	1.3932039296856768591842462603255");
	
			vector a_hard = new vector("0, 0, 0");
			vector b_hard = new vector(PI, PI, PI);
			int N_hard = 1000000;
			var answer_hard = plainmc(difficult, a_hard, b_hard, N_hard);
			WriteLine($"Calculated value with {N_hard} points:	{answer_hard.Item1} ± {answer_hard.Item2}");
			
		}
		if(arg == "mcint.data"){
			for(int i=1;i<=N;i++){
				var result = plainmc(unitcircle, a, b, i);
				WriteLine($"{i} {result.Item2}");	
			}
		}
		if(arg == "actual_volume"){
			for(int i=1;i<=N;i++){
				var result = plainmc(unitcircle, a, b, i);
				WriteLine($"{i} {Math.Abs(result.Item1-act_vol)}");
			}
		}		
		if(arg == "inv_sqrt_nth"){
			for(int i =1;i<=N;i++){
			WriteLine($"{i} {1/Math.Sqrt(i)}");
			}
		}
		if(arg == "error_div"){
			for(int i=1;i<=N;i++){
                                var result = plainmc(unitcircle, a, b, i);	
				WriteLine($"{i} { result.Item2 -(Math.Abs(result.Item1-act_vol))}");
			}
		}
	}//foreach
	}//Main
}//main
