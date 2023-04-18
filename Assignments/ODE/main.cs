using System;
using static System.Math;
using static System.Console;


public class main{
	public static class ODE{

		public static (vector,vector) rkstep12(
			Func<double,vector,vector> f /* the f from dy/dx=f(x,y) */
			double x,                    /* the current value of the variable */
			vector y,                    /* the current value y(x) of the sought function */
			double h                     /* the step to be taken */
			){
			vector k0 = f(x,y);              /* embedded lower order formula (Euler) */
			vector k1 = f(x+h/2,y+k0*(h/2)); /* higher order formula (midpoint) */
			vector yh = y+k1*h;              /* y(x+h) estimate */
			vector er = (k1-k0)*h;           /* error estimate */
		return (yh,er);
		}


		public static (genlist<double>,genlist<vector>) driver(
			Func<double,vector,vector> f /* the f from dy/dx=f(x,y) */
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
			do{
        			if(x>=b) return (xlist,ylist); /* job done */
        			if(x+h>b) h=b-x;               /* last step should end at b */
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


	}//ODE Class

	static void Main(string[] args){




	}//Main
}//main
