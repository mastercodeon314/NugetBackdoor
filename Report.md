# Summary
A critical RCE in the NuGet package manager where individual nuget packages can be infected with malware.
    
# Description
There is a vulnerability in the Nuget package manager that allows threat actors to infect Nuget packages.
The way this is done is by leveraging the init.ps1 feature. There are people actively exploiting this in the wild, and thousands of users have downloaded infected packages.

Upon installing an infected package, the script will execute. But only if this is the first time installing the infected package since opening the project/solution. Subsequent installs will not execute the script.

Any version of visual studio from 2017 onward is affected by this issue, and potentially 2015 as well.
The exact line of code that produces the result is linked below. Removing this line will prevent the package manager from executing the script. This infected packages can be installed with no worry.

## Steps to Reproduce (Add details for how we can reproduce the issue)
    
Get a nuget package to test with. The Newtonsoft.Json package is what I will be using as a reference. 
    
Then extract the newtonsoft.json.13.0.2.nupkg file to a new folder. 
    
Next, create a folder named tools, and add your init.ps1 file in that folder. 
The powershell script will contain the code that delivers the payload, or the stager of choice. 

Modify the Nuspec file
Now we must modify the packages Nuspec file to execute the init.ps1 script. 
Simply add the following xml to the package tag after the metadata tag has been closed:
```
<files>
  <file src="tools\init.ps1" target="tools\init.ps1" />
</files>
```

Your Newtonsoft.Json nuspec should look like this now
```
<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2013/05/nuspec.xsd">
  <metadata minClientVersion="2.12">
    <id>Newtonsoft.Json</id>
    <version>13.0.2</version>
    <title>Json.NET</title>
    <authors>James Newton-King</authors>
    <license type="expression">MIT</license>
    <licenseUrl>https://licenses.nuget.org/MIT</licenseUrl>
    <icon>packageIcon.png</icon>
    <readme>README.md</readme>
    <projectUrl>https://www.newtonsoft.com/json</projectUrl>
    <iconUrl>https://www.newtonsoft.com/content/images/nugeticon.png</iconUrl>
    <description>Json.NET is a popular high-performance JSON framework for .NET</description>
    <copyright>Copyright © James Newton-King 2008</copyright>
    <tags>json</tags>
    <repository type="git" url="https://github.com/JamesNK/Newtonsoft.Json" commit="4fba53a324c445f06ee08e45a015c346000a7ef2"></repository>
    <dependencies>
      <group targetFramework=".NETFramework2.0" />
      <group targetFramework=".NETFramework3.5" />
      <group targetFramework=".NETFramework4.0" />
      <group targetFramework=".NETFramework4.5" />
      <group targetFramework=".NETStandard1.0">
        <dependency id="Microsoft.CSharp" version="4.3.0" exclude="Build,Analyzers" />
        <dependency id="NETStandard.Library" version="1.6.1" exclude="Build,Analyzers" />
        <dependency id="System.ComponentModel.TypeConverter" version="4.3.0" exclude="Build,Analyzers" />
        <dependency id="System.Runtime.Serialization.Primitives" version="4.3.0" exclude="Build,Analyzers" />
      </group>
      <group targetFramework=".NETStandard1.3">
        <dependency id="Microsoft.CSharp" version="4.3.0" exclude="Build,Analyzers" />
        <dependency id="NETStandard.Library" version="1.6.1" exclude="Build,Analyzers" />
        <dependency id="System.ComponentModel.TypeConverter" version="4.3.0" exclude="Build,Analyzers" />
        <dependency id="System.Runtime.Serialization.Formatters" version="4.3.0" exclude="Build,Analyzers" />
        <dependency id="System.Runtime.Serialization.Primitives" version="4.3.0" exclude="Build,Analyzers" />
        <dependency id="System.Xml.XmlDocument" version="4.3.0" exclude="Build,Analyzers" />
      </group>
      <group targetFramework="net6.0" />
      <group targetFramework=".NETStandard2.0" />
    </dependencies>
  </metadata>
  <files>
    <file src="tools\init.ps1" target="tools\init.ps1" />
  </files>
</package>
```

Save the modified nuspec file, and then repack the package by zipping up the folder and rename to a nupkg file extension.

I have built a proof of concept that can automatically infect a given package to demonstrate that infection can be easily automated. I have recorded a demo video of this which is linked below.

## Supporting materials/ references:

The exact line that executes init.ps1 in the NuGet package manager. 
https://github.com/NuGet/NuGet.Client/blob/ee9ef1f0e1a256a6d215669256576320a02fb0ac/src/NuGet.Core/NuGet.PackageManagement/NuGetPackageManager.cs#L3308

Video demonstrating the vulnerability in action
https://youtu.be/HBaJ2rnC-9E

Video demonstrating prototype infector
https://youtu.be/2Lg85pYAloc

Video demonstrating Batch infection
https://www.youtube.com/watch?v=jDJi5uWWvNc

Please note that this is actively being exploited in the wild. I have observed people using this to infect packages with stealer malware and publishing them to nuget.org
Packages can be setup so that one of the dependencies can be infected, thus hiding infection from obvious sight in the actual package being downloaded and installed. 

Attached is a PoC package that has been infected with a dummy script. The script will delete the init.ps1 file its running from, show a MessageBox stating that this could be malware, and also outputs the same string to the console as well. 