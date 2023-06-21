using System;
using static System.Math;
using static System.Console;

public class main
{
    public static void Main(string[] args)
    {
        // Test data
        double[] xData = { 1.0, 2.0, 3.0, 4.0, 5.0 };
        double[] yData = { 2.0, 4.0, 6.0, 8.0, 10.0 };

        // Create AkimaSpline instance
        AkimaSpline spline = AkimaSpline.Create(xData, yData);

        // Test interpolation at a point
        double z = 2.5;
        double interpolatedValue = spline.Evaluate(z);
        WriteLine($"Interpolated value at z={z}: {interpolatedValue}");

        // Test interpolation at multiple points
        double[] testPoints = { 1.5, 3.5 };
        foreach (double point in testPoints)
        {
            double result = spline.Evaluate(point);
            WriteLine($"Interpolated value at z={point}: {result}");
        }
    }
}

