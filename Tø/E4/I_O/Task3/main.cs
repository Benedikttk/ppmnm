using System;
using static System.Math;
using static System.Console;

static public class main{
	static public void Main(string[] args){
        	string infile=null,outfile=null;
		
		foreach(var arg in args){
			var words=arg.Split(':');
			if(words[0]=="-input")infile=words[1];
			if(words[0]=="-output")outfile=words[1];
			}
		
		if( infile==null || outfile==null) {
			Error.WriteLine("wrong filename argument");
			}
		
		var instream =new System.IO.StreamReader(infile);
		var outstream=new System.IO.StreamWriter(outfile,append:false);
		
		for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
			double x=double.Parse(line);
			if(x-2>0){
				outstream.WriteLine($"Laura has {x} apples if she eats 2 apples she has {x-2} apples left.");
        			}
			else{
				outstream.WriteLine($"Laura has eaten imaginary apples.");
				}
			}
		instream.Close();
		outstream.Close();
	}
}
