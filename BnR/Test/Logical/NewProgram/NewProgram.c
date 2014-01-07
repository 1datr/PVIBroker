/********************************************************************
 * COPYRIGHT --  
 ********************************************************************
 * Program: NewProgram
 * File: NewProgram.c
 * Author: anton
 * Created: December 11, 2013
 ********************************************************************
 * Implementation of program NewProgram
 ********************************************************************/

#include <bur/plctypes.h>

#ifdef _DEFAULT_INCLUDES
	#include <AsDefault.h>
#endif

void _INIT NewProgramINIT(void)
{
	/* TODO: Add code here */
	gOPC.Input.command=0;
	gOPC.Input.dst_cell=0;
	gOPC.Input.src_cell=0;
	gOPC.Input.start=0;
	
	gOPC.Output.ack=0;
	gOPC.Output.DI=0;
	gOPC.Output.DOutput=0;
	gOPC.Output.driveack=0;
	gOPC.Output.drivestatus=0;
	gOPC.Output.load=0;
	gOPC.Output.status=0;
	gOPC.Output.Xpos=0;
	gOPC.Output.Ypos=0;
	gOPC.Output.Zpos=0;
}

void _CYCLIC NewProgramCYCLIC(void)
{
	/* TODO: Add code here */
	gOPC.Output.Xpos = gOPC.Output.Xpos+0.1;
	if(gOPC.Output.Xpos>200) gOPC.Output.Xpos=0;
	
}
