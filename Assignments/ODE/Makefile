All: ODE.svg 

ODE.svg: ODE.gpi Harmonic.data Pendul.data
	gnuplot $<

Harmonic.data: main.exe
	mono $< Harmonic | sed -e's/,/./g' > $@

Pendul.data: main.exe
	mono $< Pendul | sed -e's/,/./g' > $@



lib.dll :  vector.cs
	mcs -target:library -out:$@ $^


main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
                $(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

clean:
	rm -rf *.txt main.exe lib.dll *.svg *.data plots/*

