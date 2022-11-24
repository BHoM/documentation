# Check Unit Tests

This check will confirm the unit tests set up within a `.ci/Datasets` folder on a repository run successfully using the Unit Test framework.

The check will clone the repository associated to the pull request, and its dependencies listed within the `dependencies.txt` file, and compile all of them to get the relevant DLLs. Once the DLLs are generated, the unit tests will then run and compare the serialised results against the results coming out from the pull request.

The result of a unit test check may require further investigation and interpretation by a human reviewer.

If the check passes, then the unit tests serialised and the results from the pull request match exactly.

If the check fails, then it means the check found differences between the serialised results, and the new results. This is where investigation may be needed, as some differences may be failures (where the pull request is negatively impacting the result), but some differences may be improvements (where the pull request is making outcomes better compared to the serialised results which are made against a version of `master` that the toolkit leads are happy with).

If the check fails, but is providing better results and a human review agrees that the pull request is improving the standard, then it is recommended to update the unit tests against `master` after merging the pull request as soon as possible to ensure that version of results are stored for future pull requests. Unit tests can be updated on the pull request itself if agreed by the toolkit lead.

***

### Trigger commands:

**BHoMBot**
>`@BHoMBot check unit-tests`

***