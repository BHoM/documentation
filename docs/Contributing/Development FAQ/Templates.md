# BHoM coding templates

Visual studio template files have been set up to help guide and simplify the development process of the BHoM.

The currently available templates are:

- [Toolkit Template](https://github.com/BHoM/template-repository). You can use this to create a scaffolded Visual Studio solution ready for the development of a Toolkit. It includes an Adapter, an Engine and an oM project templates.
- [Engine method templates](https://github.com/BHoM/documentation/tree/master/templates/Engine%20method%20templates). They make it faster to to add new Engine methods to an Engine project.

## Toolkit template
For more guidance on how to use the Toolkit template, please see [Toolkit Template](https://github.com/BHoM/template-repository).

## Engine method templates - add them to Visual Studio

To get visual studio to detect the templates follow these steps:

1. Download the template zip files from the links above.
1. Place the files in the visual studio templates folder. This will generally be:
   1. C:\Users\ _USERNAME_ \OneDrive\Documents\ _VISUAL STUDIO VERSION_ \Templates\ProjectTemplates\Visual C# for any _project template_ like the BHoM Adapter Template.
   1. C:\Users\ _USERNAME_ \OneDrive\Documents\ _VISUAL STUDIO VERSION_ \Templates\ItemTemplates\Visual C# for any _item template_ like Engine method templates.
1. Restart visual studio.

When you choose New Project from the visual studio menu all project templates should now show up there and when adding a new item to an existing project should now mean all the item templates should show up.


**Known Issues**

If template is used to add a method by right clicking on a folder, an extra the folder name will be added. This will in many cases be wrong and conflict with the class name. Issues have been raised to improve the templates further going forward. In the meantime, **please check the namespace of added methods**.

