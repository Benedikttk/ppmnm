ALL : Out.txt Makefile
	cat $<

plot.svg : plot.gpi points.data interpolate.data integral.data
	gnuplot $<

points.data : main.exe
	mono $< points  | sed -e's/,/./g' > $@

interpolate.data : main.exe
	mono $< interpolate | sed -e's/,/./g' >$@

integral.data : main.exe
	mono $< integral | sed -e's/,/./g' >$@


main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
                $(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

lib.dll : vector.cs
	mcs -target:library -out:$@ $^

Out.txt : qspline.exe
	mono $< > $@

qspline.exe : qspline.cs lib.dll
	mcs -target:exe -out:$@ \
                $(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))


clean:
	rm -rf *.txt *.exe lib.dll *.svg *.data plots/*

