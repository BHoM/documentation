# Change to a property name.
1. In the Audience Profile Parameters object I want to change the property `NumRows` to `Rows`.
1. Before any changes to the code I create the JSON string: 

    ![Annotation 2020-08-20 160127](https://user-images.githubusercontent.com/6618854/90789117-6c9cb000-e2fe-11ea-8ca8-5fb55d4dd898.jpg)

1. And save a Grasshopper file with a panel containing that string.

    ![Annotation 2020-08-20 160242](https://user-images.githubusercontent.com/6618854/90789283-a4a3f300-e2fe-11ea-90f6-4e765692b3ec.jpg)

1. I make the property name change in the code:

    ![Annotation 2020-08-20 155214](https://user-images.githubusercontent.com/6618854/90787903-2266ff00-e2fd-11ea-8793-5201b21b2416.jpg)

1. Create the Versioning_XX.json:

    ![Annotation 2020-08-20 155326](https://user-images.githubusercontent.com/6618854/90788065-4b878f80-e2fd-11ea-9353-2c088890ef92.jpg)

1. Add it to the project.
1. Rebuild the Audience_oM and Engine.
1. Rebuild the latest Versioning_Toolkit.
1. Open Grasshopper and the test file.
1. Place the `ToNewVersion` component and pass in the JSON string of the old object.

    ![Annotation 2020-08-20 160500](https://user-images.githubusercontent.com/6618854/90789514-eb91e880-e2fe-11ea-91c4-9b76f70870f7.jpg)

1. Check the change has occurred as expected by inspecting the output string from `ToNewVersion`.

    ![Annotation 2020-08-20 160600](https://user-images.githubusercontent.com/6618854/90789665-11b78880-e2ff-11ea-9e8f-783336643d9f.jpg)

1. If that did not work then see below.