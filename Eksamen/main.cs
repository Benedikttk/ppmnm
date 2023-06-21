using System;
using static System.Math;
using static System.Console;
using System.Linq;


public class main
{
    public static void Main(string[] args)
    {
	foreach(var arg in args)
	{
		if(arg=="test")
		{ 
			double[] xTestData = {1,2,4,5};
			double[] yTestData = {1,1,2,2};

			AkimaSpline spline = AkimaSpline.Create(xTestData,yTestData); /*Here I have created an instance with an x and y lyst*/
			
			double startInterpValue = xTestData.Min();
			double endInterpValue = yTestData.Max();
			for(double dx=startInterpValue; dx<endInterpValue; dx=+1/64)
				WriteLine(dx);
			

		}
	}	

    }//Main
}//main

