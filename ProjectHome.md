Created in visual studio express 2010.

This is a small project that generates a subtitle file (.srt) from frame specific metadata in AVCHD (.mts/.m2ts) video files.

The project consists of three parts; a small c library that reads the video file using the FFMPEG libraries, a C# wrapper for the c library, and a windows GUI.