Out.txt : main.exe
	mono main.exe > Out.txt

lib.dll : mfuncs.cs
	mcs $^ -target:library -out:lib.dll

main.exe : main.cs lib.dll
	mcs main.cs -reference:lib.dll -target:exe -out:main.exe

clean : 
	rm -f Out.txt lib.dll main.exe


