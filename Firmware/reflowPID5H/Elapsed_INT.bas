'****************************************************************
'*  Name    : Elapsed_INT.bas                                   *
'*  Author  : Darrel Taylor                                     *
'*  Date    : Jan 10, 2006                                      *
'*  Notes   : Must have DT_INTS-??.bas loaded first             *
'****************************************************************

; syntax =     Handler  IntSource,        Label, Type, ResetFlag?
DEFINE  Elapsed_Handler  TMR1_INT,  _ClockCount,  PBP,  yes
; the above define can be used in the INT_LIST macro, if desired (optional)

Ticks    var byte   ' 1/100th of a second
Seconds  var byte
Minutes  var byte
Hours    var byte
Days     var word

SecondsChanged   var bit
MinutesChanged   var bit
HoursChanged     var bit
DaysChanged      var bit
SecondsChanged = 1
MinutesChanged = 1

Goto OverElapsed

' ------------------------------------------------------------------------------
' To calculate a constant for a different crystal frequency - see this web page
' http://www.picbasic.co.uk/forum/showthread.php?t=2031
' ------------------------------------------------------------------------------
Asm
  IF OSC == 4                       ; Constants for 100hz interrupt from Timer1
TimerConst = 0D8F7h                 ; Executed at compile time only
  EndIF
  If OSC == 8
TimerConst = 0B1E7h
  EndIF
  If OSC == 10
TimerConst = 09E5Fh
  EndIF
  If OSC == 16
TimerConst = 063C7h
  EndIF
  If OSC == 20
TimerConst = 03CB7h
  EndIF
  
; -----------------  ADD TimerConst to TMR1H:TMR1L
ADD2_TIMER   macro
    CHK?RP  T1CON
    BCF     T1CON,TMR1ON           ; Turn off timer
    MOVLW   LOW(TimerConst)        ;  1
    ADDWF   TMR1L,F                ;  1    ; reload timer with correct value
    BTFSC   STATUS,C               ;  1/2
    INCF    TMR1H,F                ;  1
    MOVLW   HIGH(TimerConst)       ;  1
    ADDWF   TMR1H,F                ;  1
    endm

; -----------------  ADD TimerConst to TMR1H:TMR1L and restart TIMER1 ----------
RELOAD_TIMER  macro
    ADD2_TIMER
    BSF     T1CON,TMR1ON           ;  1    ; Turn TIMER1 back on
    endm

; -----------------  Load TimerConst into TMR1H:TMR1L --------------------------
LOAD_TIMER  macro
    MOVE?CT  0, T1CON,0
    MOVE?CB  0, TMR1L
    MOVE?CB  0, TMR1H
    ADD2_TIMER
    endm
EndAsm

' ------[ This is the Interrupt Handler ]---------------------------------------
ClockCount:
@ RELOAD_TIMER                    ; Reload TIMER1
    Ticks = Ticks + 1
    if Ticks = 100 then
       Ticks = Ticks-100
       Seconds = Seconds + 1
       SecondsChanged = 1
       if Seconds = 60 then
          Minutes = Minutes + 1
          MinutesChanged = 1
          Seconds = 0
       endif
       if Minutes = 60 then
          Hours = Hours + 1
          HoursChanged = 1
          Minutes = 0
       endif
       if Hours = 24 then
          Days = Days + 1
          DaysChanged = 1
          Hours = 0
       endif
    endif
@ INT_RETURN                      ; Restore context and return from interrupt

'-----====[ END OF TMR1 Interrupt Handler ]====---------------------------------

StartTimer:
    T1CON.1 = 0                   ; (TMR1CS) Select FOSC/4 Clock Source
    T1CON.3 = 0                   ; (T1OSCEN) Disable External Oscillator
    T1CON.0 = 1                   ; (TMR1ON) Start TIMER1
return

; -----------------
StopTimer:
    T1CON.0 = 0                   ; Turn OFF Timer1
return

BitSave  VAR  BIT
; -----------------
ResetTime:
    BitSave = T1CON.0             ; Save TMR1ON bit
@   LOAD_TIMER                    ; Load TimerConst
    T1CON.0 = BitSave             ; Restore TMR1ON bit
    Ticks = 0
    Seconds = 0
    Minutes = 0
    Hours = 0
    Days = 0
    SecondsChanged = 1
    MinutesChanged = 1
    HoursChanged = 1
    DaysChanged = 1
return

OverElapsed:



