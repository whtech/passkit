# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Choosing the style and contents of the Barcode #

The PassKit server contains all the up-to-date records, and the Passbook pass is simply a copy of those records from sometime in the past.  Barcodes are most frequently used as a unique ID that directs to the records on the PassKit server.  This enables you to consult the PassKit server to, for example:
  * update a balance;
  * void a coupon or;
  * confirm that a ticket is valid.

## Barcode Format ##

Apple Passbook currently supports 3 Types of Barcode:
  * [PDF417](http://en.wikipedia.org/wiki/PDF417)
  * [QR Code](http://en.wikipedia.org/wiki/Qr_code)
  * [Aztec](http://en.wikipedia.org/wiki/Aztec_Code)

The Pass Designer allows you to select which Barcode Format you wish you use.  Please note that this is not a constraint of PassKit or the Pass Designer.  This is a constraint of placed by Apple in the Passbook App. According to Apple "these three 2D Barcodes are the most popular and scan best".

If you urgently need to use another type of Barcode (for example, if your existing scanning equipment only works with a certain format) you may consider uploading an image of a barcode into the Pass itself (eg as a Strip Image in a Event Ticket).  Of course this means you will not be able to have another image on the pass. Refer to Pass Constraints for more information.

If you would like Apple to consider other Barcode formats in Passbook we suggest you request an enhancement direct to Apple.  Please visit https://developer.apple.com/bugreporter/

If future Passbook release supports other Barcode formats, PassKit will of course support.

## Barcode Message ##

The Pass Designer allows you to choose from the available Barcode encoding formats, and will adjust the Pass layout accordingly. You provide a message that will be encoded within the Barcode. This can be:
  * Unique to each Pass - you would use this for a Store Card where you want to identify the individual Pass holder or;
  * Common for each Pass - you might use this a coupon where you just need to check that the coupon is valid).

## Message encoding ##

The message encoded in the Barcode is just data, there’s nothing that limits you from using it to carry additional information.

For example, suppose you need to scan a pass when network access is not possible (perhaps onboard a ship). This would make it impossible to communicate with the PassKit server in real time. You can sign the data you need with a private key, and use the result as a barcode. Although this approach doesn’t let you impose a one-time-use pass, it could be useful where passes are valid for a predictable period of time.

## Alternative Message ##

Optionally you can include alternate text that is displayed immediately below the barcode. You can enter whatever you want here but it’s common to display the barcode number, or the unique identifier that you want your staff to key in to the Point of Sales terminal, just in case the scanning equipment doesn’t work.

## Test your Passes in the conditions you expect your customers to use it ##

The amount of data that you include in a barcode depends on the barcode format and the conditions for scanning. The barcode format defines a hard maximum but scanning conditions often lower this limit. eg a PDF417 Barcode on a non-Retina iPhone under poor lighting conditions, scanned by an inexpensive scanner.

Test your passes in real-world conditions on multiple devices to ensure barcode scanning reliability.


---


<table border='0'>
<blockquote><tr>
<blockquote><td width='361'></td>
<td width='353'><a href='http://PassKit.com/'>PassKit Home Page</a></td>
<td width='128'><a href='https://create.passkit.com'>Register with PassKit</a></td>
</blockquote></tr>
</table>