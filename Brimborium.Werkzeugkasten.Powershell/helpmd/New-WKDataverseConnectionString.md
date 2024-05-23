---
external help file: Brimborium.Werkzeugkasten.Powershell.dll-Help.xml
Module Name: Brimborium.Werkzeugkasten
online version:
schema: 2.0.0
---

# New-WKDataverseConnectionString

## SYNOPSIS
Create a new connection string for Dataverse.

## SYNTAX

### ConnectionString (Default)
```
New-WKDataverseConnectionString [[-ConnectionString] <String>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### WKDataverseConnectionString
```
New-WKDataverseConnectionString [[-AuthenticationType] <AuthenticationType>] [[-ServiceUri] <String>]
 [[-UserName] <String>] [[-Password] <SecureString>] [[-Domain] <String>] [[-HomeRealmUri] <String>]
 [[-RequireNewInstance] <Boolean>] [[-ClientId] <String>] [[-ClientSecret] <String>] [[-RedirectUri] <String>]
 [[-TokenCacheStorePath] <String>] [[-LoginPrompt] <PromptBehavior>] [[-CertificateThumbprint] <String>]
 [[-CertificateStoreName] <StoreName>] [[-SkipDiscovery] <Boolean>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Create a new connection string for Dataverse.

## EXAMPLES

### Example 1
```powershell
PS C:\> WKDataverseConnectionString -ConnectionString 'AuthType=OAuth;Username=jsmith@contoso.onmicrosoft.com;Password=passcode;Url=https://contosotest.crm.dynamics.com;AppId=51f81489-12ee-4a9e-aaae-a2591f45987d;RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97;TokenCacheStorePath=c:\MyTokenCache;LoginPrompt=Auto'
```

{{ Add example description here }}

## PARAMETERS

### -AuthenticationType

AuthenticationType: AD, OAuth, Certificate, ClientSecret

-AuthenticationType [Microsoft.PowerPlatform.Dataverse.Client.AuthenticationType]::OAuth
-AuthenticationType [Microsoft.PowerPlatform.Dataverse.Client.AuthenticationType]::ClientSecret

```yaml
Type: AuthenticationType
Parameter Sets: WKDataverseConnectionString
Aliases:
Accepted values: AD, OAuth, Certificate, ClientSecret, ExternalTokenManagement, InvalidConnection

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificateStoreName
{{ Fill CertificateStoreName Description }}

```yaml
Type: StoreName
Parameter Sets: WKDataverseConnectionString
Aliases:
Accepted values: AddressBook, AuthRoot, CertificateAuthority, Disallowed, My, Root, TrustedPeople, TrustedPublisher

Required: False
Position: 13
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificateThumbprint
{{ Fill CertificateThumbprint Description }}

```yaml
Type: String
Parameter Sets: WKDataverseConnectionString
Aliases:

Required: False
Position: 12
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientId
{{ Fill ClientId Description }}

```yaml
Type: String
Parameter Sets: WKDataverseConnectionString
Aliases:

Required: False
Position: 7
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientSecret
{{ Fill ClientSecret Description }}

```yaml
Type: String
Parameter Sets: WKDataverseConnectionString
Aliases:

Required: False
Position: 8
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionString
{{ Fill ConnectionString Description }}

```yaml
Type: String
Parameter Sets: ConnectionString
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Domain
{{ Fill Domain Description }}

```yaml
Type: String
Parameter Sets: WKDataverseConnectionString
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HomeRealmUri
{{ Fill HomeRealmUri Description }}

```yaml
Type: String
Parameter Sets: WKDataverseConnectionString
Aliases:

Required: False
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoginPrompt
{{ Fill LoginPrompt Description }}

```yaml
Type: PromptBehavior
Parameter Sets: WKDataverseConnectionString
Aliases:
Accepted values: Auto, Always, RefreshSession, SelectAccount, Never

Required: False
Position: 11
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Password
{{ Fill Password Description }}

```yaml
Type: SecureString
Parameter Sets: WKDataverseConnectionString
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RedirectUri
{{ Fill RedirectUri Description }}

```yaml
Type: String
Parameter Sets: WKDataverseConnectionString
Aliases:

Required: False
Position: 9
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequireNewInstance
{{ Fill RequireNewInstance Description }}

```yaml
Type: Boolean
Parameter Sets: WKDataverseConnectionString
Aliases:

Required: False
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceUri
{{ Fill ServiceUri Description }}

```yaml
Type: String
Parameter Sets: WKDataverseConnectionString
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipDiscovery
{{ Fill SkipDiscovery Description }}

```yaml
Type: Boolean
Parameter Sets: WKDataverseConnectionString
Aliases:

Required: False
Position: 14
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TokenCacheStorePath
{{ Fill TokenCacheStorePath Description }}

```yaml
Type: String
Parameter Sets: WKDataverseConnectionString
Aliases:

Required: False
Position: 10
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserName
{{ Fill UserName Description }}

```yaml
Type: String
Parameter Sets: WKDataverseConnectionString
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### Brimborium.Werkzeugkasten.WKDataverseConnectionString
## NOTES

## RELATED LINKS
