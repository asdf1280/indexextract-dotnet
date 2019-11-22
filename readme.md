# Minecraft Index Extractor - .NET Version
(Working on .NET Framework 4.7.2+)

This is a beautiful working Minecraft index extract program.

If you use this program, you can easily extract the Minecraft index.
The index is **usually** stored in an `.minecraft/assets/indexes`. This time, it only works in this directory. You may fork my project to improve Indexextract(All helps are welcome!).

You can easily extract the index by using this program.
## How to use this software

> Open the program

> Click <kbd>browse</kbd> button

> Select version from list or browse file.

> Click <kbd>confirm</kbd>

> Click <kbd>start</kbd>

> When it finish. click <kbd>browse</kbd>.

Good job. You're done.

[**Download it NOW!**](https://github.com/dhkim0800/indexextract-dotnet/releases/latest)

## Known issues

You have to install Minecraft, or you will meet **unhandled exceptions!**

Issue 2. It doesn't process with json. So when minecraft json structure change even a little bit, it will not work. But i think it won't.

## Getting indexes from server

The version list file: [launchermeta.mojang.com](https://launchermeta.mojang.com/mc/game/version_manifest.json)
(You may format compressed JSON files [here(jsonformatter.curiousconcept.com)](https://jsonformatter.curiousconcept.com/))

Minecraft resources list mapping file: `{version}.json=>assetIndex=>url`

The formatted resources mapping file looks like the text below:
```json
{

  "objects": {
  
    "realms/lang/de_DE.lang": {
    
      "hash": "10a54fc66c8f479bb65c8d39c3b62265ac82e742",
      
      "size": 8112
      
    }
    
  }
  
}
```
