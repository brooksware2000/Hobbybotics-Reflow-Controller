'***************************************************************************
'*  Name    : DT_INTS-14.bas                                               *
'*  Author  : Darrel Taylor                                                *
'*  Version : 1.10 (8/13/2010)                                             *
'*  Date    : OCT 13, 2009                                                 *
'***************************************************************************
'* REV 1.10  Fixes Duplicate label error when Handlers cross page boundary *
'*           Fixes error with 16F1's and MPLAB 8.53 (high)                 *
'* REV 1.00  Completely re-written, with optimization and F1 chips in mind *
'* REV 0.93  Fixed CMIF and EEIF problem with older PIC's                  *
'*           that have the Flags in PIR1 instead of PIR2                   *
'* Rev 0.92  solves a "Missed Interrupt" and                               *
'*           banking switching problem                                     *
'***************************************************************************
DEFINE  DT_INTS_VERSION  110
DEFINE  INTHAND  INT_ENTRY

;-- Place a copy of these variables in your Main program -------------------
;--   The compiler will tell you which lines to un-comment                --
;--   Do Not un-comment these lines                                       --
;---------------------------------------------------------------------------
;wsave   VAR BYTE    $20     SYSTEM      ' location for W if in bank0
;wsave   VAR BYTE    $70     SYSTEM      ' alternate save location for W 
                                         ' if using $70, comment wsave1-3

' --- IF any of these three lines cause an error ?? ------------------------
'       Comment them out to fix the problem ----
' -- Which variables are needed, depends on the Chip you are using -- 
;wsave1  VAR BYTE    $A0     SYSTEM      ' location for W if in bank1
;wsave2  VAR BYTE    $120    SYSTEM      ' location for W if in bank2
;wsave3  VAR BYTE    $1A0    SYSTEM      ' location for W if in bank3
' --------------------------------------------------------------------------

ssave       VAR BYTE    BANK0   SYSTEM      ' location for STATUS register
psave       VAR BYTE    BANK0   SYSTEM      ' location for PCLATH register
fsave       VAR BYTE    BANK0   SYSTEM      ' location for FSR register
RetAddr     VAR WORD    BANK0   
INT_Bits    VAR BYTE    BANK0
  Serviced  VAR INT_Bits.0
  Vars_Saved VAR INT_Bits.1

GIE         VAR INTCON.7 
PEIE        VAR INTCON.6

ASM
  ifdef PM_USED                             ; verify MPASM is the assembler
    "ERROR: DT_INTS does not support the PM assembler, USE MPASM"
  endif

;---------------------------------------------------------------------------
  ifdef ReEnterUsed
    ifdef ReEnterVersion
      if (ReEnterVersion < 34)
        error "Wrong version of ReEnterPBP.bas - Ver 3.4 or higher required
      endif
    else
      error "Wrong version of ReEnterPBP.bas - Ver 3.4 or higher required
    endif
  endif

;---------------------------------------------------------------------------
    if (BANK0_END == 0x7F)
      ifdef BANK1_END
        if (BANK1_END == 0xEF)   ; doesn't find 12F683
          variable ACCESSRAM = 1
        else
          variable ACCESSRAM = 0    
        endif
      else
          variable ACCESSRAM = 0
      endif
    else
      variable ACCESSRAM = 0
    endif
    
;---------------------------------------------------------------------------
#define OrChange Or change to   wsave BYTE $70 SYSTEM
AddWsave macro B
  if (B == 0)
    if (ACCESSRAM == 1)
      error   "                     Add:"       wsave VAR BYTE $70 SYSTEM
    else
      error   "                     Add:"       wsave VAR BYTE $20 SYSTEM
    endif
  endif
  if (B == 1)
    if (ACCESSRAM == 1)
      error   "   Add:"       wsave1 VAR BYTE $A0 SYSTEM, OrChange
    else
      error   "                     Add:"       wsave1 VAR BYTE $A0 SYSTEM
    endif
  endif
  if (B == 2)
    if (ACCESSRAM == 1)
      error   "   Add:"       wsave2 VAR BYTE $120 SYSTEM, OrChange
    else
      error   "                     Add:"       wsave2 VAR BYTE $120 SYSTEM
    endif
  endif
  if (B == 3)
    if (ACCESSRAM == 1)
      error   "   Add:"       wsave3 VAR BYTE $1A0 SYSTEM, OrChange
    else
      error   "                     Add:"       wsave3 VAR BYTE $1A0 SYSTEM
    endif
  endif
  endm
  
