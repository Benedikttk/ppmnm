N = 1e9
all : Out_main.txt Out_parallel.txt
TIME = time --portability --append --output $@

Out_main.txt : main.exe
	>$@
	$(TIME) mono main.exe -terms:$N -threads:1 >> $@
	$(TIME) mono main.exe -terms:$N -threads:2 >> $@
	$(TIME) mono main.exe -terms:$N -threads:3 >> $@
	$(TIME) mono main.exe -terms:$N -threads:4 >> $@

main.exe : main.cs
	mcs $<

Out_parallel.txt : parallel.cs
	>$@
	$(TIME) mono parallel.exe -sum:$N -threads:1 >> $@

parallel.exe : parallel.cs
	mcs $$<


clean: 
	rm -rf *[Oo]ut *.exe *.txt
