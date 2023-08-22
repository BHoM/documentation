# How to check your versioned changes are working ?
## To check the upgrade of a Property, Type or Namespace upgrade. 

1. Before making any changes create an object from the Toolkit that will be upgraded.
1. Use `ToJson` to create a JSON string of the object.
1. Save a copy of that string.
1. Make changes to the code and add versioning.
1. Rebuild your Toolkit and the Versioning_Toolkit.
1. Use `ToNewVersion` to and verify the output to check the upgrade worked.