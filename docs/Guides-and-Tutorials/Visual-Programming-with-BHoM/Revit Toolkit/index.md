# Revit Toolkit intro

Welcome to the [Revit Toolkit](https://github.com/BHoM/Revit_Toolkit/) documentation! 

Here you will find information on what Revit_Toolkit can do for you as well as how to make that (and even more) happen. 

Feel free to explore and raise an [issue](https://github.com/BHoM/Revit_Toolkit/issues) if you need or do not like something. Enjoy!

## Overview

Revit_Toolkit is a set of tools that enable and support exchange of information between BHoM and Revit. The heart of the process is [the Adapter](Revit Adapter) that links Revit with BHoM. It allows for the following actions:

- [Pull from Revit to BHoM](Pull)
- [Push from BHoM to Revit](Push)
- [Remove Revit elements](Remove)

All Adapter actions can be taken from any of the BHoM-supported UIs: Grasshopper and Excel. Push and Pull include conversion [from Revit](Pull/Conversion from Revit) and [to Revit](Push/Conversion to Revit), which is being triggered on the fly. This conversion is an integral part of Push and Pull Adapter actions - besides simply translating Revit elements into BHoM objects, it ensures correctness of the units and, in general, allows representing Revit objects outside of Revit context.

## More info
Sections below explain the practicalities of that process, while its code mechanics is discussed in [Coding-with-BHoM](../../Coding-with-BHoM/Revit Toolkit) section.