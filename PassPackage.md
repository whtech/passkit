# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# How is a Pass generated #

Passes are created by providing data in a package that contains the Pass.  The package describes the contents of the Pass and allows some control over the visual appearance.

Technically this Pass package is a bundle of files:
  1. A main text file, in a prescribed format, that holds the Pass content and formatting information (e.g. Pass Type, text alignment etc..)
  1. Images
  1. Alternative text and images suitable for different languages

In addition, each Pass contains a manifest that list the contents of each Pass and a digital signature that authenticates both Pass information and images.

Passes can be updated after they have been distributed by using a push notification; instructing the device that a new version of the pass is available.

PassKit's simple and intuitive web interface enables you to quickly and easily generate and update these bundles, conforming to Apple's requirements


---


<table border='0'>
<blockquote><tr>
<blockquote><td width='361'></td>
<td width='353'><a href='http://PassKit.com/'>PassKit Home Page</a></td>
<td width='128'><a href='https://create.passkit.com'>Register with PassKit</a></td>
</blockquote></tr>
</table>