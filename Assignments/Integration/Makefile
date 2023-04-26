ALL : Out.txt Error.svg 

Error.svg : Error.gpi erfs.data error_factorials.data
	gnuplot $<


Out.txt: main.exe
	mono $< Test | sed -e's/,/./g' > $@

erfs.data: main.exe
	mono $< erfs | sed -e's/,/./g' >$@

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

main.exe : main.cs 
	mcs -target:exe -out:$@ \
                $(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

clean:
	rm -rf *.txt main.exe lib.dll *.svg *.data plots/*

