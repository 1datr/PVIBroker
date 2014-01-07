$(AS_CPU_PATH)/arconfig.br: \
	$(AS_PROJECT_PATH)/physical/$(AS_CONFIGURATION)/$(AS_PLC)/arconfig.rtc \
	$(AS_PROJECT_PATH)/physical/$(AS_CONFIGURATION)/hardware.hc \
	$(AS_PROJECT_PATH)/physical/$(AS_CONFIGURATION)/$(AS_PLC)/sysconf.syc \
	$(AS_PROJECT_PATH)/physical/$(AS_CONFIGURATION)/$(AS_PLC)/iomap.iom 
	@"$(AS_BIN_PATH)/BR.AS.ConfigurationBuilder.exe" "$(AS_PROJECT_PATH)/Physical/$(AS_CONFIGURATION)/$(AS_PLC)/ArConfig.rtc" "$(AS_PROJECT_PATH)/Physical/$(AS_CONFIGURATION)/Hardware.hc" "$(AS_PROJECT_PATH)/Physical/$(AS_CONFIGURATION)/$(AS_PLC)/sysconf.syc" "$(AS_ACTIVE_CONFIG_PATH)/IoMap.iom"  -c Simulation -arconfig -v V1.00.0 -S PLC1 -o "$(AS_CPU_PATH)/arconfig.br" "$(AS_CPU_PATH)/ChannelConfiguration.xml" -T SG4  -B V4.00 -P "$(AS_PROJECT_PATH)" -s PLC1 -secret "$(AS_PROJECT_PATH)_br.as.configurationbuilder.exe"

-include $(AS_CPU_PATH)/Force.mak 
