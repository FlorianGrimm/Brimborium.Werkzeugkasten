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
$WKPSAppHost = New-WKPSAppHost -ApplicationName "WKPSAppHostTest01" -ContentRootPath (GetRoot)
$Logger = Get-WKLogger -WKPSAppHost $WKPSAppHost -Name 'Abc'
$Logger.LogDebug("LogDebug {0} {1}", @(1,2))
$Logger.LogError("LogError {0}", @("zero"))
#
Write-Host "-fini-"
#