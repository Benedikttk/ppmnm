All : testpoints.data Akima.data AkimaSlope.data plot.svg Compare.svg Out.txt

Compare.svg : compare.gpi AkimaSlope.data CubeSlope.data points.data
	gnuplot $<

plot.svg : plot.gpi testpoints.data
	gnuplot $<

points.data : main.exe
	mono $< dataPoints | sed -e's/,/./g' > $@

CubeSlope.data : main.exe
	mono $< CubeSlope | sed -e's/,/./g' > $@

rnddata.data: main.exe
	mono $< rnddata | sed -e's/,/./g' > $@

testpoints.data : main.exe
	mono $< test | sed -e's/,/./g' > $@

AkimaSlope.data : main.exe
	mono $< AkimaSlope | sed -e's/,/./g' > $@

Akima.data : main.exe
	mono $< AkimaSubSplineInetpolation | sed -e's/,/./g' > $@

Out.txt : main.exe
	mono $< Area | sed -e's/,/./g' > $@ 
	cat $@

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))


lib.dll : AkimaSpline.cs CubeSpline.cs
	mcs -target:library -out:$@ $^


clean:
	rm -rf *.exe lib.dll *.svg *.data Out.txt
