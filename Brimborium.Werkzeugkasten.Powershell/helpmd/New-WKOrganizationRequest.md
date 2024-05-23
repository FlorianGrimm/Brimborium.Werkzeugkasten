---
external help file: Brimborium.Werkzeugkasten.Powershell.dll-Help.xml
Module Name: Brimborium.Werkzeugkasten
online version:
schema: 2.0.0
---

# New-WKOrganizationRequest

## SYNOPSIS
Create a new OrganizationRequest.

## SYNTAX

```
New-WKOrganizationRequest -OrganizationRequestKind <WKOrganizationRequestKind>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create a new OrganizationRequest.

## EXAMPLES

### Example 1
```powershell
PS C:\>  $r=New-WKOrganizationRequest -OrganizationRequestKind XrmUpsertRequest
PS C:\> $r.GetType().FullName
Microsoft.Xrm.Sdk.Messages.UpsertRequest
```

Creates a [Microsoft.Xrm.Sdk.Messages.UpsertRequest].

## PARAMETERS

### -OrganizationRequestKind
The type of the OrganizationRequest to create. 

```yaml
Type: WKOrganizationRequestKind
Parameter Sets: (All)
Aliases:
Accepted values: CrmAddAppComponentsRequest, CrmAddChannelAccessProfilePrivilegesRequest, CrmAddItemCampaignActivityRequest, CrmAddItemCampaignRequest, CrmAddListMembersListRequest, CrmAddMemberListRequest, CrmAddMembersTeamRequest, CrmAddPrincipalToQueueRequest, CrmAddPrivilegesRoleRequest, CrmAddProductToKitRequest, CrmAddRecurrenceRequest, CrmAddSolutionComponentRequest, CrmAddSubstituteProductRequest, CrmAddToQueueRequest, CrmAddUserToRecordTeamRequest, CrmApplyRecordCreationAndUpdateRuleRequest, CrmApplyRoutingRuleRequest, CrmAssignRequest, CrmAssociateEntitiesRequest, CrmAutoMapEntityRequest, CrmBackgroundSendEmailRequest, CrmBookRequest, CrmBulkDeleteRequest, CrmBulkDetectDuplicatesRequest, CrmCalculateActualValueOpportunityRequest, CrmCalculatePriceRequest, CrmCalculateRollupFieldRequest, CrmCalculateTotalTimeIncidentRequest, CrmCancelContractRequest, CrmCancelSalesOrderRequest, CrmCheckIncomingEmailRequest, CrmCheckPromoteEmailRequest, CrmCloneAsPatchRequest, CrmCloneAsSolutionRequest, CrmCloneContractRequest, CrmCloneMobileOfflineProfileRequest, CrmCloneProductRequest, CrmCloseIncidentRequest, CrmCloseQuoteRequest, CrmCommitAnnotationBlocksUploadRequest, CrmCommitAttachmentBlocksUploadRequest, CrmCommitFileBlocksUploadRequest, CrmCompoundCreateRequest, CrmCompoundUpdateDuplicateDetectionRuleRequest, CrmCompoundUpdateRequest, CrmConvertKitToProductRequest, CrmConvertOwnerTeamToAccessTeamRequest, CrmConvertProductToKitRequest, CrmConvertQuoteToSalesOrderRequest, CrmConvertSalesOrderToInvoiceRequest, CrmCopyCampaignRequest, CrmCopyCampaignResponseRequest, CrmCopyDynamicListToStaticRequest, CrmCopyMembersListRequest, CrmCopySystemFormRequest, CrmCreateActivitiesListRequest, CrmCreateAsyncJobToRevokeInheritedAccessRequest, CrmCreateExceptionRequest, CrmCreateInstanceRequest, CrmCreateKnowledgeArticleTranslationRequest, CrmCreateKnowledgeArticleVersionRequest, CrmCreatePolymorphicLookupAttributeRequest, CrmCreateWorkflowFromTemplateRequest, CrmDeleteAndPromoteAsyncRequest, CrmDeleteAndPromoteRequest, CrmDeleteAuditDataRequest, CrmDeleteFileRequest, CrmDeleteOpenInstancesRequest, CrmDeleteRecordChangeHistory1Request, CrmDeleteRecordChangeHistoryRequest, CrmDeliverImmediatePromoteEmailRequest, CrmDeliverIncomingEmailRequest, CrmDeliverPromoteEmailRequest, CrmDeprovisionLanguageRequest, CrmDisassociateEntitiesRequest, CrmDistributeCampaignActivityRequest, CrmDownloadBlockRequest, CrmDownloadReportDefinitionRequest, CrmDownloadSolutionExportDataRequest, CrmExecuteByIdSavedQueryRequest, CrmExecuteByIdUserQueryRequest, CrmExecuteFetchRequest, CrmExecuteWorkflowRequest, CrmExpandCalendarRequest, CrmExportFieldTranslationRequest, CrmExportMappingsImportMapRequest, CrmExportSolutionAsyncRequest, CrmExportSolutionRequest, CrmExportTranslationRequest, CrmFetchXmlToQueryExpressionRequest, CrmFindParentResourceGroupRequest, CrmFormatAddressRequest, CrmFulfillSalesOrderRequest, CrmFullTextSearchKnowledgeArticleRequest, CrmGenerateInvoiceFromOpportunityRequest, CrmGenerateQuoteFromOpportunityRequest, CrmGenerateSalesOrderFromOpportunityRequest, CrmGenerateSharedLinkRequest, CrmGenerateSocialProfileRequest, CrmGetAllTimeZonesWithDisplayNameRequest, CrmGetAutoNumberSeed1Request, CrmGetAutoNumberSeedRequest, CrmGetDecryptionKeyRequest, CrmGetDefaultPriceLevelRequest, CrmGetDistinctValuesImportFileRequest, CrmGetFileSasUrlRequest, CrmGetHeaderColumnsImportFileRequest, CrmGetInvoiceProductsFromOpportunityRequest, CrmGetNextAutoNumberValue1Request, CrmGetNextAutoNumberValueRequest, CrmGetPreferredSolutionRequest, CrmGetQuantityDecimalRequest, CrmGetQuoteProductsFromOpportunityRequest, CrmGetReportHistoryLimitRequest, CrmGetSalesOrderProductsFromOpportunityRequest, CrmGetTimeZoneCodeByLocalizedNameRequest, CrmGetTrackingTokenEmailRequest, CrmGrantAccessRequest, CrmGrantAccessUsingSharedLinkRequest, CrmImmediateBookRequest, CrmImportCardTypeSchemaRequest, CrmImportFieldTranslationRequest, CrmImportMappingsImportMapRequest, CrmImportRecordsImportRequest, CrmImportSolutionAsyncRequest, CrmImportSolutionRequest, CrmImportSolutionsRequest, CrmImportTranslationAsyncRequest, CrmImportTranslationRequest, CrmIncrementKnowledgeArticleViewCountRequest, CrmInitializeAnnotationBlocksDownloadRequest, CrmInitializeAnnotationBlocksUploadRequest, CrmInitializeAttachmentBlocksDownloadRequest, CrmInitializeAttachmentBlocksUploadRequest, CrmInitializeFileBlocksDownloadRequest, CrmInitializeFileBlocksUploadRequest, CrmInitializeFromRequest, CrmInitializeModernFlowFromAsyncWorkflowRequest, CrmInstallSampleDataRequest, CrmInstantiateFiltersRequest, CrmInstantiateTemplateRequest, CrmIsBackOfficeInstalledRequest, CrmIsComponentCustomizableRequest, CrmIsValidStateTransitionRequest, CrmLocalTimeFromUtcTimeRequest, CrmLockInvoicePricingRequest, CrmLockSalesOrderPricingRequest, CrmLoseOpportunityRequest, CrmMakeAvailableToOrganizationReportRequest, CrmMakeAvailableToOrganizationTemplateRequest, CrmMakeUnavailableToOrganizationReportRequest, CrmMakeUnavailableToOrganizationTemplateRequest, CrmMergeRequest, CrmModifyAccessRequest, CrmParseImportRequest, CrmPickFromQueueRequest, CrmPreferredSolutionUsedByRequest, CrmProcessInboundEmailRequest, CrmPropagateByExpressionRequest, CrmProvisionLanguageAsyncRequest, CrmProvisionLanguageRequest, CrmPublishAllXmlAsyncRequest, CrmPublishAllXmlRequest, CrmPublishDuplicateRuleRequest, CrmPublishProductHierarchyRequest, CrmPublishThemeRequest, CrmPublishXmlRequest, CrmQualifyLeadRequest, CrmQualifyMemberListRequest, CrmQueryExpressionToFetchXmlRequest, CrmQueryMultipleSchedulesRequest, CrmQueryScheduleRequest, CrmQueueUpdateRibbonClientMetadataRequest, CrmReassignObjectsOwnerRequest, CrmReassignObjectsSystemUserRequest, CrmRecalculateRequest, CrmReleaseToQueueRequest, CrmRemoveAppComponentsRequest, CrmRemoveFromQueueRequest, CrmRemoveItemCampaignActivityRequest, CrmRemoveItemCampaignRequest, CrmRemoveMemberListRequest, CrmRemoveMembersTeamRequest, CrmRemoveParentRequest, CrmRemovePrivilegeRoleRequest, CrmRemoveProductFromKitRequest, CrmRemoveRelatedRequest, CrmRemoveSolutionComponentRequest, CrmRemoveSubstituteProductRequest, CrmRemoveUserFromRecordTeamRequest, CrmRenewContractRequest, CrmRenewEntitlementRequest, CrmReplacePrivilegesRoleRequest, CrmRescheduleRequest, CrmResetUserFiltersRequest, CrmRetrieveAadUserPrivilegesRequest, CrmRetrieveAadUserRolesRequest, CrmRetrieveAadUserSetOfPrivilegesByIdsRequest, CrmRetrieveAadUserSetOfPrivilegesByNamesRequest, CrmRetrieveAbsoluteAndSiteCollectionUrlRequest, CrmRetrieveActivePathRequest, CrmRetrieveAllChildUsersSystemUserRequest, CrmRetrieveAnalyticsStoreDetailsRequest, CrmRetrieveAppComponentsRequest, CrmRetrieveApplicationRibbonRequest, CrmRetrieveAttributeChangeHistoryRequest, CrmRetrieveAuditDetailsRequest, CrmRetrieveAuditPartitionListRequest, CrmRetrieveAvailableLanguagesRequest, CrmRetrieveBusinessHierarchyBusinessUnitRequest, CrmRetrieveByGroupResourceRequest, CrmRetrieveByResourceResourceGroupRequest, CrmRetrieveByResourcesServiceRequest, CrmRetrieveByTopIncidentProductKbArticleRequest, CrmRetrieveByTopIncidentSubjectKbArticleRequest, CrmRetrieveChannelAccessProfilePrivilegesRequest, CrmRetrieveCurrentOrganizationRequest, CrmRetrieveDependenciesForDeleteRequest, CrmRetrieveDependenciesForUninstallRequest, CrmRetrieveDependentComponentsRequest, CrmRetrieveDeploymentLicenseTypeRequest, CrmRetrieveDeprovisionedLanguagesRequest, CrmRetrieveDuplicatesRequest, CrmRetrieveEntityRibbonRequest, CrmRetrieveExchangeAppointmentsRequest, CrmRetrieveExchangeRateRequest, CrmRetrieveFeatureControlSettingRequest, CrmRetrieveFeatureControlSettingsByNamespaceRequest, CrmRetrieveFeatureControlSettingsRequest, CrmRetrieveFilteredFormsRequest, CrmRetrieveFormattedImportJobResultsRequest, CrmRetrieveFormXmlRequest, CrmRetrieveInstalledLanguagePacksRequest, CrmRetrieveInstalledLanguagePackVersionRequest, CrmRetrieveLicenseInfoRequest, CrmRetrieveLocLabelsRequest, CrmRetrieveMailboxTrackingFoldersRequest, CrmRetrieveMembersBulkOperationRequest, CrmRetrieveMembersTeamRequest, CrmRetrieveMissingComponentsRequest, CrmRetrieveMissingDependenciesRequest, CrmRetrieveOrganizationInfoRequest, CrmRetrieveOrganizationResourcesRequest, CrmRetrieveParentGroupsResourceGroupRequest, CrmRetrieveParsedDataImportFileRequest, CrmRetrievePersonalWallRequest, CrmRetrievePrincipalAccessInfoRequest, CrmRetrievePrincipalAccessRequest, CrmRetrievePrincipalAttributePrivilegesRequest, CrmRetrievePrincipalSyncAttributeMappingsRequest, CrmRetrievePrivilegeSetRequest, CrmRetrieveProcessInstancesRequest, CrmRetrieveProductPropertiesRequest, CrmRetrieveProvisionedLanguagePackVersionRequest, CrmRetrieveProvisionedLanguagesRequest, CrmRetrieveRecordChangeHistoryRequest, CrmRetrieveRecordWallRequest, CrmRetrieveRequiredComponentsRequest, CrmRetrieveRolePrivilegesRoleRequest, CrmRetrieveSharedLinksRequest, CrmRetrieveSharedPrincipalsAndAccessRequest, CrmRetrieveSubGroupsResourceGroupRequest, CrmRetrieveSubsidiaryTeamsBusinessUnitRequest, CrmRetrieveSubsidiaryUsersBusinessUnitRequest, CrmRetrieveTeamPrivilegesRequest, CrmRetrieveTeamsSystemUserRequest, CrmRetrieveTimelineWallRecordsRequest, CrmRetrieveTotalRecordCountRequest, CrmRetrieveUnpublishedMultipleRequest, CrmRetrieveUnpublishedRequest, CrmRetrieveUserLicenseInfoRequest, CrmRetrieveUserPrivilegeByPrivilegeIdRequest, CrmRetrieveUserPrivilegeByPrivilegeNameRequest, CrmRetrieveUserPrivilegesRequest, CrmRetrieveUserQueuesRequest, CrmRetrieveUserSetOfPrivilegesByIdsRequest, CrmRetrieveUserSetOfPrivilegesByNamesRequest, CrmRetrieveUserSettingsSystemUserRequest, CrmRetrieveUsersPrivilegesThroughTeamsRequest, CrmRetrieveVersionRequest, CrmRevertProductRequest, CrmReviseQuoteRequest, CrmRevokeAccessRequest, CrmRevokeSharedLinkRequest, CrmRollupRequest, CrmRouteToRequest, CrmSearchByBodyKbArticleRequest, CrmSearchByKeywordsKbArticleRequest, CrmSearchByTitleKbArticleRequest, CrmSearchRequest, CrmSendBulkMailRequest, CrmSendEmailFromTemplateRequest, CrmSendEmailRequest, CrmSendFaxRequest, CrmSendTemplateRequest, CrmSetAutoNumberSeed1Request, CrmSetAutoNumberSeedRequest, CrmSetBusinessEquipmentRequest, CrmSetBusinessSystemUserRequest, CrmSetFeatureStatusRequest, CrmSetLocLabelsRequest, CrmSetParentBusinessUnitRequest, CrmSetParentSystemUserRequest, CrmSetParentTeamRequest, CrmSetPreferredSolutionRequest, CrmSetProcessRequest, CrmSetRelatedRequest, CrmSetReportRelatedRequest, CrmSetStateRequest, CrmStageAndUpgradeAsyncRequest, CrmStageAndUpgradeRequest, CrmStageSolutionRequest, CrmSyncBulkOperationRequest, CrmTransformImportRequest, CrmTriggerServiceEndpointCheckRequest, CrmUninstallSampleDataRequest, CrmUninstallSolutionAsyncRequest, CrmUnlockInvoicePricingRequest, CrmUnlockSalesOrderPricingRequest, CrmUnpublishDuplicateRuleRequest, CrmUpdateFeatureConfigRequest, CrmUpdateProductPropertiesRequest, CrmUpdateRibbonClientMetadataRequest, CrmUpdateSolutionComponentRequest, CrmUpdateUserSettingsSystemUserRequest, CrmUploadBlockRequest, CrmUtcTimeFromLocalTimeRequest, CrmValidateAppRequest, CrmValidateFetchXmlExpressionRequest, CrmValidateRecurrenceRuleRequest, CrmValidateRequest, CrmValidateSavedQueryRequest, CrmValidateUnpublishedRequest, CrmWhoAmIRequest, CrmWinOpportunityRequest, CrmWinQuoteRequest, XrmAssociateRequest, XrmCanBeReferencedRequest, XrmCanBeReferencingRequest, XrmCanManyToManyRequest, XrmConvertDateAndTimeBehaviorRequest, XrmCreateAsyncJobToRevokeInheritedAccessRequest, XrmCreateAttributeRequest, XrmCreateCustomerRelationshipsRequest, XrmCreateEntityKeyRequest, XrmCreateEntityRequest, XrmCreateManyToManyRequest, XrmCreateMultipleRequest, XrmCreateOneToManyRequest, XrmCreateOptionSetRequest, XrmCreateRequest, XrmDeleteAttributeRequest, XrmDeleteEntityKeyRequest, XrmDeleteEntityRequest, XrmDeleteOptionSetRequest, XrmDeleteOptionValueRequest, XrmDeleteRelationshipRequest, XrmDeleteRequest, XrmDisassociateRequest, XrmExecuteAsyncRequest, XrmExecuteMultipleRequest, XrmExecuteTransactionRequest, XrmGetValidManyToManyRequest, XrmGetValidReferencedEntitiesRequest, XrmGetValidReferencingEntitiesRequest, XrmInsertOptionValueRequest, XrmInsertStatusValueRequest, XrmIsDataEncryptionActiveRequest, XrmOrderOptionRequest, XrmReactivateEntityKeyRequest, XrmRetrieveAllEntitiesRequest, XrmRetrieveAllManagedPropertiesRequest, XrmRetrieveAllOptionSetsRequest, XrmRetrieveAttributeRequest, XrmRetrieveDataEncryptionKeyRequest, XrmRetrieveEntityChangesRequest, XrmRetrieveEntityKeyRequest, XrmRetrieveEntityRequest, XrmRetrieveManagedPropertyRequest, XrmRetrieveMetadataChangesRequest, XrmRetrieveMultipleRequest, XrmRetrieveOptionSetRequest, XrmRetrieveRelationshipRequest, XrmRetrieveRequest, XrmRetrieveTimestampRequest, XrmSetDataEncryptionKeyRequest, XrmUpdateAttributeRequest, XrmUpdateEntityRequest, XrmUpdateMultipleRequest, XrmUpdateOptionSetRequest, XrmUpdateOptionValueRequest, XrmUpdateRelationshipRequest, XrmUpdateRequest, XrmUpdateStateValueRequest, XrmUpsertMultipleRequest, XrmUpsertRequest

Required: True
Position: 0
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Xrm.Sdk.OrganizationRequest

## NOTES

## RELATED LINKS


```yaml
Type: WKOrganizationRequestKind
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS


```yaml
Type: WKOrganizationRequestKind
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS


```yaml
Type: WKOrganizationRequestKind
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS
