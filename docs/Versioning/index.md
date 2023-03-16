# What is BHoM versioning?

BHoM versioning provides a system to correctly load a method or component stored in a script that has had its code changed.

## Why is Versioning needed?

When you save a script that contains BHoM stuff, all of the BHoM components save information about themselves so they can initialise properly when the script is re-opened. This information is about things like the component/method name, its inputs and outputs types and names; the information is simply stored in a text (Json serialised).

If someone changes a BHoM method or object that was stored in a script, upon reopening of the script it will be impossible to reload that same method or object: the method initialisation will fail and the old component in the script will throw a warning or error, unable to work. 

Versioning fixes this by updating the old json text before using it to find the method. 

## What does BHoM versioning support?

Upgrading/downgrading of the following modifications:

- Changes on BHoM methods (e.g. saved in a script): 
    - changes in the method name
    - changes in their input/outputs names and types.
- Changes on BHoM objects (e.g. internalised in a script or stored in a file or database): 
    - changes in class properties
    - changes in their name
    - complex structural changes
- Changes in Namespaces:
    - renaming namespaces
    - general modification to namespaces 

## Ok, tell me how to do versioning for my changes! 🚀
To implement versioning when you do your changes, see [Versioning guide](versioning-guide.md).
