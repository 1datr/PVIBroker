Systemkonfiguration
RPS Name..............................@1,33,%s,*@
Prozessortyp..........................@1,11,%s,*@
RPSSW Version.........................@1,22,%s,*@
Pa�wort...............................@1,0,%s,*@
@\MEMPAGE@
______________________________________________________
Speicher
        Basiskonfiguration
		        Anwender RAM
                        Gr��e.........@2,292,%ld Byte,long@
                        Ort...........@2,156,%s,*@
                Remanenter Speicher...
                        Gr��e.........@2,296,%ld Byte,long@
                        Ort...........@2,220,%s,*@
         PV Speicher
                Fl�chtiger Speicher...@2,0,%ld Byte,long@
                Remanenter Speicher...@2,4,%ld Byte,long@
                Permanenter Speicher..@2,12,%ld Byte,long@@\LIST1:0=Nein,1=Ja@

         Kaltstart nach CF/HD Wechsel.@2,308,%LIST1,long@
         �bernahme des permanenten Speichers nach CF/HD Wechsel...@2,312,%LIST1,long@
         �bernahme der nicht fl�chtigen Systemeinstellungen nach CF/HD Wechsel...@2,316,%LIST1,long@
@\MEMPAGEEND@@\FILEPAGE@
______________________________________________________
Filedevices
@\FILELOOP@
         Devicename...................@\FILEDEVNAME@
         Pfad.........................@\FILEDEVPATH@
@\FILELOOPEND@@\FILEPAGEEND@@\MODPAGE@
______________________________________________________
System
        Zyklische Tasks...............@3,4,%ld,long@
        Restzeittasks.................@3,8,%ld,long@
        System Tasks..................@3,12,%ld,long@
        B&R Module....................@3,16,%ld,long@
        PV Tabellen...................@3,20,%ld,long@
        Gr��e User Logger Modul.......@3,36,%ld Byte,long@
	Gr��e System Logger Modul.....@3,40,%ld Byte,long@@\LIST2:0=Nein,1=Ja@


        Profiling deaktiviert.........@3,24,%LIST2,long@
        FTP Server deaktiviert........@3,32,%LIST2,long@
        USB Remote Install aktiviert..@3,44,%LIST2,long@
        CF Remote Install aktiviert...@3,48,%LIST2,long@
@\MODPAGEEND@@\TKPAGE@
______________________________________________________
Taskklassen
        Anzahl der Taskklassen........@\TKCOUNT@
@\TKLOOP@
        Taskklasse @\TKLOOPINDEX@
        Zeitverhalten:
                Zyklusdauer...........@4,0,%f ms,float,a@
                Toleranz..............@4,8,%f ms,float,a@
                Stack.................@4,32,%ld Byte,long,a@
                Priorit�t.............@4,36,%ld,long,a@
                Jitterfrei............@4,40,%LIST2,long,a@
		Mimimale Latenzzeit...@4,44,%LIST2,long,a@
@\TKLOOPEND@@\TKPAGEEND@@\EXCPAGE@
______________________________________________________
EXC Taskklasse
        Konfiguriert..................@\EXCEPTION@
        Stack.........................@\EXCSTACK@
@\EXCPAGEEND@@\TIPAGE@
______________________________________________________
Timing
        Timer Device..................@6,44,%s,*@ 
        Systemtick:...................@6,32,%ld �s,long@
        Zykluszeit TK Restzeit:.......@6,36,%ld �s,long@
        Taskklassenrestzeit:..........@6,40,%ld �s,long@@\LIST3:1=Cyclic #1,2=Cyclic #2,3=Cyclic #3,4=Cyclic #4,5=Cyclic #5,6=Cyclic #6,7=Cyclic #7,8=Cyclic #8@
        Restzeittaskklasse:...........@6,116,%LIST3,long@
@\TIPAGEEND@@\BSPAGE@@\LIST0:1=Warmstart,2=Kaltstart,3=Warmstart/Service,4=Diagnose,5=Warmstart/Service/Error@
______________________________________________________
Betriebssystem
        Kommunikation
           Parallele Verbindungen.....@8,48,%ld,long@@\LIST1:0=Nein,1=Ja@
           Turbomode..................@8,27,%LIST1,byte@
        Hochlaufverhalten
          Hochlauf nach Fehler........@8,24,%LIST0,byte@
          Hochlauf nach Reset.........@8,25,%LIST0,byte@
          Hochlauf nach Powerfail.....@8,26,%LIST0,byte@
