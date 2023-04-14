ALL: decay.svg QRdeebug.txt

exp.data : Makefile
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


decay.svg : decay.gpi exp.data fit.data
	gnuplot $<


lib.dll : LSF.cs  QRGS.cs matrix.cs vector.cs
	mcs -target:library -out:$@ $^


QRdeebug.txt : main.exe
	mono $< QRdeebug | sed -e's/,/./g'> $@

fit.data : main.exe
	mono $< fit | sed -e's/,/./g'> $@

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
                $(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

clean:
	rm -rf *.txt main.exe lib.dll *.svg *.data plots/*

