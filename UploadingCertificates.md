# Generating and Uploading Pass Certificates #

Watch [this video](GeneratePassCertificateVideo.md) or follow the steps below to create a certificate for use with PassKit and upload it to your account.

_**Note:** The certificate that you generate will be exclusively for use with the PassKit service.  If you want to independently produce and sign your own passes, you will need to generate an another certificate, using your own CSR, through the Apple Developer portal._

### Step 1 ###
Log in to PassKit and generate a CSR containing your account details through the 'Certificates' tab of your 'My Account' page.

![http://passkit.s3.amazonaws.com/wiki/Cert-1.png](http://passkit.s3.amazonaws.com/wiki/Cert-1.png)

Click "Yes! Let's Do This" and a CSR file should start to download.

![http://passkit.s3.amazonaws.com/wiki/Cert-2.png](http://passkit.s3.amazonaws.com/wiki/Cert-2.png)

---

### Step 2 ###
Log in to your Apple Developer account and navigate to the member area.  Click on "Certificates, Identifiers and Profiles".

![http://support.passkit.com/wikiimages/Cert-3.png](http://support.passkit.com/wikiimages/Cert-3.png)

Then select "Identifiers" under iOS Apps

![http://support.passkit.com/wikiimages/Cert-3-1.png](http://support.passkit.com/wikiimages/Cert-3-1.png)

---

### Step 3 ###

Create a new Pass Type ID.

Select "Pass Type IDs" and then click the + button at the top right of the list view.

![http://support.passkit.com/wikiimages/Cert-3-2.png](http://support.passkit.com/wikiimages/Cert-3-2.png)

Enter the Description and Indentifier

Your description should be something meaningful that will help you identify the certificate.

Identifiers are conventionally give in reverse domain format to ensure uniqueness. A certificate named _greatstorecard_ for _example.com_ would have an identifier of  _pass.com.example.greatsotrecard_. However, your identifier can be anything, providing the first five characters are pass. and it is unique.

![http://support.passkit.com/wikiimages/Cert-3-3.png](http://support.passkit.com/wikiimages/Cert-3-3.png)

Click on "Continue" to register the Pass Type ID, when done the Registration Complete confirmation, click on "Done" to finish the process.

![http://support.passkit.com/wikiimages/Cert-3-4.png](http://support.passkit.com/wikiimages/Cert-3-4.png)

---

### Step 4 ###

Configure your new Pass Type ID and generate your certificate.

After the previous step you will return to the Pass Type Identifiers list, your new Pass Type ID will be visible, click on the Pass Type ID to expand the view.  Click on "Edit"

![http://support.passkit.com/wikiimages/Cert-4.png](http://support.passkit.com/wikiimages/Cert-4.png)

Click on the "Create Certificate" button

![http://support.passkit.com/wikiimages/Cert-5.png](http://support.passkit.com/wikiimages/Cert-5.png)

Choose the CSR file that you downloaded in Step 1 and click the "Generate" button

![http://support.passkit.com/wikiimages/Cert-6.png](http://support.passkit.com/wikiimages/Cert-6.png)


---

### Step 5 ###

When you certificate is generated you will see the Your Certificate is Ready page.  Now download your certificate by clicking "download"

![http://support.passkit.com/wikiimages/Cert-7.png](http://support.passkit.com/wikiimages/Cert-7.png)

You should now have a certificate file called pass.cer in your downloads folder.


---


### Step 6 ###

Upload your certificate to PassKit.  Click the button to select your certificate (the pass.cer file generated in Step 5).  It will automatically start uploading to PassKit.

![http://support.passkit.com/wikiimages/Cert-8.png](http://support.passkit.com/wikiimages/Cert-8.png)

![http://support.passkit.com/wikiimages/Cert-9.png](http://support.passkit.com/wikiimages/Cert-9.png)


---

### Step 7 ###
Logout of your account to activate your certificate.  When you return to the certificates page, you should see your certificate listed. When you return to the Pass Designer, you should also see your certificate in the Pass Certificate dropdown.

![http://support.passkit.com/wikiimages/Cert-10.png](http://support.passkit.com/wikiimages/Cert-10.png)

![http://support.passkit.com/wikiimages/Cert-11.png](http://support.passkit.com/wikiimages/Cert-11.png)


---


<table border='0'>
<blockquote><tr>
<blockquote><td width='361'></td>
<td width='353'><a href='http://PassKit.com/'>PassKit Home Page</a></td>
<td width='128'><a href='https://create.passkit.com'>Register with PassKit</a></td>
</blockquote></tr>
</table>