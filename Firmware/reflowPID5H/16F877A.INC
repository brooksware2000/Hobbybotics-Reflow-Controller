;****************************************************************
;*  16F877A.INC                                                 *
;*                                                              *
;*  By        : Leonard Zerman, Jeff Schmoyer                   *
;*  Notice    : Copyright (c) 2003 microEngineering Labs, Inc.  *
;*              All Rights Reserved                             *
;*  Date      : 11/06/03                                        *
;*  Version   : 2.45                                            *
;*  Notes     :                                                 *
;****************************************************************
        NOLIST
    ifdef PM_USED
        LIST
        include 'M16F87xA.INC'  ; PM header
        ;device  pic16F877A, xt_osc, wdt_on, lvp_off, protect_off
        XALL
        NOLIST
    else
        LIST
        LIST p = 16F877A, r = dec, w = -302
        INCLUDE "P16F877A.INC"  ; MPASM  Header
        ;__config _XT_OSC & _WDT_ON & _LVP_OFF & _CP_OFF
        NOLIST
    endif
        LIST
