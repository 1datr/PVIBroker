/* Automation Studio generated header file */
/* Do not edit ! */

#ifndef _BUR_1387053737_1_
#define _BUR_1387053737_1_

#include <bur/plctypes.h>

/* Datatypes and datatypes of function blocks */
typedef struct StructInput
{	plcbit start;
	unsigned char src_cell;
	unsigned char dst_cell;
	unsigned char command;
} StructInput;

typedef struct StructOutput
{	float Xpos;
	float Ypos;
	float Zpos;
	plcbit load;
	plcbit DI;
	plcbit DOutput;
	unsigned short status;
	unsigned short drivestatus;
	plcbit driveack;
	plcbit ack;
} StructOutput;

typedef struct gOPCType
{	struct StructInput Input;
	struct StructOutput Output;
} gOPCType;






__asm__(".section \".plc\"");

/* Used IEC files */
__asm__(".ascii \"iecfile \\\"Logical/Global.typ\\\" scope \\\"global\\\"\\n\"");

/* Exported library functions and function blocks */

__asm__(".previous");


#endif /* _BUR_1387053737_1_ */

