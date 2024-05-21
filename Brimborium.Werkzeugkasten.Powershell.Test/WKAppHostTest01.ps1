#
Write-Host "-start-"
#
Set-StrictMode -Version Latest

$m = Import-Module 'Brimborium.Werkzeugkasten' -PassThru
if ($null -eq $m){
    Write-Error "Cannot Import-Module 'Brimborium.Werkzeugkasten'"
}
#
<# Get the PSScriptRoot or the CurrentDirectory (if the this is called via REPL - Run Selection ) #>
function GetRoot(){
    [string]$Root = Get-Variable -Name 'PSScriptRoot' -ValueOnly -ErrorAction SilentlyContinue
    if ([string]::IsNullOrEmpty($Root)){
        return ([System.Environment]::CurrentDirectory)
    } else {
        return (Split-Path $Root)
    }
}
#
New-WKAppHost -ApplicationName "WKAppHostTest01" -ContentRootPath (GetRoot) -
#
Write-Host "-fini-"
#