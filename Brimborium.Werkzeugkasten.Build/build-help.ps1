#Install-Module platyps -Force
Import-Module platyps

Import-Module 'Brimborium.Werkzeugkasten'
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
    LogPath = 'helplog.txt'
    Encoding = [System.Text.Encoding]::UTF8
}
Update-MarkdownHelpModule @parameters

#Update-MarkdownHelpModule -Path 'helpmd' -RefreshModulePage

New-ExternalHelp -Path 'helpmd' -OutputPath 'PowershellHelp' -Force