# Pull from links

It is possible to pull elements directly from Revit link documents, in the coordinate system of the host model. This can be achieved using `FilterByLink` request combined with other filters using the `LogicalAndRequest`. For example, the script below would pull all beams from the link named _MyLinkDocument_.

[![Pull from link in Grasshopper](https://user-images.githubusercontent.com/26874773/112680469-b38eed00-8e6d-11eb-8864-7bc54962edd0.png)](https://user-images.githubusercontent.com/26874773/112680469-b38eed00-8e6d-11eb-8864-7bc54962edd0.png)

Please note that pulling from link has a few limitations caused by the way in which Revit works:

- it is impossible to pull selection from link
- it is impossible to filter link elements by visibility in view
- pull of walls/floors/roofs as well as doors/windows uses different method of extracting their geometry, which may lead to slight degradation of the output
