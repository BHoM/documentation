# Check Core

This check will confirm the pull request will compile successfully on its own. This check is operated by both BHoMBot (all repositories) and Azure DevOps (selected repositories).

The check will clone the repository associated to the pull request, then clone the repositories listed in that repositories `dependencies.txt` file and build them in the order listed in that file. The pull request will then be built last.

Providing the compilation is successful, the check will return a pass. If the pull request cannot compile then it will return an error. BHoMBot will list the errors as annotations, while Azure needs to be reviewed to ascertain the errors.

***

### Trigger commands:

**BHoMBot**
>`@BHoMBot check core`

**Azure DevOps**>`/azp run <Your_Toolkit>.CheckCore`

(where `<Your_Toolkit>` is the name of your repository).


***