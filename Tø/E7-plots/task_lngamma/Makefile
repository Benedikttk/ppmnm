lngamma.svg :lngamma.gpi lngamma.data 
	gnuplot $<

lngamma.data : main.exe
	mono $< | sed -e 's/,/./g' > $@

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
	$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

lib.dll : mfuncs.cs
	mcs -target:library -out:$@ $^

clean:
	rm -rf *.txt *.exe *.dll *.data *.svg
