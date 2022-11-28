# Editing the documentation 

This documentation is simply a set of Markdown documents.
The markdown documents are then automatically mapped to a web page every time a Push to the main branch of the [documentation repository](https://github.com/BHoM/documentation) is done. See below for technical details on how this is achieved.

In order to edit the documentation, you just need to:

1. Clone the [documentation repository](https://github.com/BHoM/documentation) on your machine
1. Navigate to the `docs` folder, and edit a markdown file or add new markdown files.  
You can also group markdown files in folders, see below.

Alternatively, for small modifications, you can **click the pencil** ✏️ icon on the top-right of the page. This will bring you to the Github Markdown editor. Avoid this for large changes.

Depending on your account permissions, you should be able to commit directly to `main`, or a Pull Request will be required to perform the changes.

## The enhanced markdown
The documentation markdown can incorporate non-markdown content. You can embed:

- HTML blocks with embedded functionality, e.g. (click on `details` to see!):
  <details> 
  <iframe height="500px" width="100% - 200px"  src="https://service.tib.eu/webvowl/#url=https://raw.githubusercontent.com/BHoM/RDF_Prototypes/main/WebVOWLOntology/BH.oM.Base.json" frameborder="0" allowfullscreen></iframe>
  </details>

- Latex/Mathjax, e.g. $f(x) = x^2$ (enclose the formula between single `$` for inline and double `$$` for block).

  

!!! tip

    Many more features are available to spice up the look of the documentation and help you convey information.  
    Have a look at [Customising the appearance of the documentation](#customising-the-appearance-of-the-documentation) below for more info.

## Using a text editor to edit the documentation

We recommend using either Visual Studio Code or Markdown Monster to edit the documentation. 

With Visual Studio Code you can [preview the markdown](https://code.visualstudio.com/docs/languages/markdown#_dynamic-previews-and-preview-locking) while editing.

## Adding pages
If you want to add a page, just add an new markdown document. 

The first H1 header (`#`) of the page will be taken as the title of the corresponding webpage.

Each header will be reflected in the navigation menu on the right hand side of the page.

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

Check the `.pages` file in the `docs` folder.

You can customise it according to [mkdocs awesome pages plugin](https://github.com/lukasgeiter/mkdocs-awesome-pages-plugin).

### Customising the appearance of the documentation

See the available customisations of [Material for Mkdocs](https://squidfunk.github.io/): [setup](https://squidfunk.github.io/mkdocs-material/setup/changing-the-colors/) and [extra elements](https://squidfunk.github.io/mkdocs-material/reference/).


## Github actions configuration
Every time a push to this repository is done, a GitHub action kicks in and calls:

- [mkdocs](https://www.mkdocs.org/) functionality to transform markdown to HTML
- [mkdocs-material](https://squidfunk.github.io/mkdocs-material) functionality, which expands the markdown translation of mkdocs with more features
- [mkdocs awesome pages plugin](https://github.com/lukasgeiter/mkdocs-awesome-pages-plugin) functionality, which gives extra configs on top of mkdocs.

The actions are configured as described in https://squidfunk.github.io/mkdocs-material/publishing-your-site/.
