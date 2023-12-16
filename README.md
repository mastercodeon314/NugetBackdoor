# NugetBackdoor

# Summary
A critical RCE in the NuGet package manager where individual nuget packages can be infected with malware.
    
# Description
There is a vulnerability in the Nuget package manager that allows threat actors to infect Nuget packages.
The way this is done is by leveraging the init.ps1 feature. There are people actively exploiting this in the wild, and thousands of users have downloaded infected packages.

Upon installing an infected package, the script will execute. But only if this is the first time installing the infected package since opening the project/solution. Subsequent installs will not execute the script.

Any version of visual studio from 2017 onward is affected by this issue, and potentially 2015 as well.
The exact line of code that produces the result is linked below. Removing this line will prevent the package manager from executing the script. The infected packages can be installed with no worry.

# Background
I learned of this vulnerability back in the summer of 2022. It wasn’t until January 2nd though of 2023 that I reported it to Microsoft. This was 2 months before JFrog Security came out with their report on the vuln. Microsoft responded to my report and said that "this behavior is considered to be by design" in reference to the vuln. It is now known that threat actors are exploiting this in the wild and compromising development chains because of Microsoft's lack of care about this feature of Nuget. 

# Disclosure
As of writing this, the exploit still works on the latest version of Visual Studio 2022 Enterprise, 17.8.3, and it’s been almost a year since I reported this to Microsoft. I have decided to publicly disclose this in hopes that the report will gain validation one day and this very problematic issue is fixed. Its always very disappointing when companies take the security of their products as not a concern, and this time its Microsoft. 
![image](https://github.com/mastercodeon314/NugetBackdoor/assets/78676320/424154f7-c3fd-4e31-ab99-0ea8dc6e3063)

Submission of the report of this vuln to Microsoft on Jan 2nd, 2023:
![image](https://github.com/mastercodeon314/NugetBackdoor/assets/78676320/d85dbb8a-2deb-4cb5-9e82-1e9803dc74e0)

Microsoft's Response to the report on Jan 6th, 2023:
![image](https://github.com/mastercodeon314/NugetBackdoor/assets/78676320/7f8335fd-17e8-4c0f-9dce-03f32fcc5318)

Vulnerability Demo:
https://youtu.be/HBaJ2rnC-9E?si=23hJJWpTg4YXEo7i

Batch Package Infection (Aedificator Automatica) Demo:
https://youtu.be/jDJi5uWWvNc?si=rjh7x9FFSIGJzFJV

Detailed Package Editor and Infector Demo:
https://youtu.be/2Lg85pYAloc?si=4EpuN7ZdJJBSIWyG