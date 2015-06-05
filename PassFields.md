# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Text fields on a Pass #

The information shown on the Pass is broken up into fields.  A field refers to the information that is displayed on a pass. Each field contains a value and label, and a unique identifier (or key) and additional formatting information. The label and value fields are displayed on the Pass.

For example:

  * "ID" : "Passenger name"
  * "Label" : "Passenger"
  * "Value" : "Percy Passkit"

Only the label and value fields "Passenger" and "Percy Passkit" will appear on the pass. The ID helps the pass issuer identify the field

The [Pass Designer](https://create.passkit.com) allows you to identify each field that is allowed by Pass Type and you simply enter the ID, Label and Value appropriate for the pass.

## Field names ##

Using the [Pass Designer](https://create.passkit.com) you don't have to worry about the field names, but if you are not using the Pass Designer tool and creating Pass Templates with the PassKit API you do need to know the field names:

  * Logo Text - this is the only field that does not have an ID or a Label.  It's just a value
  * Header Fields - should contain highly salient information, and they are the only field that is visible when the passes are stacked up in Passbook.  You should use them wisely.
  * Primary Fields - contain the most important information and are prominent on the Pass
  * Secondary Fields- are less important and therefore less prominent
  * Auxiliary Fields - and you've guess it, these fields are even less important and less prominent on the pass

The beauty of using the [Pass Designer](https://create.passkit.com) is you can quickly and easily see how the Pass will look when you generate and distribute.  You don't have to worry about learning the names of these fields, other than when you are using the API.

## Ordering of field name ##

This not relevant for the [Pass Designer](https://create.passkit.com), as what you see is what you get.  But when using the PassKit API it is important that you order within the field list as this will determine how it appears on the Pass. For example, putting the primary fields before or after the secondary fields doesn't change where the primary and secondary will appear as this is fixed by the Pass Type template. However if you put 'Cardholder Name' before or after 'Balance' the ordering of those 2 fields on the pass will change.  This is because the ID/value pairs are not ordered but lists are.


---


<table border='0'>
<blockquote><tr>
<blockquote><td width='361'></td>
<td width='353'><a href='http://PassKit.com/'>PassKit Home Page</a></td>
<td width='128'><a href='https://create.passkit.com'>Register with PassKit</a></td>
</blockquote></tr>
</table>