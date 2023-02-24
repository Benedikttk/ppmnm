using System;
using static System.Math;
using static System.Console;
static public class main{
	public static void Main(string[] args){
		char[] split_delimiters = {' ','\t','\n', ','};
		var split_options = StringSplitOptions.RemoveEmptyEntries;
		for( string line = ReadLine(); line != null; line = ReadLine() ){
			var numbers = line.Split(split_delimiters,split_options);
			foreach(var number in numbers){
				double x = double.Parse(number);
				WriteLine($"if x={x} then sin(x)={Sin(x)} and  cos(x)={Cos(x)} ");
                		}	
        		}
	}
}



/*Try running echo 1 2 3 4 5 > input.txt
 and then mono main.exe < input.txt > out.txt*/
