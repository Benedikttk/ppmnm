using System;
using static System.Math;
using static System.Console;
using static System.Random;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class main
{

	public static double Func(double x){ return Math.Sin(x);}


    public static void Main(string[] args)
    {
        var random = new Random();
        int dataSize=random.Next(10, 50);

        double[] xTestData = new double[dataSize];
        double[] yTestData = new double[dataSize];

        for(int i = 0;i<dataSize; i++)
        {
            xTestData[i] = random.NextDouble();
            yTestData[i] = random.NextDouble();
        }

        Array.Sort(xTestData, yTestData);
	
	foreach(var arg in args)
        {
            if(arg == "test")
            {
                for(int i=0;i<dataSize;i++)
                {
                    WriteLine($"{xTestData[i]} {yTestData[i]}");
                }
            }
		
	
	    else if(arg=="AkimaSlope")
	    {
		    double[] x = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
		    double[] y = { 11, 11, 10, 10, 13, 10, 13, 60, 62, 60, 13, 10, 10 };
	
			AkimaSpline spline = AkimaSpline.Create(x,y);
			
			for(double dx=x.Min()+1.0/1000;dx<=x.Max();dx+=1.0/1000){

    				double interpolatedValue = spline.Evaluate(dx);

				double slope = spline.GetSlope(dx);
				WriteLine($"{dx} {interpolatedValue} {slope}");
			}
	    }
		else if(arg=="dataPoints")
		{
                    double[] x = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
                    double[] y = { 11, 11, 10, 10, 13, 10, 13, 60, 62, 60, 13, 10, 10 };

			for(int i=0; i<x.Length-1;i++)
			{
				WriteLine($"{x[i]} {y[i]}");
			}
		}

	    else if(arg=="CubeSlope")
	    {	
		        double[] x = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
       			double[] y = { 11, 11, 10, 10, 13, 10, 13, 60, 62, 60, 13, 10, 10 };

        // Build the cubic spline interpolation
        int n = x.Length;
        double[] b = new double[n];
        double[] c = new double[n - 1];
        double[] d = new double[n - 1];
        double[] A = new double[n];
        double[] D = new double[n];
        double[] Q = new double[n];
        double[] B = new double[n];

        CubeSpline.cspline_build(x, y, b, c, d, A, D, Q, B);

        // Interpolate values in a loop
        double minX = x[0];
        double maxX = x[n - 1];
        double step = 1.0 / 1000;

        for (double i = minX + step; i < maxX; i += step)
        {
            double interpolatedValue = CubeSpline.cspline_evaluate(x, y, b, c, d, i);
            double slope = CubeSpline.cspline_diff(x, y, b, c, d, i);
            WriteLine("{0} {1} {2}", i, interpolatedValue, slope);
        }

	    }		    
	 
            else if(arg=="AkimaSubSplineInetpolation")
            {
                var rnd_data = File.ReadAllText("testpoints.data").Split("\n");
                int fileDataSize = rnd_data.Length - 1;
                
                // Resize arrays if needed
                if(fileDataSize>dataSize)
                {
                    xTestData = new double[fileDataSize];
                    yTestData = new double[fileDataSize];
                }

                for(int i=0;i<fileDataSize;i++)
                {
                    var xys = rnd_data[i].Split(' ');
                    var x = xys[0].Replace(",", ".");
                    var y = xys[1].Replace(",", ".");
                    double.TryParse(x, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out xTestData[i]);
                    double.TryParse(y, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out yTestData[i]);
                }

                Array.Sort(xTestData, yTestData);

                AkimaSpline spline = AkimaSpline.Create(xTestData, yTestData);

                double startInterpValue = xTestData.Min();
                double endInterpValue = xTestData.Max();

                for(double dx=startInterpValue; dx<=endInterpValue; dx+=1.0/1000)
                {
                    double interpolatedValue = spline.Evaluate(dx);
                    WriteLine($"{dx} {interpolatedValue}");
                }
            }
		
	    else if(arg=="Area")
	    {

		double[] x = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
                double[] y = { 11, 11, 10, 10, 13, 10, 13, 60, 62, 60, 13, 10, 10 };
		AkimaSpline spline = AkimaSpline.Create(x,y);

		double a = x.Min();
		double b = x.Max();

		double area = spline.Integrate(a, b);
		
		WriteLine("Data Points");
		for(int i=0; i<x.Length-1;i++)
                        {
                                WriteLine($"x={x[i]} and y={y[i]}");
                        }

		
		WriteLine($"x=1.5, interpolated value={spline.Evaluate(1.5)}");
		WriteLine($"Area under data poins between 0 and 12 using akima: {area}");


	    }

        }

    }//Main
}//main

