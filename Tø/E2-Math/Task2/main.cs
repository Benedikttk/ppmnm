using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;

public static class main{
	public static void Main(){
/// Gives different values to the gamma function in mfuncs.cs
		mfuncs.print();
		WriteLine($"Gamma(1) = {mfuncs.gamma(1)}");
		WriteLine($"Gamma(2) = {mfuncs.gamma(2)}");
		WriteLine($"Gamma(3) = {mfuncs.gamma(3)}");
		WriteLine($"Gamma(10) = {mfuncs.gamma(10)}");


//Uses for loops over a specified list to print values og gamma function 
		List<int> numbers = new List<int>(){1,2,3,10};
		for(int i = 0; i < numbers.Count; i++){
    			WriteLine($"Gamma({i}) with forloop = {mfuncs.gamma(numbers[i])}");
			WriteLine($"numbers.Count = {numbers.Count}");
			}


/// Now we will make the same loop with a foreach loop
		WriteLine($"Now we will try gamma and lngamma with a foreachloop");

		foreach (var i in numbers) {
			WriteLine($"lngamma({i}) = {mfuncs.lngamma(i)}");
			WriteLine($"gamma({i}) = {mfuncs.gamma(i)}");
			}
	}
}
