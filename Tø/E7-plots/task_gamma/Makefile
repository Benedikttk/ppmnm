Gamma.svg : gamma.gpi gamma.data factorials.data
	gnuplot $<

gamma.data : main.exe
	        mono $< | sed -e 's/,/./g' > $@

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

lib.dll : mfuncs.cs
	mcs -target:library -out:$@ $^

factorials.data : Makefile
	>$@
	echo 0 1 >>$@
	echo 1 1 >>$@
	echo 2 2 >>$@
	echo 3 6 >>$@
	echo 4 24 >>$@
	echo 5 120 >>$@
	echo 6 $$(echo '6*120' | bc) >>$@

main: main.exe lib.dll
	mkbundle -o $@ --simple $^

clean:
	rm -rf *.txt *.exe *.dll *.data *.svg

