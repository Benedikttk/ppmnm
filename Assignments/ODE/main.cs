using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.IO;

public class genlist<T>{
	public T[] data;
	public int size => data.Length;
	public T this[int i] => data[i]; 
	public genlist(){ data = new T[0]; }
	public void add(T item){
		T[] newdata = new T[size+1];
		System.Array.Copy(data,newdata,size);
		newdata[size]=item;
		data=newdata;
	}
}

public static class main{
		
	public static (vector,vector) rkstep12(
	Func<double,vector,vector> f, /* the f from dy/dx=f(x,y) */
	double x,                    /* the current value of the variable */
	vector y,                    /* the current value y(x) of the sought function */
	double h                     /* the step to be taken */
	)
{
	vector k0 = f(x,y);              /* embedded lower order formula (Euler) */
	vector k1 = f(x+h/2,y+k0*(h/2)); /* higher order formula (midpoint) */
	vector yh = y+k1*h;              /* y(x+h) estimate */
	vector er = (k1-k0)*h;           /* error estimate */
	return (yh,er);
}	

	
	public static (genlist<double>,genlist<vector>) driver(
	Func<double,vector,vector> F, /* the f from dy/dx=f(x,y) */
	double a,                    /* the start-point a */
	vector ya,                   /* y(a) */
	double b,                    /* the end-point of the integration */
	double h=0.01,               /* initial step-size */
	double acc=0.01,             /* absolute accuracy goal */
	double eps=0.01              /* relative accuracy goal */
	){
	if(a>b) throw new ArgumentException("driver: a>b");
	double x=a; vector y=ya.copy();
	var xlist=new genlist<double>(); xlist.add(x);
	var ylist=new genlist<vector>(); ylist.add(y);
	do{ if(x>=b) return (xlist,ylist);/* job done */
	if(x+h>b) h=b-x;/* last step should end at b */
		var (yh,erv) = rkstep12(F,x,y,h);
		double tol = (acc+eps*yh.norm()) * Sqrt(h/(b-a));
		double err = erv.norm();
	if(err<=tol){ // accept step
		x+=h; y=yh;
		xlist.add(x);
		ylist.add(y);
	}
		h *= Min( Pow(tol/err,0.25)*0.95 , 2); // reajust stepsize
	}while(true);
}//driver

//Dif functioner som skal løses
	static vector harmonic(double x, vector y){/*Testing of harmonic oscialtion u''=-u Task A.3*/
		return new vector(y[1], -y[0]);
	}


	static vector pendul(double x, vector y){
		double b = 0.25;
		double a = 5.0;
		//theta''(t) + b*theta'(t) + c*sin(theta(t)) = 0
		return new vector(y[1], -b*y[1]-a*Math.Sin(y[0]));
	}

	

public static void Main(string[] args){


	foreach(var arg in args){
		if(arg == "Harmonic"){
			vector init_y = new vector(0, 1);
			(var xs, var ys) = driver(harmonic, 0, init_y, 30);
			//var harmonic_data = new StreamWriter("harmonic_data.data");
			for(int i=0; i<xs.size; i++) 
				WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]} {ys[i][0]+ys[i][1]}");
		}

		if(arg=="Pendul"){
		vector init_pendul = new vector(Math.PI-0.1,0);
		(var pendul_xs, var pendul_ys) = driver(pendul,0,init_pendul,30);
		for(int i=0; i<pendul_xs.size;i++)
			WriteLine($"{pendul_xs[i]} {pendul_ys[i][0]} {pendul_ys[i][1]}");
		}


	}//foreach	


	}//Main
}//main












