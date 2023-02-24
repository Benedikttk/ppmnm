main.exe: main.cs
	mcs $< -target:exe -Out:$@
	mono main.exe < input.txt > Out.txt

clean: 
	rm -rf Out.txt main.exe




