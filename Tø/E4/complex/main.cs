using System;
using static System.Console;
using static System.Math;

static public class main{
	static public void Main(){
		

		WriteLine("Euqation | Hand calc. | Calc from lib | False/True");
		complex one = new complex(1,0);
		complex i = new complex(0,1);


	WriteLine("--------------------------------------------");
	WriteLine("Equation   | Hand calc. |   Calc from lib.");
	WriteLine("--------------------------------------------");
	WriteLine(String.Format("{0,-10} | {1,-10} | {2,5}", "sqrt(-1)", "i", $"{cmath.sqrt(-one)}" ));
	WriteLine(String.Format("{0,-10} | {1,-10} | {2,5}", "sqrt(i)", "(-1)^(1/4)", $"{cmath.sqrt(i)}" ));
	WriteLine(String.Format("{0,-10} | {1,-10} | {2,5}", "exp(i)", "e^i ", $"{cmath.exp(i)}" ));
	WriteLine(String.Format("{0,-10} | {1,-10} | {2,5}", "exp(i*pi)", "-1", $"{cmath.exp(i*PI)}" ));
	WriteLine(String.Format("{0,-10} | {1,-10} | {2,5}", "i^i", "0.21", $"{cmath.pow(i,i)}" ));
	WriteLine(String.Format("{0,-10} | {1,-10} | {2,5}", "log(i)", "i*pi/2", $"{cmath.log(i)}" ));
	WriteLine(String.Format("{0,-10} | {1,-10} | {2,5}", "sin(i*pi)", "11.5*i", $"{cmath.sin(i*PI)}" ));

	
	WriteLine("--------------------------------------------");

	}
}


