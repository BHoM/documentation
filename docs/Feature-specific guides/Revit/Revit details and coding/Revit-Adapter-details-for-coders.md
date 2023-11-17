# Revit Adapter in detail for coders and programmers

## Code structure

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

## Flowchart and dealing with threads

As already mentioned, the adapter is divided in two sides. On the code level this means the adapter instructions are being processed by two objects:
- BHoM side - `RevitAdapter`
- Revit side - `RevitUIAdapter`

In most cases the above objects exist on two separate threads, one per each side. This means the data needs to be exchanged between the threads, which is done with the use of [Sockets](https://github.com/BHoM/Socket_Toolkit/wiki) and data package dispatchers:
- BHoM side - `RevitAdapter`
- Revit side - `RevitListener`

In general case, the adapter action procedure can be explained as follows: once `RevitAdapter` receives an adapter instruction, it passes it to `RevitListener` via Sockets, locks itself to wait, while `RevitListener` raises an event that triggers [CRUD methods](https://github.com/BHoM/documentation/wiki/Adapter-Actions#the-crud-paradigm) in `RevitUIAdapter`. Then, once CRUD methods return output, it is passed to `RevitListener`, which sends in back to `RevitAdapter` - it then unlocks itself and returns the output to the user.

In a case when the UI runs on Revit thread, data exchange between the threads is not needed. Instead, an instance of `RevitUIAdapter` is assigned to `RevitAdapter.InternalAdapter` static property and CRUD methods get triggered directly based on instructions received by the `RevitAdapter`.

Both scenarios are presented in the flowchart below. Flowchart explaining each of the adapter actions can be found in [Pull](Pull-from-Revit-details)/[Push](Push-to-Revit-details)/[Remove](Remove-from-Revit-details) detail sections.

[![Revit Adapter flowchart](https://user-images.githubusercontent.com/26874773/78884623-89290180-7a5b-11ea-80b3-b878b263849a.png)](https://user-images.githubusercontent.com/26874773/78884623-89290180-7a5b-11ea-80b3-b878b263849a.png)
