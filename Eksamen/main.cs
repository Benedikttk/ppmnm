using System;
using static System.Math;
using static System.Console;
using System.Linq;


public class main
{
    public static void Main(string[] args)
    {

        double[] xTestData = {-2,-1,1,2};
        double[] yTestData = {-1,-1,1,1};

	foreach(var arg in args)
	{
		if(arg=="test")
		{ 
			for(int i=0;i<xTestData.Length;i++){
				
				WriteLine($"{xTestData[i]} {yTestData[i]}");
			}
		
		}//if
		if(arg=="AkimaSubSplineInetpolation")
		{	AkimaSpline spline = AkimaSpline.Create(xTestData,yTestData); /*Here I have created an instance with an x and y lyst*/
			
			double startInterpValue = xTestData.Min();
			double endInterpValue = xTestData.Max();
			
			
			for(double dx=startInterpValue+1.0/128;dx<=endInterpValue;dx+=1.0/64){
			
				double interpolatedValue = spline.Evaluate(dx);
				WriteLine($"{dx} {interpolatedValue}");
			}
		


		}//if
	}//foreach	

    }//Main
}//main

