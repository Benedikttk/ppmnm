using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;

public static class main{
	
	public static matrix Ham(double rmax, double dr){
		int npoints = (int)(rmax/dr)-1;
		vector r = new vector(npoints);

		for(int i=0; i<npoints; i++)
			r[i]=dr*(i+1);

		matrix H = new matrix(npoints,npoints);
		
		for(int i=0;i<npoints-1;i++){
			H[i,i]=-2;
			H[i,i+1]=1;
			H[i+1,i]=1;
		}
		H[npoints-1,npoints-1]=-2;
		matrix.scale(H,-0.5/dr/dr);

		for(int i=0;i<npoints;i++)
			H[i,i]+=-1/r[i];
		return H;
	}

	public static void Main(string[] args){
		double rmax=10;
		double dr=0.3;
		

		foreach(var arg in args){
			var words = arg.Split(':');

			if(words[0] == "-rmaxs") {
				for(rmax=2.5; rmax<15;rmax+=0.5){
					matrix H = Ham(rmax, dr);
					(var D, var V) = jacobi.cyclic(H);
                        		vector e = new vector(D.size1);
					for(int i=0; i<D.size1;i++)
                              			e[i]=D[i,i];
					WriteLine($"{rmax} {e[0]}");
				}
			}
			else if(words[0] == "-drs"){
				for(dr=0.05; dr<2;dr+=0.05){
					matrix H = Ham(rmax, dr);
					(var D, var V) = jacobi.cyclic(H);
                        		vector e = new vector(D.size1);
					for(int i=0; i<D.size1;i++)
                                		e[i]=D[i,i];
					WriteLine($"{dr} {e[0]}");
				}
			}
		}	

	}
}
