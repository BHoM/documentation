## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/DynamicChecks/IsValidDataset.cs)

## Details

Datasets should be stored as valid BHoM JSON objects within a `Dataset` folder of a repository/toolkit. Dataset files should contain only one serialised dataset object (from [BH.oM.Data.Library.Dataset](https://github.com/BHoM/BHoM/blob/master/Data_oM/Library/Dataset.cs) ).

This test will take the JSON file and attempt to deserialise it back to a `Dataset` object. If the deserialisation fails, the error will be reported.

### Warnings

The check will also interrogate the source information for the dataset and ensure:

 - That source information exists
 - That an author has been provided for the source
 - That a title has been provided for the source

If any of these conditions is not met, a warning will be returned. A warning will not prohibit the Pull Request from being merged, but it may be prudent to address the issues to provide confidence in the source of the dataset.