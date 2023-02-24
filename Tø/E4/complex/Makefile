Out.txt : main.exe
	mono $^ > Out.txt

DIR = /home/benedikttk/6_Semester_au/PragPropMedNumMet/Reposetory_ppmnm/ppmnm/Tø/E4/complex


lib.dll : $(DIR)/cmath.cs $(DIR)/complex.cs
	mcs -target:library -out:./lib.dll $^

main.exe : main.cs lib.dll
	mcs -reference:lib.dll -out:main.exe $<

clean:
	rm -rf lib.dll main.exe Out.txt
