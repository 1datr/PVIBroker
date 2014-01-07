(********************************************************************
 * COPYRIGHT --  
 ********************************************************************
 * File: Global.typ
 * Author: anton
 * Created: December 11, 2013
 ********************************************************************
 * Global data types of project test
 ********************************************************************)

TYPE
	gOPCType : 	STRUCT 
		Input : StructInput;
		Output : StructOutput;
	END_STRUCT;
END_TYPE

(*gOPC.Output*)

TYPE
	StructOutput : 	STRUCT 
		Xpos : REAL;
		Ypos : REAL;
		Zpos : REAL;
		load : BOOL;
		DI : BOOL;
		DOutput : BOOL;
		status : UINT;
		drivestatus : UINT;
		driveack : BOOL;
		ack : BOOL;
	END_STRUCT;
END_TYPE

(*gOPC.Input*)

TYPE
	StructInput : 	STRUCT 
		start : BOOL;
		src_cell : USINT;
		dst_cell : USINT;
		command : USINT;
	END_STRUCT;
END_TYPE
