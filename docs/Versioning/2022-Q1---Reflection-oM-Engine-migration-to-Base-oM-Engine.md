Following the discussion in [this issue](https://github.com/BHoM/admin/issues/17) and associated discussions in [this issue](https://github.com/BHoM/BHoM_Engine/issues/1645) and [this issue](https://github.com/BHoM/BHoM_Engine/issues/2671), the Reflection oM was removed from BHoM, and significant changes made to the location of methods between Reflection_Engine and BHoM_Engine DLLs.

Reflection_oM has been removed entirely, while Reflection_Engine has been modified. Moving forward, Reflection_Engine will house methods which allow the code base to ask questions about itself, following the traditional route of Reflection in programming, so the engine will continue to exist, but core methods that are more commonly used for general operation of the eco-system have been migrated to the Base_Engine.

### Pull Requests

To jump straight into the code changes, see these PRs:

 - BHoM: [Reflection_oM: Migrate objects to Base_oM - Removing Reflection_oM](https://github.com/BHoM/BHoM/pull/1339)
 - BHoM_Engine: [Align to changes in oM - moving Reflection_oM objects to Base_oM -> updating usings and codings to the new object locations](https://github.com/BHoM/BHoM_Engine/pull/2729)

Further changes were made to all repositories within the installer. A full list is available in the following files. These links will take you to the commit states at the time this work was done, and will highlight which repositories received the updates at the time. All repositories received the updates described in this article to ensure they could compile against the base changes, with no other changes provided during this work.

 - [Dependencies](https://github.com/BHoM/BHoM_Installer/blob/8dfab160c13b200c9898b931f02e28b40fd733b6/dependencies.txt)
 - [Includes](https://github.com/BHoM/BHoM_Installer/blob/8dfab160c13b200c9898b931f02e28b40fd733b6/include.txt)
 - [User Interfaces](https://github.com/BHoM/BHoM_Installer/blob/8dfab160c13b200c9898b931f02e28b40fd733b6/userInterfaces.txt)
 - [Alpha Includes](https://github.com/BHoM/BHoM_Installer/blob/8dfab160c13b200c9898b931f02e28b40fd733b6/alphaIncludes.txt)

## Reflection_oM -> Attributes

### `BH.oM.Reflection.Attributes` -> `BH.oM.Base.Attributes`

The biggest impact to repositories was via the migration of all Reflection_oM objects to the BHoM project, falling under the `Base` namespace. This included `Attributes`, `Debugging`, and the interfaces for `MultiOutput` objects.

The `Attributes` are a key part of BHoM documentation, providing `Input`, `Output`, and `MultiOutput` documentation attributes, as well as versioning attributes such as `ToBeRemoved` and `PreviousVersion`.

Prior to this work, they were housed under the namespace `BH.oM.Reflection.Attributes`, but this has now become `BH.oM.Base.Attributes` following the migration. Updating your `using` statements and referencing `BHoM.dll` rather than `Reflection_oM.dll` should be sufficient to resolve compilation issues here.

## Reflection_oM -> Debugging

### `BH.oM.Reflection.Debugging` -> `BH.oM.Base.Debugging`

For anyone needing to use the `Debugging` objects of BHoM (such as `Event`), these are now housed in the `BH.oM.Base.Debugging` namespace. Existing uses of this should be sufficient to rename the `using` statement and ensure a reference to `BHoM.dll` rather than `Reflection_oM.dll`.

## Reflection_oM -> Output

### `BH.oM.Reflection` -> `BH.oM.Base` (`BH.oM.Reflection.Output<T>` -> `BH.oM.Base.Output<T>`)

The `Output<T>` objects were housed in the top level of the Reflection_oM in the namespace `BH.oM.Reflection`. These have been moved to the top level of the BHoM in the namespace `BH.oM.Base`.

Anyone using `Output<T, Tn>` objects should find it sufficient to replace `using BH.oM.Reflection;` with `using BH.oM.Base;` and ensuring a reference to `BHoM.dll` rather than `Reflection_oM.dll` going forward.

## Reflection_Engine -> Loading/Reflecting Assemblies

### `BH.Engine.Reflection` -> `BH.Engine.Base`

These methods were primarily used by UIs to load DLLs appropriately into their platforms. These have moved to the Base Engine, in the `BHoM_Engine.dll` reference. Adding a reference to `BHoM_Engine.dll` and updating using statements and method calls should be sufficient.

The use of the name `Reflect` has been removed from the Base Engine to avoid confusion with the ongoing use of Reflection_Engine, and has become `Extract`. See [this file](https://github.com/BHoM/BHoM_Engine/blob/ae5f832e75f8f8a4d4f3b994e6253c4485a5e829/BHoM_Engine/Compute/ExtractAssembly.cs) for more information.

## Reflection_Engine -> Error/Warning/Note recording

### `BH.Engine.Reflection` -> `BH.Engine.Base`

### `BH.Engine.Reflection.Compute.RecordError()` -> `BH.Engine.Base.Compute.RecordError()`

### `BH.Engine.Reflection.Compute.RecordWarning()` -> `BH.Engine.Base.Compute.RecordWarning()`

### `BH.Engine.Reflection.Compute.RecordNote()` -> `BH.Engine.Base.Compute.RecordNote()`

Another big change with the migration is the housing of methods related to the logging system within BHoM. These have been updated as above, with the same functionality as before. If your code was using the logging system, updating `Reflection` to `Base` and ensuring a reference to `BHoM_Engine.dll` should be sufficient.

## Questions/Issues

If you encounter any problems following this migration, please reach out with [discussion](https://github.com/BHoM/BHoM/discussions) or [issues](https://github.com/BHoM/BHoM/issues) as appropriate 😄 