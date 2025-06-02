# Aprimo Optimizely Connector
Aprimo Optimizley(Opti) Connector is a content provider plugin that allows you to interact with Aprimo
Image assets in your Optimizely website. This connector provides the communication to and from
Aprimo without leaving your website.

## Aprimo's Open Source Policy
This code is provided by Aprimo as-is as an example of how you might solve a specific business problem. It is not intended for direct use in Production without modification.

You are welcome to submit issues or feedback to help us improve visibility into potential bugs or enhancements. Aprimo may, at its discretion, address minor bugs, but does not guarantee fixes or ongoing support.

It is expected that developers who clone or use this code take full responsibility for supporting, maintaining, and securing any deployments derived from it.

If you are interested in a production-ready and supported version of this solution, please contact your Aprimo account representative. They can connect you with our technical services team or a partner who may be able to build and support a packaged implementation for you.

Please note: This code may include references to non-Aprimo services or APIs. You are responsible for acquiring any required credentials or API keys to use those services—Aprimo does not provide them.

## Features
- Search and navigation support for Aprimo assets in Optimizely
- Integration with own section for Aprimo assets
- Add any meta data information from Aprimo to strongly typed properties for your asset.
- Offline support for meta data.
## Requirements
1. Asp.Net 5.0+
2. Optimizely v11
   - This connector was built and tested on Optimizely v11. We expect that development work will be needed for the connector to support Optimizely v12.

## Installation
Install the nuget package from Optimizely Nuget Feed

