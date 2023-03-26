All : rmaxplot.svg drplot.svg
	mv -t plots $^	
	xdg-open plots/rmaxplot.svg


rmaxplot.svg : rmax.gpi rmax.data
	gnuplot $<

drplot.svg : dr.gpi dr.data
	gnuplot $<

rmax.data : main.exe
	mono $< -rmaxs | sed -e 's/,/./g' > $@

dr.data : main.exe
	mono $< -drs | sed -e 's/,/./g' > $@

lib.dll : jacobi.cs QRGS.cs matrix.cs vector.cs
	mcs $< -target:library -out:$@ $^

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

clean:
	rm -rf Out.txt main.exe lib.dll *.svg *.data plots/*

