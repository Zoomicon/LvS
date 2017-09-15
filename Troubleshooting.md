*Fix for Office files not opening up inside LvS window*

issue: LvS doesn't open doc, ppt or pdf files embedded in the Packed activity in the text area. The error message is "Type the correct address".

Try this:

* Press the FIX IT button at the following page:

http://support.microsoft.com/?id=927009

then run the program it downloads to fix the issue where Office 2007 documents open outside of the LvS window (fixes the issue with Internet Explorer too which LvS is using internally)

* When you open a LvS activity you may be asked to open or save the file for each file - select open and DO check to not be asked again (since it gets very annoying). Since this "not ask again" will be remembered for IE too, if you want to clear it later on see the following article

http://www.howtogeek.com/howto/windows-vista/reset-opensave-choice-for-internet-explorer-downloads-in-vista/

it has a zip download at the end of the page, can open that zip and run the .reg file it has, replying yes to merge changes in registry. This will reset all remembered "don't ask again for this file" for Open/Save dialog of IE and next time you open such file IE will ask about open/save again

*Fix for PDF files not opening up inside LvS window*

Use Start/All Programs menu from the Windows Taskbar and run Adobe Reader application. Then go to its menu "Edit/Preferences..." and at the dialog that opens up, go to "Internet" and check "Display PDF in browser", then press OK (can then close Adobe Reader).



