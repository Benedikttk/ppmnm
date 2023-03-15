CSC = mcs
RUN = mono

all: Out.txt; cat $<

Out.txt: main.exe
	$(RUN) $< > $@

main.exe: main.cs matrix.dll 
	$(CSC) -reference:$(word 2,$^) $<

matrix.dll : vector.cs matrix.cs QRGS.cs
	$(CSC) -target:library -out:$@ $^

clean:
	$(RM) *.dll *.exe [Oo]ut*
