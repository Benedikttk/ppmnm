
Out.txt: main.exe
	mono $< Test | sed -e's/,/./g' > $@


main.exe : main.cs 
	mcs -target:exe -out:$@ \
                $(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

clean:
	rm -rf *.txt main.exe lib.dll *.svg *.data plots/*

