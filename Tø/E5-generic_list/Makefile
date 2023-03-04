Out.txt : main.exe 
	mono main.exe $$(cat inputfile) > Out.txt

lib.dll: genlist.cs
	mcs -target:library -out:lib.dll genlist.cs

main.exe : main.cs lib.dll
	mcs -target:exe -out:main.exe -reference:lib.dll main.cs


clean:
	rm -rf Out.txt main.exe
