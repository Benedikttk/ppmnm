using System;
using static System.Console;
using static System.Math;

public static class main{

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



	static double integrate(Func<double,double> f, double a, double b,
			double acc=0.001, double eps=0.001, double f2=Double.NaN, double f3=Double.NaN){
		double h=b-a;
		if(Double.IsNaN(f2)){f2=f(a+2*h/6); f3=f(a+4*h/6); } // first call, no points to reuse
		double f1=f(a+h/6), f4=f(a+5*h/6);
		double Q = (2*f1+f2+f3+2*f4)/6*(b-a); // higher order rule
		double q = (  f1+f2+f3+  f4)/4*(b-a); // lower order rule
		double err = Abs(Q-q);
		if (err <= acc+eps*Abs(Q)) return Q;
		else return integrate(f,a,(a+b)/2,acc/Sqrt(2),eps,f1,f2)+integrate(f,(a+b)/2,b,acc/Sqrt(2),eps,f3,f4);
	}//integral



	public static bool approx(double a, double b, double acc=0.001, double eps=0.001){
		if(Abs(b-a) < acc) return true;
		else if(Abs(b-a) < Max(Abs(a),Abs(b))*eps) return true;
		else return false;
	}//approx


	/*functions to be tested*/
	static double func1(double x){return Math.Sqrt(x);}
	static double func2(double x){return 1/func1(x);}
	static double func3(double x){return 4*Sqrt(1-(x*x));}
	static double func4(double x){return Log(x)/func1(x);}


	/*Old error-function*/
        public static double errf(double x){
        /// single precision error function (Abramowitz and Stegun, from Wikipedia)
                if(x<0) return -errf(-x);
                double[] a={0.254829592,-0.284496736,1.421413741,-1.453152027,1.061405429};
                double t=1/(1+0.3275911*x);
                double sum=t*(a[0]+t*(a[1]+t*(a[2]+t*(a[3]+t*a[4]))));/* the right thing */
                return 1-sum*Exp(-x*x);
        }

	/*New error-function*/
	
	static double helper1(double x){return Math.Exp(-x*x);}
	public static Func<double,double> helper2(double z){
		return (x) => {return Math.Exp(-(z+(1-x)/x)*(z+(1-x)/x))/x/x;};
	}
	static double erf(double z){
		if(z<0) return -erf(-z);
		else if(0<=z & z<=1) return (2/Sqrt(PI))*integrate(helper1, 0, z);
		else if(1<z) return 1-(2/Sqrt(PI))*integrate(main.helper2(z), 0, 1);
		else return 0;
	

	}//erf


	public static void Main(string[] args){

	/*Testing of integration*/
		double test1 = integrate(func1,0,1); //∫01 dx √(x) = 2/3 
		double test2 = integrate(func2,0,1); //∫01 dx 1/√(x) = 2
		double test3 = integrate(func3,0,1);//∫01 dx 4√(1-x²) = π
		double test4 = integrate(func4,0,1);//∫01 dx ln(x)/√(x) = -4

		double answer1 = (2.0/3.0);
		double answer2 = 2.0;
		double answer3 = Math.PI;
		double answer4 = -4.0;


		foreach(var arg in args){
			
			if(arg == "Test"){
				WriteLine("Test of integration for 4 functions.");
				WriteLine($"Calculated Result {test1} Answer {answer1}, It works = {approx(test1, answer1)}  ");
                                WriteLine($"Calculated Result {test2} Answer {answer2}, It works = {approx(test2, answer2)}  ");
                                WriteLine($"Calculated Result {test3} Answer {answer3}, It works = {approx(test3, answer3)}  ");
                                WriteLine($"Calculated Result {test4} Answer {answer4}, It works = {approx(test4, answer4)}  ");
				
				double[] z_values = {0.1, 0.2, 0.5, 1.0, 2.0};
				double[] table_values = {0.112462916, 0.222702589, 0.520499878, 0.842700793, 0.995322265};
				var new_erf = new genlist<double>();
				var old_errf = new genlist<double>();
				for(int i=0;i<z_values.Length;i++){
					new_erf.add(Math.Abs(erf(z_values[i]) - table_values[i]));
					old_errf.add(Math.Abs(errf(z_values[i]) - table_values[i]));
				}
				WriteLine("Comparison between new error function and old error function from plot-exercise.");
				WriteLine($"x-value	table-value	new deviation	old deviation");
				for(int i=0;i<z_values.Length;i++){
				WriteLine($"{z_values[i]}	{table_values[i]}	{new_erf[i]}	{old_errf[i]}");
				}

			}
			if(arg == "erfs"){
				for(double x=-5+1.0/128;x<=5;x+=1.0/64){
					WriteLine($"{x} {errf(x)+ .5} {erf(x)-.5} {erf(x)-errf(x)}");
				}
			
			}


		}//foreach
	







	}//Main
}//main
