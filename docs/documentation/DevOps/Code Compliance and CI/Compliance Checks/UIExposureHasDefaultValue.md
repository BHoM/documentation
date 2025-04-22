## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/main/CodeComplianceTest_Engine/Query/Checks/UIExposureHasDefaultValue.cs)

## Details

This check ensures that if you have set any `Input` attributes to have `UIExposure.Hidden`, they have default values for the parameters.

This is because inputs which are being hidden from the UI are unable to be given inputs by users, so suitable defaults must be provided if the input is to be hidden from a UI but accessible within code-use.

An example of the check failing is given below.

```
[Input("environmentObject", "Any object implementing the IEnvironmentObject interface that can have its tilt queried.")]
[Input("distanceTolerance", "Distance tolerance for calculating discontinuity points, default is set to BH.oM.Geometry.Tolerance.Distance.", UIExposure.Hidden)]
[Input("angleTolerance", "Angle tolerance for calculating discontinuity points, default is set to the value defined by BH.oM.Geometry.Tolerance.Angle.", UIExposure.Hidden)]
public static double SomeMethod(this IEnvironmentObject environmentObject, double distanceTolerance, double angleTolerance = BH.oM.Geometry.Tolerance.Angle)
{
    return 0.0;
}

```

In this example, the second `Input` for `distanceTolerance` does not have a default value set, while `angleTolerance` does.

To correct this, we need to give a default value to `distanceTolerance`, or remove the desire to have `UIExposure.Hidden` on the input.