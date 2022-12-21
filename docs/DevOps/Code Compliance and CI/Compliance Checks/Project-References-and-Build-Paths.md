## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/main/CodeComplianceTest_Engine/Compute/CheckProjectFile.cs)

## Details

### References

In order to aid people working on BHoM repositories across multiple platforms, and to avoid conflict between BHoM DLLs, project references to other BHoM repositories (for example, the `Environment_oM` from BHoM itself, or the `Environment_Engine` from BHoM_Engine) need to be set to a certain path.

This path should be to the `ProgramData` folder in the `C:/` drive of the machine. BHoM installs to the location `C:/ProgramData/BHoM` folder, and all project files inside a toolkit have a postbuild event (see below) to copy their DLLs to the `C:/ProgramData/BHoM/Assemblies` folder. By referencing DLLs in this location, it means people can install BHoM using an installer, clone a toolkit and begin developing without needing to clone and build the dependencies.

Therefore, DLL references should be set to:

`C:/ProgramData/BHoM/Assemblies/TheDLL.dll`

For example, if we want to reference `Environment_oM` from BHoM, our project reference should look like:

`C:/ProgramData/BHoM/Assemblies/Environment_oM.dll`

If the project reference is set to a copy of the `Environment_oM` DLL from another location, there is a risk that the DLL will be out of date to the `master` and you could therefore be building on top of an out of date framework.

If the project reference is not set to the example above, then this check will highlight that, and provide a suggestion of the path the DLL reference should have.

#### Exemptions

References to DLLs within your own solution file should be made as Project References, rather than as DLL references.

### Copy Local

In order to prevent duplicate DLLs, some of which may be out of date, being placed in your repositories `Build` folder, and risk ending up in your Assesmblies folder run building `BHoM_UI`, the `copy local` property for all BHoM references should be set to `false`.

This check will also ensure this and flag any DLLs which do not have their `copy local` property set to `false`.

### Specific Version

In order to prevent DLLs being locked to specific versions, some of which may be out of date, the `specific version` property for all BHoM references should be set to `false`.

This check will also ensure this and flag any DLLs which do not have their `specific version` property set to `false`.

### Build Folder

In order to facilitate the above, a projects output folder should be set to `..\Build\` to put all DLLs from your solution file in the correct folder. The `Build` folder is where the BHoM_UI looks to take DLLs for the install process when building locally.

This check will ensure that all build configurations (including Debug and Release) have their output folder path set to `..\Build\` and flag any instances where this is not correct.

### Assembly Information

This section is only valid for projects utilising the new-style CSProject files, where an `AssemblyInfo.cs` file is not present. If an `AssemblyInfo.cs` file is present, then the compliance of this information can be found [here](AssemblyInfo-compliance).

Each DLL should have suitable assembly information to support automated processes and confirming the version of the code which the DLL was built against. This includes these three items:

 - `<AssemblyVersion>`
 - `<FileVersion>`
 - `<Description>`

The `AssemblyVersion` should be set to the major version for the annual development cycle. This is set by DevOps, and will typically be a 4-digit number where the first number is the major version for the year, followed by three 0's - e.g. `5.0.0.0` for the 2022 development calendar (note, development calendars are based on release schedules as outlined by DevOps, not any other calendar system).

The `FileVersion` should be set to the current development milestone, which is the major version followed by the milestone, followed by two 0's - e.g. `5.3.0.0` for the development milestone running from June-September 2022.

The `Description` attribute should contain the full link to the repository where the DLL is stored, e.g. `https://github.com/BHoM/Test_Toolkit` for DLLs where the code resides in Test_Toolkit.

At the start of each milestone, BHoMBot will automatically uptick the `AssemblyVersion` and `FileVersion` as appropriate, and set the `Description` if it was not previously set. However, if you add a new project during a milestone, BHoMBot will flag these items as incompliant if they have not been resolved prior to running the `project-compliance` check. These items can be fixed by BHoMBot if you request BHoMBot to fix the project information.

### PostBuild events

In order to facilitate a projects DLL being placed in the `ProgramData` folder for development testing, each project within a `sln` file must have its own postbuild event for copying its DLL to the correct location.

The postbuild event for this should be:

`xcopy "$(TargetDir)$(TargetFileName)"  "C:\ProgramData\BHoM\Assemblies" /Y`

With nothing changed from the above example.

If your toolkit relies on external libraries to run, then the relevant project must also provide the suitable postbuild event to copy those DLLs to the `ProgramData` folder as well.

Similarly, if your toolkit has any datasets, then a suitable project within your toolkit must provide the suitable postbuild event to copy the datasets to the `C:/ProgramData/BHoM/Datasets` folder.

**BHoMBot is not able to provide any automatic fixes for this compliance item, but will highlight if it detects that it is inaccurate**