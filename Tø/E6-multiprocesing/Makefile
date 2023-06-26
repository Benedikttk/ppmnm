N = 5e8
TIME = time --portability --append --output $@

All: Out_para.txt Out_main.txt
	cat $<
	cat $<

Out_para.txt: parallel.exe
	$(TIME) mono parallel.exe -to_sum:$N -threads:1 >> $@


Out_main.txt : main.exe
	>$@
	$(TIME) mono main.exe -to_sum:$N -threads:1 >> $@
	$(TIME) mono main.exe -to_sum:$N -threads:2 >> $@
	$(TIME) mono main.exe -to_sum:$N -threads:3 >> $@
	$(TIME) mono main.exe -to_sum:$N -threads:4 >> $@

parallel.exe: parallel.cs
	mcs $<


main.exe : main.cs
	mcs $< -target:exe -out:$@

clean:
	rm -rf *.txt *.exe
