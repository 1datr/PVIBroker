UnmarkedObjectFolder := C:/Users/anton/Documents/Visual Studio 2010/Projects/PviBroker/BnR/Test/Logical/NewProgram
MarkedObjectFolder := C:/Users/anton/Documents/Visual\ Studio\ 2010/Projects/PviBroker/BnR/Test/Logical/NewProgram

$(AS_CPU_PATH)/NewProgram.br: \
	$(AS_PROJECT_PATH)/Physical/$(AS_CONFIGURATION)/$(AS_PLC)/Cpu.per \
	$(AS_CPU_PATH)/NewProgram/NewProgram.ox
	@"$(AS_BIN_PATH)/BR.AS.TaskBuilder.exe" "$(AS_CPU_PATH)/NewProgram/NewProgram.ox" -o "$(AS_CPU_PATH)/NewProgram.br" -v V1.00.0 -f "$(AS_CPU_PATH)/Global.ofs" -T SG4  -B V4.00 -extConstants -r Cyclic4 -p 2 -s NewProgram -L "AsIecCon: V*, astime: V*, Operator: V*, Runtime: V*" -P "$(AS_PROJECT_PATH)/" -secret "$(AS_PROJECT_PATH)_br.as.taskbuilder.exe"

$(AS_CPU_PATH)/NewProgram/NewProgram.ox: \
	$(AS_CPU_PATH)/NewProgram/a.out
	@"$(AS_BIN_PATH)/BR.AS.Backend.exe" "$(AS_CPU_PATH)/NewProgram/a.out" -o "$(AS_CPU_PATH)/NewProgram/NewProgram.ox" -T SG4 -r Cyclic4   -G V4.1.2  -secret "$(AS_PROJECT_PATH)_br.as.backend.exe"

$(AS_CPU_PATH)/NewProgram/a.out: \
	$(AS_CPU_PATH)/NewProgram/NewProgram.o
	@"$(AS_BIN_PATH)/BR.AS.CCompiler.exe" -link -o "$(AS_CPU_PATH)/NewProgram/a.out" "$(AS_CPU_PATH)/NewProgram/NewProgram.o"  -G V4.1.2  "-Wl,$(AS_PROJECT_PATH)/AS/System/V0400/SG4/libAsIecCon.a" "-Wl,$(AS_PROJECT_PATH)/AS/System/V0400/SG4/libastime.a" "-Wl,$(AS_PROJECT_PATH)/AS/System/V0400/SG4/libOperator.a" "-Wl,$(AS_PROJECT_PATH)/AS/System/V0400/SG4/libRuntime.a" -specs=I386specs -Wl,-q,-T,SG4.x -T SG4  -secret "$(AS_PROJECT_PATH)_br.as.ccompiler.exe"

$(AS_CPU_PATH)/NewProgram/NewProgram.o: \
	$(AS_PROJECT_PATH)/Logical/NewProgram/NewProgram.c \
	$(AS_PROJECT_PATH)/Logical/Global.var \
	$(AS_PROJECT_PATH)/Logical/Global.typ
	@"$(AS_BIN_PATH)/BR.AS.CCompiler.exe" "$(AS_PROJECT_PATH)/Logical/NewProgram/NewProgram.c" -o "$(AS_CPU_PATH)/NewProgram/NewProgram.o"  -T SG4  -B V4.00 -G V4.1.2  -s NewProgram -t "$(AS_TEMP_PATH)" -I "$(AS_PROJECT_PATH)/Logical/NewProgram" "$(AS_TEMP_PATH)/Includes/NewProgram" "$(AS_TEMP_PATH)/Includes" -trigraphs -fno-asm -D _DEFAULT_INCLUDES -D _SG4 -fPIC -O0 -g -nostartfiles -Wall -include "$(AS_CPU_PATH)/Libraries.h" -x c -P "$(AS_PROJECT_PATH)/" -secret "$(AS_PROJECT_PATH)_br.as.ccompiler.exe"

-include $(AS_CPU_PATH)/Force.mak 

