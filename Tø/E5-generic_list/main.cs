using System;
using static System.Math;
using static System.Console;

static public class main{
	public static void Main(string[] args){
	
	var list = new genlist<double[]>(); // make a new list that will be read.
	
	foreach(var arg in args){          // look for arg for every argument in inputfile 
		var words = arg.Split(' ', '\t'); 
		int n = words.Length;
		var numbers = new double[n];
		for(int i=0;i<n;i++){       
			numbers[i] = double.Parse(words[i]); //it has now made a list with all the numbers in the inputfile
			}
		list.add(numbers);
		}	
	WriteLine("--------------------------------------------");
       	WriteLine("number index.| raw value.| value.");
	WriteLine("--------------------------------------------");

	for(int i=0; i<list.size;i++){
		var numbers = list[i];
		foreach(var number in numbers) WriteLine(String.Format("{0,-12} | {1,-9} | {2,5}",$"{i}  ", $"{number}",$"{number : 0.00e+00;-0.00e+00}" ));
		}
	WriteLine("--------------------------------------------");

	}
}
