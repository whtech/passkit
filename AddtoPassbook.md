# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Adding a Pass to Passbook #

## No input required from the user ##

If you have designed a Pass with no dynamic fields then when the user receive the Pass they will be instantly presented with the Pass

### _Add to Passbook in iPhone / iPod Touch_ ###

If they are accessing the Pass on their iOS6 enabled device (not including iPad) they will be presented their Pass, with an 'Add' button in the top right corner.

Here's an example

![http://passkit.googlecode.com/files/All-static-data-add-to-passbook-in-iPhone.png](http://passkit.googlecode.com/files/All-static-data-add-to-passbook-in-iPhone.png)

### _Add to Passbook in Safari 10.8.2 and above_ ###

If they are accessing the Pass on Safari (version 10.8.2 and above) they will be presented with an image of the Pass with the option to 'Add to Passbook'.  When the user clicks it will fly off the screen and will then appear in the user's iPhone.  This only happens when the user has iCloud and has linked their Mac with the iDevice.

![http://passkit.googlecode.com/files/All-static-data-add-to-passbook-safari.png](http://passkit.googlecode.com/files/All-static-data-add-to-passbook-safari.png)

## Input required from the user ##

If you have designed a Pass with dynamic data then when your user will be presented with an input screen, which they need to complete before they can add the Pass to Passbook.

### _Add to Passbook in iPhone / iPod Touch_ ###

If they are accessing the Pass on their iOS6 enabled device (not including iPad) they will be presented with the fields to complete (fields you selected as 'Dynamic' in the Pass Designer).  The then click 'Add to Passbook' which will then generate their Pass with their input, display it on the screen and then they can click Add.

![http://passkit.googlecode.com/files/Dynamic-data-add-to-passbook-in-iPhone.png](http://passkit.googlecode.com/files/Dynamic-data-add-to-passbook-in-iPhone.png)

### _Add to Passbook in Safari 10.8.2 and above_ ###

If they are accessing the Pass on Safari (version 10.8.2 and above) they will be asked to input their information (for the fields you selected as 'Dynamic').  When the user clicks 'Add to Passbook', the Pass will be simulated in the browser window and have the option to add to Passbook (as above).

![http://passkit.googlecode.com/files/Dynamic-data-add-to-passbook-in-Safari.png](http://passkit.googlecode.com/files/Dynamic-data-add-to-passbook-in-Safari.png)


---


<table border='0'>
<blockquote><tr>
<blockquote><td width='361'></td>
<td width='353'><a href='http://PassKit.com/'>PassKit Home Page</a></td>
<td width='128'><a href='https://create.passkit.com'>Register with PassKit</a></td>
</blockquote></tr>
</table>