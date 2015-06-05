# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Pass Certificates (PassID) #

Certificates, also referred to as Pass IDs play an important role in how a Pass functions in Passbook.

Apple® requires that anyone who issues a Pass does so using their own certificate.

Passes with the same certificate are grouped together in the Passbook application and in the Notification Center.

The Pass Organization Name and Icon is also shared across all passes that have the same certificate.  In the case that 2 passes have the same certificate, but different icons and names, the second pass will automatically use the icon and name of the first.

If you are experiencing 'strange' behavior with push alerts showing the wrong icon or name, it will be because you have another pass installed that is using the same certificate.

## Use of PassKit certificates ##

We supply a number of certificates that can be used <font color='#f00'><b>FOR EVALUATION AND TESTING PURPOSES ONLY</b></font>.  Our certificates can help you understand how Passes behave and whether you are better using a separate certificate for the different passes that you wish to create.

In <font color='#f00'><b>ALL CASES</b></font> you should be using your own certificate to issue passes commercially.

## Obtaining a Certificate ##

Currently, the only way to obtain a certificate is by opening a Developer Account with Apple.  This costs US$99 per year and usually takes 24-48 hours to complete. [This video](AppleDeveloperVideo.md) guides you through the Account opening process.

Once your account is opened, you can generate as many certificates as you require via the provisioning portal within your Apple® Developer account.

You can then upload your certificates to the PassKit server using the Certificates tab of the Account management page.


---


<table border='0'>
<blockquote><tr>
<blockquote><td width='361'></td>
<td width='353'><a href='http://PassKit.com/'>PassKit Home Page</a></td>
<td width='128'><a href='https://create.passkit.com'>Register with PassKit</a></td>
</blockquote></tr>
</table>