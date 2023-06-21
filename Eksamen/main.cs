using System;
using static System.Math;
using static System.Console;

public class main
{
    public static void Main(string[] args)
    {

	double[] xs = {1,2,3,4,5,6,7,8,9,10,11};
        double[] ys = {0,0,0,6,4,12,12,1,0.5,3,5};



	foreach(var arg in args){
		if(arg=="test"){
			int l = xs.Length;
			
			for(int i=0;i<l;i++){
				WriteLine($"{xs[i]+1} {ys[i]+1}");
			}//for
		}//if test

		if(arg=="AkimaSubSplineInetpolation"){
			
			int numPoints = (int)((xs[xs.Length-1]-xs[0])*10)+1;
			double[] interpolatedValues = new double[numPoints];

			int index = 0;

			for(double z=xs[0]; z<=xs[xs.Length-1];z+=1.0/10.0)
			{	
				double interpValue = spline.Evaluate(z);
            			interpolatedValues[index] = interpValue;
            			index++;
            			WriteLine($"{z} {interpValue}");

			}
		}




        }//foreach
    }//Main
}//main

