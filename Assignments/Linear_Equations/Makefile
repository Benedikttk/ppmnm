CSC = mcs
RUN = mono

all: Out.txt; cat $<

Out.txt: main.exe
	$(RUN) $< > $@

main.exe: main.cs matrix.dll 
	$(CSC) -reference:$(word 2,$^) $<

matrix.dll : vector.cs matrix.cs QRGS.cs
	$(CSC) -target:library -out:$@ $^

out.times.data : main.exe
	>$@
	for N in $$(seq 100 20 200); do \
		time --format "$$N %e" --output $@ --append \
		mono $< -size:$$N 1>out 2>err ;\
	done


clean:
	$(RM) *.dll *.exe [Oo]ut*
