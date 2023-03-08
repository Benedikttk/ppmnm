using System;
using System.Threading;
using static System.Console;
using static System.Math;
class main{

public class data { public int a,b; public double sumab; }
	public static void harm(object obj){
		data x = (data)obj;
		WriteLine($"{Thread.CurrentThread.Name} Starting value a={x.a} end value b={x.b}");
		x.sumab=0;
		for(int i=x.a;i<x.b;i++)x.sumab+=1.0/i;
			WriteLine($"{Thread.CurrentThread.Name} partial sum = {x.sumab}");
		}

	public static int Main(string[] args){
		int nterms=(int)1e8, nthreads = 1;
		foreach(var arg in args)
		{
			var words = arg.Split(':');
			if(words[0]=="-terms"  )nterms  =(int)float.Parse(words[1]);
			if(words[0]=="-threads")nthreads=(int)float.Parse(words[1]);
		}

		WriteLine($"nterms={nterms} nthreads={nthreads}");

		data[] x = new data[nthreads];
		for(int i=0;i<nthreads;i++){
			x[i] = new data();
			x[i].a = 1 + (nterms*i)/nthreads;
			x[i].b = 1 + ((1+i)*nterms)/nthreads;
			}

		Thread[] threads = new Thread[nthreads];
		
		for(int i=0;i<nthreads;i++){
			threads[i] = new Thread(harm);
			threads[i].Name = $"thread number {i+1}";
			threads[i].Start(x[i]);
			}
	
		WriteLine("master thread: now waiting for othrer threads...");
		for(int i=0;i<nthreads;i++){threads[i].Join();}

		double total_sum=0;
		for(int i=0;i<nthreads;i++){
			total_sum+=x[i].sumab;
			}
		WriteLine($"total sum = {total_sum}");

		return 0;
	}

}
