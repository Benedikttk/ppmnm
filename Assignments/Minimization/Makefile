All : Out.txt higgs.txt fitsdata.data HiggsFitPlot.svg
	cat $<
	cat higgs.txt


lib.dll : LSF.cs  QRGS.cs matrix.cs vector.cs
	mcs -target:library -out:$@ $^

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
                $(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

HiggsFitPlot.svg: plot.gpi fitdata.data fitsdata.data
	gnuplot $<

fitdata.data: main.exe
	mono $< $@ | sed -e's/,/./g' > $@

fitsdata.data: main.exe
	mono $< $@ | sed -e's/,/./g' > $@

higgs.txt: main.exe
	mono $< $@ | sed -e's/,/./g' > $@

Out.txt: main.exe
	mono $< $@ | sed -e's/,/./g' > $@

clean :
	rm -rf *.txt main.exe fitsdata.data fitdata.data estimated_error.data *.svg *.dll