#define WsaveE1(B) Chip has RAM in BANK#v(B), but wsave#v(B) was not found.
;#define WsaveE2(B) Uncomment wsave#v(B) in the DT_INTS-14.bas file.
#define WsaveCouldBe This chip has access RAM at $70
  
#define WsaveError(B) error  WsaveE1(B)
  ifndef FSR0L     ; not a 16F1
    ifndef wsave
;      if (ACCESSRAM == 1)
        error wsave variable not found,
        AddWsave(0)
        variable wsave = 0 ; stop further wsave errors
;      else
        
;      endif
    else
      if (wsave == 0x70)
        if (ACCESSRAM == 0)
          error This chip does not have AccessRAM at $70, change to   wsave VAR BYTE $20 SYSTEM
        endif
      else
          if (wsave != 0x20)
            error wsave must be either $20 or $70
          endif
      endif
    endif
    ifdef BANK1_START
      ifndef wsave1
        ifdef wsave
          if (wsave != 0x70)
            WsaveError(1)
            AddWsave(1)
          endif
        else
          if (ACCESSRAM == 1)
            if (wsave != 0x70)
              WsaveCouldBe 
            endif
          endif
        endif
      endif
    endif
    ifdef BANK2_START
      ifndef wsave2
        ifdef wsave
          if (wsave != 0x70)
            WsaveError(2)
            AddWsave(2)
          endif
        endif
      endif
    endif
    ifdef BANK3_START
      ifndef wsave3
        ifdef wsave
          if (wsave != 0x70)
            WsaveError(3)
            AddWsave(3)
          endif
        endif
      endif
    endif
  
        
  endif
ENDASM

ASM
asm = 0
Asm = 0
ASM = 0
pbp = 1
Pbp = 1
PBP = 1
yes = 1
Yes = 1
YES = 1
no  = 0
No  = 0
NO  = 0


  #define ALL_INT      INTCON,GIE, INTCON,GIE      ;-- Global Interrupts   *
  #define T1GATE_INT   PIR1,TMR1GIF, PIE1,TMR1GIE  ;-- Timer1 Gate         *
  #define INT_INT      INTCON,INTF,  INTCON,INTE   ;-- External INT
  #define GPC_INT      INTCON,GPIF,  INTCON,GPIE   ;-- GPIO Int On Change  *
  #define IOC_INT      INTCON,IOCIF, INTCON,IOCIE  ;-- Int On Change       *
  #define RAC_INT      INTCON,RAIF,  INTCON,RAIE   ;-- RA Port Change      *
  #define RBC_INT      INTCON,RBIF,  INTCON,RBIE   ;-- RB Port Change
  #define RABC_INT     INTCON,RABIF, INTCON,RABIE  ;-- RAB Port Change     *
  ifdef T0IF
    #define TMR0_INT   INTCON,T0IF, INTCON,T0IE    ;-- TMR0 Overflow
  else
    ifdef TMR0IF
      #define TMR0_INT INTCON,TMR0IF, INTCON,TMR0IE ;-- TMR0 alternate sym
    endif
  endif
  ifdef TMR1IF
    #define TMR1_INT   PIR1,TMR1IF, PIE1,TMR1IE    ;-- TMR1 Overflow
  else
    ifdef T1IF
      #define TMR1_INT PIR1,T1IF, PIE1,T1IE        ;-- TMR1 alternate sym
    endif
  endif
  ifdef TMR2IF
    #define TMR2_INT   PIR1,TMR2IF, PIE1,TMR2IE    ;-- TMR2 - PR2 Match 
  else
    #define TMR2_INT   PIR1,T2IF, PIE1,T2IE        ;-- TMR2 - PR2 Match alt
  endif
  #define TMR4_INT     PIR3,TMR4IF, PIE3,TMR4IE    ;-- TMR4 - PR4 Match    *
  #define TMR6_INT     PIR3,TMR6IF, PIE3,TMR6IE    ;-- TMR6 - PR6 Match    *
  #define TX_INT       PIR1,TXIF, PIE1,TXIE        ;-- USART Transmit 
  #define RX_INT       PIR1,RCIF, PIE1,RCIE        ;-- USART Receive 

  #define PSP_INT      PIR1,PSPIF, PIE1,PSPIE      ;-- Parallel Slave Port
  #define AD_INT       PIR1,ADIF, PIE1,ADIE        ;-- A/D Converter 

  ifdef SSPIF
    #define SSP_INT    PIR1,SSPIF, PIE1,SSPIE      ;-- (M)SSP module
    #define BUS_INT    PIR2,BCLIF, PIE2,BCLIE      ;-- Bus Collision 
  else
    ifdef SSP1IF
      #define SSP_INT  PIR1,SSP1IF, PIE1,SSP1IE    ;-- (M)SSP module 1     *
      #define SSP1_INT PIR1,SSP1IF, PIE1,SSP1IE    ;                       *
      #define BUS_INT  PIR2,BCL1IF, PIE2,BCL1IE    ;-- Bus Collision 1     *
      #define BUS1_INT PIR2,BCL1IF, PIE2,BCL1IE    ;                       *
    endif
    ifdef SSP2IF
      #define SSP2_INT PIR4,SSP2IF, PIE4,SSP2IE    ;-- (M)SSP module 2     *
      #define BUS2_INT PIR4,BCL2IF, PIE4,BCL2IE    ;-- Bus Collision 2     *
    endif
  endif      
  #define CCP1_INT     PIR1,CCP1IF, PIE1,CCP1IE    ;-- CCP1 
  #define CCP2_INT     PIR2,CCP2IF, PIE2,CCP2IE    ;-- CCP2 
  #define CCP3_INT     PIR3,CCP3IF, PIE3,CCP3IE    ;-- CCP3                *
  #define CCP4_INT     PIR3,CCP4IF, PIE3,CCP4IE    ;-- CCP4                *
  #define CCP5_INT     PIR3,CCP5IF, PIE3,CCP5IE    ;-- CCP5                *

  ifdef CMIF
    ifdef PIR2
      #define CMP_INT  PIR2,CMIF, PIE2,CMIE        ;-- Comparator
    else
      #define CMP_INT  PIR1,CMIF, PIE1,CMIE
    endif
  else
    ifdef C1IF
      #define CMP_INT  PIR2,C1IF, PIE2,C1IE        ;-- Comparator 1        *
      #define CMP1_INT PIR2,C1IF, PIE2,C1IE        ;-- Comparator 1        *
    endif
    ifdef C2IF
      #define CMP2_INT PIR2,C2IF, PIE2,C2IE        ;-- Comparator 2        *
    endif
  endif
   
  ifndef PIR2
    #define EE_INT     PIR1,EEIF, PIE1,EEIE
    #define OSCF_INT   PIR1,OSFIF, PIE1,OSFIE      ;-- OSC Fail if no PIR2 *
    #define LVD_INT    PIR1,LVDIF, PIE1,LVDIE      ;-- Low-Voltage Detect  *
  else
    #define EE_INT     PIR2,EEIF, PIE2,EEIE        ;-- EEPROM/FLASH Write
    #define OSCF_INT   PIR2,OSFIF, PIE2,OSFIE      ;-- OSC Fail            *
    #define LVD_INT    PIR2,LVDIF, PIE2,LVDIE      ;-- Low-Voltage Detect  *
  endif
  
  #define LCD_INT      PIR2,LCDIF, PIE2,LCDIE      ;-- LCD controller      *
  #define CRYPT_INT    PIR1,CRIF, PIE1,CRIE        ;-- KeeLoq Cryptographic*
  #define USB_INT      PIR1,USBIF, PIE1,USBIE      ;-- USB 16C745/765 only *
