# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Obtaining your keys #

You can request your API Keys from the Details tab from the account section of the pass designer at https://create.passkit.com/.

## Key Format ##

To access our API you will require an API Key and an API Secret.

Your API Key is 32 character Hexadecimal string or a 20 character base62 string (depending on how early you requested your keys):

```
Example base16 API Key: ff0b04afe47feacd09a850d9a1dd91d0```
```
Example base62 API Key: B9gaEoDarsV7e1EgutQg```
There is no difference in how these keys are used, just that the newer keys are shorter.

Your API Secret is a longer base64 string than may contain periods and forward slashes:

```
Example API Secret: kFTlvlfrjU/djar.V3tO0uyvoF0svLGVhM7ccGN.ek80GdqcJNcju```

These keys provide the ability to access, edit, update and delete templates and passes on your account.  They should be treated the same as your username and password, and should never be written down or shared.


---


<table border='0'>
<blockquote><tr>
<blockquote><td width='361'></td>
<td width='353'><a href='http://PassKit.com/'>PassKit Home Page</a></td>
<td width='128'><a href='https://create.passkit.com'>Register with PassKit</a></td>
</blockquote></tr>
</table>