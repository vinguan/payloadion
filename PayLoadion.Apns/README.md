# PayLoadion.Apns 
<img src="https://raw.githubusercontent.com/vinguan/payloadion/master/Project%20Icons/PayLoadion.Apns/payloadion_apple.png" width="200">

Implementation of PayLoadion for Apple Push Notification Service(APNS), following [Remote Notification Programming Guide](https://developer.apple.com/library/ios/documentation/NetworkingInternet/Conceptual/RemoteNotificationsPG/Chapters/TheNotificationPayload.html) of APNS.

# Nuget
```
Install-Package PayLoadion.Apns
```
# Getting Started
## Creating the PayloadBuilder
```csharp
var apnsPayloadBuilder = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
```
## Building a simple Apns's Payload

### PayLoad built to object
```csharp
var apnsPayload = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                           .Alert("Simple Message")
                                           .BuildPayLoad();
```
### PayLoad built and serialized to string
```csharp
var apnsPayloadString = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                                 .Alert("Simple Message")
                                                 .BuildPayLoadToString(true);
```
It should produce this Payload : 
```
{
  "aps": {
    "alert": "Simple Message"
  }
}
```

# More complex cenarios
## Custom Alert 
```csharp
var apnsPayLoadString = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                                 .Alert()
                                                 .Title("Hello Payloadion.Apns Title")
                                                 .Body("Hello Payloadion.Apns Body")
                                                 .BuildPayLoadToString(true);
```
It should produce this Payload : 
```
{
  "aps": {
    "alert": {
      "title": "Hello Payloadion.Apns Title",
      "body": "Hello Payloadion.Apns Body"
    }
  }
}
```

## With Custom data  
```csharp
var apnsPayLoadString = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                                 .Alert()
                                                 .Title("Hello Payloadion.Apns")
                                                 .Body("Hello Payloadion.Apns Body")
                                                 .AddCustomData("NewsId", 11)
                                                 .BuildPayLoadToString(true);
```
It should produce this Payload : 
```
{
  "aps": {
    "alert": {
      "title": "Hello Payloadion.Apns",
      "body": "Hello Payloadion.Apns Body"
    }
  },
  "NewsId": 11
}
```

# Author
Vinicius Gualberto [@Vinguan](http://twitter.com/vinguan).

# Contribute
Fork me and send the pull requests =).
