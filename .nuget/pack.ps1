#
# pack.ps1
#
$root = (split-path -parent $MyInvocation.MyCommand.Definition) + '\..'
$version = [System.Reflection.Assembly]::LoadFile("$root\Pingo.CommandLine\bin\Release\Pingo.CommandLine.dll").GetName().Version
$versionStr = "{0}.{1}.{2}" -f ($version.Major, $version.Minor, $version.Build)

Write-Host "Setting .nuspec version tag to $versionStr"

$content = (Get-Content $root\.nuget\Pingo.Console.nuspec) 
$content = $content -replace '\$version\$',$versionStr

$content | Out-File $root\.nuget\Pingo.Console.compiled.nuspec

& $root\.nuget\NuGet.exe pack $root\.nuget\Pingo.Console.compiled.nuspec