ENDASM


ASM
;---[Returns the Address of a Label as a Word]------------------------------
GetAddress macro Label, Wout
    CHK?RP Wout
    movlw low Label          ; get low byte
    movwf Wout
;    movlw High Label         ; get high byte  MPLAB 8.53 killed high
    movlw Label >> 8         ; get high byte
    movwf Wout + 1
  endm

;---[find correct bank for a BIT variable]----------------------------------
CHKRP?T  macro reg, bit
    CHK?RP  reg
  endm
    
;---[This creates the main Interrupt Service Routine (ISR)]-----------------
INT_CREATE  macro
  local OverCREATE
    L?GOTO OverCREATE

INT_ENTRY
    ifndef FSR0L  
      if (CODE_SIZE <= 2)
          movwf   wsave       ; 1 copy W to wsave register
          swapf   STATUS,W    ; 2 swap status reg to be saved into W
          clrf    STATUS      ; 3 change to bank 0
          movwf   ssave       ; 4 save status reg to a bank 0 register
          movf    PCLATH,W    ; 5 move PCLATH reg to be saved into W reg
          movwf   psave       ; 6 save PCLATH reg to a bank 0 register
      endIF
      movf      FSR,W         ; 7 move FSR reg to be saved into W reg
      movwf     fsave         ; 8 save FSR reg to a bank 0 register
    else
      banksel 0               ; BANK 0 for F1 chips
    endif  
    variable  PREV_BANK = 0
    MOVE?CT  0, _Vars_Saved
    
List_Start
    ifdef LoopWhenServiced
      MOVE?CT  0, _Serviced   ; indicate nothing has been serviced
    endif

    INT_LIST                  ; Expand the users list of interrupt handlers
                            ; INT_LIST macro must be defined in main program
    
    ifdef LoopWhenServiced
      BIT?GOTO  1, _Serviced, List_Start
    endif

    ifdef ReEnterUsed         ; if ReEnterPBP.bas was included
        CHKRP?T  _Vars_Saved
        btfss    _Vars_Saved  ; if PBP system vars have been saved 
        goto     INT_EXIT
        L?GOTO   _RestorePBP  ; Restore PBP system Vars
    endif
    
INT_EXIT
    variable  PREV_BANK = 0
    ifndef FSR0L              ; if chip is not an F1 - restore context
      clrf    STATUS          ; BANK 0
      movf    fsave,W         ; Restore the FSR reg
      movwf   FSR
      movf    psave,w         ; Restore the PCLATH reg
      movwf   PCLATH
      swapf   ssave,w         ; Restore the STATUS reg
      movwf   STATUS
      swapf   wsave,f
      swapf   wsave,w         ; Restore W reg
    endif
    retfie                    ; Exit the interrupt routine
;-----------------------------
  LABEL?L OverCREATE
    bsf      INTCON, 6      ; Enable Peripheral interrupts
    bsf      INTCON, 7      ; Enable Global interrupts
    endm
    
ENDASM

