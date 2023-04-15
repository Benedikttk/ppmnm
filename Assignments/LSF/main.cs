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

	double c_a = Math.Exp(bf[0]); //amplitude
	double c_lamda = bf[1]; //decay constant

	//Equation for deacay e^(ln(y)=ln(a)-λt).
	foreach(var arg in args){
		if(arg == "fit"){
			//generate data for plotting the fit 
			for(double x=0.1+1.0/128;x<=15;x+=1.0/64){
				double fit_val = c_a*Math.Exp(c_lamda*x);
				double fit_val_err_sub = (c_a-c_errors[0])*Math.Exp((c_lamda-c_errors[1])*x);
				double fit_val_err_add = (c_a+c_errors[0])*Math.Exp((c_lamda+c_errors[1])*x);
				WriteLine($"{x} {fit_val} {fit_val_err_sub} {fit_val_err_add} ");
			}
			}
		if(arg == "info"){
			double halflife_theory = 3.631;
			double halflife_exp = Math.Log(2.0)/(-1*c_lamda);
			double halflife_deviation = (halflife_theory/halflife_exp)*100;
			
			//will be using error-propagation to find uncerntainty of the calculated halflife
			/*
			 * y = ln(2)/l -> y(l)
			 * e_y = |dy/dl|e_l
			 * ln(2)|-1/(l²)|e_l
			 * */
			double halflife_error = Math.Log(2)/(c_lamda*c_lamda) * c_errors[1];  
			string pm = "\u00B1";

			WriteLine($"The expirimental halflife of ThX is {halflife_exp} {pm} {halflife_error}  [Days] \n The theoretical halflife is {halflife_theory} [Days]");			
			WriteLine($"The Deviation from the theoretical value is {halflife_deviation} %");
			if(halflife_exp-halflife_error<=halflife_theory && halflife_theory<=halflife_exp+halflife_error){
					WriteLine("Experiemental value for the halflife do agree with theory.");
				}
			else{WriteLine("Experimental values for the halflife do not agree with theory.\n");}
			
			
			//WriteLine($"c_lamda{c_lamda}"); c_lamda is negative becaouse we have fitted to a exponential increasing function when it should be decreasing, fix with a minus
		}	

		}

	}//Main
}//main
