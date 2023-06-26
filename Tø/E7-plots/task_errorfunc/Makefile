All : Error.svg
	eog $<

Error.svg : error.gpi error.data error_factorials.data
	gnuplot $<

error.data : main.exe
	mono $< | sed -e 's/,/./g' > $@

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
	$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

lib.dll : mfuncs.cs
	mcs -target:library -out:$@ $^

error_factorials.data : Makefile
	>$@
	echo 0 0 >>$@
	echo 0.2 0.222702589 >>$@
	echo 1 0.842700793 >>$@
	echo 0.6 0.60385609 >>$@
	echo 1.3 0.934007945 >>$@
	echo -0.2 -0.222702589 >>$@
	echo -1 -0.842700793 >>$@
	echo -0.6 -0.60385609 >>$@
	echo -1.3 -0.934007945 >>$@


clean:
	rm -rf *.txt *.exe *.dll *.data *.svg
