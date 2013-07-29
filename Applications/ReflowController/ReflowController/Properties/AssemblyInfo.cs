using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("ReflowController")]
[assembly: AssemblyDescription("Data access layer for application development information")]

#if DEBUG
    [assembly: AssemblyConfiguration("Development Build")]
#else
    [assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyCompany("Hobbybotics, Inc.")]
[assembly: AssemblyProduct("Reflow Controller")]
[assembly: AssemblyCopyright("Copyright © 2011 Hobbybotics, Inc. All Rights Reserved.")]
[assembly: AssemblyTrademark("Hobbybotics®")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("5fa77a9c-5651-460d-8b7b-0dd49d52f7b2")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("6.0.0.*")]
[assembly: AssemblyFileVersion("6.0.0.0")]
