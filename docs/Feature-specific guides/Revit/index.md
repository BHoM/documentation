# Revit_Toolkit documentation

Welcome to the [Revit_Toolkit](https://github.com/BHoM/Revit_Toolkit/) documentation! 

Here you will find information on what Revit_Toolkit can do for you as well as how to make that (and even more) happen. 

Feel free to explore and raise an [issue](https://github.com/BHoM/Revit_Toolkit/issues) if you need or do not like something. Enjoy!

## Revit_Toolkit overview

Revit_Toolkit is a set of tools that enable and support exchange of information between BHoM and Revit. The heart of the process is [the Adapter](Revit-Adapter-basics) that links Revit with BHoM. It allows for the following actions:
- [Pull from Revit to BHoM](Pull-from-Revit-basics)
- [Push from BHoM to Revit and update Revit elements](Push-to-Revit-basics)
- [Remove Revit elements](Remove-from-Revit-basics)

Push and Pull include [conversion](Revit-BHoM-conversion) from and to Revit, which is being triggered on the fly.

Revit_Toolkit includes a range of support classes and methods that extend the core BHoM to embrace the complexity of Revit. These, among others, are:
- [dedicated Requests](Requests-and-filtering) supported by a range of [filtering methods](https://github.com/BHoM/Revit_Toolkit/tree/master/Engine_Revit_UI/Query/ElementIds) that allow specified queries
- BHoM wrappers for Revit elements: `Sheets`, `Viewports`, `IViews`, `DraftingInstances`, `ModelInstances` etc.
- general methods to process Revit elements and documents, mainly for conversion purposes

All Adapter actions can be taken from any of the BHoM-supported UIs: Grasshopper, Excel, .... Additionally, all relevant methods and classes are `public`, therefore other applications can be built upon the code base of Revit_Toolkit ([see simple Forms app sample](https://github.com/BHoM/samples/tree/master/Revit_Toolkit/C%23)).