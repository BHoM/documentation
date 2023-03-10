# The BHoM Toolkit

A Toolkit is a set of tools (_definitions_, _functionality_, and _connectivity_) used for a specific purpose. 

For example, you will find a [Robot_Toolkit](https://github.com/BHoM/Robot_Toolkit) to do structural analysis with Autodesk Robot; similarly, you can find a [Revit_Toolkit](https://github.com/BHoM/Revit_Toolkit), a [LifeCycleAssessment_Toolkit](https://github.com/BHoM/LifeCycleAssessment_Toolkit), and many many others.

## Structure of a Toolkit
In short, a Toolkit can contain **one or more** of the following projects:

- A [BHoM_oM](/documentation/BHoM_oM) project, that contains the _definitions_ specific to your Toolkit (the types, or the _schema_, needed for your purposes).
- A [BHoM_Engine](/documentation/BHoM_Engine) project, that contains the _functionality_ specific to your Toolkit.
- A [BHoM_Adapter](/documentation/BHoM_Adapter) project, that contains the _connectivity_ required to interface with an external software.

If you are an User, head to one of the sections linked above to learn more (oM, Engine, Adapter).

If you are interested in programming, creating your own new Toolkit, or contributing to the code of an existing one, keep reading.

## Implementing a new Toolkit

In order to implement a new Toolkit, we prepared a Toolkit Template that prepares a Visual Studio solution with all the scaffolding done for you: [create an new Toolkit using the BHoM Toolkit Template](https://github.com/BHoM/template-repository).


## Create a new software Toolkit using the BHoM Toolkit Template

### Create a new Toolkit repository
Use the [template repository](https://github.com/BHoM/template-repository) to create a new repository. See the readme there.

## Implement the oM

The oM should contain property-only classes that make the schema for your Toolkit. All functionality should be placed in the Engine.
Functionality that is specific to a class should be defined in the Engine as an extension method. 

See [The Object Model](/documentation/BHoM_oM) and [The Engine](/documentation/BHoM_Engine) for more information.


## Implement the Engine

The Engine should contain the functions applicable to the objects you've defined in the oM.

See [The Engine](/documentation/BHoM_Engine) for more information.

## Implement the Adapter

See the dedicated page to [Implementing an Adapter](/documentation/Implement-an-Adapter).