` INSTALL-PACKAGE APRIMO.OPTIMIZELY.EXTENSION ` 
1. You will need to retrieve your ClientID, ClientSecret from your Aprimo portal which uses OAuth
2.0 authorization. Before the connector will start to communicate with Aprimo, You will need ot
register your client (website). You can read about registering your client here.
(https://developers.aprimo.com/distributed-marketing/rest-api/authorization/)
2. After you have those 2 items, you will need your integration name (normally found at
https://(integration-name).aprimo.com that was configured for you by Aprimo.
3. Once you have those two pieces of information, you will need to add those to your AppSettings
section in you web.config.
```
<appSettings>
  <add key="aprimo-api-tenantid" value="your_aprimo_username" />
  <add key="aprimo-api-clientid" value="your_aprimo_client_id" />
  <add key="aprimo-api-clientsecret" value="your_aprimo_clientsecret"
  />
  <add key="aprimo-api-dialogmode" value="default" />
  <add key="aprimo-api-dialogbuttontext" value="Select" />
  <add key="aprimo-api-dialogdescription" value="Select Asset" />
  <add key="aprimo-api-dialogtitle" value="Select" />
</appSettings>
```
Connector Configuration
To configuration Aprimo to return object models from the CMS to use in your views and api, we need to
setup a model.
** You can configure more than one for EACH extension for images, but you can use 1 model for all images if need be. **
1. Create a new ContentType class.
(https://world.optimizely.com/documentation/developer-guides/archive/-net-corepreview/
CMS/Content/content-types/#CreatingContentType).
  a. In this example, we will create a class called AprimoImageFile.
2. Add the attribute:
[AprimoAssetDescriptor(ExtensionString = "jpg,jpeg,png,tif,tiff,gif")]
  a. This tells the system that any file with the following extension will map its Aprimo Asset
to this Model class
3. Derive your ContentType from AprimoImageData. This is REQUIRED. This add properties
needed for the system such as thumbnails, and metadata properties
4. You will be able to add your properties to allow the mapper to fill the properties in your model.
To map properties to Aprimo properties, you will need to create public properties with the
attribute [AprimoFieldName(“NameofPropertyInAprimo”)]
  a. This will map the property on the Aprimo Asset to the AprimoImageFile property when
filling its data.
## Aprimo Field Mapping.
Each Aprimo ContentType in Opti allows you to specify any number of properties on your model. The
connector allows you to map those properties to Aprimo by specifying the AprimoField Attribute.
[AprimoFieldName] attribute
1. Can be used to map the Aprimo Metadata property to Opti property
2. Can have as many as you need. Follow Opti ContentType requires for number of properties per
model
3. Does not do type conversion.

### SAMPLE Content Type with Attribute
```
[ContentType(DisplayName = "Aprimo Image File", GUID = "5420194f-16ae-46d2-8f3a-0c682d232581", Description = "Respresents aprimo image asset", Order = 1)]
[AprimoAssetDescriptor(ExtensionString = "jpg,jpeg,png,tif,tiff,gif")]
public class AprimoImageAsset : AprimoImageData
{
  [AprimoFieldName("Alt")]
  public virtual string AltText { get; set; }
}
```
#### Aprimo Transform Attribute
[AprimoTransform()]
Aprimo Transform attribute allows you to generate custom image transformations for the asset. If you
need to change the output type to webp, or crop an image, AprimoTransform attribute property can be
used. You do not need to use the aprimotransform attribute, you can tack it on to the end of the url and
will produce the same result. The attribute is just a nice helper attribute to configure the resulting
transform for you.
The attribute properties you can use for Aprimo Transform are as follows:
- auto - Enable optimization features automatically.
- bg-color - Set the background color of an image.
- blur - Set the blurriness of the output image.
- brightness - Set the brightness of the output image.
- canvas - Increase the size of the canvas around an image.
- contrast - Set the contrast of the output image.
- crop - Remove pixels from an image.
- disable - Disable functionality that is enabled by default.
- dpr - Serve correctly sized images for devices that expose a device pixel ratio.
- enable - Enable functionality that is disabled by default.
- fit - Set how the image will fit within the size bounds provided.
- format - Specify the output format to convert the image to.
- frame - Extract the first frame from an animated image sequence.
- height - Resize the height of the image.
- level - Specify the level constraints when converting to video.
- optimize - Automatically apply optimal quality compression.
- orient Change the cardinal orientation of the image.
- pad Add pixels to the edge of an image.
- precrop Remove pixels from an image before any other transformations occur.
- profile Specify the profile class of application when converting to video.
- quality Optimize the image to the given compression level for lossy file formatted images.
- resizefilter - specify the resize filter used when resizing images.
- saturation Set the saturation of the output image.
- sharpen Set the sharpness of the output image.
- trim Remove pixels from the edge of an image.
- width Resize the width of the image.

The process order for these attributes are as follows.
1. Precrop
2. trim
3. crop
4. orient
5. width height DPR fit resize-filter disable enable
6. pad canvas bg-color
7. brightness contrast saturation
8. sharpen
9. blur
10. format auto optimize quality profile level
### SAMPLE Transform Attribute
```
[ContentType(DisplayName = "Aprimo Image File", GUID = "5420194f-16ae-46d2-8f3a-0c682d232581", Description = "Respresents aprimo image asset", Order = 1)]
[AprimoAssetDescriptor(ExtensionString = "jpg,jpeg,png,tif,tiff,gif")]
public class AprimoImageAsset : AprimoImageData
{
  [AprimoTransform(Auto = "webp", Width = "400", Crop = "16:9")]
  public virtual string Teaser { get; set; }
  [AprimoFieldName("Alt")]
  public virtual string AltText { get; set; }
  [AprimoTransform(Auto = "webp", Width = "800", Crop = "16:9")]
  public virtual string JumboTronImage { get; set; }
}
```
### Additional Extension Methods
The connector provides a couple extensions to use for retrieving the Aprimo ImageUrl based on
contentreference, Url, and propertynames. The 3 following extensions are available.
```
public static string GetAprimoUrl(this ContentReference contentReference) // will return
normal image if you are using both optimizely and aprimo image types
public static string GetAprimoUrl(this Url url)
public static string GetAprimoUrl(this ContentReference contentReference, string
propertyName) // for thumbnails or different values
```
With these extension methods, they are not necessary, they are for your help in getting
the right url in your code or views.


----------------------------------------------------------------------------
# Install Through Source Code


## Getting Started
Before we can see the data in our Optimizely interface, we need to update the AppSettings values for handling the connection between the aprimo/optimizely connector and Aprimo REST API / Content Selector.

Take the keys you saved from Aprimo and update the values in the appsettings.json file.
```json
  "aprimo-api-tenantid": "TenantID HERE",
  "aprimo-api-clientid": "CliendID HERE",
  "aprimo-api-clientsecret": "Client Secret HERE"
```
and then click save.

In the startup class file, we need to add the extension for including Aprimo Content Provider.
You can add the following to the configureServices method after addMVC();

```csharp
    services.AddAprimo();
```

## Including code in project (Manual Setup)
If you choose to include the project in your own project.  You will need to setup this in a slightly different way.  You will need to reference the project and complete the same setup configuration as above by updating the configuration settings.  

Next, you will need to copy the folder in the client resources folder "Aprimo.Opti.Core".  You will need to copy the Aprimo.Opti.Core folder into the main web project's modules/protected folder.  This will provide the custom property to render in edit mode.  So your web project modules folders should look like this
```
"/modules/protected/Aprimo.Optio.Core"
```
![Configuration Manager](https://github.com/JoshuaFolkerts/Aprimo.Opti/blob/master/readme-files/Aprimo.opti.png)

## Customizing the Configuration Behavior

To customize how assets are rendered, we are going to create a model called AprimoImageAsset.  This allows the configuration system to strongly type the asset coming from the connector.
```csharp
    [ContentType(DisplayName = "Aprimo Image File", GUID = "CAE94870-C2D3-4C08-A8A8-CE6FC7820510", Description = "Respresents aprimo image asset", Order = 1)]
    [AprimoAssetDescriptor(ExtensionString = "jpg,jpeg,png,tif,tiff,gif")]
    public class AprimoImageAsset : AprimoImageData
    {
        [AprimoTransform(Auto = "webp", Width = "400", Crop = "16:9")]
        public virtual string Teaser { get; set; }
    }
```
note the Attribute descriptor to tell the connector what filetypes to support.  we added jpg, jpeg, etc to AprimoImageAsset
```csharp
[AprimoAssetDescriptor(ExtensionString = "jpg,jpeg,png,tif,tiff,gif")]
```
Inherit all image types from AprimoImageData.  

Next we have a teaser property with the AprimoTransform Attribute on the property.
```csharp
[AprimoTransform(Auto = "webp", Width = "400", Crop = "16:9")]
public virtual string Teaser { get; set; }
```
AprimoTransform attribute allows us to give the connector the ability to transform the image as we see fit to custom the returning url from the CDN.  In this case, we are returning an image with the width of 400 with a 16:9 aspect ratio and deliver it to us as webp.

the following attribute properties are available for to you send to the cdn in the attribute.
```csharp
public string Width { get; set; } // Resize the width of the image.

public string Height { get; set; } // Resize the height of the image.

public string Format { get; set; } // Specify the output format to convert the image to.

public string Crop { get; set; } //	Remove pixels from an image.

public string DPR { get; set; } // Serve correctly sized images for devices that expose a device pixel ratio.

public string Fit { get; set; } // 	Set how the image will fit within the size bounds provided.

public string Pad { get; set; } // Add pixels to the edge of an image.

public string Quality { get; set; } // 	Optimize the image to the given compression level for lossy file formatted images.

public string Saturation { get; set; } // Set the saturation of the output image.

public string Sharpen { get; set; } // 	Set the sharpness of the output image.

public string Trim { get; set; } // 	Remove pixels from the edge of an image.

public string Contrast { get; set; } // Set the contrast of the output image.

public string Brightness { get; set; } // Set the brightness of the output image.

public string Blur { get; set; } //	Set the blurriness of the output image.

public string BackgroundColor { get; set; } // Set the background color of an image.

public string Auto { get; set; } // Enable optimization features automatically.
```

You can see all the values here 
https://developer.fastly.com/reference/io/

Add the controller if you need to which in this case, the sample is from Alloy
```csharp
[TemplateDescriptor(Inherited = false, ModelType = typeof(AprimoImageAsset), TemplateTypeCategory = EPiServer.Framework.Web.TemplateTypeCategories.MvcPartialController)]
public class AprimoImageAssetController : PartialContentController<AprimoImageAsset>
{
    /// <summary>
    /// The index action for the image file. Creates the view model and renders the view.
    /// </summary>
    /// <param name="currentContent">The current image file.</param>
    public override ActionResult Index(AprimoImageAsset currentContent)
    {
        var model = new ImageViewModel
        {
            Url = currentContent.Url,
            Name = currentContent.Name
        };

        return PartialView(model);
    }
}
```
You can see here we are just passing the AprimoImageAsset to the viewmodel and sending to view.

As a normal model that needs to be rendered in a view, you can pass the model to the view and then render the image.  For those sites that already have a uihint for ContentReference of Image, you can just get the url as such:
```html
if (Model.ProviderName.Equals(AprimoConstants.ProviderKey))
{
    var originalUrl = Model.GetAprimoUrl();
    if (!string.IsNullOrWhiteSpace(originalUrl))
    {
        <img src="@originalUrl" class="img-fluid" />
    }
}
```
You also have some extension methods available to you for rendering images and different size images based on your property thumbnails
```csharp
public static string GetAprimoUrl(this ContentReference contentReference)  // will return normal image if you are using both optimizely and aprimo image types
public static string GetAprimoUrl(this Url url)
public static string GetAprimoUrl(this ContentReference contentReference, string propertyName) // for thumbnails or different values
```

# Open Source Policy

For more information about Aprimo's Open Source Policies, please refer to
https://community.aprimo.com/knowledgecenter/aprimo-connect/aprimo-connect-open-source
