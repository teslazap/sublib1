# Introduction #

Currently this project consists of three parts. The most important is a small c code piece, sublib1, that extracts metadata from h264 files in mts or m2ts containers and returns a subtitle string to code that consumes it.

The second part is SubExtractor. It is a C# wrapper for sublib1 that uses Pinvoke to call sublib1 which returns subtitles from h264/mts files.

The third part is a simple GUI, SubMaker, that provides a trivial interface to the other parts.


# Details #

## Setting up Visual Studio Express to build sublib1 ##

  1. Download the FFMPEG win32 shared and shared-dev from the following locations: http://ffmpeg.arrozcru.org/autobuilds/ffmpeg/mingw32/dev/shared/ffmpeg-r26400-swscale-r32676-mingw32-shared-dev.7z  and  http://ffmpeg.arrozcru.org/autobuilds/ffmpeg/mingw32/shared/ffmpeg-r26400-swscale-r32676-mingw32-shared.7z
  1. Extract the shared.dev file into any location on your HD.
  1. Download the sublib1 source from here. Open the solution file. You will need to edit the properties of the project to find the FFMPEG headers and .lib files that you just extracted.
  1. Right click on **sublib1** in the solution explorer and select **Properties**
  1. Under **Configuration Properties** select **C/C++**
  1. In the right panel you should see a line for **Additional Include Directories**. Select this and then select **edit** from the dropdown.
  1. Find the location of the "include" folder that you extracted from the FFMPEG shared-dev file. That is the location of the FFMPEG headers that you will need to build.
  1. Select "Linker" from the left panel.
  1. In the right panel you should see a line for **Additional Library Directories**. Select this and then select **edit** from the dropdown.
  1. This time navigate to the "lib" directory that you extracted from the FFMPEG shared-dev file. This is the location of the .lib files the visual studio will need to link your project.
  1. Finally, expand the **Linker** section in the left panel and click on **Input**. In the right panel you will see a line for **Additional Dependencies**. Each .lib file that is in the "lib" directory you selected above needs to be entered here. If they aren't already entered, click on this and manually enter each file in the the "lib" directory here (such as "avcodec.lib" ...)
  1. The project should now build without linker errors and produce a .dll file called "sublib1.dll".

## Using the sublib1.dll ##

  1. Extract the FFMPEG shared file to any location on your HD.
  1. Locate the "bin" directory. You will need to place all the .dll files in the "bin" directory along side the sublib1.dll you created above.
  1. For example, in order to run and debug the SubExtractor and SubMaker projects, you will need to place all these .dlls along side your application .exe in either the "debug" or "build" directories.