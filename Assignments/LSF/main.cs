using System;
using static System.Console;
using System.Diagnostics;
using static System.Math;


public class main{
static void Main(string[] args){
	double[] tdata  = new double[]{1  ,2,3,4,6,9,10,13,15};
	double[] ydata  = new double[]{117,100,88,72,53,29.5,25.2,15.2,11.1};
	double[] dydata = new double[]{5,5,5,4,4,3,3,2,2};
	
	vector t =(vector)tdata;
	vector y =(vector)ydata;
	vector dy=(vector)dydata;
	vector ln_y = y.copy();
	vector ln_dy = dy.copy();
	
	for(int i=0;i<y.size;i++){
		ln_y[i] = Log(y[i]);
		ln_dy[i] = dy[i]/y[i];
	}
	
	int n=t.size;
	var fs = new Func<double,double>[] {z => 1, z => z};
	var fit_params = ls.lsfit(fs, t, ln_y, ln_dy);
	
	vector bf = fit_params.Item1;
	vector c_errors = fit_params.Item3;

	
/*	Func<double,double> fit = (z) => bf[0]*fs[0](z)+bf[1]*fs[1](z);
	
	for(int i=0;i<n;i++){
		WriteLine($"{t[i]} {ln_y[i]} {fit(t[i])}");
		}
	return;
*/

	double c_a = Math.Exp(bf[0]);
	double c_lamda = bf[1];

	foreach(var arg in args){
		if(arg == "fit"){
			//generate data for plotting the fit 
			for(double x=0.1+1.0/128;x<=15;x+=1.0/64){
				WriteLine($"{x} {(c_a*Math.Exp(c_lamda*x))} ");
			}
			}
		
		}

	c_errors.print("c_erros=");
	}//Main
}//main