@\BSPAGEEND@
Ende

@\LANG001@
System Configuration
PLC Name................................@1,33,%s,*@
Processor Type..........................@1,11,%s,*@
PLC SW Version..........................@1,22,%s,*@
Password................................@1,0,%s,*@
@\MEMPAGE@
______________________________________________________
Memory
        Basic Configuration
		        User RAM
                        Size...............@2,292,%ld bytes,long@
                        Location...........@2,156,%s,*@
                Remanent Memory...
                        Size...............@2,296,%ld bytes,long@
                        Location...........@2,220,%s,*@
         PV Memory
                Nonvolatile Memory.........@2,0,%ld bytes,long@
                Remanent Memory............@2,4,%ld bytes,long@
                Permanent Memory...........@2,12,%ld bytes,long@@\LIST1:0=No,1=Yes@

         Coldstart after CF/HD change.@2,308,%LIST1,long@
         Assume permanent PV memory after CF/HD change...@2,312,%LIST1,long@
         Preserve non volatile system settings after CF/HD change...@2,316,%LIST1,long@
@\MEMPAGEEND@@\FILEPAGE@
______________________________________________________
File Devices
@\FILELOOP@
         Device Name...................@\FILEDEVNAME@
         Path..........................@\FILEDEVPATH@
@\FILELOOPEND@@\FILEPAGEEND@@\MODPAGE@
______________________________________________________
System
        Cyclical Tasks..................@3,4,%ld,long@
        Idle Time Tasks.................@3,8,%ld,long@
        System Tasks....................@3,12,%ld,long@
        B&R Modules.....................@3,16,%ld,long@
        PV Tables.......................@3,20,%ld,long@
        Size of User Logger Module......@3,36,%ld Byte,long@
	Size of system Logger Module....@3,40,%ld Byte,long@@\LIST2:0=Nein,1=Ja@


        Profiling Deactivated...........@3,24,%LIST2,long@
        FTP Server Deactivated..........@3,32,%LIST2,long@
        USB Remote Install activated....@3,44,%LIST2,long@
        CF Remote Install activated.....@3,48,%LIST2,long@
@\MODPAGEEND@@\TKPAGE@
______________________________________________________
Task Classes
        Number of Task Classes........@\TKCOUNT@
@\TKLOOP@
        Task Classes @\TKLOOPINDEX@
        Timing:
                Cycle Time.............@4,0,%f ms,float,a@
                Tolerance..............@4,8,%f ms,float,a@
                Stack..................@4,32,%ld bytes,long,a@
                Priority...............@4,36,%ld,long,a@
                Jitterfree.............@4,40,%LIST2,long,a@
                Mimimal Latency........@4,44,%LIST2,long,a@
@\TKLOOPEND@@\TKPAGEEND@@\EXCPAGE@
______________________________________________________
EXC Task Class
        configured.....................@\EXCEPTION@
        Stack.........................@\EXCSTACK@
@\EXCPAGEEND@@\TIPAGE@
______________________________________________________
Timing
        Timer Device...................@6,44,%s,*@ 
        System Tick:...................@6,32,%ld �s,long@
        Cycle Time TK Idle TIme:.......@6,36,%ld �s,long@
        Task Classes Idle Time:........@6,40,%ld �s,long@@\LIST3:1=Cyclic #1,2=Cyclic #2,3=Cyclic #3,4=Cyclic #4,5=Cyclic #5,6=Cyclic #6,7=Cyclic #7,8=Cyclic #8@
        Idle Time Task Class:..........@6,116,%LIST3,long@
@\TIPAGEEND@@\BSPAGE@@\LIST0:1=Warm Restart,2=Cold Restart,3=Warm Restart/Service,4=Diagnostics,5=Warm Restart/Service/Error@
______________________________________________________
Operating System
        Communication
           Parallel Connections........@8,48,%ld,long@@\LIST1:0=No,1=Yes@
           Turbo Mode..................@8,27,%LIST1,byte@
        Boot Behavior
          Booting after Error..........@8,24,%LIST0,byte@
          Booting after Reset..........@8,25,%LIST0,byte@
          Booting after Power Failure..@8,26,%LIST0,byte@
@\BSPAGEEND@
End

