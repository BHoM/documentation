## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/main/CodeComplianceTest_Engine/Compute/CheckAssemblyInfo.cs)

## Details

### Assembly Information

This section is only valid for projects utilising the old-style CSProject files, where an `AssemblyInfo.cs` file is present. If an `AssemblyInfo.cs` file is not present, then the compliance of this information can be found [here](Project-References-and-Build-Paths).

Each DLL should have suitable assembly information to support automated processes and confirming the version of the code which the DLL was built against. This includes these three items:

 - `<AssemblyVersion>`
 - `<AssemblyFileVersion>`
 - `<AssemblyDescription>`

The `AssemblyVersion` should be set to the major version for the annual development cycle. This is set by DevOps, and will typically be a 4-digit number where the first number is the major version for the year, followed by three 0's - e.g. `5.0.0.0` for the 2022 development calendar (note, development calendars are based on release schedules as outlined by DevOps, not any other calendar system).

The `AssemblyFileVersion` should be set to the current development milestone, which is the major version followed by the milestone, followed by two 0's - e.g. `5.3.0.0` for the development milestone running from June-September 2022.

The `AssemblyDescription` attribute should contain the full link to the repository where the DLL is stored, e.g. `https://github.com/BHoM/Test_Toolkit` for DLLs where the code resides in Test_Toolkit.

At the start of each milestone, BHoMBot will automatically uptick the `AssemblyVersion` and `AssemblyFileVersion` as appropriate, and set the `AssemblyDescription` if it was not previously set. However, if you add a new project during a milestone, BHoMBot will flag these items as incompliant if they have not been resolved prior to running the `project-compliance` check. These items can be fixed by BHoMBot if you request BHoMBot to fix the project information.