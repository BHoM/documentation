## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/HasSingleNamespace.cs)

## Details

The `HasSingleNamespace` check makes sure only one namespace is declared in a given file.

For example, the file below would fail because it is declaring two namespaces within the file.

```
namespace BH.Engine.Test
{
}

namespace BH.Engine.Environment
{
}
```