using System;
using static System.Math;
using static System.Console;

public class main
{
    public static void Main(string[] args)
    {
        double[] xs = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
        double[] ys = {0, 0, 0, 6, 4, 12, 12, 1, 0.5, 3, 5};

        foreach (var arg in args)
        {
		if (arg == "test")
            {
                int l = xs.Length;

                for (int i = 0; i < l; i++)
                {
                    WriteLine($"{xs[i]+1} {ys[i]+1}");
                }//for
            }//if
        	if(arg=="AkimaSubSplineInetpolation")
		{

        	// Create an instance of AkimaSpline
        	AkimaSpline spline = AkimaSpline.Create(xs, ys);

        	// Interpolate a range of values
        	double start = xs[0];
        	double end = xs[xs.Length - 1];
        	double step = 0.05;
        		for (double value = start; value <= end; value += step)
        		{	
            		double interpolated = spline.Evaluate(value);
            		WriteLine($"{value},  {interpolated}");
        		}
		}
	
	
	
	
	}//foreach
    }//Main
}//main

