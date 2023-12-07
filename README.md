# TxtAppender
Small application for making low-friction notes from the command line.  
Suggest renaming the compiled .exe file to "tx.exe" or similar. Add the path the program files are in to your system environment variables paths, or save the program files to a folder which already is in the sytem environ variables paths.
You can then call the application from the command line with the stem of the txt filename as the only argument.
e.g. tx foo  
This will open a foo.txt file. The user will see a prompt, each line of input will be appended to the end of the file. 
To exit the application type "quit" or exit", this will exit the  applicaton and close the text file.  
The txt file will be in a directory specified in the txt.config file. Use the format "directoryname" or "basedirectory\middledirectory\topdirectory", the program automatically adds "C:\\".
A new text file will be created if it did not previouly exist.
The directory will be created if it did not previously exist. If a directory is not specified in the config the save folder will default to "baseThoughts".  
This program is for writing new lines to the file only. To read or edit the file open it with your preferred editor.  
The program is designed to be a low friction way of taking notes rather than versatile.
