default: test-shell Out.txt

Out.txt: main.exe
	mono main.exe > Out.txt
main.exe: main.cs
	mcs main.cs -out:main.exe -target:exe
clean: 
	rm --force Out.txt main.exe
test-shell:
	echo $$0

