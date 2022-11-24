# Object name change and associated custom create method
In the Audience_oM I want to change the object name for `ProfileParameters` to `TierProfileParameters`. There are two `Create` methods that will also need to be upgraded. This page describes the steps to achieve that.
## First I am going to set up some files and data to help with the process
1. Capture the JSON string of the object to change as described [here](/How-to-check-your-versioned-changes-are-working-%3F).
1. Set up a simple file with the auto generated object create method component and related methods that the changes will impact:

    ![Annotation 2020-08-21 121114](https://user-images.githubusercontent.com/6618854/90884388-8a721f80-e3a7-11ea-9df9-0e3c33255643.jpg)
1. Use the `VersioningKey` component to get the string that will later be used for the the `PreviousVersion` Attribute that I will add to the affected methods.

    ![Annotation 2020-08-21 121421](https://user-images.githubusercontent.com/6618854/90884538-db821380-e3a7-11ea-9477-2b89860a3123.jpg)
1. Copy the output of `VersioningKey` and paste into a text editor.
## Change the code to change the object name
1. Change the object name and the file name for this object.
1. In the Engine and oM projects replace all instances of the old name with the new name.

    ![Annotation 2020-08-21 115657](https://user-images.githubusercontent.com/6618854/90883301-73cac900-e3a5-11ea-9c3c-b41faa674f8b.jpg)
    I'm using find and replace for the renaming - care should be taken here.

1. Check the solution builds.
1. Create and add the versioning JSON file to the project. See [here](#decentralisation-of-the-upgrade-information) for the content of an empty `Versioning_XX.json` file.
1. Add the key value pairs to describe the `ToNew` and `ToOld` upgrade / downgrade.

    ![Annotation 2020-08-21 120337](https://user-images.githubusercontent.com/6618854/90884688-1dab5500-e3a8-11ea-89bf-34efc873407e.jpg).
1. At this we can rebuild the solution and rebuild the `Versioning_Toolkit`.
1. First I'll check the upgrade using the json string and `ToNewVersion`:

    ![Annotation 2020-08-21 123930](https://user-images.githubusercontent.com/6618854/90887011-74fef480-e3ab-11ea-842c-266c57dd1b69.jpg)
1. If this fails double check all the steps above.
1. Open Rhino and the simple test file.
1. We'll see the auto generated create method has correctly upgraded, but the others show errors:

    ![Annotation 2020-08-21 122346](https://user-images.githubusercontent.com/6618854/90885312-3f590c00-e3a9-11ea-9eaa-b2e4ba75d50d.jpg)
    
## Change the code to change the methods
1. I need to add the `PreviousVersion` attribute to ensure the methods are upgraded.
1. The text we saved earlier looks like:
    ```
    BH.Engine.Audience.Create.ProfileParameters(System.Double)
    BH.Engine.Audience.Create.ProfileParameters(System.Double, System.Double, System.Double, System.Double, System.Int32, System.Double, 
    BH.oM.Humans.ViewQuality.EyePositionParameters, BH.oM.Audience.PlatformParameters)
    ```
1. I'll use the first of those two as arguments to the `PreviousVersion` attribute which will be added to the first method like this:

    ![Annotation 2020-08-21 123225](https://user-images.githubusercontent.com/6618854/90886493-65cb7700-e3aa-11ea-90e5-d4a1e53bd35a.jpg)
1. And adding the `PreviousVersion` attribute to the second method with more arguments will look like this:

    ![Annotation 2020-08-21 123439](https://user-images.githubusercontent.com/6618854/90886646-b2af4d80-e3aa-11ea-8402-d19007b94e96.jpg)

1. For compliance I will also change the name of the file containing those methods to match the renamed object type they return `TierProfileParameters`.
1. We can now rebuild the solution and the `Versioning_Toolkit` and check again if this has worked.

    ![Annotation 2020-08-21 124131](https://user-images.githubusercontent.com/6618854/90887107-aa0b4700-e3ab-11ea-971b-2577860df16b.jpg)

