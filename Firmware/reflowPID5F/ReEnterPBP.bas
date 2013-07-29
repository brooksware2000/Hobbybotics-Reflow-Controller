'***************************************************************************
'*  Name    : ReEnterPBP.pbp                                               *
'*  Author  : Darrel Taylor                                                *
'*  Version : 3.4  (8/13/2010)                                             *
'*  Notes   : Allows re-entry to PBP from an ASM interrupt                 *
'*          : Must have DT_INTS-14.bas loaded first                        *
'***************************************************************************
'*  ver 3.4 (8/13/2010)                                                    *
'*           Changed Restore to use 1 less stack level                     * 
'*  ver 3.3 (1/16/2010)                                                    *
'*           compatability with PIC16F1 chips                              *
'*  ver 3.2 
'*           Bug Fix, RS1/RS2 were being restored incorrectly              *
'***************************************************************************
MaxTvars    CON 4

DEFINE   ReEnterUsed  1
DEFINE   ReEnterVersion 34  
  
goto OverReEnter
   
' Save locations for PBP system Vars
R0_Save     VAR WORD ;BANK0 SYSTEM
R1_Save     VAR WORD ;BANK0 SYSTEM
R2_Save     VAR WORD ;BANK0 SYSTEM
R3_Save     VAR WORD ;BANK0 SYSTEM
R4_Save     VAR WORD ;BANK0 SYSTEM
R5_Save     VAR WORD ;BANK0 SYSTEM
R6_Save     VAR WORD ;BANK0 SYSTEM
R7_Save     VAR WORD ;BANK0 SYSTEM
R8_Save     VAR WORD ;BANK0 SYSTEM
Flags_Save  VAR BYTE ;BANK0 SYSTEM
GOP_Save    VAR BYTE ;BANK0 SYSTEM
RM1_Save    VAR BYTE ;BANK0 SYSTEM
RM2_Save    VAR BYTE ;BANK0 SYSTEM
RR1_Save    VAR BYTE ;BANK0 SYSTEM
RR2_Save    VAR BYTE ;BANK0 SYSTEM
RS1_Save    VAR BYTE ;BANK0 SYSTEM
RS2_Save    VAR BYTE ;BANK0 SYSTEM

TsaveVars   VAR WORD[MaxTvars]

ASM
ChkTvar   macro Name, LastTvar
    ifdef Name
      error Temp variables exceeding LastTvar "Increase the MaxTvars constant"
    endif
  endm
  
SaveTvar  macro Name, Svar
    ifdef Name
        MOVE?WW  Name, Svar
    endif
  endm

RestTvar  macro Name, Svar
    ifdef Name
        MOVE?WW  Svar, Name
    endif
  endm
ENDASM
   
SavePBP:                ' Save all PBP system Vars
    R0_Save = R0        '  4/ 4
    R1_Save = R1        '  4/ 8
    R2_Save = R2        '  4/12
    R3_Save = R3        '  4/16
    R4_Save = R4        '  4/20
    R5_Save = R5        '  4/24
    R6_Save = R6        '  4/28
    R7_Save = R7        '  4/32
    R8_Save = R8        '  4/36
    Flags_Save = FLAGS  '  2/38
    GOP_Save = GOP      '  2/40
    RM1_Save = RM1      '  2/42
    RM2_Save = RM2      '  2/44
    RR1_Save = RR1      '  2/46
    RR2_Save = RR2      '  2/48
    ASM
        ifdef RS1
            MOVE?BB    RS1, _RS1_Save    ; 2/50
        endif
        ifdef RS2
            MOVE?BB    RS2, _RS2_Save    ; 2/52
        endif

        variable Tcount = 1              ; 4 per Tvar
        while (Tcount <= _MaxTvars)
          SaveTvar T#v(Tcount), _TsaveVars + ((Tcount-1) << 1)
          variable Tcount = Tcount + 1
        endw
        ChkTvar  T#v(Tcount), T#v(Tcount-1)
    ENDASM   

    Vars_Saved = 1
@ INT_RETURN

RestorePBP:
    R0 = R0_Save
    R1 = R1_Save
    R2 = R2_Save
    R3 = R3_Save
    R4 = R4_Save
    R5 = R5_Save
    R6 = R6_Save
    R7 = R7_Save
    R8 = R8_Save
    FLAGS = Flags_Save
    GOP = GOP_Save
    RM1 = RM1_Save
    RM2 = RM2_Save
    RR1 = RR1_Save
    RR2 = RR2_Save
    ASM
        ifdef RS1
            MOVE?BB     _RS1_Save, RS1
        endif
        ifdef RS2
            MOVE?BB     _RS2_Save, RS2
        endif
        
        variable Tcount = 1                ; restore Temp vars
        while (Tcount <= _MaxTvars)
          RestTvar T#v(Tcount), _TsaveVars + ((Tcount-1) << 1)
          variable Tcount = Tcount + 1
        endw
    ENDASM   
   Vars_Saved = 0
@  L?GOTO INT_EXIT
;RETURN

OverReEnter:
