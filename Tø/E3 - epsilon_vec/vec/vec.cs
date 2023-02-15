using System;
using static System.Console;
using static System.Math;

///Task1 and Task2 
public class vec{
	public double x,y,z;
	public vec (){ x=y=z=0; }
	public vec (double x,double y,double z)
		{ this.x=x; this.y=y; this.z=z; }
///Task 4
	public void print(string s){Write(s);WriteLine($"{x} {y} {z}");}
	public void print(){this.print("");}
	
	
///Task3 start

	//Adding
	public static vec operator+(vec u,vec v){
		return new vec(u.x+v.x,u.y+v.y,u.z+v.z);
			}
	//Subtracting
	public static vec operator-(vec u,vec v){
		return new vec(u.x-v.x,u.y-v.y,u.z-v.z);
			}
	//making negative
	public static vec operator-(vec v){ 
		return new vec(-v.x,-v.y,-v.z);
			}
	//multiplication of scallar
	public static vec operator*(vec u,double c){
		return new vec(u.x*c,u.y*c,u.z*c);
			}
	//multiplication of scallar
	public static vec operator*(double c,vec u){
		return u*c;
			}

///Task3 end


///Task5
	//Now we will make dot products for vectors. The => is another way of writing return.
	public static double dot(vec a, vec b) => a.x*b.x+a.y*b.y+a.z*b.z;
	// Now we make the cross product.
	public static vec cross(vec u, vec v){
		return new vec(u.y*v.z-u.z*v.y , u.z*v.x-u.x*v.z , u.x*v.y-u.y*v.x );
	}
	//The norm of the vector.
	public static double norm(vec a){
		return Sqrt(a.x*a.x+a.y*a.y+a.z*a.z);
	}

///Task6
	public static bool approx(double a,double b,double acc=1e-9,double eps=1e-9){
		if(Abs(a-b)<acc)return true;
		if(Abs(a-b)<(Abs(a)+Abs(b))*eps)return true;
		return false;
		}
		
	public static bool approx(vec a, vec b){
		if(!approx(a.x,b.x))return false;
                if(!approx(a.y,b.y))return false;
                if(!approx(a.z,b.z))return false;
		return true;
		}

	public override string ToString(){ 
		return $"{x} {y} {z}";
       		}


}





