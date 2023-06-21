using System;
using static System.Math;
using static System.Console;

public class main
{
    public static void Main(string[] args)
    {

	foreach(var arg in args){
		if(arg=="test"){
			double[] xs = {1,2,3,4,5,6,7,8,9,10,11};
			double[] ys = {0,0,0,6,4,12,12,1,0.5,3,5};
			int l = xs.Length;
			
			for(int i=0;i<l;i++){
				WriteLine($"{xs[i]+1} {ys[i]+1}");
			}//for
		}//if test
	
        }//foreach
    }//Main
}//main

