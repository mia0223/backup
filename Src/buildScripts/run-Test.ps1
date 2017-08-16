param(
    [string] $userName,
    [securestring] $secpasswd
)

$mycreds = New-Object System.Management.Automation.PSCredential ($userName, $secpasswd)

#$mycreds = Get-Credential
#cd C:\sources\SeatPlan\Src\QA

function run-process([string]$processName,[string]$argument, [System.Management.Automation.PSCredential]$Credential)
{
    $StdErrFile = Join-Path -Path $PWD -ChildPath "stdErr.log"
    $StdOutFile = Join-Path -Path $PWD -ChildPath "stdOut.log"
    $npmProcess = Start-Process $processName -NoNewWindow -WorkingDirectory $PWD -RedirectStandardError $StdErrFile -RedirectStandardOutput $StdOutFile -PassThru -ArgumentList $argument -Credential $Credential
    while( -not ($npmProcess.HasExited) ) {}

    if( Test-Path -Path $StdErrFile )
    {
        Write-Output -InputObject "File $StdErrFile exists"
        Get-Item -Path $StdErrFile | Write-Output
        Get-Content -Path $StdErrFile -Force
    }
    else
    {
        Write-Output -InputObject "File $StdErrFile does NOT exist"
    }

    if( Test-Path -Path $StdErrFile )
    {
        Write-Output -InputObject "File $StdOutFile exists"
        Get-Item -Path $StdOutFile | Write-Output
        Get-Content -Path $StdOutFile -force 
    }
    else
    {
        Write-Output -InputObject "File $StdOutFile does NOT exist"
    }

}

run-process -processName npm -argument "run integration" -Credential $mycreds
