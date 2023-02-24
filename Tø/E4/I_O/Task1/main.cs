using static System.Console;
using static System.Math;

static public class main{ //should always be as standard class
	public static void Main(string[] args){ //Here we tell it to look at a string array with 
	foreach(var arg in args){		//arguments with a foreach loop over every argument
		var words = arg.Split(':'); //Telling it that our input will consist of a splitter
		if(words[0]=="-numbers"){   //it gets split and if the first input is words proceed
			var numbers=words[1].Split(','); // same as above
			foreach(var number in numbers){ //we loop over numbers in second input
				double x = double.Parse(number); //ive x the value of numbers
				
				
				if (Sin(x)<Cos(x)){	
					WriteLine($"When x={x} we have that sin(x)={Sin(x) } and that cos(x ={Cos(x)}");
					WriteLine($"Here we have that for x={x} sin(x)<cos(x)");
					}	       
				else{
					WriteLine($"When x={x} we have that sin(x)={Sin(x) } and that cos(x ={Cos(x)}");
                                        WriteLine($"Here we have that for x={x} sin(x)>cos(x)");

					}
				}
			}
		}
	}

}
