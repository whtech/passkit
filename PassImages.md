# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Uploading your images #

As summarized in Pass Constraints section, each Pass Type prescribes particular areas on the front of the pass for each image. Apple has prescribed a certain size of image dependent on the Pass Type.

PassKit automatically scales these images to fit within each allotted space, preserving aspect ratio, but are cropped if the aspect ratio is different than their allotted space.

## Pass Sizes ##

| Image Type | Position on the Pass | Other notes | iOS7 Minimum Size (pixels) | iOS6 Minimum Size (pixels) |
|:-----------|:---------------------|:------------|:---------------------------|:---------------------------|
| Background Image | Behind the entire front of the pass |Available on the Event Pass Type. The image is cropped slightly on all sides and blurred | 360 x 440                  | 360 x 440                  |
| Footer Image | Above the barcode    | Available on the Transport Pass Type only | 572 x 30                   | 572 x 30                   |
| Icon Image | On the lock screen and by apps like Mail when showing an attached Pass | A shine is automatically applied to the icon for you | 120 x 120                  | 116 x 116                  |
| Logo Image | Displayed in the top left corner of the Pass | In iOS6 the maximum width is 620 pixels and in iOS7 the maximum width is 320 pixels. In most cases it should be narrower.  If you use the full 620 pixel width note you will not have room for any Logo Text, or Header fields. | 350 x 100                  | 620 x 100                  |
| Strip Image | Displayed behind the Primary Fields | In iOS6 a shine effect is applied by default but you can turn this off in the Pass Designer. In iOS7 the shine effect is no longer supported. | Event Tickets: 640 x 168<br />Square Barcode: 640 x 220<br />All other cases: 640 x 246 | Event Tickets: 624 x 168<br />Square Barcode: 624 x 220<br />All other cases: 624 x 246 |

Please note that your images do not have to be exactly these dimensions, as PassKit will automatically crop, scale and optimise them.  However, please check in the [Pass Designer](https://create.passkit.com) that the images appear as you want them to.  We also recommend that once you have saved your pass template you test the pass design in both iOS6 device and iOS7 device.

IMPORTANT: If you upload images that are smaller in size than the dimensions above they will not appear sharp. We strongly recommend you do not use small images.


---


<table border='0'>
<blockquote><tr>
<blockquote><td width='361'></td>
<td width='353'><a href='http://PassKit.com/'>PassKit Home Page</a></td>
<td width='128'><a href='https://create.passkit.com'>Register with PassKit</a></td>
</blockquote></tr>
</table>