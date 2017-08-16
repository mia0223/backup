param(
 [string] $serverName,
 [string] $iisApplication,
 [string] $username,
 [string] $password
)

$backEndFilesPlusLog = @("bin","Global.asax","ConnectionStrings.config","NLog.config","packages.config","web.config", "logs")

 if (-not $Env:MSDeployPath ) {
	Import-Module Microsoft.PowerShell.Management
	$Env:MSDeployPath = Get-ItemProperty -Path registry::'HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\IIS Extensions\MSDeploy\*' |% {$_.InstallPath} 
}

[string] $msDeployFullPath = Join-Path $Env:MSDeployPath msdeploy.exe

# To delete folder content before the folder itself, the file list is sorted according to file name length
$files = (cmd.exe /C "$msDeployFullPath" "-verb:dump" "-source:computername='$serverName',contentPath='$iisApplication',userName='$username',password='$password'") | sort { $_.length } -Descending 

foreach ($file in $files)
{
   if( $file.StartsWith($iisApplication+'\', $true, $null))
   {
        [bool] $toBeDelete = $true
        foreach ($backEndFile in $backEndFilesPlusLog)
        {
           if($file.StartsWith($iisApplication+'\'+$backEndFile, $true, $null))
           {
                $toBeDelete = $false
           }
        }

        if($toBeDelete)
        {
           cmd.exe /C "$msDeployFullPath" "-verb:delete" "-dest:computername='$serverName',contentPath='$file',userName='$username',password='$password'"
        }
   }
}
