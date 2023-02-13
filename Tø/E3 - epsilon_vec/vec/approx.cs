using static System.Console;
public class approx{
        public double x,y,z;

	static bool approx(double a,double b,double acc=1e-9,double eps=1e-9){
		if(Abs(a-b)<acc)return true;
		if(Abs(a-b)<(Abs(a)+Abs(b))*eps)return true;
		return false;
	}

	public bool approx(vec other){
		if(!approx(this.x,other.x)return false;
		if(!approx(this.y,other.y)return false;
		if(!approx(this.z,other.z)return false;
		return true;
	}

public static bool approx(vec u, vec v) => u.approx(v);


}
