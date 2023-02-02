# Editing the documentation 

This documentation is simply a set of Markdown documents, stored and organised in the [Documentation repository](https://github.com/BHoM/documentation).
The markdown documents are then automatically mapped to a web page every time a Push to the main branch of the Documentation repository is done. See below for technical details on how this is achieved.

Depending on your account permissions, you should be able to commit directly to `main`, or a Pull Request will be required to perform the changes.

### Minor modifications
For small modifications, you can **click the pencil** ✏️ icon on the top-right of the page. This will bring you to the Github Markdown editor. 

Avoid this for non-minor changes. Limit this approach to e.g. correcting typos, rephrasing sentences for clarity, adding short sentences, fixing URLs.

### General modifications
In order to edit the documentation, you need to:

1. Clone the [documentation repository](https://github.com/BHoM/documentation) on your machine
1. Navigate to the `docs` folder, and edit a markdown file or add new markdown files.  

## The enhanced markdown
The documentation markdown can incorporate non-markdown content. You can embed:

- HTML blocks with embedded functionality, e.g. (click on `details` to see!):
  <details>
  
  <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d158857.7281078492!2d-0.2416804375114147!3d51.52877184053824!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x47d8a00baf21de75%3A0x52963a5addd52a99!2sLondon!5e0!3m2!1sen!2suk!4v1675252817914!5m2!1sen!2suk" width="100% - 200px" height="500" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
  
  </details>

- Latex/Mathjax, e.g. $f(x) = x^2$ (enclose the formula between single `$` for inline and double `$$` for block).

  

!!! tip

    Many more features are available to spice up the look of the documentation and help you convey information.
    See the available customisations of [Material for Mkdocs: setup](https://squidfunk.github.io/mkdocs-material/setup/changing-the-colors/) and [Markdocs extra elements](https://squidfunk.github.io/mkdocs-material/reference/).

## Using a text editor to edit the documentation

We recommend using either Visual Studio Code or Markdown Monster to edit the documentation. 

With Visual Studio Code you can [preview the markdown](https://code.visualstudio.com/docs/languages/markdown#_dynamic-previews-and-preview-locking) while editing.

## Adding pages
If you want to add a page, just add an new markdown document. 

The first H1 header (`#`) of the page will be taken as the title of the corresponding webpage.

Each header will be reflected in the navigation menu on the right hand side of the page.

## Linking to other documentation pages

### Recommended way
Links to other documentation pages should be relative URLs (starting with a `/`) where the first slash must be followed with the `documentation` folder. Some examples:

- To link to the [Introduction to BHoM_Adapter](/documentation/BHoM_Adapter/Introduction-to-the-BHoM_Adapter) page, you can provide this link: `/documentation/BHoM_Adapter/Introduction-to-the-BHoM_Adapter`.
- To link to the [IsValidDataset](/documentation/DevOps/Code%20Compliance%20and%20CI/Compliance%20Checks/IsValidDataset) page, you can provide this link: `/documentation/DevOps/Code%20Compliance%20and%20CI/Compliance%20Checks/IsValidDataset`.

!!! note

    This way of providing URL to pages is required because MkDocs reflects the markdown files starting from the root `documentation`.

### Alternative (not recommended)
If you are editing a specific nested page you can also use URLs relative to the current page. Some examples:
- To link to the [Getting started for developers](../Getting-started-for-developers) page, relative to this current page (Editing-the-documentation), you can provide: `../Getting-started-for-developers`.


## Folders
Folders behave as groups for sub-pages and are reflected into the left menu of the website.

A folder may contain one markdown file called `index.md`; if it exists, that file is taken to be the first page of the folder when viewed from the website.

For information on how to sort the pages, [see below](#customising-the-ordering-of-the-pages-in-the-menu).


## Previewing the website before pushing to the repository

You may want to preview how your markdown documents will appear in the automatically-generated website. In order to do this, you can use [mkdocs](https://www.mkdocs.org/) from command line.

You need to:

1. Have Python and PIP installed on your machine. Install `mkdocs` by running `pip install mkdocs`.
2. Navigate to your locally cloned `documentation` repository folder.
3. In that location, invoke from command line:  
  `python -m mkdocs serve`.

Mkdocs should spin up a local server and you should be able to connect to `http://localhost:8000/` in your browser to display the documentation website. Any change to your local file will be hot-reloaded into the webpage.


## Website configurations

As mentioned, the Markdown documents are transformed into a proper web page thanks to [mkdocs](https://www.mkdocs.org/) every time a Push to the main branch of the [documentation repository](https://github.com/BHoM/documentation) is done. 

The web page can be configured by configuring mkdocs and related dependencies.

### Dependencies
On top of [mkdocs](https://www.mkdocs.org/), we also use:

- an extender theme called [Material for Mkdocs](https://squidfunk.github.io/mkdocs-material/), which exposes more customisation and [extra functionality](https://squidfunk.github.io/mkdocs-material/reference/).
- a plugin for customising the sorting of the pages: [mkdocs awesome pages plugin](https://github.com/lukasgeiter/mkdocs-awesome-pages-plugin)


### Customising the ordering of the pages in the menu

You just need to add a `.pages` text file in the specific folder where you want to sort out your pages. For an example, see the `.pages` file in the `docs` folder.

You can edit the `.page` file according to [mkdocs awesome pages plugin](https://github.com/lukasgeiter/mkdocs-awesome-pages-plugin#customize-navigation).

### Customising the appearance of the documentation

See the available customisations of [Material for Mkdocs](https://squidfunk.github.io/): [setup](https://squidfunk.github.io/mkdocs-material/setup/changing-the-colors/) and [extra elements](https://squidfunk.github.io/mkdocs-material/reference/).


## Github actions configuration
Every time a push to this repository is done, a GitHub action kicks in and calls:

- [mkdocs](https://www.mkdocs.org/) functionality to transform markdown to HTML
- [mkdocs-material](https://squidfunk.github.io/mkdocs-material) functionality, which expands the markdown translation of mkdocs with more features
- [mkdocs awesome pages plugin](https://github.com/lukasgeiter/mkdocs-awesome-pages-plugin) functionality, which gives extra configs on top of mkdocs.

The actions are configured as described in https://squidfunk.github.io/mkdocs-material/publishing-your-site/.
