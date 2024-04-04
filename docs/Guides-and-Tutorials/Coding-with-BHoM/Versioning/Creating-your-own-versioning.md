# Creating your own versioning

The BHoM eco-system provides the [Versioning_Toolkit](https://github.com/BHoM/Versioning_Toolkit) to handle upgrading and versioning of any object, method, or dataset within the BHoM organisation/framework.

If you have built toolkits on top of the BHoM, then you may want to have your own versioning occur on your own objects, without revealing their existence to the open-source community (though of course, [we actively encourage sharing knowledge back to the community!](https://bhom.xyz/documentation/#so-what-exactly-is-the-bhom)). To this end, we have revamped the Versioning Toolkit in the 7.2 milestone to accommodate you building your own Versioning Toolkit without needing to copy what BHoM is doing to get our upgrades.

## BHoM Versioning

When we version a milestone in BHoM, we produce an `Upgrader`, which is usually called `BHoMUpgraderXY` where `XY` refers to the development major (X)/minor (Y) milestone numbers. For example, `BHoMUpgrader63` refers to the 6.3 upgrader and upgrades objects/methods made prior to the 6.3 milestone to the 6.3 standard. This upgrader is an `exe` file which allows [`Versioning_Engine`](https://github.com/BHoM/BHoM_Engine/tree/develop/Versioning_Engine) to pipe items to it for upgrade.

In addition to the `exe` file, we also produce the upgrader as a `DLL` file, allowing other upgraders to reference is - this means when someone adds versioning to BHoM via the converter in a given upgrader, your versioning toolkit can benefit from it as well.

Similarly, the [`PostBuild`](https://github.com/BHoM/Versioning_Toolkit/tree/develop/PostBuild) project which scrapes versioning data (`PreviousVersion` attributes, etc.) from compiled code is now placed within `$(ProgramData)\BHoM\Developer\Versioning` when Versioning Toolkit is built - allowing other developers to utilise the `PostBuild.exe` from a central location rather than needing to update any relative path references, which is beneficial to the rest of this tutorial guide.

## Technical elements

When building your versioning, you will be inheriting from the `Converter` class provided by BHoM's Versioning_Toolkit and overwriting the Upgrader `exe` file with your own. By inheriting from the BHoM `Converter`, you will obtain any upgrades contained in that `Converter` for BHoM related objects, and by using the same `PostBuild.exe` builder, providing you're building on top of the BHoM framework, you will scrape all `PreviousVersion` attributes (and other relevant attributes) from all compiled DLLs, which will include BHoM DLLs and your own - thus any versioning provided by the BHoM community will be scraped and picked up by your versioning when using this methodology. Then by overwriting the Upgrader `exe` deployed by the BHoM will allow it to be called by the Versioning_Engine when upgrading elements, allowing versioning to occur for the objects/methods/datasets within both BHoM and your own DLLs.

## Setting up your versioning toolkit

You can start by having a solution in the same way as any other BHoM Toolkit. The differences will come in the projects the solution contains. Instead of `_oM`, `_Engine`, and `_Adapter` projects, a versioning solution will contain `BHoMUpgraderXY` projects, where `XY` refers to the milestone you want to handle upgrades for.

### Adding a project

Add a console application project targeting .NetFramework4.7.2. Ensure the project name is `BHoMUpgraderXY` where `XY` is the milestone - `70` for the 7.0 milestone, `73` for the 7.3 milestone, etc.

Set up the namespace to be `BH.Upgrader.vXY` where `XY` is the milestone your project targets as above.

Set up the output folder for all configurations to be `Build\`.

Set up the post build events to be one of the following:

#### Adding a live versioning project

If you're adding a versioning project for the current milestone being developed (and thus want fresh versioning changes to be captured each time you build the toolkit), use this post build:

```
xcopy /Y /I /E "$(TargetDir)*.dll" $(ProgramData)\BHoM\Upgrades\BHoMUpgraderXY
xcopy /Y /I /E "$(TargetDir)BHoMUpgraderXY.exe" $(ProgramData)\BHoM\Upgrades\BHoMUpgraderXY
call "$(ProgramData)\BHoM\Developer\Versioning\PostBuild.exe" ..\..\..\ "$(ProgramData)\BHoM\Upgrades"
```

Where `XY` refers to the project milestone.

#### Adding a fixed versioning project

If you're adding a versioning project for a previous milestone, and want the versioning to be fixed and not scrape information every time you build the toolkit, use this post build:

```
xcopy /Y /I /E "$(TargetDir)*.dll" $(ProgramData)\BHoM\Upgrades\BHoMUpgraderXY
xcopy /Y /I /E "$(TargetDir)BHoMUpgraderXY.exe" $(ProgramData)\BHoM\Upgrades\BHoMUpgraderXY
xcopy /Y /I /E "$(TargetDir)Upgrades.json" $(ProgramData)\BHoM\Upgrades\BHoMUpgraderXY
```

Where again `XY` refers to the project milestone.

#### JSON Upgrades

This file should be fixed after a milestone is completed, so if you're adding a project for a past milestone, simply add your versioning to the existing BHoM JSON Upgrades file for that milestone and add it to your project.

### Adding references

Add references to `$(ProgramData)\BHoM\Upgrades\BHoMUpgraderXY\BHoMUpgrader.dll` and `$(ProgramData)\BHoM\Upgrades\BHoMUpgraderXY\BHoMUpgraderXY.dll` - where `XY` refers to the milestone your project targets. Ensure you add the DLLs that correspond to the same versioning version that your project targets.

### Adding the Converter

Add a new file to your project - you can call it whatever you like but we recommend `Converter.cs` so you can map it to the Versioning_Toolkit.

In this file you need to inherit from the Versioning_Toolkit `Converter` class which will come from the `BHoMUpgraderXY.dll` you referenced in the previous step. Ensuring your namespace is the same will help with this. Below is an example empty class you can copy into your `Converter` class.

```
namespace BH.Upgrader.v72
{
    public class YourToolConverter : Converter
    {
        public YourToolConverter() : base()
        {

        }
    }
}

```

In this example, the 7.2 `Converter` class is being inherited from. In here you can add versioning as you would to the BHoM versioning toolkit as outlined [here](https://bhom.xyz/documentation/Guides-and-Tutorials/Coding-with-BHoM/Versioning/versioning-guide/#structural-changes-to-a-a-class).

### Adding the program

You will likely have had a `Program.cs` file added automatically - if you don't then add one now. If you do have one, ensure the namespace matches for your project, and then paste this code into it:

```
namespace BH.Upgrader.v72
{
    static class Program
    {
        /***************************************************/
        /**** Entry Methods                             ****/
        /***************************************************/

        static void Main(string[] args)
        {
            if (args.Length == 0)
                return;

            Base.Upgrader upgrader = new Base.Upgrader();
            upgrader.ProcessingLoop(args[0], new YourToolConverter());
        }

        /***************************************************/
    }
}
```

This will be the entry point for Versioning_Engine to run your versioning upgrader later.

### Add your upgrades JSON file

Ensure your `Upgrades.json` file is added to the project, and that the `Copy to Output Directory` file property is set to `Copy Always`.

This file can be empty (if a new milestone project) or contain existing versioning JSON (from BHoM or combined with your own) depending on your circumstances.

### Compile

Compile the project - you shouldn't encounter any errors and you should find that your `BHoMUpgrader` will have overwritten the BHoM `BHoMUpgrader` in the `$(ProgramData)\BHoM\Upgrades\BHoMUpgraderXY` folder.

## Complete

Once you've reached this step, you will have your own versioning toolkit which you can add custom versioning to and it will work with the BHoM ecosystem.

Any versioning for BHoM objects/methods/datasets will happen in BHoM's Versioning_Toolkit, so using this methodology will prevent you needing to keep an update of our versioning alongside your own. As mentioned, we encourage sharing knowledge back with the BHoM community if you are building off our toolkits, but if you need to have your own private versioning within our ecosystem, hopefully this documentation will aid you with that.