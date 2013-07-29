The application uses specific fonts that need to be installed in order for text to appear correctly.
These fonts can be found in the "Fonts" folder.

The project makes use of three class libraries that have been compiled into DLL files.  These are:

- DS1307Lib: Interface class to setup a DS1307 RTC (This class has not been tested or debugged)
- FileLib:   Class for file and *.ini
- SerialLib: Class for controller functionality.  Allows Reflow board to be controlled through a serial connection

this project also makes use of the ZedGraph control.  This control is already contained as part of the project and
provides easy functionality for a graphing reflow sessions.  I do not believe the author supports this control any
longer however, it is still available on the web.