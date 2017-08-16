param(
 [string] $pathToDeploy,
 [string] $targetComputer,
 [string] $targetApplication,
 [string] $username,
 [string] $password
)


# ---------------------------------------------------------------------------------
# if user does not set MsDeployPath environment variable, we will try to retrieve it from registry.
# ---------------------------------------------------------------------------------
if (-not $Env:MSDeployPath ) {
	Import-Module Microsoft.PowerShell.Management
	$Env:MSDeployPath = Get-ItemProperty -Path registry::'HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\IIS Extensions\MSDeploy\*' |% {$_.InstallPath} 
}

[string] $msDeployFullPath = Join-Path $Env:MSDeployPath msdeploy.exe

if (Test-Path $msDeployFullPath ) {
    cd $Env:MSDeployPath
    cmd.exe /C "msdeploy.exe -source:contentPath='$pathToDeploy' -dest:contentPath='$targetApplication',computerName='$targetComputer',userName='$username',password='$password' -verb:sync -enableRule:Donotdeleterule"
} else {
   Write-Error -message "msdeploy.exe is not found on this machine. Please install Web Deploy before execute the script. Please visit http://go.microsoft.com/?linkid=9278654" -Category NotInstalled -CategoryActivity "Deployment with MSDeploy" -ErrorId "Deployment with MSDeploy"
}