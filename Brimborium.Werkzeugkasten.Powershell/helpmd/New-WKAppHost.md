---
external help file: Brimborium.Werkzeugkasten.Powershell.dll-Help.xml
Module Name: Brimborium.Werkzeugkasten
online version:
schema: 2.0.0
---

# New-WKAppHost

## SYNOPSIS
Creates a new instance of the WKAppHost, which contains configuration for logging.

## SYNTAX

```
New-WKAppHost [[-ApplicationName] <String>] [[-ContentRootPath] <String>] [[-AppSettingsJsonPath] <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Creates a new instance of the WKAppHost, which contains configuration for logging.

## EXAMPLES

### Example 1
```powershell
PS C:\> $AppHost = New-WKAppHost -ApplicationName 'MyPowershell' -AppSettingsJsonPath 'appsettings.json'
```

Creates a new instance of the WKAppHost with the specified application name and appsettings.json path.

## PARAMETERS

### -ApplicationName
The ApplicationName.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppSettingsJsonPath
Loads the configuration from the specified appsettings.json file.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContentRootPath
Set the root path of the content, if not set, the current directory is used. This is used to resolve relative paths.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
Not used.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### Brimborium.Werkzeugkasten.WKAppHost
## NOTES

## RELATED LINKS
