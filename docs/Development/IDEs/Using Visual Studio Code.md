# Using Visual Studio Code For BHoM Development

Visual Studio Code as of [June 2023](https://devblogs.microsoft.com/visualstudio/announcing-csharp-dev-kit-for-visual-studio-code/) is a viable option for .Net and C# development on windows. 


## Required Software
- [VS Code](https://code.visualstudio.com/)
- [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
- [C# Intellisense](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.vscodeintellicode-csharp)


## Required Configuration

### Attach to Process For Debugging
Add a folder to your tool's root directory titled `.vscode`
Add a file to `.vscode` folder titled `launch.json`
```bash
Tool_Repo_Folder
|
|--- .vscode
      |
      |---launch.json
```

#### Attach to process of your choosing
within your `launch.json`
add the following

```json
{
    // Use IntelliSense to learn about possible attributes.
    // Hover to view descriptions of existing attributes.
    // For more information, visit: https://go.microsoft.com/fwlink/?linkid=830387
    //To attach to running process of your choosing
    "version": "0.2.0",
    "configurations": [
        {
            "name": "Attach to Process",
            "type": "clr", 
            "request": "attach",
            "processId": "${command:pickProcess}"
        }
      ],
        "postDebugTask": "echo"
}

```

#### Attach to running process of pre-defined name
within your `launch.json`
add the following

```json
{
    // Use IntelliSense to learn about possible attributes.
    // Hover to view descriptions of existing attributes.
    // For more information, visit: https://go.microsoft.com/fwlink/?linkid=830387
    //To attach to running process automatically
    "version": "0.2.0",
    "configurations": [
         {
             "name": "Attach to Revit",
             "type": "coreclr", 
             "request": "attach",
             "processName": "Revit.exe",
             "justMyCode": false
         }
    ],
        "postDebugTask": "echo"
}

```


### Working As A Team
Not all members of the team will want to work in VS Code.
Please be considerate of this as you develop by adding the `.vscode` folder to your `.gitignore`
