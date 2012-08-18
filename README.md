PhatStudio 2012
===============

This is a fork of the original PhatStudio open source project found here: (http://phatstudio.sourceforge.net/).  I'm not sure if the project is still active or not, but the installer does not install the add-in for Visual Studio 2012.  This fork is meant to address that.

Installation
------------
I have included the 1.0.11 version of PhatStudio as a download which will now install itself for Visual Studio 2012 (in addition to previous versions)

Build it yourself
-----------------
As I discovered there are a few dependencies if you want to build the MSI installer yourself.  You'll need to download [Blinksync](http://blinksync.sourceforge.net/) as well as [Inno](http://www.jrsoftware.org/isinfo.php/).  The `/setup` folder contains the `phatstudio.iss` file.  You may need to modify the `BuildSetupPackages.cmd` file as well, depending on where you install the dependencies.

License
-------

I guess the original version is GPL.  I'm not sure what that means in terms of my obligations.  Hopefully having the source here is sufficient.  I believe the GPL license is viral so I presume this fork is also GPL?  If not, do whatever you want with it :)

