## Summary

**Severity** - Warning

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/main/CodeComplianceTest_Engine/Query/Checks/HiddenInputsAreLast.cs)

## Details

This check ensures that if you have set any `Input` attributes to have `UIExposure.Hidden`, they are the last parameters in the list of the method.

This is because inputs which are being hidden from the UI are likely to be of a lower priority than those being displayed, and should not get higher precedence in the method signature, particularly when displaying the method to users.

This is however just a warning, and final say will rest with the relevant maintainers of the repository.

An example of the check failing is given below.

```
[Input("environmentObject", "Any object implementing the IEnvironmentObject interface that can have its tilt queried.")]
[Input("distanceTolerance", "Distance tolerance for calculating discontinuity points, default is set to BH.oM.Geometry.Tolerance.Distance.", UIExposure.Hidden)]
[Input("angleTolerance", "Angle tolerance for calculating discontinuity points, default is set to the value defined by BH.oM.Geometry.Tolerance.Angle.")]
public static double SomeMethod(this IEnvironmentObject environmentObject, double distanceTolerance = BH.oM.Geometry.Tolerance.Distance, double angleTolerance = BH.oM.Geometry.Tolerance.Angle)
{
    return 0.0;
}

```

In this example, the second `Input` attribute for `distanceTolerance` is setting the `UIExposure` to be `Hidden`, but the third method parameter, `angleTolerance`, does not have the same `UIExposure` (the default being `Display`). This would flag with this compliance check.

To correct this, we can either set `angleTolerance` to also have a `UIExposure.Hidden`, or change the tolerances around so that `angleTolerance` comes before `distanceTolerance` in the argument list.