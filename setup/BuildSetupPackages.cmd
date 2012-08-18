
"c:\Program Files (x86)\BlinkSync\blinksync.exe" -d -xd obj,debug,release,.svn,TestResults -xf release.cmd,*.vshost.*,*.exe.config,*.user,test*.cmd,phatstudio-*.* -xh .. c:\PhatStudioRel

del *src.zip
"d:\Program Files\7zip\7z.exe" a -r PhatStudio-1.11-src.zip c:\PhatStudioRel\*.*

del *.exe
"c:\Program Files (x86)\Inno Setup 5\iscc.exe" PhatStudio.iss