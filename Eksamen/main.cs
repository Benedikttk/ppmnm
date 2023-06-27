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

        }

    }//Main
}//main

