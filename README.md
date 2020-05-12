# c4f-sandman
MSDN - Coding 4 Fun - Sandman  \
_Imported from [CodePlex archive](https://archive.codeplex.com/?p=sandman)_

**Project Description**  
Sandman lets you put your computer to sleep (or shutdown/logoff/etc) when windows appear, disappear, or change. For example, you can standby after a "File Copying" or "Downloading..." dialog disappears.  
  

## Introduction

It happens more than I’d like, that I’m performing some long-running task and I’d like to go to bed (usually way too late\!). It might be a large file download, transcoding a long home video file, or defragmenting my hard drive. I feel guilty leaving the computer on all night, but I don’t want to stay up that extra time to shut down or standby at the end. Some software has a checkbox to “Shutdown when complete,” but many applications don’t have that, and I don’t necessarily want to perform a full shutdown anyway.  
  
Once again, out of necessity, I’m writing a small utility to help with some annoyance\! This application lives in the system tray and just waits on the condition that you specify, then performs the specified power management action (shuts down, goes to sleep, hibernates, etc.).  

## How to use Sandman

Run the application and it shows up in your tray. You can either right-click the icon and take immediate actions like logging off or shutting down, or double-click the icon to show the menu options.  
  
![Sandman.png](docs/images/780c1b24-6c7e-49ed-8489-922e6359c7a0
"Sandman.png")  
  
The application has several modes. You can either shutdown based on time, or based on a window. The window conditions include watching for a window with a given title to appear or disappear, or watching a window for the title to contain or not contain a certain string. This can be used to standby after a file copy completes, or a browser download, or a progress dialog from a DVD burner changes from "Burning" to "Complete."  Lots of options\!  

## The Code

This code hasn't been touched (other than minor Visual Studio 2008 upgrade) since its initial release on .NET 2.0. There are many changes to be made, I'm sure, and the interface-based extensibility should really be MEF or some other framework now. I'd love to expand on it when I have time, or work with anyone else interested in digging into it. Just let me know if you want commit access.  
  
-Arian  
  
*This was originally published as part of a [Coding 4 Fun article](https://web.archive.org/web/20100301071540/http://blogs.msdn.com/coding4fun/archive/2006/12/14/1287579.aspx) in 2006 or so*