ASM
;---[Add an Interrupt Source to the user's list of INT Handlers]------------
#INT_HANDLER  macro  FlagReg,FlagBit, EnableReg,EnableBit, Label, Type,Reset
  list
    local AfterSave, AfterUserRoutine, NoInt
      ifdef FlagBit
        CHK?RP   EnableReg
        btfss    EnableReg, EnableBit        ; if the INT is enabled
        goto     NoInt
        CHK?RP   FlagReg                    
        btfss    FlagReg, FlagBit            ; and the Flag set?
        goto     NoInt
        ifdef LoopWhenServiced
          MOVE?CT  1, _Serviced
        endif
            
        if (Type == PBP)                     ; If INT handler is PBP
          ifdef ReEnterUsed
            btfsc  _Vars_Saved
            goto   AfterSave
            GetAddress  AfterSave, _RetAddr  
            L?GOTO  _SavePBP                 ; Save PBP system Vars
            LABEL?L  AfterSave
          else
            error ReEnterPBP must be INCLUDEd to use PBP type interrupts
          endif
        endif
        GetAddress  AfterUserRoutine, _RetAddr   ; save return address
        L?GOTO   Label                       ; goto the users INT handler
        LABEL?L AfterUserRoutine

        if (Reset == YES)
          CHK?RP   FlagReg
          bcf      FlagReg, FlagBit        ; reset flag (if specified)
        endif
      else
        INT_ERROR  "INT_Handler"
      endif
NoInt
      banksel  0
PREV_BANK = 0        
    endm
;-----------------------------------
#define INT_HANDLER(FlagReg,FlagBit, EnableReg,EnableBit, Label, Type,Reset)  #INT_HANDLER FlagReg,FlagBit, EnableReg,EnableBit, Label, Type,Reset
  ifndef INT_Handler
#define INT_Handler(FlagReg,FlagBit, EnableReg,EnableBit, Label, Type,Reset)  #INT_HANDLER FlagReg,FlagBit, EnableReg,EnableBit, Label, Type,Reset
#define int_handler(FlagReg,FlagBit, EnableReg,EnableBit, Label, Type,Reset)  #INT_HANDLER FlagReg,FlagBit, EnableReg,EnableBit, Label, Type,Reset
#define Int_Handler(FlagReg,FlagBit, EnableReg,EnableBit, Label, Type,Reset)  #INT_HANDLER FlagReg,FlagBit, EnableReg,EnableBit, Label, Type,Reset
#define Int_handler(FlagReg,FlagBit, EnableReg,EnableBit, Label, Type,Reset)  #INT_HANDLER FlagReg,FlagBit, EnableReg,EnableBit, Label, Type,Reset
#define int_Handler(FlagReg,FlagBit, EnableReg,EnableBit, Label, Type,Reset)  #INT_HANDLER FlagReg,FlagBit, EnableReg,EnableBit, Label, Type,Reset
  endif
  
;---[Returns from a "goto" subroutine]--------(RetAddr must be set first)---
#INT_RETURN  macro
      CHK?RP  _RetAddr
      movf    _RetAddr + 1, W  ; Set PCLATH with top byte of return address
      movwf   PCLATH
      movf    _RetAddr, W      ; Go back to where we were
      movwf   PCL
    endm    
;_____________________________
#define INT_RETURN  #INT_RETURN
  ifndef INT_Return
#define INT_Return  #INT_RETURN 
#define int_return  #INT_RETURN 
#define Int_Return  #INT_RETURN 
#define Int_return  #INT_RETURN 
#define int_Return  #INT_RETURN 
  endif

;----[Display not found error]----------------------------------------------
INT_ERROR macro From
    error From -  Interrupt Flag ( FlagReg,FlagBit ) not found.
  endm

;---[Enable an interrupt source]--------------------------------------------
  ifndef INT_ENABLECLEARFIRST
    #define INT_ENABLECLEARFIRST 1             ; default to Clear First
  endif          ; use DEFINE INT_ENABLECLEARFIRST 0 to NOT clear First
  
#INT_ENABLE  macro  FlagReg, FlagBit, EnableReg, EnableBit
      ifdef FlagBit
        ifdef INT_ENABLECLEARFIRST
          if (INT_ENABLECLEARFIRST == 1)       ; if specified
            MOVE?CT 0, FlagReg, FlagBit        ;   clear the flag first
          endif
        endif
        MOVE?CT  1, EnableReg, EnableBit       ; enable the INT source
      else
        INT_ERROR  "INT_ENABLE"
      endif
    endm    
;_____________________________
#define INT_ENABLE(FlagReg, FlagBit, EnableReg, EnableBit)  #INT_ENABLE FlagReg, FlagBit, EnableReg, EnableBit
  ifndef INT_Enable
#define INT_Enable(FlagReg, FlagBit, EnableReg, EnableBit)  #INT_ENABLE FlagReg, FlagBit, EnableReg, EnableBit
#define int_enable(FlagReg, FlagBit, EnableReg, EnableBit)  #INT_ENABLE FlagReg, FlagBit, EnableReg, EnableBit
#define Int_Enable(FlagReg, FlagBit, EnableReg, EnableBit)  #INT_ENABLE FlagReg, FlagBit, EnableReg, EnableBit
#define Int_enable(FlagReg, FlagBit, EnableReg, EnableBit)  #INT_ENABLE FlagReg, FlagBit, EnableReg, EnableBit
#define int_Enable(FlagReg, FlagBit, EnableReg, EnableBit)  #INT_ENABLE FlagReg, FlagBit, EnableReg, EnableBit
  endif

;---[Disable an interrupt source]-------------------------------------------
#INT_DISABLE  macro  FlagReg, FlagBit, EnableReg, EnableBit
      ifdef FlagBit
        MOVE?CT  0, EnableReg, EnableBit       ; disable the INT source  
      else
        INT_ERROR  "INT_DISABLE"
      endif
    endm    
;_____________________________
#define INT_DISABLE(FlagReg, FlagBit, EnableReg, EnableBit)  #INT_DISABLE FlagReg, FlagBit, EnableReg, EnableBit
  ifndef INT_Disable
#define INT_Disable(FlagReg, FlagBit, EnableReg, EnableBit)  #INT_DISABLE FlagReg, FlagBit, EnableReg, EnableBit
#define int_disable(FlagReg, FlagBit, EnableReg, EnableBit)  #INT_DISABLE FlagReg, FlagBit, EnableReg, EnableBit
#define Int_Disable(FlagReg, FlagBit, EnableReg, EnableBit)  #INT_DISABLE FlagReg, FlagBit, EnableReg, EnableBit
#define Int_disable(FlagReg, FlagBit, EnableReg, EnableBit)  #INT_DISABLE FlagReg, FlagBit, EnableReg, EnableBit
#define int_Disable(FlagReg, FlagBit, EnableReg, EnableBit)  #INT_DISABLE FlagReg, FlagBit, EnableReg, EnableBit
  endif

;---[Clear an interrupt Flag]-----------------------------------------------
#INT_CLEAR  macro  FlagReg, FlagBit, EnableReg, EnableBit
      ifdef FlagBit
        MOVE?CT  0, FlagReg, FlagBit           ; clear the flag
      else
        INT_ERROR "INT_CLEAR" 
      endif
    endm
;_____________________________
#define INT_CLEAR(FlagReg, FlagBit, EnableReg, EnableBit)  #INT_CLEAR FlagReg, FlagBit, EnableReg, EnableBit
  ifndef INT_Clear
#define INT_Clear(FlagReg, FlagBit, EnableReg, EnableBit)  #INT_CLEAR FlagReg, FlagBit, EnableReg, EnableBit
#define int_clear(FlagReg, FlagBit, EnableReg, EnableBit)  #INT_CLEAR FlagReg, FlagBit, EnableReg, EnableBit
#define Int_Clear(FlagReg, FlagBit, EnableReg, EnableBit)  #INT_CLEAR FlagReg, FlagBit, EnableReg, EnableBit
#define Int_clear(FlagReg, FlagBit, EnableReg, EnableBit)  #INT_CLEAR FlagReg, FlagBit, EnableReg, EnableBit
#define int_Clear(FlagReg, FlagBit, EnableReg, EnableBit)  #INT_CLEAR FlagReg, FlagBit, EnableReg, EnableBit
  endif
ENDASM