@\LANG033@
Configuration syst�me
Nom d'API...............................@1,33,%s,*@
Type de processeur......................@1,11,%s,*@
Version de SE d'API.....................@1,22,%s,*@
Mot de passe............................@1,0,%s,*@
@\MEMPAGE@
______________________________________________________
M�moire
        Configuration de base
		        RAM utilisateur
                        Taille.............@2,292,%ld octets,long@
                        Emplacement........@2,156,%s,*@
                M�moire r�manente...
                        Taille.............@2,296,%ld octets,long@
                        Emplacement........@2,220,%s,*@
         M�moire des variables de processus
                M�moire volatile...........@2,0,%ld octets,long@
                M�moire r�manente..........@2,4,%ld octets,long@
                M�moire permanente.........@2,12,%ld octets,long@@\LIST1:0=Non,1=Oui@

	 Initialisation totale apr�s changement de Compact Flash/Disque dur.@2,308,%LIST1,long@
         Adopter la m�moire des variables de processus permanente apr�s le changement de CF/HD...@2,312,%LIST1,long@
         Preserve non volatile system settings after CF/HD change...@2,316,%LIST1,long@
@\MEMPAGEEND@@\FILEPAGE@
______________________________________________________
Support de fichiers
@\FILELOOP@
         Nom du support................@\FILEDEVNAME@
         Chemin d'acc�s................@\FILEDEVPATH@
@\FILELOOPEND@@\FILEPAGEEND@@\MODPAGE@
______________________________________________________
Syst�me
        T�ches cycliques................@3,4,%ld,long@
        T�ches de temps d'inactivit�....@3,8,%ld,long@
        T�ches syst�me..................@3,12,%ld,long@
        Modules B&R.....................@3,16,%ld,long@
        Tables de var. de processus.....@3,20,%ld,long@
        Size of User Logger Module......@3,36,%ld Byte,long@
	Size of system Logger Module....@3,40,%ld Byte,long@@\LIST2:0=Non,1=Oui@


        Profilage d�sactiv�.............@3,24,%LIST2,long@
        FTP Server d�sactiv�............@3,32,%LIST2,long@
        USB Remote Install activated....@3,44,%LIST2,long@
        CF Remote Install activated.....@3,48,%LIST2,long@
@\MODPAGEEND@@\TKPAGE@
______________________________________________________
Classes de t�ches
        Nombre de classes de t�ches.....@\TKCOUNT@
@\TKLOOP@
        Classe de t�ches @\TKLOOPINDEX@
        Comportement temporel :
                Temps de cycle.........@4,0,%f ms,float,a@
                Tol�rance..............@4,8,%f ms,float,a@
                Pile...................@4,32,%ld octets,long,a@
                Priorit�...............@4,36,%ld,long,a@
                Jitterfree.............@4,40,%LIST2,long,a@
                Mimimal Latency........@4,44,%LIST2,long,a@
@\TKLOOPEND@@\TKPAGEEND@@\EXCPAGE@
______________________________________________________
Classe de t�ches EXC
        Configur�......................@\EXCEPTION@
        Stack.........................@\EXCSTACK@
@\EXCPAGEEND@@\TIPAGE@
______________________________________________________
Comportement temporel
        Composant timer...........................@6,44,%s,*@ 
        Tic syst�me:..............................@6,32,%ld �s,long@
        Temps de cycle TK Temps d'inactivit�......@6,36,%ld �s,long@
        Temps d'inactivit� de classes de t�ches:..@6,40,%ld �s,long@@\LIST3:1=Cyclique #1,2=Cyclique #2,3=Cyclique #3,4=Cyclique #4,5=Cyclique #5,6=Cyclique #6,7=Cyclique #7,8=Cyclique #8@
        Classe de t�ches Temps d'inactivit�:......@6,116,%LIST3,long@
@\TIPAGEEND@@\BSPAGE@@\LIST0:1=Initialisation,2=Initialisation totale,3=Initialisation/Service,4=Diagnostic,5=Initialisation/Service/Erreur@
______________________________________________________
Syst�me d'exploitation
        Communication
           Liaisons parall�les..........@8,48,%ld,long@@\LIST1:0=Non,1=Oui@
           Mode Turbo...................@8,27,%LIST1,byte@
        Comportement au d�marrage
          D�marrage apr�s erreur........@8,24,%LIST0,byte@
          D�marrage apr�s reset.........@8,25,%LIST0,byte@
          D�marrage apr�s panne secteur.@8,26,%LIST0,byte@
@\BSPAGEEND@
Fin
