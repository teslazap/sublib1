# Introduction #

The Time and Date Subtitle Generator program will generate a subtitle (.mts) file from metadata stored in each frame of a AVCHD (.mts/m2ts) file. The current version allows the user to select a single .mts/m2ts file and generate time/date subtitle file based on the frame specific metadata. It also provides a batch tool to process an entire directory tree of .mts/.m2ts files. The current version also allows for calculating the framerate based on two possible approaches, and allows the user to generate subtitles with time and date, or date only.


# Installation #

There is no installer. Simply uncompress the binaries and run the .exe

  1. Download the latest binary from the "Downloads" section of this project
  1. Extract the .7z file to any convenient location
  1. Run the program by starting SubTitleMaker.exe directly

# Usage #

Usage is straightforward and should be self explanatory. To generate subtitle from a single .mts or .m2ts file do the following:

  1. Click the "Select Movie File" buton.
  1. Select your .mts or .m2ts file. The path will appear in the top box.
  1. Chose the correct Camera type. You need to do this before generating the subtitles. If the subtitle timing is wrong, use the other setting.
  1. Click "Generate Subtitles". The timer beside "Elapsed Time" will begin counting up. Generating subtitles can take some time. For instance, in one test it took 30 seconds to process a 2GB .mts file. This process is limited by harddisk IO, and will go faster with faster harddisks.
  1. The subtitles will appear in the bottom box. Select or deselect "Display Time" depending on if you want to display the time or not.
  1. Click "Save Subtitles". This version does not allow you to overwrite a previous subtitle file.

If you wish to process an entire directory of .mts files, or even an entire directory tree of .mts files, you can use the batch tool. This tool reads all .mts files in a folder, and all subfolders if desired, and generates a .srt file for each .mts file. Usage is also straightforward.

  1. Select "Batch Tool" under the "Tools" Menu.
  1. Click the "Add Directory" button. Navigate to the folder with your .mts files and click OK. You will see the directory appear in the "Directories to Process" list.
  1. Add more directories if you wish.
  1. To remove a directory from the list, simply select it and then click "Remove Directory".
  1. If you wish to recursively process all the subdirectories below each of the folders you add to the list, select "process subdirectories".
  1. If you wish to allow the batch tool to overwrite previous .mts files, select "Overwrite existing files".
  1. If you wish to generate subtitles that display time as well as date, then select "Show time".
  1. You will need to select the proper Camera type. This is the same setting as used with the single file mode described above.
  1. Click "Start". The tool will begin processing your folders and display the results in the "Results Log" list. If you wish to stop the processing, you can click "Stop", but be aware that this will only stop the tool after it has finished processing the current .mts file it is working on.
  1. If you will to save the log of the results, click "Save Log".

# Dumping Metadata to File #

The latest version has a feature to dump all the frame specific metadata to a text file. This is an experimental feature that is still work in progress. Usage is simple:

#Choose "metadata extractor" from the Tools menu
#Select the .mts file you are interested in
#Click "analyze file" - This starts the process of reading the .mts file and extracting the metadata. It may take a while depending on the size of the file. It also might crash until the bugs are worked out
#If the file is read successfully, some information about that video file will be output to the textbox
#After a successful read, click "Save" to store the metadata in a text file.

A text representation of the metadata in each frame of the video file is stored. Currently the output includes:

  1. The frame number
  1. FFMpeg's presentation timestamp (pts)
  1. FFMpeg's decompression timestamp (dts)
  1. FFMPeg's reported position in the file (in bytes, probably)
  1. The metadata itself, in hex representation

Search Google for "EXIFtool", a sophisticated Perl tool for reading metadata. More information about the metatags is available.

For my tool, the metadata itself is read to a C# class that is easy to extend if one wishes a different output format. Feel free to download the source and edit to your wishes, or let me know if you would like other features.



That's about it.