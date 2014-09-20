#General

This is a relatively straightforward dojo, which should be appropriate for beginners and advanced users.

The dojo is written to lead to one goal: use all the pixels of one image and re-arrange them to reconstruct something that looks like another image; however, it is also meant to be somewhat free-form, and encourage people to find creative ways to manipulate images. [This page][Picasso-Velasquez-reconstruction] shows an example reconstructing a Picasso painting using pixels from a Velasquez, and vice-versa (hence the title of the dojo, mashing up the two painters names).

The folder Dojo contains a [guided script][Guided-script] which is guiding participants through the problem. Participants should either clone or download the entire folder, because it also depends on the [paintings folder][Paintings-folder], which contains a couple of classic paintings that are used as examples.

The dojo is broken in 4 steps:

* Steps 1 and 2 are meant as an introduction to using Bitmaps, creating and saving images and manipulating their colors.
* Step 3 introduces the idea of mixing / mashing up images.
* Step 4 describes one possible way to re-arrange pixels from 1 image to another one, similar to what was done for the Picasso/Velasquez mashup.

There are plenty of other creative things people can do with images; the dojo is not very prescriptive. Here is an example of what [people created][[Warhol-Velasquez-mashup]. 

**Encourage people to Tweet or share images of their work, using the hashtag #fsharp!**

If the group is not too large, this is a good dojo to have a show-and-tell at the end: reserve 30 minutes at the end of the session, and have people show the result of their work, as well as their code. Comparing what directions people took, and what problems they had, is often quite interesting!

#Potential problems

The images are save in a folder named "masterpieces", to avoid over-writing existing images

Most paintings have been resized to be of equal width and height. However, some images are of different formats (Klimt and Warhol are 500x500, all the others 400x472)

**Please let us know if you have ideas/suggestions on how to make this better!**


[Picasso-Velasquez-reconstruction]: http://clear-lines.com/blog/post/Picasquez-vs-Velasso-Classics-Mashup-with-FSharp.aspx "reconstructing one painting from another"

[Guided-script]: https://github.com/c4fsharp/Dojo-Picasquez-and-Velasso/blob/master/dojo/Script.fsx "guided script" 

[Paintings-folder]: https://github.com/c4fsharp/Dojo-Picasquez-and-Velasso/tree/master/dojo/paintings "paintings"

[Warhol-Velasquez-mashup]: https://twitter.com/orlandpm/status/510483892889845761 "Warhol/Velasquez mashup"