using System;
using static System.Console;
using static System.Math;
public static class main{
	public static void Main(){
		sfuns.print(); 
		System.Console.Write("Hej fra Main\n");
			
		sfuns.print();
		double sqrt2=Sqrt(2.0);
		Write($"sqrt2^2 = {sqrt2*sqrt2} (should equal 2)\n");
	
		double a=Pow(2,1.0/5.0);
		Write($"2^(1/5) = {a}\n");
                
		
		
		double pie = Pow(PI,E);
		Write($"pi^e = {pie}\n");


		double epi = Pow(E,PI);
		Write($"e^pi = {epi}\n");
	}
							

	
}
