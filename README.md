# IISAnyCors
Module for IIS that automatically sets Access-Control-Allow headers depending on the request headers

## What is it?
At some point I got tired of the way IIS works with CORS policies for backends that must be publicly accessible with authorization. Preflight requests constantly failed to get the correct headers, which made using my backend just one big problem.

This module simply solves the problem by forcing IIS to set Access-Control-Allow headers the way the requester wants them to be seen.

Yes, I know that this may not be entirely safe, but nevertheless, in some situations it is necessary

## How to install

### Preparing

Firstly, since this is a module, feature `Modules` must be enabled in IIS

For the module to work correctly, since it is written in C#, support for managed modules is required, module requires the `.NET Extensibility 4.6` component to work
#### Install .NET Extensibility 4.6
Path for Server Manager (Windows Server 2016):

Page `Server Roles`

Web server (IIS) -> Web Server -> Application Development -> .NET Extensibility 4.6

![NET Extensibility 4.6.png](<images/NET Extensibility 4.6.png>)

Select and proceed installation

### Installing

1. Create subfolder `Bin` in your application folder. For example, if your application root is C:\Sites\MyBestSite, you need to create C:\Sites\MyBestSite\Bin
2. Place files IISAnyCors.dll and IISAnyCors.pdb in bin folder from previous step
3. Go to IIS Manager
4. Choose you site, go to modules

![IIS Modules.png](<images/IIS Modules.png>)

5. Click `Add Managed Module`

![Add Managed Module.png](<images/Add Managed Module.png>)

6. In `Type` dropdown list choose `AnyCors.AnyCorsModule`

![Add Managed Module 2](<images/Add Managed Module 2.png>)

7. Done

![Work Done.png](<images/Work Done.png>)
