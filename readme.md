# Minecraft Index Extractor - VB.NET Version
(Working on .NET Framework 4.7.1+)

This is an beautiful working Minecraft index extract program.

If you are using this program, you can easily extract the Minecraft index.
The index is **usually** stored in an `.minecraft/assets/indexes`. This time, it only work in this directory. Please fork my project and improve it!

You can easily extract the index would use this program.
## How to use this software

> Open the program

> Click <kbd>browse</kbd> button

> Select version from list or browse file.

> Click <kbd>confirm</kbd>

> Click <kbd>start</kbd>

> When it finish. click <kbd>browse</kbd>.

Good job. You're done.

[**Download it NOW!**](https://github.com/dhkim0800/indexextract/releases/download/18.06e0/indexextract.exe)

## Known issues

You have to install Minecraft, or you will meet **unhandled exceptions!**

Issue 2. In fact, Java is much faster in json processing with Gson. (I couldn't find JSON api. If you find it, Please contact to bycommandntwk@gmail.com, dhkim0800@naver.com, or Issues page in this project(recommended). AND I DON'T KNOW ASYNC PROGRAMMING WITH VB WELL AND I CANNOT CHANGE CODE WITH JSON API.

## Get index from server

Versions json file: [launchermeta.mojang.com](https://launchermeta.mojang.com/mc/game/version_manifest.json)

Format json file: [jsonformatter.curiousconcept.com](https://jsonformatter.curiousconcept.com/)

Assets json URL: `{version}.json=>assetIndex=>url`

Looks like this:
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
