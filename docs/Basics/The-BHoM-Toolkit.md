# What is a BHoM Toolkit?

A Toolkit is set of tools that can contain one or more of the following:

- A [BHoM_Adapter](/BHoM_Adapter) project, that allows to implement the connection with an external software.
- A [BHoM_Engine](/BHoM_Engine) project, that should contain the Engine methods specific to your Toolkit.
- A [BHoM_oM](/BHoM_oM) project, that should contain any oM class (the types, or the _schema_) specific to your Toolkit.

## Implementing a new Toolkit

In order to implement a new Toolkit, we prepared a Toolkit Template that prepares a Visual Studio solution with all the scaffolding done for you: [create an new Toolkit using the BHoM Toolkit Template](https://github.com/BHoM/template-repository).

Let's get started!

## Create a new software Toolkit using the BHoM Toolkit Template

### Create a new Toolkit repository
Use the [template repository](https://github.com/BHoM/template-repository) to create a new repository. See the readme there.

## Implement the oM

The oM should contain property-only classes that make the schema for your Toolkit. All functionality should be placed in the Engine.
Functionality that is specific to a class should be defined in the Engine as an extension method. 

See [The Object Model](/BHoM_oM) and [The Engine](/BHoM_Engine) for more information.


## Implement the Engine

The Engine should contain the functions applicable to the objects you've defined in the oM.

See /BH.Engine-%E2%80%90-Create-New-Algorithms for more information.

## Implement the Adapter

See the dedicated page to [Implementing an Adapter](/Implement-an-Adapter).