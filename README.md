# TxtAppender
Small application for making low-friction notes from the command line.
At the moment requires a user to create a batch file to help run from the command line.
Call the batch file and use the filename stem as the only argument
e.g. tx foo
This will open a foo.txt file. The user will see a prompt, each line of input will be appended to the end of the file. 
To exit the application type "quit" or exit", this will exit the  applicaton and close the text file.
The txt file will be in a directory specified in the config file.
A new text file will be created if it did not previouly exist.
The directory will be created if it did not previously exist. If a directory is not specified in the config (with the key "UserDirectory") the save folder will default to "defaultTxtAppender".
This program is for writing new lines to the file only. To read or edit the file open it with your preferred editor.
The program is designed to be a low friction way of taking notes rather than versatile.
