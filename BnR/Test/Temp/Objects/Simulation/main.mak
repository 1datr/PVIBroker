CYGWIN=nontsec
export PATH := C:\Windows\system32;C:\Windows;C:\Windows\System32\Wbem;C:\Windows\System32\WindowsPowerShell\v1.0\;C:\Program Files (x86)\Microsoft SQL Server\100\Tools\Binn\;C:\Program Files\Microsoft SQL Server\100\Tools\Binn\;C:\Program Files\Microsoft SQL Server\100\DTS\Binn\;C:\Program Files (x86)\Git\cmd;C:\Program Files (x86)\GtkSharp\2.12\bin;C:\Program Files (x86)\Microsoft SQL Server\100\Tools\Binn\VSShell\Common7\IDE\;C:\Program Files (x86)\Microsoft SQL Server\100\DTS\Binn\;C:\Program Files (x86)\Common Files\Hilscher GmbH\TLRDecode;C:\ProgramData\Drush\;C:\Program Files (x86)\Drush\GnuWin32\bin;C:\Program Files (x86)\Drush\Php;C:\Program Files (x86)\Common Files\Hilscher GmbH\TLRDecode;C:\ProgramData\Drush\;C:\Program Files (x86)\Drush\GnuWin32\bin;C:\Program Files (x86)\Drush\Php
export AS_COMPANY_NAME :=  
export AS_USER_NAME := anton
export AS_PATH := C:/BrAutomation/AS30090
export AS_BIN_PATH := C:/BrAutomation/AS30090/bin-en
export AS_PROJECT_PATH := C:/Users/anton/Documents/Visual\ Studio\ 2010/Projects/PviBroker/BnR/Test
export AS_PROJECT_NAME := Test
export AS_SYSTEM_PATH := C:/BrAutomation/AS/System
export AS_VC_PATH := C:/BrAutomation/AS30090/AS/VC
export AS_TEMP_PATH := C:/Users/anton/Documents/Visual\ Studio\ 2010/Projects/PviBroker/BnR/Test/Temp
export AS_CONFIGURATION := Simulation
export AS_BINARIES_PATH := C:/Users/anton/Documents/Visual\ Studio\ 2010/Projects/PviBroker/BnR/Test/Binaries
export AS_GNU_INST_PATH := C:/BrAutomation/AS30090/AS/GnuInst/V4.1.2
export AS_GNU_BIN_PATH := $(AS_GNU_INST_PATH)/bin
export AS_GNU_INST_PATH_SUB_MAKE := C:/BrAutomation/AS30090/AS/GnuInst/V4.1.2
export AS_GNU_BIN_PATH_SUB_MAKE := $(AS_GNU_INST_PATH_SUB_MAKE)/bin
export AS_INSTALL_PATH := C:/BrAutomation/AS30090
export WIN32_AS_PATH := C:\\BrAutomation\\AS30090
export WIN32_AS_BIN_PATH := C:\\BrAutomation\\AS30090\\bin-en
export WIN32_AS_PROJECT_PATH := C:\\Users\\anton\\Documents\\Visual Studio 2010\\Projects\\PviBroker\\BnR\\Test
export WIN32_AS_SYSTEM_PATH := C:\\BrAutomation\\AS\\System
export WIN32_AS_VC_PATH := C:\\BrAutomation\\AS30090\\AS\\VC
export WIN32_AS_TEMP_PATH := C:\\Users\\anton\\Documents\\Visual Studio 2010\\Projects\\PviBroker\\BnR\\Test\\Temp
export WIN32_AS_BINARIES_PATH := C:\\Users\\anton\\Documents\\Visual Studio 2010\\Projects\\PviBroker\\BnR\\Test\\Binaries
export WIN32_AS_GNU_INST_PATH := C:\\BrAutomation\\AS30090\\AS\\GnuInst\\V4.1.2
export WIN32_AS_GNU_BIN_PATH := $(WIN32_AS_GNU_INST_PATH)\\bin
export WIN32_AS_INSTALL_PATH := C:\\BrAutomation\\AS30090

.suffixes:

ProjectMakeFile:

	@"$(AS_BIN_PATH)/BR.AS.AnalyseProject.exe" "$(AS_PROJECT_PATH)/Test.apj" -t "$(AS_TEMP_PATH)" -c "$(AS_CONFIGURATION)" -o "$(AS_BINARIES_PATH)"   -sfas -buildMode "Build"

	@$(AS_GNU_BIN_PATH)/mingw32-make.exe -r -f 'C:/Users/anton/Documents/Visual Studio 2010/Projects/PviBroker/BnR/Test/Temp/Objects/$(AS_CONFIGURATION)/PLC1/#cpu.mak' -k

