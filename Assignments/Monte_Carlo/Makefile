All: plot.svg Out.txt


plot.svg: plot.gpi mcint.data actual_volume.data error_scale.data error_div.data hard_conv.data
	gnuplot $<

Out.txt: main.exe
	mono $< Out| sed -e's/,/./g' >$@

mcint.data: main.exe
	mono $< mcint.data | sed -e's/,/./g' >$@

actual_volume.data: main.exe
	mono $< actual_volume | sed -e's/,/./g' >$@

error_scale.data: main.exe
	mono $< inv_sqrt_nth | sed -e's/,/./g' >$@
error_div.data:main.exe
	mono $< error_div | sed -e's/,/./g' >$@



lib.dll : vector.cs
	mcs -target:library -out:$@ $^

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
                $(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))
clean:
	rm -rf *.txt main.exe lib.dll *.svg *.data plots/*



