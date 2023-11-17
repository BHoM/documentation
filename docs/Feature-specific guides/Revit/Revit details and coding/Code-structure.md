The code of Revit_Toolkit has some differences with other Toolkits, because we need to reference the Revit API, which needs to run inside a Revit thread. 

Therefore, Revit_Toolkit split into two realms:
- BHoM side - [standard BHoM toolkit structure](https://github.com/BHoM/documentation/wiki/The-BHoM-Toolkit#what-is-a-toolkit):
    - **Revit_oM** (`BH.oM.Adapters.Revit`) - Revit_Toolkit-specific classes, mainly settings/config and wrappers for Revit types
    - **Revit_Engine** (`BH.Engine.Adapters.Revit`) - methods to process the objects from Revit_oM
    - **Revit_Adapter** (`BH.Adapter.Revit`) - BHoM side of Revit-specific implementation of `BHoMAdapter` without CRUD, which is sitting on the Revit side of the solution (see below)
- Revit side:
    - **Revit_Core_Adapter** (`BH.Revit.Adapter.Core`) - Revit side of Revit-specific implementation of `BHoMAdapter`, including adapter action methods, CRUD as well as Revit Listener plugin and event handlers
    - **Revit_Core_Engine** (`BH.Revit.Engine.Core`) - methods to process Revit objects ([filter](Requests-and-filtering), [convert](Revit-BHoM-conversion), query etc.)

The relationship and interaction between Revit side and BHoM side of the Adapter is explained in [Adapter Details](Revit-Adapter-Details) section, including a flowchart explaining the process on high level. Similarly, each of the adapter actions is mapped out in action specific section:
- [Pull Details](Pull-from-Revit-details)
- [Push Details](Push-to-Revit-details)
- [Remove Details](Remove-from-Revit-details)