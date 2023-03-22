CSC = mcs
RUN = mono

all: Out.txt; cat $<

Out.txt: main.exe
	$(RUN) $< > $@

main.exe: main.cs  lib.dll
	$(CSC) -reference:$(word 2,$^) $<

lib.dll : jacobi.cs vector.cs matrix.cs QRGS.cs
	$(CSC) -target:library -out:$@ $^

clean:
	$(RM) *.dll *.exe [Oo]ut*
