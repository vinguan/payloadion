
#PayLoadion.Apns 
<img src="https://raw.githubusercontent.com/vinguan/payloadion/master/Project%20Icons/PayLoadion.Gcm/payloadion_google.png" width="200">

Implementation of PayLoadion for Google Cloud Messaging(GCM), following [Notification payload Support](https://developers.google.com/cloud-messaging/http-server-ref#table2). PayLoadion.Gcm comes with a plus that is a 
builder for [Downstream HTTP messages](https://developers.google.com/cloud-messaging/http-server-ref#table1)
#Nuget
```
Install-Package PayLoadion.Gcm
```
# Getting Started
## Creating the PayloadBuilder
```csharp
var gcmPayLoadBuilder = GcmPayLoadBuilderFactory.CreateGcmPayLoadBuilder();
```
##Building a simple Apns's Payload

* PayLoad built to object
```csharp
var gcmPayLoad = GcmPayLoadBuilderFactory.CreateGcmPayLoadBuilder()
                                         .Notification()
                                         .Title("Hello Payloadion.GCM")
                                         .Icon("DefaultIcon")
                                         .AddCustomData("NewsId", 11)
                                         .BuildPayLoad();
```
* PayLoad built and serialized to string
```csharp
var gcmPayLoadString = GcmPayLoadBuilderFactory.CreateGcmPayLoadBuilder()
                                               .Notification()
                                               .Title("Hello Payloadion.GCM")
                                               .Icon("DefaultIcon")
                                               .AddCustomData("NewsId", 11)
                                               .BuildPayLoadToString();
```
# More cenarios
## Only with custom data 
```csharp
var gcmPayLoadString = GcmPayLoadBuilderFactory.CreateGcmPayLoadBuilder()
                                               .AddCustomData("NewsId", 11)
                                               .BuildPayLoadToString();
```

## With Notification, Custom Data and others arguments
```csharp
var gcmPayLoadString = GcmPayLoadBuilderFactory.CreateGcmPayLoadBuilder()
                                               .Notification()
                                               .Title("Hello Payloadion.GCM")
                                               .Icon("DefaultIcon")
                                               .Body("Hello Payloadion.GCM Body")
                                               .BodyLocalizableKey("BodyLocKey")
                                               .AddBodyLocalizableArgument("2")
                                               .TitleLocalizableKey("TitleLocKey")
                                               .AddTitleLocalizableArgument("1")
                                               .AddCustomData("NewsId", 11)
                                               .BuildPayLoadToString();
```
#Downstream HTTP messages
# Getting Started
## Creating the DownStream HttpMessage Builder
```csharp
var gcmDownStreamHttpMessageBuilder = GcmDownStreamHttpMessageBuilderFactory.CreateGcmDownStreamHttpMessageBuilder();
```
## Building a simple message
```csharp
var gcmDownStreamHttpMessage = GcmDownStreamHttpMessageBuilderFactory.CreateGcmDownStreamHttpMessageBuilder()
                                                                     .ToDevice("123")
                                                                     .Priority(GcmPriorityEnum.Normal)
                                                                     .TimeToLiveUntil(DateTimeOffset.Now.AddMonths(1))
                                                                     .IsDryRun(true)
                                                                     .PayLoad()
                                                                     .Notification()
                                                                     .Title("Hello Payloadion.GCM")
                                                                     .Icon("DefaultIcon")
                                                                     .AddCustomData("NewsId", 11)
                                                                     .BuildGcmDownStreamHttpMessageToJson(true);
```
##Sending to multiple targets the same message
```csharp
var gcmDownStreamHttpMessage = GcmDownStreamHttpMessageBuilderFactory.CreateGcmDownStreamHttpMessageBuilder()
                                                                     .AddDeviceId("GcmDeviceUniqueId1")
                                                                     .AddDeviceId("GcmDeviceUniqueId2")
                                                                     .AddDeviceId("GcmDeviceUniqueId3")
                                                                     .Priority(GcmPriorityEnum.Normal)
                                                                     .TimeToLiveUntil(DateTimeOffset.Now.AddMonths(1))
                                                                     .IsDryRun(true)
                                                                     .PayLoad()
                                                                     .Notification()
                                                                     .Title("Hello Payloadion.GCM")
                                                                     .Icon("DefaultIcon")
                                                                     .AddCustomData("NewsId", 11)
                                                                     .BuildGcmDownStreamHttpMessageToJson(true);
```

# Author
Vinicius Gualberto [@Vinguan](http://twitter.com/vinguan).

# Contribute
Fork me and send the pull requests =).
