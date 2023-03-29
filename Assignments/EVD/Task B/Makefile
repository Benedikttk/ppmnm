All : rmaxplot.svg drplot.svg
#	pkill xdg-open || true
#	rm -f plots/*.svg
#	mv -t plots $^
#	xdg-open plots/rmaxplot.svg
#	xdg-open plots/drplot.svg

rmaxplot.svg : rmax.gpi rmax.data
	gnuplot $<

drplot.svg : dr.gpi dr.data
	gnuplot $<

rmax.data : main.exe Makefile
	>$@
	mono $< -rmax:1 -dr:0,1 | sed -e 's/,/./g' >> $@
	mono $< -rmax:2 -dr:0,1 | sed -e 's/,/./g' >> $@
	mono $< -rmax:3 -dr:0,1 | sed -e 's/,/./g' >> $@
	mono $< -rmax:4 -dr:0,1 | sed -e 's/,/./g' >> $@
	mono $< -rmax:5 -dr:0,1 | sed -e 's/,/./g' >> $@
	mono $< -rmax:6 -dr:0,1 | sed -e 's/,/./g' >> $@
	mono $< -rmax:7 -dr:0,1 | sed -e 's/,/./g' >> $@
	mono $< -rmax:8 -dr:0,1 | sed -e 's/,/./g' >> $@
	mono $< -rmax:9 -dr:0,1 | sed -e 's/,/./g' >> $@ 

dr.data : main.exe Makefile
	>$@
	mono $< -rmax:10 -dr:0,9 | sed -e 's/,/./g' >> $@
	mono $< -rmax:10 -dr:0,8 | sed -e 's/,/./g' >> $@
	mono $< -rmax:10 -dr:0,7 | sed -e 's/,/./g' >> $@
	mono $< -rmax:10 -dr:0,6 | sed -e 's/,/./g' >> $@
	mono $< -rmax:10 -dr:0,5 | sed -e 's/,/./g' >> $@
	mono $< -rmax:10 -dr:0,4 | sed -e 's/,/./g' >> $@
	mono $< -rmax:10 -dr:0,3 | sed -e 's/,/./g' >> $@
	mono $< -rmax:10 -dr:0,2 | sed -e 's/,/./g' >> $@
	mono $< -rmax:10 -dr:0,1 | sed -e 's/,/./g' >> $@

lib.dll : jacobi.cs QRGS.cs matrix.cs vector.cs
	mcs -target:library -out:$@ $^

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

clean:
	rm -rf Out.txt main.exe lib.dll *.svg *.data plots/*

