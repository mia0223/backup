param(
   [string] $sqlFile,
   [string] $serverName,
   [string] $DBName,
   [string] $userName,
   [string] $password
)

Import-Module SQLPS

Invoke-Sqlcmd -ServerInstance "$serverName" -Database "$DBName" -Username "$userName" -Password "$password" -InputFile "$sqlFile"