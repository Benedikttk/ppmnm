Out.txt : main.exe
	mono $< half_life > $@

decay.svg : decay.gpi ruth.data fit.data
	gnuplot $<

fit.data : main.exe
	mono $< plot > $@

ruth.data : Makefile
	>$@
	echo 1 117 5 >>$@
	echo 2 100 5 >>$@
	echo 3 88 5 >>$@
	echo 4 72 4 >>$@
	echo 6 53 4 >>$@
	echo 9 29.5 3 >>$@
	echo 10 25.2 3 >>$@
	echo 13 15.2 2 >>$@
	echo 15 11.1 2 >>$@


lib.dll : jacobi.cs QRGS.cs matrix.cs vector.cs
	mcs -target:library -out:$@ $^

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

clean:
	rm -rf Out.txt main.exe lib.dll *.svg *.data plots/*



