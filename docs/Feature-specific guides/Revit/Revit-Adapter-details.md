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
