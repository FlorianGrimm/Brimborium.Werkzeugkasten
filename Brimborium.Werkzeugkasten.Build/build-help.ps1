Set-StrictMode -Version Latest

#Install-Module platyps -Force

Import-Module platyps

$Module = Import-Module 'Brimborium.Werkzeugkasten' -PassThru -Verbose
if ($null -eq $Module) {
    Write-Error 'Cannot Import-Module Brimborium.Werkzeugkasten'
    exit
}
<#
$OutputFolder = 'helpmd'

$parameters = @{
    Module = 'Brimborium.Werkzeugkasten'
    OutputFolder = $OutputFolder
    AlphabeticParamsOrder = $true
    WithModulePage = $true
    ExcludeDontShow = $true
    Encoding = [System.Text.Encoding]::UTF8
}
New-MarkdownHelp @parameters

#New-MarkdownAboutHelp -OutputFolder $OutputFolder -AboutName "topic_name"

#>
$parameters = @{
    Path = 'helpmd'
    RefreshModulePage = $true
    AlphabeticParamsOrder = $true
    UpdateInputOutput = $true
    ExcludeDontShow = $true
    LogPath = 'helpmd\helplog.txt'
    Encoding = [System.Text.Encoding]::UTF8
}
Update-MarkdownHelpModule @parameters

#Update-MarkdownHelpModule -Path 'helpmd' -RefreshModulePage

New-ExternalHelp -Path 'helpmd' -OutputPath 'PowershellHelp' -Force