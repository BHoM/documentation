# Getting started for developers

Welcome Developers! 🚀

Here's a quick start guide. After reading this, you might want to head to [create your own Toolkit](/Basics/The-BHoM-Toolkit).

## Building BHoM from Source

Please follow the steps below:

1. Use **git `clone`** (or use [GitHub desktop](https://desktop.github.com/)) to download the repositories in the list below.
2. Use your preferred IDE to build the solutions **in the order as they appear below**. 
We recommend [Visual Studio Community](https://visualstudio.microsoft.com/vs/community/).

!!! note "Build order"
    
    The first time you build BHoM you need to clone and build the repos **in the order specified below**.
    
    You must pick all the _Mandatory_ repos.

!!! note "Rebuilding and seeing changes in the UIs (Grasshopper/Dynamo/Excel)"

    When building in visual studio, the compiled assemblies will go in the `./Build` folder of your Repo; additionally, there is a **Post-Build event** that copies the files in the **central BHoM folder: `C:\ProgramData\BHoM\Assemblies`**.

    When you build, **if there is any UI open** (e.g. Rhino/Grasshopper/Revit/Excel), **the dlls will not be overwritten in the central folder** because they are referenced by the UI software. Therefore, to ensure the changes are visible in the UI, you must make sure to close all UI software, then reopen it to see updated changes.
    
!!! tip

      When developing a Toolkit, in order to reduce rebuild iterations, you might want to:
      
      1. Rebuild your Toolkit
      2. Rebuild BHoM_UI 
      3. [Start Debugging your Toolkit with an UI application attached](https://user-images.githubusercontent.com/6352844/74458548-c91ba000-4e81-11ea-9590-cf37698b911a.png). 

      The last step will fire up your UI application and you will be able to modify the code while debugging, on-the-fly (just press the `Pause` button in Visual Studio).

      Note that _not all IDEs support this_ (notably, not the Express editions of Visual Studio – only the Community, Professional and Enterprise ones do).

      An alternative that always works is, after steps 1 and 2 above, simply [fire up your UI application and attach to its process](https://docs.microsoft.com/en-us/visualstudio/debugger/attach-to-running-processes-with-the-visual-studio-debugger?view=vs-2019#BKMK_Attach_to_a_running_process).
      This way you will be able to follow code execution and check exceptions; however, this does not allow for code modification while debugging.



### Mandatory _base_ repos

#### Main repos
Compile **each of these, one after the other**:

- [BHoM](https://github.com/BHoM/BHoM)
- [BHoM_Engine](https://github.com/BHoM/BHoM_Engine)
- [BHoM_Adapter](https://github.com/BHoM/BHoM_Adapter) 
- [BHoM_UI](https://github.com/BHoM/BHoM_UI)
- [CSharp_Toolkit](https://github.com/BHoM/CSharp_Toolkit)
   
#### User interface(s)
Compile **one or more of the following** - depending on the User interface software you want to use:

1. [Rhinoceros_Toolkit](https://github.com/BHoM/Rhinoceros_Toolkit) and then [Grasshopper_Toolkit](https://github.com/BHoM/Grasshopper_Toolkit) (requires Rhinoceros_Toolkit)
2. [Excel_Toolkit](https://github.com/BHoM/Excel_Toolkit)
3. [Dynamo_Toolkit](https://github.com/BHoM/Dynamo_Toolkit)


The following repos are optional.

### Optional _base_ repos
These repos are sometimes used as stand-alone, and sometimes are also referenced by other repos. 

You might find them useful 🚀 

- [BHoM_Datasets](https://github.com/BHoM/BHoM_Datasets) - makes Datasets available (some test scripts might be using them)
- [Socket_Toolkit](https://github.com/BHoM/Socket_Toolkit) - send messages through Sockets. Some toolkits use this.
- [Mongo_Toolkit](https://github.com/BHoM/Mongo_Toolkit) - database connection. Some toolkits use this.
- [Versioning_Toolkit](https://github.com/BHoM/Versioning_Toolkit) - allows retro-compatibility of components (auto upgrade to newest version).


### Toolkits 🌍

Toolkits provide the connection to other software.

Clone and build any toolkit you want to use!

Some examples:

- For Structural FEA analysis
   - [Robot_Toolkit](https://github.com/BHoM/Robot_Toolkit) (for students, Robot offers a free version)
   - [GSA_Toolkit](https://github.com/BHoM/GSA_Toolkit)
   - [ETABS_Toolkit](https://github.com/BHoM/ETABS_Toolkit)
   - Many others available!
- For Environmental simulation 
   - [IES_Toolkit](https://github.com/BHoM/IES_Toolkit)
   - [EnergyPlus_Toolkit](https://github.com/BHoM/EnergyPlus_Toolkit)
   - Many others available too!
- Others:
   - [Speckle_Toolkit](https://github.com/BHoM/Speckle_Toolkit)
   - [LifeCycleAssessment_Toolkit](https://github.com/BHoM/LifeCycleAssessment_Toolkit)
   - Explore https://github.com/BHoM ...



## FAQ and help

### I can't Rebuild the solution: `NuGet package(s) missing` error
Sometimes you might encounter [this error](https://user-images.githubusercontent.com/6352844/74666820-1e192800-519a-11ea-9c4e-340ea8cedbc9.png). Although Visual Studio "Rebuild All" command should take care of Restoring the NuGet packages for you, to solve this just run that manually.  
Right click the solution → `Restore NuGet Packages`.

### I have done some changes to my code, but when I open Grasshopper (or Dynamo, or Excel) the code still behaves as before! Why it is not updated?
After compiling, check that the Build was successful, by looking in the "Output" tab at the bottom of the VS interface; make sure no errors are there, and also that the Post-build event worked successfully. See the notes above.

