# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Constraints of each Pass Type #

The way in which different Pass types look is determined by Apple.  The main constraints are the types and location of images that can be used and the number and location of the (text) fields.

The [Pass Designer](https://create.passkit.com) will only allow you to input the correct images and text, depending on what Pass Type you choose.

For specific Pass Type examples and layout diagrams please visit the following pages:

  * [Transport](PassLayoutTransport.md)
  * [Coupon](PassLayoutCoupon.md)
  * [Store Card](PassLayoutStoreCard.md)
  * [Membership](PassLayoutMembership.md)
  * [Event Ticket](PassLayoutEvent.md)

## Image Constraints ##

The Pass Type determines which images can be used

| **Pass Type** | **Authorized Images** |
|:--------------|:----------------------|
| [Transport](PassLayoutTransport.md) | Icon, Logo, Footer    |
| [Coupon](PassLayoutCoupon.md) | Icon, Logo, Strip     |
| [Store Card](PassLayoutStoreCard.md) | Icon, Logo, Strip     |
| [Membership](PassLayoutMembership.md) | Icon, Logo, Thumbnail |
| [Event Ticket](PassLayoutEvent.md) (with background image) | Icon, Logo, Background, Thumbnail |
| [Event Ticket](PassLayoutEvent.md) (with strip image) | Icon, Logo, Strip     |

## Field Constraints ##

The Pass Type determines the maximum number of fields that can appear on the front of a Pass. In general, pass can have:
  * Up to 3 header fields
  * 1 primary field
  * Up to 4 secondary fields
  * Up to 4 auxiliary fields.

Specifically there are differences as summarised below:

| **Pass Type** | **Field Constraints** |
|:--------------|:----------------------|
| [Transport](PassLayoutTransport.md) | Up to 2 primary field and Up to 5 Auxiliary Fields|
| [Coupon](PassLayoutCoupon.md) | Up to 4 secondary fields and 4 auxiliary fields |
| [Store Card](PassLayoutStoreCard.md) | Up to 4 secondary fields and 4 auxiliary fields |
| [Membership](PassLayoutMembership.md) | No auxiliary fields (when a square barcode) |
| [Event Ticket](PassLayoutEvent.md) | No auxiliary fields (with a background image) |


---


<table border='0'>
<blockquote><tr>
<blockquote><td width='361'></td>
<td width='353'><a href='http://PassKit.com/'>PassKit Home Page</a></td>
<td width='128'><a href='https://create.passkit.com'>Register with PassKit</a></td>
</blockquote></tr>
</table>