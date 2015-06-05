# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Displaying messages on the Lock Screen #

Passes let your customers take some action in the real world, and Passbook makes them easy and fast to access. Passbook integrates with the lock screen so relevant passes are accessible from the lock screen.

A Pass can be relevant at a particular time or place where your customer can redeem it. For example a cup cake coupon is relevant at the Cup Cake Store, and a Ferry Ticket is relevant at the time the Ferry boards.

Via the [Pass Designer](https://create.passkit.com), or PassKit API, you provide a time or place. PassKit encodes this information into the Pass, and Passbook determines the appropriate duration of time and radius in space around these points such that the pass appears on the lock screen.

There are no alerts or buzzes; passes will simply appear on the lock screen. This is in contrast to the notification that is delivered when a Pass is updated.

Pass Designer allows you to easily choose the appropriate location and time.
  * Locations require a longitude and latitude input, along with the optional altitude information.  You can use the map to find a location and zoom in on the exact location.
  * Time is set with a complete date plus hours and minutes, or a complete date plus hours, minutes, and seconds. Pass Designer presents you with a date and time wheel so the date is encoded in the correct format.

## Up to 10 locations ##

Each pass can contain a maximum of 10 locations. (note that this is an Apple Passbook constraint and not a PassKit constraint.  If Apple increases this limit then of course PassKit will allow you to add more locations).

In cases where you have more than 10 stores you have to pick the best 10. There are a variety of ways to do this.
  * Create a number of different Pass Templates for the various groups of customers.  i.e. For your rather than create one Pass Template for all your customers. You can create a Pass Template for your New York based customers and then copy the Template to create another one for your Florida based customers;
  * You could allow customers to add their favorite store or the stores they frequently visit. Or;
  * Like any other fields, the locations can be updated. A Pass could have very generic location information initially, and then replaced over time with relevant locations tailored specifically to your customer.

## Passbook interpretation of time and location ##

Within the Passbook restrictions relevance information is interpreted in moderately different ways. A small radius means that the current location must be on the order of 100 meters or closer, and a large radius 1000 meters or closer.

Do not select an incorrect Pass Type to get a large radius. Not only will this frustrate your customers it could see your Passes revoked.

| Pass Type | Relevant Date | Relevant Locations | Relevance |
|:----------|:--------------|:-------------------|:----------|
| Transport | Optional      | Large radius       | If time or location matches.<br />Without a relevant time, relevant if any location matches |
| Coupon    | Not supported | Small radius       | If any location matches |
| Event Ticket | Required if any relevant locations are specified | Large radius       | When time and location matches |
| Membership | Optional      | Small radius<br />Required if a relevant date is specified | If the time and location matches.<br />Without a relevant time, relevant if any location matches. |
| Store Card | Not supported | Small radius       | If any location matches |

Passbook provides appropriate text for Passes that have time-based relevance. For passes with a relevant location, you provide text. This can be as simple as "Theatre nearby" or include a brief description of how to find a relevant location. You should not include your company name in the text, and don't include instructions to the user such as "Redeem this Pass at blah blah blah"


---


<table border='0'>
<blockquote><tr>
<blockquote><td width='361'></td>
<td width='353'><a href='http://PassKit.com/'>PassKit Home Page</a></td>
<td width='128'><a href='https://create.passkit.com'>Register with PassKit</a></td>
</blockquote></tr>
</table>