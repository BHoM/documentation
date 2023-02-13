# Posting test files

Posting test files in GitHub Issues and Pull Requests (PR) is important, because they allow to reproduce the problem you may have or the feature being implemented.

Please remember that there are also other means of testing the code (e.g. code Unit tests; automated Data-driven equality unit tests), so some PRs may not expose any test file. However, if you only know how to reproduce your issue or wanted feature via a script (e.g. a Grasshopper script), or if you think that the PR/issue would benefit from it, then you should post it in the body of your issue (or PR, where applicable).

## How to post a test file
- Create your test script (e.g. in Grasshopper).
- Save your test script in a file.
- Zip your test script file.
- Drag and drop the test script file in the body of the GitHub issue or PR.


## Large test files
The zipped test file must be less than 50 MB (GitHub size limit), and in general should be less than 10 MB.
If your test file is larger than that, it means that you've embedded (internalised) too much testing data. You should simplify the test script to use the minimal amount of data necessary to reproduce the problem.
If your test script purposedly targets a large model, then the script should only hold a reference to such model (e.g. a link to it) and the model should be uploaded via another file hosting service.