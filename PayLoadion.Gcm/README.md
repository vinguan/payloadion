
#PayLoadion.Gcm 
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

###PayLoad built to object
```csharp
var gcmPayLoad = GcmPayLoadBuilderFactory.CreateGcmPayLoadBuilder()
                                         .Notification()
                                         .Title("Hello Payloadion.GCM")
                                         .Icon("DefaultIcon")
                                         .AddCustomData("NewsId", 11)
                                         .BuildPayLoad();
```
###PayLoad built and serialized to string
```csharp
var gcmPayLoadString = GcmPayLoadBuilderFactory.CreateGcmPayLoadBuilder()
                                               .Notification()
                                               .Title("Hello Payloadion.GCM")
                                               .Icon("DefaultIcon")
                                               .AddCustomData("NewsId", 11)
                                               .BuildPayLoadToString(true);
```
It should produce this Payload : 
```
  {
  "notification": {
    "title": "Hello Payloadion.GCM",
    "icon": "DefaultIcon"
  },
  "data": {
    "NewsId": 11
  }
}
```

# More cenarios
## Only with custom data 
```csharp
var gcmPayLoadString = GcmPayLoadBuilderFactory.CreateGcmPayLoadBuilder()
                                               .AddCustomData("NewsId", 11)
                                               .BuildPayLoadToString(true);

```
It should produce this Payload : 
```
{
  "notification": {},
  "data": {
    "NewsId": 11
  }
}
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
                                               .BuildPayLoadToString(true);
```
It should produce this Payload : 
```
{
  "notification": {
    "title": "Hello Payloadion.GCM",
    "body": "Hello Payloadion.GCM Body",
    "icon": "DefaultIcon",
    "body_loc_key": "BodyLocKey",
    "body_loc_args": [
      "2"
    ],
    "title_loc_key": "TitleLocKey",
    "title_loc_args": [
      "1"
    ]
  },
  "data": {
    "NewsId": 11
  }
}
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
It should produce this message :
```
{
  "to": "123",
  "priority": "normal",
  "time_to_live": 2678400,
  "dry_run": true,
  "notification": {
    "title": "Hello Payloadion.GCM",
    "icon": "DefaultIcon"
  },
  "data": {
    "NewsId": 11
  }
}
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
It should produce this message :
```
{
  "registration_ids": [
    "GcmDeviceUniqueId1",
    "GcmDeviceUniqueId2",
    "GcmDeviceUniqueId3"
  ],
  "priority": "normal",
  "time_to_live": 2678400,
  "dry_run": true,
  "notification": {
    "title": "Hello Payloadion.GCM",
    "icon": "DefaultIcon"
  },
  "data": {
    "NewsId": 11
  }
}
```

# Author
Vinicius Gualberto [@Vinguan](http://twitter.com/vinguan).

# Contribute
Fork me and send the pull requests =).
