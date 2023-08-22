# Merge Teams

Merge teams are set up to deploy code to protected branches (`main` or `develop` in most cases) following a successful Pull Request review process.

Merge teams are managed by DevOps, and inclusion or exclusion from a team may occur at any time.

Merge teams will be reviewed at regular intervals to ensure they are up to date and reflective of the current development needs.

## Creating a merge team

Creation of a merge team should be done when a repository is created, regardless of whether that repository requires Pull Request reviews or not. The merge team should be named the same as the repository they will be collaborators for. Discipline level teams may be created if approved by DevOps to handle multiple repositories, but this should be in addition to a specific merge team for that repository.

## Adding people to a merge team

A request should be made to DevOps to add an individual to a merge team. Merging Pull Requests is a responsible action which results in code being potentially deployed via Alpha or Beta installers. As such, people who are merging Pull Requests need to be competent in discharging this duty. DevOps is responsible for determining whether an individual is competent in this role and can be added to a merge team. The decision of DevOps is final, however, individuals may make future requests to be added to merge teams and previous prohibition will not be a detrimental factor in a subsequent decision. DevOps will ask individuals to prove competency in a manner appropriate at the time of the request, but will include a review of procedures and policies to ensure the individual understands the broader development picture, as well as the associated risks of merging code.

## Removing people from a merge team

Any individual can request to be removed from a merge team and DevOps will action this as soon as is appropriate without question.

Discipline Code Leads may request individuals to be removed from a merge team they are responsible for.

DevOps may remove any individual from a merge team at any time if appropriate.

## The DevOps Merge Team

The DevOps merge team is a separate team to repository teams, and exists for the purpose of protecting merging to the `main` branch of repositories included in the Beta. Individuals will only be added to this merge team if they are part of the DevOps team.