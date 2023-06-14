# FileWacther Example

Goal is a small tool to monitor a folder (with subfolders) and obtain a list of all files sorted by topic and date.

## Structure

- settings file for path and other stuff
- FileWatcher ...to monitor the folders
- helper to write file-description to a single json-file
- helper to read file-descriptions from single json-file and print to output
- helper uses JSON Serializer/Deserializer
- register to use in terminal ?!