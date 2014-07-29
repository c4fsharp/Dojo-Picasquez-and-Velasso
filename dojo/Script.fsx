(*
Dojo: Picasquez & Velasso

The goal of this dojo is to have fun with 
images, transforming their colors and creating
hybrids of images.
Part 1 and 2 are more of a warm-up to introduce
useful tools; 3 and further are more free-form,
suggested directions that can be interesting
to explore...
Source code is on GitHub at:

We'd love to hear your feedback/comments! And
we take pull requests, too!

(c) Community for F# (c4fsharp.net, @c4fsharp). 
Use freely, spread the word, attribution 
appreciated ;)
Created by Mathias Brandewinder (@brandewinder),
inspired by a discussion with Tomas Petricek
(@tomaspetricek).
*)

(*
-------------------------------------------------
1. READING & SAVING BITMAP IMAGES
-------------------------------------------------
Using System.Drawing.Bitmap, you can
read and write .bmp files as images
*)

//[TODO] run the code below
open System.IO
open System.Drawing

type Dir = string
type Img = string

let root = __SOURCE_DIRECTORY__
let paintings = Path.Combine(root,"paintings")
let output = Path.Combine(root,"masterpieces")

let img = @"klimt.bmp"

let copy (dir:Dir) (name:Img) = 
    let path = Path.Combine(dir,name)
    let bitmap = new Bitmap(path)
    let newPath = Path.Combine(dir,"copy_" + name)
    bitmap.Save(newPath)
    
copy paintings img

//[TODO]
//check that you have now a copy_klimt.bmp file

(*
-------------------------------------------------
2. TWEAKING PIXELS COLORS
-------------------------------------------------
Using Bitmap.GetPixel(...), Bitmap.SetPixel(...)
you can access and modify pixels from a Bitmap.
GetPixel(x,y) returns the Color of pixel at 
location x and y. Color is encoded as ARGB 
(Alpha, Red, Green, Blue).
*)

//[TODO] run the code below
let tweaker (c:Color) =
    Color.FromArgb(int c.A,int c.B,0,int c.G)

let tweak (from:Dir) (into:Dir) (name:Img) = 
    let path = Path.Combine(from,name) 
    let bitmap = new Bitmap(path)
    let w,h = bitmap.Width, bitmap.Height
    for x in 0 .. (w-1) do
        for y in 0 .. (h-1) do
            let color = bitmap.GetPixel(x,y)
            let tweaked = tweaker color
            bitmap.SetPixel(x,y,tweaked)
    let newPath = Path.Combine(into,"tweak_" + name)
    bitmap.Save(newPath)

tweak paintings output "davinci.bmp"
//[TODO] check the resulting file

//[TODO] try out another tweak?
//Maybe swap each color for another?
//Maybe refactor to inject arbitrary function?

(*
-------------------------------------------------
3. MIXING IMAGES TOGETHER
-------------------------------------------------
Instead of transforming an image simply by
modifying its pixels, we can use the pixels from
an image to transform another one. In essence,
we can create "hybrids" between the two images.
For instance, how about taking every pixel from
our image, but replacing its Red value by the
Blue value in the other image?
To keep things easy here, start with images of
same size...
*)

//[TODO] create a hybrid from these two.
//They have the same width and height; for
//different images you might have to be clever.
let painting1 = @"warhol.bmp"
let painting2 = @"klimt.bmp"

let mixer (c1:Color) (c2:Color) =
    Color.FromArgb(int c1.A,int (max c1.R c2.R),int (max c1.G c2.G),int (max c1.B c2.B))
let hybrid (from:Dir) (into:Dir) (mix:Img) (target:Img) =
    let bitmap = new Bitmap(Path.Combine(from,target) )
    let mix = new Bitmap(Path.Combine(from,mix))
    let w,h = bitmap.Width, bitmap.Height
    for x in 0 .. (w-1) do
        for y in 0 .. (h-1) do
            let origin = bitmap.GetPixel(x,y)
            let noise  = mix.GetPixel(x,y)
            let tweaked = mixer origin noise
            bitmap.SetPixel(x,y,tweaked)
    let newPath = Path.Combine(into,"mixed_" + target)
    bitmap.Save(newPath)

hybrid paintings output painting1 painting2

(*
-------------------------------------------------
4. RECONSTRUCTING ONE IMAGE FROM ANOTHER
-------------------------------------------------
Another possible way to create a hybrid from two
images is to take every pixel from the first, and
try to re-arrange them to replicate the second 
one.
A reasonably easy way to do this is the 
following: 
- take every pixel from image 1 and 2,
- sort them by some metric (ex: how much Red they
contain), 
- replace the color of the first pixel in list 1
by the color of the first pixel in list 2, and do
the same matching every pixel in both lists,
- save the resulting image.
*)

//[TODO] reconstruct painting3 from painting4,
//and vice-versa, painting4 from painting3.
//They have the same width and height; for
//different images you might have to be clever.
let painting3 = @"painting3.bmp"
let painting4 = @"painting4.bmp"

(*
-------------------------------------------------
5. GO WILD! OR PRACTICAL.
-------------------------------------------------
This is what I could think of... but I am sure
there are plenty of other transformations you
could do!
Also... there is a practical problem we have
dodged, and that is images of different
dimensions. How about handling that, too?
Finally, there is likely some repetition in your
code. Can you refactor into composable pieces?
*)