## Introduction

The change log is made by aggregating the notes from Pull Requests for each repository within the organisation. They are available [here](https://github.com/BHoM/documentation/releases)


## Pull requests

To simplify the managing of the changelog it is best practice to note what has changed at the time of a pull request. The change log will be generated from the title and body of the pull request using the [PULL_REQUEST_TEMPLATE](https://github.com/BHoM/BHoM/blob/master/docs/PULL_REQUEST_TEMPLATE).

The Pull Request Title should state, in a simple sentence, what the Pull Request is changing. For toolkits, this should not include the toolkit title, however, for multi-project repositories it should. For example:

A Pull Request raised on the XML Toolkit to update Space Type will simply have the title of:
 - Update Space Type  

Whereas a Pull Request on the BHoM_Engine to update the Environment Engine panel query will have the title of:
 - Environment_Engine: Update panel query to use names

If the changes are greater than a single sentence can describe, then in the Changelog section, describe the changes in a bulleted list. 
The bullet points are required and no other information other than brief definition of changes should be made in this section. The `Additional Comments` section is then for any additional information or more verbose context.

For example:

```
### Changelog

- `Query.Tangent()` Query method added in the `Structure_Engine` for `Bar` class
```

The entries made here will be mined for the next release and added to the changelog in one go.

Pull requests must also have a label defining their `type` - either feature, bug fix, test script, documentation, compliance, or other approved type of pull request. This is to aid categorisation of pull requests for the change log. Where a pull request might span multiple types (for example, a pull request adding a new feature and fixing a bug in the same work), then multiple type labels may be applied.
