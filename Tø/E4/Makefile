#RM = rm ---force

all: Out.txt

Out.txt : main.exe Makefile 
	mono main.exe hello world \
		-input:infile.txt \
		-output:outfile.txt \
		-numbers:1,2,3,4,5,6 1> $@ 2> log < infile.txt
	cat infile.txt | mono main.exe hello world \
		-input:infile.txt \
		-output:outfile.txt \
		-numbers:1,2,3,4,5,6 1>> $@ 2>> log
	cat infile.txt | mono main.exe hello world \
		-input:infile.txt \
		-output:outfile.txt \
		$$(cat numbers.txt) 1>> $@ 2>> log

main.exe : main.cs
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))


numbers.txt : Makefile
	echo "-numbers:7,8,9" > $@


.PHONEY : clean
clean:
	$(RM) *.exe *.dll [Oo]ut* log*

test:
	echo $(RM)
