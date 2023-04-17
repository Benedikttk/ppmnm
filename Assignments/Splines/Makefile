plot.svg : plot.gpi points.data
	gnuplot $<

points.data : main.exe
	mono $< points > $@

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
                $(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

lib.dll : vector.cs
	mcs -target:library -out:$@ $^


clean:
	rm -rf *.txt main.exe lib.dll *.svg *.data plots/*

