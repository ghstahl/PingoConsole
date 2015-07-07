#
# pack.ps1
#
$root = (split-path -parent $MyInvocation.MyCommand.Definition) + '\..'
$version = [System.Reflection.Assembly]::LoadFile("$root\Pingo.CommandLine\bin\Release\Pingo.CommandLine.dll").GetName().Version
$versionStr = "{0}.{1}.{2}" -f ($version.Major, $version.Minor, $version.Build)

############################################################################################
Write-Host "Processing Pingo.Console.nuspec"
Write-Host "Setting .nuspec version tag to $versionStr"

$content = (Get-Content $root\.nuget\Pingo.Console.nuspec) 
$content = $content -replace '\$version\$',$versionStr

$content | Out-File $root\.nuget\Pingo.Console.compiled.nuspec

& $root\.nuget\NuGet.exe pack $root\.nuget\Pingo.Console.compiled.nuspec -Verbosity detailed

############################################################################################
Write-Host "Processing Pingo.CommandLineHelp.nuspec"
Write-Host "Setting .nuspec version tag to $versionStr"

$content = (Get-Content $root\.nuget\Pingo.CommandLineHelp.nuspec) 
$content = $content -replace '\$version\$',$versionStr

$content | Out-File $root\.nuget\Pingo.CommandLineHelp.compiled.nuspec

& $root\.nuget\NuGet.exe pack $root\.nuget\Pingo.CommandLineHelp.compiled.nuspec -Verbosity detailed

############################################################################################
Write-Host "Processing Pingo.JsonConverters.Commands.nuspec"
Write-Host "Setting .nuspec version tag to $versionStr"

$content = (Get-Content $root\.nuget\Pingo.JsonConverters.Commands.nuspec) 
$content = $content -replace '\$version\$',$versionStr

$content | Out-File $root\.nuget\Pingo.JsonConverters.Commands.compiled.nuspec

& $root\.nuget\NuGet.exe pack $root\.nuget\Pingo.JsonConverters.Commands.compiled.nuspec -Verbosity detailed

############################################################################################
Write-Host "Processing Pingo.TestCommands.nuspec"
Write-Host "Setting .nuspec version tag to $versionStr"

$content = (Get-Content $root\.nuget\Pingo.TestCommands.nuspec) 
$content = $content -replace '\$version\$',$versionStr

$content | Out-File $root\.nuget\Pingo.TestCommands.compiled.nuspec

& $root\.nuget\NuGet.exe pack $root\.nuget\Pingo.TestCommands.compiled.nuspec -Verbosity detailed

############################################################################################
Write-Host "Processing Pingo.Console.DevStarterKit"
Write-Host "Setting .nuspec version tag to $versionStr"

$content = (Get-Content $root\.nuget\Pingo.Console.DevStarterKit.nuspec) 
$content = $content -replace '\$version\$',$versionStr

$content | Out-File $root\.nuget\Pingo.Console.DevStarterKit.compiled.nuspec

& $root\.nuget\NuGet.exe pack $root\.nuget\Pingo.Console.DevStarterKit.compiled.nuspec -Verbosity detailed
