using System;
using static System.Console;
public static class main{
	public static void Main(){

		vec u = new vec(1,2,3);
		vec v = new vec(2,3,4);
		u.print("u=");
		v.print("v=");
		(u+v).print("u+v=");

		


		vec a = new vec(3,4,5);
		vec b = new vec(4,5,6);
		a.print("a=");
		b.print("b=");
		
		(a-b).print("a-b=");
		(-a).print("-a=");
		
		
		var w = a*5;
		w.print("a*5=");
		WriteLine($"a%b={a%b}");

		


	}
}
