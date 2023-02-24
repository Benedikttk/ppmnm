Out.txt : main.exe
	mono main.exe > Out.txt

main.exe: main.cs
	mcs $< -target:exe -out:$@

clean:
	rm --force Out.txt main.exe
