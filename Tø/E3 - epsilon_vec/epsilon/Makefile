Out.txt : main.exe    
	mono main.exe > Out.txt

main.exe : main.cs          
	mcs -out:main.exe main.cs

clean:
	rm --force Out.txt main.exe
