# Brimborium.Werkzeugkasten

Goals:
- PowerShell module for Dataverse (Dynamics 365 / Power Platform)
- C# library of the Dataverse (Dynamics 365 / Power Platform)
- UI Tools via local web server
- for Windows PowerShell framework since not all want to install the new one.
- for PowerShell Core: since it is so much better.

## Issues with current implementations for PowerShell:

- Microsoft.Xrm.Data.PowerShell is deprecated / archived.
- Microsoft.Xrm.Tooling.CrmConnector.Powershell is deprecated.
- PSDataverse focus on WebAPI (may be good), but enforce you to use JObject - feels odd.