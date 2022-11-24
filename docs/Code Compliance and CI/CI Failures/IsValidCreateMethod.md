## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/IsValidCreateMethod.cs)

## Details

A create method name should meet the following conditions:

 - If the return type matches the method name, the method name must match the filename and sit within the create folder (without any subfolders)
   - e.g. a `Panel` object can sit within a file with the structure `Engine/Create/Panel.cs` in a method called `Panel`

If the above cannot be done, then:
 - A sub-folder should be created which matches the return type, the method name must match the file name, and the method name should partially match the return type
   - e.g. a `Panel` object can sit within a file with the structure `Engine/Create/Panel/EnvironmentPanel.cs` in a method called `EnvironmentPanel`
   - A level of grouping/nesting is permitted when using the second option to help group create methods appropriately. This nesting is permitted up to two levels before it would become incompliant with the guidelines.
     - e.g. a `Panel` object can fit within a file with the structure `Engine/Create/PlanarPanels/Panel/EnvironmentPanel.cs` or `Engine/Create/Panel/PlanarPanels/EnvironmentPanel.cs` - here we group the panels by `PlanarPanels`. Either option is compliant for the check to pass. Any further folders would however be incompliant.