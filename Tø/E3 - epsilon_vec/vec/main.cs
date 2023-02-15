using System;
using static System.Console;
public static class main{
	
	public static void Main(){
		///Task1 and Task2 have been done in vec.cs.
		///Task3 as also been done, as the different opperators.

		WriteLine("The public class vec, can be found in vec.cs and is read through the vec.llb. There you can see all of its opperations.");

		
		vec u = new vec(1,2,3);
		vec v = new vec(2,3,4);
	
		WriteLine($"We start by adding to vectors together, vector u and vector v.");
		u.print("u=");
		v.print("v=");
		(u+v).print("u+v=");

		WriteLine("\n We now define 2 more vectors - a, b. and subtract them and make one of them negative.");
		vec a = new vec(3,4,5);
		vec b = new vec(4,5,6);
		a.print("a=");
		b.print("b=");
		
		(a-b).print("a-b=");
		(-a).print("-a=");
		
		WriteLine("\n Now we see if we can do scallar multiplication on our vectors, with a scallar, w=a*5. Note that if using (5*a).print this will give a value, but (a*5).print will grant an error as it is a bug in all c programs.");
		var w = a*5;
		w.print("a*5=");
		
		///Task 5 - test
		WriteLine($"\n We are now going to find the dot product between two vectors, a, v-> dot(a,v)={vec.dot(a,v)}");

		
		///Task 6 -test
		WriteLine("\n We will now be testing to see if the approximation works on our vectors and scallars.");
		
		///Task6

		var test_2_vec = vec.approx(a,b);
		WriteLine($"are these two vecotrs vector a: {a} and vector b: {b} equal -> {test_2_vec}");
	
		var cross_a_b = vec.cross(a,b);	
		(cross_a_b).print("The crossproduct of a and b is (a X b)=");
		
		var norm_a = vec.norm(a);
                WriteLine($"Croos product Norm(a) = {norm_a}");


	///Task7	

		string str_vec_a = a.ToString();
		WriteLine($"We have now written the vector a as a string ->{str_vec_a}");

	}
}
