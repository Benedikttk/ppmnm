All : Out.txt
	cat $<

Out.txt : main.exe
	mono main.exe > Out.txt

main.exe: main.cs
	mcs $< -target:exe -Out:$@

clean:
	rm --force Out.txt main.exe
