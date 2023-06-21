All : Out.txt Akima.data


Out.txt : main.exe
	mono $< test | sed -e's/,/./g' > $@

Akima.data: main.exe
	mono $< AkimaSubSplineInetpolation | sed -e's/,/./g' > $@

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
                $(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

lib.dll : AkimaSpline.cs
	mcs -target:library -out:$@ $^


clean:
	rm -rf *.txt main.exe lib.dll *.svg *.data
