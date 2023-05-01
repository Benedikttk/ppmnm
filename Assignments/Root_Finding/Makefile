Out.txt :main.exe
	mono $<>$@

lib.dll : LSF.cs  QRGS.cs matrix.cs vector.cs
	mcs -target:library -out:$@ $^

Info.txt : main.exe
	mono $< info | sed -e's/,/./g' > $@

fit.data : main.exe
	mono $< fit | sed -e's/,/./g' > $@

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
                $(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

clean:
	rm -rf *.txt main.exe lib.dll *.svg *.data plots/*
