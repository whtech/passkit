# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# The Back of the Pass #

As detailed in the previous section the content displayed on front of the Pass is finite; ie the number of fields are limited, and the content needs to be brief, so that all of the front of the Pass can fit in one screen. On the Back of the Pass you can have as many fields as needed and the content can be much longer.

If there is too much content to fit on one screen the user can simply scroll through it.

Each back field is comprised of 3 components as with the fields on the front:
  * ID
  * Label
  * Data

The Pass displays the value and label fields. Longer text and additional information can be put here, such as terms and conditions, addresses, and website URLs.  The more text in each field, the smaller the font size.  Issuers can add as many back fields as they desire.

The text of the back fields is run through data detectors for URLs and phone numbers, which appear as live links in Passbook. (Note that the [Pass Designer](https://create.passkit.com) will not show the live links). Users can simply tap on these live links in Passbook and directly launch Safari and be taken to the URL, or call the phone number.

While not possible to provide a link to an app in the Pass Designer you can do so using the PassKit API.


---


<table border='0'>
<blockquote><tr>
<blockquote><td width='361'></td>
<td width='353'><a href='http://PassKit.com/'>PassKit Home Page</a></td>
<td width='128'><a href='https://create.passkit.com'>Register with PassKit</a></td>
</blockquote></tr>
</table>