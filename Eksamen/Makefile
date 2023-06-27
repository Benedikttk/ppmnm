All : testpoints.data Akima.data plot.svg 


plot.svg : plot.gpi testpoints.data
	gnuplot $<

rnddata.data: main.exe
	mono $< rnddata | sed -e's/,/./g' > $@

testpoints.data : main.exe
	mono $< test | sed -e's/,/./g' > $@

Akima.data : main.exe
	mono $< AkimaSubSplineInetpolation | sed -e's/,/./g' > $@

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))


lib.dll : AkimaSpline.cs
	mcs -target:library -out:$@ $^


clean:
	rm -rf *.exe lib.dll *.svg *.data
