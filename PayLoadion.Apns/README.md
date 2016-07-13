#PayLoadion.Apns
Implementation of PayLoadion for Apple Push Notification Service(APNS), following [Remote Notification Programming Guide](https://developer.apple.com/library/ios/documentation/NetworkingInternet/Conceptual/RemoteNotificationsPG/Chapters/TheNotificationPayload.html) of APNS.
#Nuget
```
Install-Package PayLoadion.Apns
```
# Getting Started
## Creating the PayloadBuilder
```csharp
var apnsPayloadBuilder = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
```
##Building a simple Apns's Payload

* PayLoad built to object
```csharp
var apnsPayload = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                           .Alert("Simple Message")
                                           .BuildPayLoad();
```
* PayLoad built and serialized to string
```csharp
var apnsPayloadString = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                                 .Alert("Simple Message")
                                                 .BuildPayLoadToString();
```
# More complex cenarios
## Custom Alert 
```csharp
var apnsPayLoad = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                            .Alert()
                                            .Title("Hello Payloadion.Apns Title")
                                            .Body("Hello Payloadion.Apns Body");

var apnsPayLoadString = apnsPayLoad.BuildPayLoadToString(true);
```

## With Custom data  
```csharp
var apnsPayLoad = ApnsPayLoadBuilderFactory.CreateApnsPayLoadBuilder()
                                            .Alert("Hello Payloadion.Apns")
                                            .Title("Simple Custom Alert Message")
                                            .Body("Hello Payloadion.Apns Body")
                                            .AddCustomData("NewsId", "123");

var apnsPayLoadString = apnsPayLoad.BuildPayLoadToString(true);
```

# Author
Vinicius Gualberto [@Vinguan](http://twitter.com/vinguan).

# Contribute
Fork me and send the pull requests =).
