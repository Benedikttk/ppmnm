using System;
using static System.Console;
using static System.Math;
public static class main{

	public static bool approx
	(double a, double b, double acc=1e-9, double eps=1e-9){
		if(Abs(b-a) < acc) return true;
		else if(Abs(b-a) < Max(Abs(a),Abs(b))*eps) return true;
		else return false;
}


        public static void Main(){

///Task1 
		{///start
		int i = 1;
	     	WriteLine("When a int i is given the start value, what is the maximal/minimal init value i can take:");  
		while (i+1>i){i++;}
		Write("my max int = {0}\n",i);
		
                while (i-1<i){i--;}
                Write("my min int = {0}\n",i);

		}///end
///Task2 	
                WriteLine("The machine epsilon is the difference between 1.0 and the next representable floating point number. Using the while loop calculate the machine epsilon for the types float and double");

		double x = 1;
		while (1+x!=1){x/=2;} x*=2;
                Write("double x = {0}\n",x);


		float y=1F;
	       	while ((float)(1F+y) != 1F){y/=2F;} y*=2F;
                Write("float y = {0}\n",y);
		
		WriteLine("What is the difference between these two?");
		Write("double x - float y = {0}\n",(x-y));

		WriteLine("They can also be writen as power functions");
		Write("Double machine epsilon =2⁻²⁵={0}\n",Pow(2,-52) );
                Write("float machine epsilon=2⁻²³={0}\n",Pow(2,-23) );


///Task3
		int n = (int) 1e6;
		Write("n ={0}\n",n); /// should show 1000000

		double epsilon = Pow(2,-52);
		double tiny = epsilon/2;
		double sumA=0,sumB=0;

		
		sumA+=1;          ///since we want sumA=1 + tiny+tiny....+tiny we start by adding 1 
 			for(int i=0 ; ///Variable in forloop
			i<n ; ///first condition, that states the for loop should run as long as i is les than n
		       	i++){ ///after every run it should increas the value of i by one
				sumA+=tiny; /// since sumA already has the value of 1 we will add the value of tiny to it inside of the loop until i is equal n amount of times
			}


	/// now the same is done for sumB just	sumB=tiny+tiny...+tiny +1 we stirt by summing over i' numbers of tiny and add 1 at the end
	/// we start this time with creating a sum from o to n-> 1000000
			
			for(int i=0; i<n; i++){
				sumB+=tiny;
			}
			sumB+=1;
		
		WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}");
		WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}");

		Write(" I think that the reason sumA dosent equal what it should is due to the fact that we start by assesing it a value of 1 where the tiny contributions wont count meaning sumA=1, så becaus they dont have a binary representation they get rounded to 0 becouse 1+ tiny stil equals 1 in binary, but tiny + tiny does not equal 0 in binary\n");


///Task4	
		double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
		double d2 = 8*0.1;		
		

		WriteLine($"d1={d1:e15}=0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1");
		WriteLine($"d2={d2:e15}= 8*0.1");
		WriteLine($"is d1=d2; {d1==d2}");
		Write("That is because the decimal number 0.1 cannot be represented exactly as a 52-digit binary number\n");

		Write("Now we will use a function which we creat to solve this problem, it takes 2 arguments and 2 values to compare - > Two doubles in a finite digit representation can only be compared with the given absolute and/or relative precision (where the values for the precision actually depend on the task at hand and generally must be supplied by the user\n");



		WriteLine($"are the numbers 4 and 5 equal -> {approx(4,5)}");
		WriteLine($"are the numbers 4 and 4 equal -> {approx(4,4)}");





	}		
}
