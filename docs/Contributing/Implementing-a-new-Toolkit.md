# Implementing a new Toolkit

To assist with implementing a new Toolkit, we have a Toolkit Template that prepares a Visual Studio solution with all the scaffolding done for you: [create an new Toolkit using the BHoM Toolkit Template](https://github.com/BHoM/template-repository).


## Structure of a Toolkit
In short, a Toolkit can contain **one or more** of the following projects:

- A [BHoM_oM](../BHoM_oM/index.md) project, that contains the _definitions_ specific to your Toolkit (the types, or the _schema_, needed for your purposes).
- A [BHoM_Engine](../BHoM_Engine/index.md) project, that contains the _functionality_ specific to your Toolkit.
- A [BHoM_Adapter](../BHoM_Adapter/index.md) project, that contains the _connectivity_ required to interface with an external software.

If you are an User you might want to check out [Getting started with the BHoM in Visual Programming](<../Guides and Tutorials/Visual Programming with BHoM/index.md>).

If you are interested in programming, creating your own new Toolkit, or contributing to the code of an existing one, keep reading.


## Create a new software Toolkit using the BHoM Toolkit Template

### Create a new Toolkit repository
Use the [template repository](https://github.com/BHoM/template-repository) to create a new repository. See the readme there.

## Implement the oM

The oM should contain property-only classes that make the schema for your Toolkit. All functionality should be placed in the Engine.
Functionality that is specific to a class should be defined in the Engine as an extension method. 

See [The Object Model](../BHoM_oM/index.md) and [The Engine](../BHoM_Engine/index.md) for more information.


## Implement the Engine

The Engine should contain the functions applicable to the objects you've defined in the oM.

See [The Engine](../BHoM_Engine/index.md) for more information.

## Implement the Adapter

See the dedicated page to [Implementing an Adapter](../BHoM_Adapter/Implement-an-Adapter.md).
