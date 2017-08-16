param(
[string] $processName
)

if ( -not [string]::IsNullOrWhiteSpace($processName) )
{
    Get-Process $processName | Stop-Process -ErrorAction SilentlyContinue -Force
}
else
{
    Write-Output -InputObject "Nothing to be killed"
}