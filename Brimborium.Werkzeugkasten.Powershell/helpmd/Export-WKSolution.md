---
external help file: Brimborium.Werkzeugkasten.Powershell.dll-Help.xml
Module Name: Brimborium.Werkzeugkasten
online version:
schema: 2.0.0
---

# Export-WKSolution

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### Content (Default)
```
Export-WKSolution [-Connection] <WKDataverseConnection> [-SolutionName] <String> [[-Managed] <Boolean>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Folder
```
Export-WKSolution [-Connection] <WKDataverseConnection> [-SolutionName] <String> [[-Managed] <Boolean>]
 [[-Folder] <String>] [[-FileName] <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Connection
Connection to access Dataverse.

```yaml
Type: WKDataverseConnection
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileName
the export fileName: '{SolutionName}-{Now}.zip' used if not set.
'{SolutionName}' is replaced by the SolutionName. '{Now}' is replaced by the current DateTime 'yyyy-MM-dd-HH-mm-ss'. '{Today}' is replaced by the current Date 'yyyy-MM-dd'.


```yaml
Type: String
Parameter Sets: Folder
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Folder
The export folder.

```yaml
Type: String
Parameter Sets: Folder
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Managed
Export Managed Solution.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
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

### -SolutionName
{{ Fill SolutionName Description }}

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### System.Byte[]
### System.Byte[]
## NOTES

## RELATED LINKS
