Out.txt: main.exe
	mono main.exe -input:input.txt -output:Out.txt

main.exe: main.cs
	mcs $< -target:exe -Out:$@

clean: 
	rm -rf Out.txt main.exe
