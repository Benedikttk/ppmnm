using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
public static class main{

	public static double get_p(vector xs, vector ys, int i){
		return (ys[i+1]-ys[i])/(xs[i+1]-xs[i]);
	}

	public static double get_c_forward(vector xs, vector ys, vector cs, int i){/* We get c_i+1 */
		return 1.0/(xs[i+2] - xs[i+1])*(get_p(xs, ys, i+1) - get_p(xs, ys, i) - cs[i]*(xs[i+1]-xs[i]));
	}

	public static double get_c_backward(vector xs, vector ys, vector cs, int i){/* We get c_i */
		return 1.0/(xs[i+1] - xs[i])*(get_p(xs, ys, i+1) - get_p(xs, ys, i) - cs[i+1]*(xs[i+2]-xs[i+1]));
	}
	
	public static double get_b(vector xs, vector ys, vector cs, int i){
		return get_p(xs, ys, i) - cs[i]*(xs[i+1]-xs[i]);
	}
	
	public static double get_s(double x, vector xs, vector ys, vector bs, vector cs){
		int i = 0;
		int j = xs.size - 1;
		
		while(j-i > 1){
			int m = (i+j)/2;
			if(x > xs[m]) i = m;
			else j = m;
		}
	
		return ys[i] + bs[i]*(x-xs[i]) + cs[i]*Pow(x-xs[i], 2);
	}
	
	public static (vector, vector) get_bs_cs(vector xs, vector ys){
		int n = xs.size;
		vector cs_f = new vector(n);
		vector cs_b = new vector(n);
		vector bs = new vector(n);
	
		for(int i=0; i<n-2; i++) cs_f[i+1] = get_c_forward(xs, ys, cs_f, i);
		cs_b[n-2] = 1/2*cs_f[n-2];
		for(int i=n-3; i>=1; i--) cs_b[i] = get_c_backward(xs, ys, cs_b, i);
		vector cs = (cs_b+cs_f)/2;
		for(int i=0; i<n-1; i++) bs[i] = get_b(xs, ys, cs, i);
		return (bs, cs);
	}


	public static void Main(){
		int n =5;
		vector xs = new vector(n);
		vector ys = new vector(n);
		
		for(int i=0; i<n; i++){
			xs[i] = i+1;
			ys[i] = 1;
		}
		
		(vector bs, vector cs) = get_bs_cs(xs, ys);
		
		for(int i=n-2; i>1; i--) WriteLine(i);
		
		WriteLine("What will be shown are the solutions and the analytical solution\n");	
		xs.print("xs = ");
		ys.print("ys = ");
		WriteLine("Analytic solution: b[i]=c[i]=0");
		WriteLine("i, b[i], c[i]");
		
		for(int i=1; i<n-1; i++) WriteLine($"{i}, {bs[i]}, {cs[i]}");

		WriteLine("\n");
		
		for(int i=0; i<n; i++){
			xs[i] = i+1;
			ys[i] = i+1;
		}
		
		xs.print("xs = ");
		ys.print("ys = ");
		(bs, cs) = get_bs_cs(xs, ys);
		
		WriteLine("Analytic solution: b[i]=1, c[i]=0");
		WriteLine("i, b[i], c[i]");
		
		for(int i=1; i<n-1; i++) WriteLine($"{i}, {bs[i]}, {cs[i]}");
		
		WriteLine("\n");
		
		for(int i=0; i<n; i++){
			xs[i] = i+1;
			ys[i] = Pow(i+1, 2);
		}
		xs.print("xs = ");
		ys.print("ys = ");
		(bs, cs) = get_bs_cs(xs, ys);
		
		WriteLine("Analytic solution: b[i]=2*x[i], c[i]=1");
		WriteLine("i, b[i], c[i], x[i]");
		
		for(int i=1; i<n-1; i++) WriteLine($"{i}, {bs[i]}, {cs[i]}, {xs[i]}");


			
	}//Main
}//main
