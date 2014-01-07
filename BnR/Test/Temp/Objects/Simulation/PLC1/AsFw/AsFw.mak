$(AS_CPU_PATH)/asfw.br: \
	$(AS_PROJECT_PATH)/Physical/Simulation/Hardware.hc \
	$(AS_INSTALL_PATH)/Upgrades/Modified.txt
	@"$(AS_BIN_PATH)/BR.AS.ConfigurationBuilder.exe"  "$(AS_PROJECT_PATH)/Physical/$(AS_CONFIGURATION)/Hardware.hc" -v V1.00.0 -S PLC1 -o "$(AS_CPU_PATH)/asfw.br" -T SG4 -B V4.00 -P "$(AS_PROJECT_PATH)" -zip -s PLC1 -firmware -secret "$(AS_PROJECT_PATH)_br.as.configurationbuilder.exe"
