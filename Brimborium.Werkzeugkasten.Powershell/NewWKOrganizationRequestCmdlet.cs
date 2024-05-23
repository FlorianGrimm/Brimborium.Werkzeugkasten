namespace Brimborium.Werkzeugkasten.Powershell;

public enum WKOrganizationRequestKind {
            CrmAddAppComponentsRequest,
            CrmAddChannelAccessProfilePrivilegesRequest,
            CrmAddItemCampaignActivityRequest,
            CrmAddItemCampaignRequest,
            CrmAddListMembersListRequest,
            CrmAddMemberListRequest,
            CrmAddMembersTeamRequest,
            CrmAddPrincipalToQueueRequest,
            CrmAddPrivilegesRoleRequest,
            CrmAddProductToKitRequest,
            CrmAddRecurrenceRequest,
            CrmAddSolutionComponentRequest,
            CrmAddSubstituteProductRequest,
            CrmAddToQueueRequest,
            CrmAddUserToRecordTeamRequest,
            CrmApplyRecordCreationAndUpdateRuleRequest,
            CrmApplyRoutingRuleRequest,
            CrmAssignRequest,
            CrmAssociateEntitiesRequest,
            CrmAutoMapEntityRequest,
            CrmBackgroundSendEmailRequest,
            CrmBookRequest,
            CrmBulkDeleteRequest,
            CrmBulkDetectDuplicatesRequest,
            CrmCalculateActualValueOpportunityRequest,
            CrmCalculatePriceRequest,
            CrmCalculateRollupFieldRequest,
            CrmCalculateTotalTimeIncidentRequest,
            CrmCancelContractRequest,
            CrmCancelSalesOrderRequest,
            CrmCheckIncomingEmailRequest,
            CrmCheckPromoteEmailRequest,
            CrmCloneAsPatchRequest,
            CrmCloneAsSolutionRequest,
            CrmCloneContractRequest,
            CrmCloneMobileOfflineProfileRequest,
            CrmCloneProductRequest,
            CrmCloseIncidentRequest,
            CrmCloseQuoteRequest,
            CrmCommitAnnotationBlocksUploadRequest,
            CrmCommitAttachmentBlocksUploadRequest,
            CrmCommitFileBlocksUploadRequest,
            CrmCompoundCreateRequest,
            CrmCompoundUpdateDuplicateDetectionRuleRequest,
            CrmCompoundUpdateRequest,
            CrmConvertKitToProductRequest,
            CrmConvertOwnerTeamToAccessTeamRequest,
            CrmConvertProductToKitRequest,
            CrmConvertQuoteToSalesOrderRequest,
            CrmConvertSalesOrderToInvoiceRequest,
            CrmCopyCampaignRequest,
            CrmCopyCampaignResponseRequest,
            CrmCopyDynamicListToStaticRequest,
            CrmCopyMembersListRequest,
            CrmCopySystemFormRequest,
            CrmCreateActivitiesListRequest,
            CrmCreateAsyncJobToRevokeInheritedAccessRequest,
            CrmCreateExceptionRequest,
            CrmCreateInstanceRequest,
            CrmCreateKnowledgeArticleTranslationRequest,
            CrmCreateKnowledgeArticleVersionRequest,
            CrmCreatePolymorphicLookupAttributeRequest,
            CrmCreateWorkflowFromTemplateRequest,
            CrmDeleteAndPromoteAsyncRequest,
            CrmDeleteAndPromoteRequest,
            CrmDeleteAuditDataRequest,
            CrmDeleteFileRequest,
            CrmDeleteOpenInstancesRequest,
            CrmDeleteRecordChangeHistory1Request,
            CrmDeleteRecordChangeHistoryRequest,
            CrmDeliverImmediatePromoteEmailRequest,
            CrmDeliverIncomingEmailRequest,
            CrmDeliverPromoteEmailRequest,
            CrmDeprovisionLanguageRequest,
            CrmDisassociateEntitiesRequest,
            CrmDistributeCampaignActivityRequest,
            CrmDownloadBlockRequest,
            CrmDownloadReportDefinitionRequest,
            CrmDownloadSolutionExportDataRequest,
            CrmExecuteByIdSavedQueryRequest,
            CrmExecuteByIdUserQueryRequest,
            CrmExecuteFetchRequest,
            CrmExecuteWorkflowRequest,
            CrmExpandCalendarRequest,
            CrmExportFieldTranslationRequest,
            CrmExportMappingsImportMapRequest,
            CrmExportSolutionAsyncRequest,
            CrmExportSolutionRequest,
            CrmExportTranslationRequest,
            CrmFetchXmlToQueryExpressionRequest,
            CrmFindParentResourceGroupRequest,
            CrmFormatAddressRequest,
            CrmFulfillSalesOrderRequest,
            CrmFullTextSearchKnowledgeArticleRequest,
            CrmGenerateInvoiceFromOpportunityRequest,
            CrmGenerateQuoteFromOpportunityRequest,
            CrmGenerateSalesOrderFromOpportunityRequest,
            CrmGenerateSharedLinkRequest,
            CrmGenerateSocialProfileRequest,
            CrmGetAllTimeZonesWithDisplayNameRequest,
            CrmGetAutoNumberSeed1Request,
            CrmGetAutoNumberSeedRequest,
            CrmGetDecryptionKeyRequest,
            CrmGetDefaultPriceLevelRequest,
            CrmGetDistinctValuesImportFileRequest,
            CrmGetFileSasUrlRequest,
            CrmGetHeaderColumnsImportFileRequest,
            CrmGetInvoiceProductsFromOpportunityRequest,
            CrmGetNextAutoNumberValue1Request,
            CrmGetNextAutoNumberValueRequest,
            CrmGetPreferredSolutionRequest,
            CrmGetQuantityDecimalRequest,
            CrmGetQuoteProductsFromOpportunityRequest,
            CrmGetReportHistoryLimitRequest,
            CrmGetSalesOrderProductsFromOpportunityRequest,
            CrmGetTimeZoneCodeByLocalizedNameRequest,
            CrmGetTrackingTokenEmailRequest,
            CrmGrantAccessRequest,
            CrmGrantAccessUsingSharedLinkRequest,
            CrmImmediateBookRequest,
            CrmImportCardTypeSchemaRequest,
            CrmImportFieldTranslationRequest,
            CrmImportMappingsImportMapRequest,
            CrmImportRecordsImportRequest,
            CrmImportSolutionAsyncRequest,
            CrmImportSolutionRequest,
            CrmImportSolutionsRequest,
            CrmImportTranslationAsyncRequest,
            CrmImportTranslationRequest,
            CrmIncrementKnowledgeArticleViewCountRequest,
            CrmInitializeAnnotationBlocksDownloadRequest,
            CrmInitializeAnnotationBlocksUploadRequest,
            CrmInitializeAttachmentBlocksDownloadRequest,
            CrmInitializeAttachmentBlocksUploadRequest,
            CrmInitializeFileBlocksDownloadRequest,
            CrmInitializeFileBlocksUploadRequest,
            CrmInitializeFromRequest,
            CrmInitializeModernFlowFromAsyncWorkflowRequest,
            CrmInstallSampleDataRequest,
            CrmInstantiateFiltersRequest,
            CrmInstantiateTemplateRequest,
            CrmIsBackOfficeInstalledRequest,
            CrmIsComponentCustomizableRequest,
            CrmIsValidStateTransitionRequest,
            CrmLocalTimeFromUtcTimeRequest,
            CrmLockInvoicePricingRequest,
            CrmLockSalesOrderPricingRequest,
            CrmLoseOpportunityRequest,
            CrmMakeAvailableToOrganizationReportRequest,
            CrmMakeAvailableToOrganizationTemplateRequest,
            CrmMakeUnavailableToOrganizationReportRequest,
            CrmMakeUnavailableToOrganizationTemplateRequest,
            CrmMergeRequest,
            CrmModifyAccessRequest,
            CrmParseImportRequest,
            CrmPickFromQueueRequest,
            CrmPreferredSolutionUsedByRequest,
            CrmProcessInboundEmailRequest,
            CrmPropagateByExpressionRequest,
            CrmProvisionLanguageAsyncRequest,
            CrmProvisionLanguageRequest,
            CrmPublishAllXmlAsyncRequest,
            CrmPublishAllXmlRequest,
            CrmPublishDuplicateRuleRequest,
            CrmPublishProductHierarchyRequest,
            CrmPublishThemeRequest,
            CrmPublishXmlRequest,
            CrmQualifyLeadRequest,
            CrmQualifyMemberListRequest,
            CrmQueryExpressionToFetchXmlRequest,
            CrmQueryMultipleSchedulesRequest,
            CrmQueryScheduleRequest,
            CrmQueueUpdateRibbonClientMetadataRequest,
            CrmReassignObjectsOwnerRequest,
            CrmReassignObjectsSystemUserRequest,
            CrmRecalculateRequest,
            CrmReleaseToQueueRequest,
            CrmRemoveAppComponentsRequest,
            CrmRemoveFromQueueRequest,
            CrmRemoveItemCampaignActivityRequest,
            CrmRemoveItemCampaignRequest,
            CrmRemoveMemberListRequest,
            CrmRemoveMembersTeamRequest,
            CrmRemoveParentRequest,
            CrmRemovePrivilegeRoleRequest,
            CrmRemoveProductFromKitRequest,
            CrmRemoveRelatedRequest,
            CrmRemoveSolutionComponentRequest,
            CrmRemoveSubstituteProductRequest,
            CrmRemoveUserFromRecordTeamRequest,
            CrmRenewContractRequest,
            CrmRenewEntitlementRequest,
            CrmReplacePrivilegesRoleRequest,
            CrmRescheduleRequest,
            CrmResetUserFiltersRequest,
            CrmRetrieveAadUserPrivilegesRequest,
            CrmRetrieveAadUserRolesRequest,
            CrmRetrieveAadUserSetOfPrivilegesByIdsRequest,
            CrmRetrieveAadUserSetOfPrivilegesByNamesRequest,
            CrmRetrieveAbsoluteAndSiteCollectionUrlRequest,
            CrmRetrieveActivePathRequest,
            CrmRetrieveAllChildUsersSystemUserRequest,
            CrmRetrieveAnalyticsStoreDetailsRequest,
            CrmRetrieveAppComponentsRequest,
            CrmRetrieveApplicationRibbonRequest,
            CrmRetrieveAttributeChangeHistoryRequest,
            CrmRetrieveAuditDetailsRequest,
            CrmRetrieveAuditPartitionListRequest,
            CrmRetrieveAvailableLanguagesRequest,
            CrmRetrieveBusinessHierarchyBusinessUnitRequest,
            CrmRetrieveByGroupResourceRequest,
            CrmRetrieveByResourceResourceGroupRequest,
            CrmRetrieveByResourcesServiceRequest,
            CrmRetrieveByTopIncidentProductKbArticleRequest,
            CrmRetrieveByTopIncidentSubjectKbArticleRequest,
            CrmRetrieveChannelAccessProfilePrivilegesRequest,
            CrmRetrieveCurrentOrganizationRequest,
            CrmRetrieveDependenciesForDeleteRequest,
            CrmRetrieveDependenciesForUninstallRequest,
            CrmRetrieveDependentComponentsRequest,
            CrmRetrieveDeploymentLicenseTypeRequest,
            CrmRetrieveDeprovisionedLanguagesRequest,
            CrmRetrieveDuplicatesRequest,
            CrmRetrieveEntityRibbonRequest,
            CrmRetrieveExchangeAppointmentsRequest,
            CrmRetrieveExchangeRateRequest,
            CrmRetrieveFeatureControlSettingRequest,
            CrmRetrieveFeatureControlSettingsByNamespaceRequest,
            CrmRetrieveFeatureControlSettingsRequest,
            CrmRetrieveFilteredFormsRequest,
            CrmRetrieveFormattedImportJobResultsRequest,
            CrmRetrieveFormXmlRequest,
            CrmRetrieveInstalledLanguagePacksRequest,
            CrmRetrieveInstalledLanguagePackVersionRequest,
            CrmRetrieveLicenseInfoRequest,
            CrmRetrieveLocLabelsRequest,
            CrmRetrieveMailboxTrackingFoldersRequest,
            CrmRetrieveMembersBulkOperationRequest,
            CrmRetrieveMembersTeamRequest,
            CrmRetrieveMissingComponentsRequest,
            CrmRetrieveMissingDependenciesRequest,
            CrmRetrieveOrganizationInfoRequest,
            CrmRetrieveOrganizationResourcesRequest,
            CrmRetrieveParentGroupsResourceGroupRequest,
            CrmRetrieveParsedDataImportFileRequest,
            CrmRetrievePersonalWallRequest,
            CrmRetrievePrincipalAccessInfoRequest,
            CrmRetrievePrincipalAccessRequest,
            CrmRetrievePrincipalAttributePrivilegesRequest,
            CrmRetrievePrincipalSyncAttributeMappingsRequest,
            CrmRetrievePrivilegeSetRequest,
            CrmRetrieveProcessInstancesRequest,
            CrmRetrieveProductPropertiesRequest,
            CrmRetrieveProvisionedLanguagePackVersionRequest,
            CrmRetrieveProvisionedLanguagesRequest,
            CrmRetrieveRecordChangeHistoryRequest,
            CrmRetrieveRecordWallRequest,
            CrmRetrieveRequiredComponentsRequest,
            CrmRetrieveRolePrivilegesRoleRequest,
            CrmRetrieveSharedLinksRequest,
            CrmRetrieveSharedPrincipalsAndAccessRequest,
            CrmRetrieveSubGroupsResourceGroupRequest,
            CrmRetrieveSubsidiaryTeamsBusinessUnitRequest,
            CrmRetrieveSubsidiaryUsersBusinessUnitRequest,
            CrmRetrieveTeamPrivilegesRequest,
            CrmRetrieveTeamsSystemUserRequest,
            CrmRetrieveTimelineWallRecordsRequest,
            CrmRetrieveTotalRecordCountRequest,
            CrmRetrieveUnpublishedMultipleRequest,
            CrmRetrieveUnpublishedRequest,
            CrmRetrieveUserLicenseInfoRequest,
            CrmRetrieveUserPrivilegeByPrivilegeIdRequest,
            CrmRetrieveUserPrivilegeByPrivilegeNameRequest,
            CrmRetrieveUserPrivilegesRequest,
            CrmRetrieveUserQueuesRequest,
            CrmRetrieveUserSetOfPrivilegesByIdsRequest,
            CrmRetrieveUserSetOfPrivilegesByNamesRequest,
            CrmRetrieveUserSettingsSystemUserRequest,
            CrmRetrieveUsersPrivilegesThroughTeamsRequest,
            CrmRetrieveVersionRequest,
            CrmRevertProductRequest,
            CrmReviseQuoteRequest,
            CrmRevokeAccessRequest,
            CrmRevokeSharedLinkRequest,
            CrmRollupRequest,
            CrmRouteToRequest,
            CrmSearchByBodyKbArticleRequest,
            CrmSearchByKeywordsKbArticleRequest,
            CrmSearchByTitleKbArticleRequest,
            CrmSearchRequest,
            CrmSendBulkMailRequest,
            CrmSendEmailFromTemplateRequest,
            CrmSendEmailRequest,
            CrmSendFaxRequest,
            CrmSendTemplateRequest,
            CrmSetAutoNumberSeed1Request,
            CrmSetAutoNumberSeedRequest,
            CrmSetBusinessEquipmentRequest,
            CrmSetBusinessSystemUserRequest,
            CrmSetFeatureStatusRequest,
            CrmSetLocLabelsRequest,
            CrmSetParentBusinessUnitRequest,
            CrmSetParentSystemUserRequest,
            CrmSetParentTeamRequest,
            CrmSetPreferredSolutionRequest,
            CrmSetProcessRequest,
            CrmSetRelatedRequest,
            CrmSetReportRelatedRequest,
            CrmSetStateRequest,
            CrmStageAndUpgradeAsyncRequest,
            CrmStageAndUpgradeRequest,
            CrmStageSolutionRequest,
            CrmSyncBulkOperationRequest,
            CrmTransformImportRequest,
            CrmTriggerServiceEndpointCheckRequest,
            CrmUninstallSampleDataRequest,
            CrmUninstallSolutionAsyncRequest,
            CrmUnlockInvoicePricingRequest,
            CrmUnlockSalesOrderPricingRequest,
            CrmUnpublishDuplicateRuleRequest,
            CrmUpdateFeatureConfigRequest,
            CrmUpdateProductPropertiesRequest,
            CrmUpdateRibbonClientMetadataRequest,
            CrmUpdateSolutionComponentRequest,
            CrmUpdateUserSettingsSystemUserRequest,
            CrmUploadBlockRequest,
            CrmUtcTimeFromLocalTimeRequest,
            CrmValidateAppRequest,
            CrmValidateFetchXmlExpressionRequest,
            CrmValidateRecurrenceRuleRequest,
            CrmValidateRequest,
            CrmValidateSavedQueryRequest,
            CrmValidateUnpublishedRequest,
            CrmWhoAmIRequest,
            CrmWinOpportunityRequest,
            CrmWinQuoteRequest,
            XrmAssociateRequest,
            XrmCanBeReferencedRequest,
            XrmCanBeReferencingRequest,
            XrmCanManyToManyRequest,
            XrmConvertDateAndTimeBehaviorRequest,
            XrmCreateAsyncJobToRevokeInheritedAccessRequest,
            XrmCreateAttributeRequest,
            XrmCreateCustomerRelationshipsRequest,
            XrmCreateEntityKeyRequest,
            XrmCreateEntityRequest,
            XrmCreateManyToManyRequest,
            XrmCreateMultipleRequest,
            XrmCreateOneToManyRequest,
            XrmCreateOptionSetRequest,
            XrmCreateRequest,
            XrmDeleteAttributeRequest,
            XrmDeleteEntityKeyRequest,
            XrmDeleteEntityRequest,
            XrmDeleteOptionSetRequest,
            XrmDeleteOptionValueRequest,
            XrmDeleteRelationshipRequest,
            XrmDeleteRequest,
            XrmDisassociateRequest,
            XrmExecuteAsyncRequest,
            XrmExecuteMultipleRequest,
            XrmExecuteTransactionRequest,
            XrmGetValidManyToManyRequest,
            XrmGetValidReferencedEntitiesRequest,
            XrmGetValidReferencingEntitiesRequest,
            XrmInsertOptionValueRequest,
            XrmInsertStatusValueRequest,
            XrmIsDataEncryptionActiveRequest,
            XrmOrderOptionRequest,
            XrmReactivateEntityKeyRequest,
            XrmRetrieveAllEntitiesRequest,
            XrmRetrieveAllManagedPropertiesRequest,
            XrmRetrieveAllOptionSetsRequest,
            XrmRetrieveAttributeRequest,
            XrmRetrieveDataEncryptionKeyRequest,
            XrmRetrieveEntityChangesRequest,
            XrmRetrieveEntityKeyRequest,
            XrmRetrieveEntityRequest,
            XrmRetrieveManagedPropertyRequest,
            XrmRetrieveMetadataChangesRequest,
            XrmRetrieveMultipleRequest,
            XrmRetrieveOptionSetRequest,
            XrmRetrieveRelationshipRequest,
            XrmRetrieveRequest,
            XrmRetrieveTimestampRequest,
            XrmSetDataEncryptionKeyRequest,
            XrmUpdateAttributeRequest,
            XrmUpdateEntityRequest,
            XrmUpdateMultipleRequest,
            XrmUpdateOptionSetRequest,
            XrmUpdateOptionValueRequest,
            XrmUpdateRelationshipRequest,
            XrmUpdateRequest,
            XrmUpdateStateValueRequest,
            XrmUpsertMultipleRequest,
            XrmUpsertRequest,
}

// New-WKOrganizationRequest
[Cmdlet(VerbsCommon.New, $"WK{nameof(OrganizationRequest)}")]
[OutputType(typeof(OrganizationRequest))]
public sealed class NewWKOrganizationRequestCmdlet : PSCmdlet {
    private static Dictionary<WKOrganizationRequestKind, Func<OrganizationRequest>> _FactoryByName = new();
    public static OrganizationRequest? GetOrganizationRequestByName(WKOrganizationRequestKind typeName) {
        if (_FactoryByName.Count == 0) {
            _FactoryByName.Add(WKOrganizationRequestKind.CrmAddAppComponentsRequest, () => new Microsoft.Crm.Sdk.Messages.AddAppComponentsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmAddChannelAccessProfilePrivilegesRequest, () => new Microsoft.Crm.Sdk.Messages.AddChannelAccessProfilePrivilegesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmAddItemCampaignActivityRequest, () => new Microsoft.Crm.Sdk.Messages.AddItemCampaignActivityRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmAddItemCampaignRequest, () => new Microsoft.Crm.Sdk.Messages.AddItemCampaignRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmAddListMembersListRequest, () => new Microsoft.Crm.Sdk.Messages.AddListMembersListRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmAddMemberListRequest, () => new Microsoft.Crm.Sdk.Messages.AddMemberListRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmAddMembersTeamRequest, () => new Microsoft.Crm.Sdk.Messages.AddMembersTeamRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmAddPrincipalToQueueRequest, () => new Microsoft.Crm.Sdk.Messages.AddPrincipalToQueueRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmAddPrivilegesRoleRequest, () => new Microsoft.Crm.Sdk.Messages.AddPrivilegesRoleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmAddProductToKitRequest, () => new Microsoft.Crm.Sdk.Messages.AddProductToKitRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmAddRecurrenceRequest, () => new Microsoft.Crm.Sdk.Messages.AddRecurrenceRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmAddSolutionComponentRequest, () => new Microsoft.Crm.Sdk.Messages.AddSolutionComponentRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmAddSubstituteProductRequest, () => new Microsoft.Crm.Sdk.Messages.AddSubstituteProductRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmAddToQueueRequest, () => new Microsoft.Crm.Sdk.Messages.AddToQueueRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmAddUserToRecordTeamRequest, () => new Microsoft.Crm.Sdk.Messages.AddUserToRecordTeamRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmApplyRecordCreationAndUpdateRuleRequest, () => new Microsoft.Crm.Sdk.Messages.ApplyRecordCreationAndUpdateRuleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmApplyRoutingRuleRequest, () => new Microsoft.Crm.Sdk.Messages.ApplyRoutingRuleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmAssignRequest, () => new Microsoft.Crm.Sdk.Messages.AssignRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmAssociateEntitiesRequest, () => new Microsoft.Crm.Sdk.Messages.AssociateEntitiesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmAutoMapEntityRequest, () => new Microsoft.Crm.Sdk.Messages.AutoMapEntityRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmBackgroundSendEmailRequest, () => new Microsoft.Crm.Sdk.Messages.BackgroundSendEmailRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmBookRequest, () => new Microsoft.Crm.Sdk.Messages.BookRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmBulkDeleteRequest, () => new Microsoft.Crm.Sdk.Messages.BulkDeleteRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmBulkDetectDuplicatesRequest, () => new Microsoft.Crm.Sdk.Messages.BulkDetectDuplicatesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCalculateActualValueOpportunityRequest, () => new Microsoft.Crm.Sdk.Messages.CalculateActualValueOpportunityRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCalculatePriceRequest, () => new Microsoft.Crm.Sdk.Messages.CalculatePriceRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCalculateRollupFieldRequest, () => new Microsoft.Crm.Sdk.Messages.CalculateRollupFieldRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCalculateTotalTimeIncidentRequest, () => new Microsoft.Crm.Sdk.Messages.CalculateTotalTimeIncidentRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCancelContractRequest, () => new Microsoft.Crm.Sdk.Messages.CancelContractRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCancelSalesOrderRequest, () => new Microsoft.Crm.Sdk.Messages.CancelSalesOrderRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCheckIncomingEmailRequest, () => new Microsoft.Crm.Sdk.Messages.CheckIncomingEmailRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCheckPromoteEmailRequest, () => new Microsoft.Crm.Sdk.Messages.CheckPromoteEmailRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCloneAsPatchRequest, () => new Microsoft.Crm.Sdk.Messages.CloneAsPatchRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCloneAsSolutionRequest, () => new Microsoft.Crm.Sdk.Messages.CloneAsSolutionRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCloneContractRequest, () => new Microsoft.Crm.Sdk.Messages.CloneContractRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCloneMobileOfflineProfileRequest, () => new Microsoft.Crm.Sdk.Messages.CloneMobileOfflineProfileRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCloneProductRequest, () => new Microsoft.Crm.Sdk.Messages.CloneProductRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCloseIncidentRequest, () => new Microsoft.Crm.Sdk.Messages.CloseIncidentRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCloseQuoteRequest, () => new Microsoft.Crm.Sdk.Messages.CloseQuoteRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCommitAnnotationBlocksUploadRequest, () => new Microsoft.Crm.Sdk.Messages.CommitAnnotationBlocksUploadRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCommitAttachmentBlocksUploadRequest, () => new Microsoft.Crm.Sdk.Messages.CommitAttachmentBlocksUploadRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCommitFileBlocksUploadRequest, () => new Microsoft.Crm.Sdk.Messages.CommitFileBlocksUploadRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCompoundCreateRequest, () => new Microsoft.Crm.Sdk.Messages.CompoundCreateRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCompoundUpdateDuplicateDetectionRuleRequest, () => new Microsoft.Crm.Sdk.Messages.CompoundUpdateDuplicateDetectionRuleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCompoundUpdateRequest, () => new Microsoft.Crm.Sdk.Messages.CompoundUpdateRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmConvertKitToProductRequest, () => new Microsoft.Crm.Sdk.Messages.ConvertKitToProductRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmConvertOwnerTeamToAccessTeamRequest, () => new Microsoft.Crm.Sdk.Messages.ConvertOwnerTeamToAccessTeamRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmConvertProductToKitRequest, () => new Microsoft.Crm.Sdk.Messages.ConvertProductToKitRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmConvertQuoteToSalesOrderRequest, () => new Microsoft.Crm.Sdk.Messages.ConvertQuoteToSalesOrderRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmConvertSalesOrderToInvoiceRequest, () => new Microsoft.Crm.Sdk.Messages.ConvertSalesOrderToInvoiceRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCopyCampaignRequest, () => new Microsoft.Crm.Sdk.Messages.CopyCampaignRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCopyCampaignResponseRequest, () => new Microsoft.Crm.Sdk.Messages.CopyCampaignResponseRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCopyDynamicListToStaticRequest, () => new Microsoft.Crm.Sdk.Messages.CopyDynamicListToStaticRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCopyMembersListRequest, () => new Microsoft.Crm.Sdk.Messages.CopyMembersListRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCopySystemFormRequest, () => new Microsoft.Crm.Sdk.Messages.CopySystemFormRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCreateActivitiesListRequest, () => new Microsoft.Crm.Sdk.Messages.CreateActivitiesListRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCreateAsyncJobToRevokeInheritedAccessRequest, () => new Microsoft.Crm.Sdk.Messages.CreateAsyncJobToRevokeInheritedAccessRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCreateExceptionRequest, () => new Microsoft.Crm.Sdk.Messages.CreateExceptionRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCreateInstanceRequest, () => new Microsoft.Crm.Sdk.Messages.CreateInstanceRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCreateKnowledgeArticleTranslationRequest, () => new Microsoft.Crm.Sdk.Messages.CreateKnowledgeArticleTranslationRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCreateKnowledgeArticleVersionRequest, () => new Microsoft.Crm.Sdk.Messages.CreateKnowledgeArticleVersionRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCreatePolymorphicLookupAttributeRequest, () => new Microsoft.Crm.Sdk.Messages.CreatePolymorphicLookupAttributeRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmCreateWorkflowFromTemplateRequest, () => new Microsoft.Crm.Sdk.Messages.CreateWorkflowFromTemplateRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmDeleteAndPromoteAsyncRequest, () => new Microsoft.Crm.Sdk.Messages.DeleteAndPromoteAsyncRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmDeleteAndPromoteRequest, () => new Microsoft.Crm.Sdk.Messages.DeleteAndPromoteRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmDeleteAuditDataRequest, () => new Microsoft.Crm.Sdk.Messages.DeleteAuditDataRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmDeleteFileRequest, () => new Microsoft.Crm.Sdk.Messages.DeleteFileRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmDeleteOpenInstancesRequest, () => new Microsoft.Crm.Sdk.Messages.DeleteOpenInstancesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmDeleteRecordChangeHistory1Request, () => new Microsoft.Crm.Sdk.Messages.DeleteRecordChangeHistory1Request());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmDeleteRecordChangeHistoryRequest, () => new Microsoft.Crm.Sdk.Messages.DeleteRecordChangeHistoryRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmDeliverImmediatePromoteEmailRequest, () => new Microsoft.Crm.Sdk.Messages.DeliverImmediatePromoteEmailRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmDeliverIncomingEmailRequest, () => new Microsoft.Crm.Sdk.Messages.DeliverIncomingEmailRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmDeliverPromoteEmailRequest, () => new Microsoft.Crm.Sdk.Messages.DeliverPromoteEmailRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmDeprovisionLanguageRequest, () => new Microsoft.Crm.Sdk.Messages.DeprovisionLanguageRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmDisassociateEntitiesRequest, () => new Microsoft.Crm.Sdk.Messages.DisassociateEntitiesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmDistributeCampaignActivityRequest, () => new Microsoft.Crm.Sdk.Messages.DistributeCampaignActivityRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmDownloadBlockRequest, () => new Microsoft.Crm.Sdk.Messages.DownloadBlockRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmDownloadReportDefinitionRequest, () => new Microsoft.Crm.Sdk.Messages.DownloadReportDefinitionRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmDownloadSolutionExportDataRequest, () => new Microsoft.Crm.Sdk.Messages.DownloadSolutionExportDataRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmExecuteByIdSavedQueryRequest, () => new Microsoft.Crm.Sdk.Messages.ExecuteByIdSavedQueryRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmExecuteByIdUserQueryRequest, () => new Microsoft.Crm.Sdk.Messages.ExecuteByIdUserQueryRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmExecuteFetchRequest, () => new Microsoft.Crm.Sdk.Messages.ExecuteFetchRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmExecuteWorkflowRequest, () => new Microsoft.Crm.Sdk.Messages.ExecuteWorkflowRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmExpandCalendarRequest, () => new Microsoft.Crm.Sdk.Messages.ExpandCalendarRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmExportFieldTranslationRequest, () => new Microsoft.Crm.Sdk.Messages.ExportFieldTranslationRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmExportMappingsImportMapRequest, () => new Microsoft.Crm.Sdk.Messages.ExportMappingsImportMapRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmExportSolutionAsyncRequest, () => new Microsoft.Crm.Sdk.Messages.ExportSolutionAsyncRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmExportSolutionRequest, () => new Microsoft.Crm.Sdk.Messages.ExportSolutionRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmExportTranslationRequest, () => new Microsoft.Crm.Sdk.Messages.ExportTranslationRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmFetchXmlToQueryExpressionRequest, () => new Microsoft.Crm.Sdk.Messages.FetchXmlToQueryExpressionRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmFindParentResourceGroupRequest, () => new Microsoft.Crm.Sdk.Messages.FindParentResourceGroupRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmFormatAddressRequest, () => new Microsoft.Crm.Sdk.Messages.FormatAddressRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmFulfillSalesOrderRequest, () => new Microsoft.Crm.Sdk.Messages.FulfillSalesOrderRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmFullTextSearchKnowledgeArticleRequest, () => new Microsoft.Crm.Sdk.Messages.FullTextSearchKnowledgeArticleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGenerateInvoiceFromOpportunityRequest, () => new Microsoft.Crm.Sdk.Messages.GenerateInvoiceFromOpportunityRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGenerateQuoteFromOpportunityRequest, () => new Microsoft.Crm.Sdk.Messages.GenerateQuoteFromOpportunityRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGenerateSalesOrderFromOpportunityRequest, () => new Microsoft.Crm.Sdk.Messages.GenerateSalesOrderFromOpportunityRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGenerateSharedLinkRequest, () => new Microsoft.Crm.Sdk.Messages.GenerateSharedLinkRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGenerateSocialProfileRequest, () => new Microsoft.Crm.Sdk.Messages.GenerateSocialProfileRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGetAllTimeZonesWithDisplayNameRequest, () => new Microsoft.Crm.Sdk.Messages.GetAllTimeZonesWithDisplayNameRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGetAutoNumberSeed1Request, () => new Microsoft.Crm.Sdk.Messages.GetAutoNumberSeed1Request());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGetAutoNumberSeedRequest, () => new Microsoft.Crm.Sdk.Messages.GetAutoNumberSeedRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGetDecryptionKeyRequest, () => new Microsoft.Crm.Sdk.Messages.GetDecryptionKeyRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGetDefaultPriceLevelRequest, () => new Microsoft.Crm.Sdk.Messages.GetDefaultPriceLevelRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGetDistinctValuesImportFileRequest, () => new Microsoft.Crm.Sdk.Messages.GetDistinctValuesImportFileRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGetFileSasUrlRequest, () => new Microsoft.Crm.Sdk.Messages.GetFileSasUrlRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGetHeaderColumnsImportFileRequest, () => new Microsoft.Crm.Sdk.Messages.GetHeaderColumnsImportFileRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGetInvoiceProductsFromOpportunityRequest, () => new Microsoft.Crm.Sdk.Messages.GetInvoiceProductsFromOpportunityRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGetNextAutoNumberValue1Request, () => new Microsoft.Crm.Sdk.Messages.GetNextAutoNumberValue1Request());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGetNextAutoNumberValueRequest, () => new Microsoft.Crm.Sdk.Messages.GetNextAutoNumberValueRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGetPreferredSolutionRequest, () => new Microsoft.Crm.Sdk.Messages.GetPreferredSolutionRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGetQuantityDecimalRequest, () => new Microsoft.Crm.Sdk.Messages.GetQuantityDecimalRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGetQuoteProductsFromOpportunityRequest, () => new Microsoft.Crm.Sdk.Messages.GetQuoteProductsFromOpportunityRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGetReportHistoryLimitRequest, () => new Microsoft.Crm.Sdk.Messages.GetReportHistoryLimitRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGetSalesOrderProductsFromOpportunityRequest, () => new Microsoft.Crm.Sdk.Messages.GetSalesOrderProductsFromOpportunityRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGetTimeZoneCodeByLocalizedNameRequest, () => new Microsoft.Crm.Sdk.Messages.GetTimeZoneCodeByLocalizedNameRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGetTrackingTokenEmailRequest, () => new Microsoft.Crm.Sdk.Messages.GetTrackingTokenEmailRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGrantAccessRequest, () => new Microsoft.Crm.Sdk.Messages.GrantAccessRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmGrantAccessUsingSharedLinkRequest, () => new Microsoft.Crm.Sdk.Messages.GrantAccessUsingSharedLinkRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmImmediateBookRequest, () => new Microsoft.Crm.Sdk.Messages.ImmediateBookRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmImportCardTypeSchemaRequest, () => new Microsoft.Crm.Sdk.Messages.ImportCardTypeSchemaRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmImportFieldTranslationRequest, () => new Microsoft.Crm.Sdk.Messages.ImportFieldTranslationRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmImportMappingsImportMapRequest, () => new Microsoft.Crm.Sdk.Messages.ImportMappingsImportMapRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmImportRecordsImportRequest, () => new Microsoft.Crm.Sdk.Messages.ImportRecordsImportRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmImportSolutionAsyncRequest, () => new Microsoft.Crm.Sdk.Messages.ImportSolutionAsyncRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmImportSolutionRequest, () => new Microsoft.Crm.Sdk.Messages.ImportSolutionRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmImportSolutionsRequest, () => new Microsoft.Crm.Sdk.Messages.ImportSolutionsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmImportTranslationAsyncRequest, () => new Microsoft.Crm.Sdk.Messages.ImportTranslationAsyncRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmImportTranslationRequest, () => new Microsoft.Crm.Sdk.Messages.ImportTranslationRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmIncrementKnowledgeArticleViewCountRequest, () => new Microsoft.Crm.Sdk.Messages.IncrementKnowledgeArticleViewCountRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmInitializeAnnotationBlocksDownloadRequest, () => new Microsoft.Crm.Sdk.Messages.InitializeAnnotationBlocksDownloadRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmInitializeAnnotationBlocksUploadRequest, () => new Microsoft.Crm.Sdk.Messages.InitializeAnnotationBlocksUploadRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmInitializeAttachmentBlocksDownloadRequest, () => new Microsoft.Crm.Sdk.Messages.InitializeAttachmentBlocksDownloadRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmInitializeAttachmentBlocksUploadRequest, () => new Microsoft.Crm.Sdk.Messages.InitializeAttachmentBlocksUploadRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmInitializeFileBlocksDownloadRequest, () => new Microsoft.Crm.Sdk.Messages.InitializeFileBlocksDownloadRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmInitializeFileBlocksUploadRequest, () => new Microsoft.Crm.Sdk.Messages.InitializeFileBlocksUploadRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmInitializeFromRequest, () => new Microsoft.Crm.Sdk.Messages.InitializeFromRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmInitializeModernFlowFromAsyncWorkflowRequest, () => new Microsoft.Crm.Sdk.Messages.InitializeModernFlowFromAsyncWorkflowRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmInstallSampleDataRequest, () => new Microsoft.Crm.Sdk.Messages.InstallSampleDataRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmInstantiateFiltersRequest, () => new Microsoft.Crm.Sdk.Messages.InstantiateFiltersRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmInstantiateTemplateRequest, () => new Microsoft.Crm.Sdk.Messages.InstantiateTemplateRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmIsBackOfficeInstalledRequest, () => new Microsoft.Crm.Sdk.Messages.IsBackOfficeInstalledRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmIsComponentCustomizableRequest, () => new Microsoft.Crm.Sdk.Messages.IsComponentCustomizableRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmIsValidStateTransitionRequest, () => new Microsoft.Crm.Sdk.Messages.IsValidStateTransitionRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmLocalTimeFromUtcTimeRequest, () => new Microsoft.Crm.Sdk.Messages.LocalTimeFromUtcTimeRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmLockInvoicePricingRequest, () => new Microsoft.Crm.Sdk.Messages.LockInvoicePricingRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmLockSalesOrderPricingRequest, () => new Microsoft.Crm.Sdk.Messages.LockSalesOrderPricingRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmLoseOpportunityRequest, () => new Microsoft.Crm.Sdk.Messages.LoseOpportunityRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmMakeAvailableToOrganizationReportRequest, () => new Microsoft.Crm.Sdk.Messages.MakeAvailableToOrganizationReportRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmMakeAvailableToOrganizationTemplateRequest, () => new Microsoft.Crm.Sdk.Messages.MakeAvailableToOrganizationTemplateRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmMakeUnavailableToOrganizationReportRequest, () => new Microsoft.Crm.Sdk.Messages.MakeUnavailableToOrganizationReportRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmMakeUnavailableToOrganizationTemplateRequest, () => new Microsoft.Crm.Sdk.Messages.MakeUnavailableToOrganizationTemplateRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmMergeRequest, () => new Microsoft.Crm.Sdk.Messages.MergeRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmModifyAccessRequest, () => new Microsoft.Crm.Sdk.Messages.ModifyAccessRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmParseImportRequest, () => new Microsoft.Crm.Sdk.Messages.ParseImportRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmPickFromQueueRequest, () => new Microsoft.Crm.Sdk.Messages.PickFromQueueRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmPreferredSolutionUsedByRequest, () => new Microsoft.Crm.Sdk.Messages.PreferredSolutionUsedByRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmProcessInboundEmailRequest, () => new Microsoft.Crm.Sdk.Messages.ProcessInboundEmailRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmPropagateByExpressionRequest, () => new Microsoft.Crm.Sdk.Messages.PropagateByExpressionRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmProvisionLanguageAsyncRequest, () => new Microsoft.Crm.Sdk.Messages.ProvisionLanguageAsyncRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmProvisionLanguageRequest, () => new Microsoft.Crm.Sdk.Messages.ProvisionLanguageRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmPublishAllXmlAsyncRequest, () => new Microsoft.Crm.Sdk.Messages.PublishAllXmlAsyncRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmPublishAllXmlRequest, () => new Microsoft.Crm.Sdk.Messages.PublishAllXmlRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmPublishDuplicateRuleRequest, () => new Microsoft.Crm.Sdk.Messages.PublishDuplicateRuleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmPublishProductHierarchyRequest, () => new Microsoft.Crm.Sdk.Messages.PublishProductHierarchyRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmPublishThemeRequest, () => new Microsoft.Crm.Sdk.Messages.PublishThemeRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmPublishXmlRequest, () => new Microsoft.Crm.Sdk.Messages.PublishXmlRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmQualifyLeadRequest, () => new Microsoft.Crm.Sdk.Messages.QualifyLeadRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmQualifyMemberListRequest, () => new Microsoft.Crm.Sdk.Messages.QualifyMemberListRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmQueryExpressionToFetchXmlRequest, () => new Microsoft.Crm.Sdk.Messages.QueryExpressionToFetchXmlRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmQueryMultipleSchedulesRequest, () => new Microsoft.Crm.Sdk.Messages.QueryMultipleSchedulesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmQueryScheduleRequest, () => new Microsoft.Crm.Sdk.Messages.QueryScheduleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmQueueUpdateRibbonClientMetadataRequest, () => new Microsoft.Crm.Sdk.Messages.QueueUpdateRibbonClientMetadataRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmReassignObjectsOwnerRequest, () => new Microsoft.Crm.Sdk.Messages.ReassignObjectsOwnerRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmReassignObjectsSystemUserRequest, () => new Microsoft.Crm.Sdk.Messages.ReassignObjectsSystemUserRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRecalculateRequest, () => new Microsoft.Crm.Sdk.Messages.RecalculateRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmReleaseToQueueRequest, () => new Microsoft.Crm.Sdk.Messages.ReleaseToQueueRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRemoveAppComponentsRequest, () => new Microsoft.Crm.Sdk.Messages.RemoveAppComponentsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRemoveFromQueueRequest, () => new Microsoft.Crm.Sdk.Messages.RemoveFromQueueRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRemoveItemCampaignActivityRequest, () => new Microsoft.Crm.Sdk.Messages.RemoveItemCampaignActivityRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRemoveItemCampaignRequest, () => new Microsoft.Crm.Sdk.Messages.RemoveItemCampaignRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRemoveMemberListRequest, () => new Microsoft.Crm.Sdk.Messages.RemoveMemberListRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRemoveMembersTeamRequest, () => new Microsoft.Crm.Sdk.Messages.RemoveMembersTeamRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRemoveParentRequest, () => new Microsoft.Crm.Sdk.Messages.RemoveParentRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRemovePrivilegeRoleRequest, () => new Microsoft.Crm.Sdk.Messages.RemovePrivilegeRoleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRemoveProductFromKitRequest, () => new Microsoft.Crm.Sdk.Messages.RemoveProductFromKitRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRemoveRelatedRequest, () => new Microsoft.Crm.Sdk.Messages.RemoveRelatedRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRemoveSolutionComponentRequest, () => new Microsoft.Crm.Sdk.Messages.RemoveSolutionComponentRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRemoveSubstituteProductRequest, () => new Microsoft.Crm.Sdk.Messages.RemoveSubstituteProductRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRemoveUserFromRecordTeamRequest, () => new Microsoft.Crm.Sdk.Messages.RemoveUserFromRecordTeamRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRenewContractRequest, () => new Microsoft.Crm.Sdk.Messages.RenewContractRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRenewEntitlementRequest, () => new Microsoft.Crm.Sdk.Messages.RenewEntitlementRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmReplacePrivilegesRoleRequest, () => new Microsoft.Crm.Sdk.Messages.ReplacePrivilegesRoleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRescheduleRequest, () => new Microsoft.Crm.Sdk.Messages.RescheduleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmResetUserFiltersRequest, () => new Microsoft.Crm.Sdk.Messages.ResetUserFiltersRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveAadUserPrivilegesRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveAadUserPrivilegesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveAadUserRolesRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveAadUserRolesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveAadUserSetOfPrivilegesByIdsRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveAadUserSetOfPrivilegesByIdsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveAadUserSetOfPrivilegesByNamesRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveAadUserSetOfPrivilegesByNamesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveAbsoluteAndSiteCollectionUrlRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveAbsoluteAndSiteCollectionUrlRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveActivePathRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveActivePathRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveAllChildUsersSystemUserRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveAllChildUsersSystemUserRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveAnalyticsStoreDetailsRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveAnalyticsStoreDetailsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveAppComponentsRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveAppComponentsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveApplicationRibbonRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveApplicationRibbonRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveAttributeChangeHistoryRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveAttributeChangeHistoryRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveAuditDetailsRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveAuditDetailsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveAuditPartitionListRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveAuditPartitionListRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveAvailableLanguagesRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveAvailableLanguagesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveBusinessHierarchyBusinessUnitRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveBusinessHierarchyBusinessUnitRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveByGroupResourceRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveByGroupResourceRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveByResourceResourceGroupRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveByResourceResourceGroupRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveByResourcesServiceRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveByResourcesServiceRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveByTopIncidentProductKbArticleRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveByTopIncidentProductKbArticleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveByTopIncidentSubjectKbArticleRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveByTopIncidentSubjectKbArticleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveChannelAccessProfilePrivilegesRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveChannelAccessProfilePrivilegesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveCurrentOrganizationRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveCurrentOrganizationRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveDependenciesForDeleteRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveDependenciesForDeleteRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveDependenciesForUninstallRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveDependenciesForUninstallRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveDependentComponentsRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveDependentComponentsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveDeploymentLicenseTypeRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveDeploymentLicenseTypeRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveDeprovisionedLanguagesRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveDeprovisionedLanguagesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveDuplicatesRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveDuplicatesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveEntityRibbonRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveEntityRibbonRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveExchangeAppointmentsRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveExchangeAppointmentsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveExchangeRateRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveExchangeRateRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveFeatureControlSettingRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveFeatureControlSettingRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveFeatureControlSettingsByNamespaceRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveFeatureControlSettingsByNamespaceRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveFeatureControlSettingsRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveFeatureControlSettingsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveFilteredFormsRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveFilteredFormsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveFormattedImportJobResultsRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveFormattedImportJobResultsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveFormXmlRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveFormXmlRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveInstalledLanguagePacksRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveInstalledLanguagePacksRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveInstalledLanguagePackVersionRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveInstalledLanguagePackVersionRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveLicenseInfoRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveLicenseInfoRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveLocLabelsRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveLocLabelsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveMailboxTrackingFoldersRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveMailboxTrackingFoldersRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveMembersBulkOperationRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveMembersBulkOperationRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveMembersTeamRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveMembersTeamRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveMissingComponentsRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveMissingComponentsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveMissingDependenciesRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveMissingDependenciesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveOrganizationInfoRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveOrganizationInfoRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveOrganizationResourcesRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveOrganizationResourcesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveParentGroupsResourceGroupRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveParentGroupsResourceGroupRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveParsedDataImportFileRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveParsedDataImportFileRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrievePersonalWallRequest, () => new Microsoft.Crm.Sdk.Messages.RetrievePersonalWallRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrievePrincipalAccessInfoRequest, () => new Microsoft.Crm.Sdk.Messages.RetrievePrincipalAccessInfoRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrievePrincipalAccessRequest, () => new Microsoft.Crm.Sdk.Messages.RetrievePrincipalAccessRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrievePrincipalAttributePrivilegesRequest, () => new Microsoft.Crm.Sdk.Messages.RetrievePrincipalAttributePrivilegesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrievePrincipalSyncAttributeMappingsRequest, () => new Microsoft.Crm.Sdk.Messages.RetrievePrincipalSyncAttributeMappingsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrievePrivilegeSetRequest, () => new Microsoft.Crm.Sdk.Messages.RetrievePrivilegeSetRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveProcessInstancesRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveProcessInstancesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveProductPropertiesRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveProductPropertiesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveProvisionedLanguagePackVersionRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveProvisionedLanguagePackVersionRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveProvisionedLanguagesRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveProvisionedLanguagesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveRecordChangeHistoryRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveRecordChangeHistoryRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveRecordWallRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveRecordWallRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveRequiredComponentsRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveRequiredComponentsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveRolePrivilegesRoleRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveRolePrivilegesRoleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveSharedLinksRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveSharedLinksRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveSharedPrincipalsAndAccessRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveSharedPrincipalsAndAccessRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveSubGroupsResourceGroupRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveSubGroupsResourceGroupRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveSubsidiaryTeamsBusinessUnitRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveSubsidiaryTeamsBusinessUnitRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveSubsidiaryUsersBusinessUnitRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveSubsidiaryUsersBusinessUnitRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveTeamPrivilegesRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveTeamPrivilegesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveTeamsSystemUserRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveTeamsSystemUserRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveTimelineWallRecordsRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveTimelineWallRecordsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveTotalRecordCountRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveTotalRecordCountRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveUnpublishedMultipleRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveUnpublishedMultipleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveUnpublishedRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveUnpublishedRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveUserLicenseInfoRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveUserLicenseInfoRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveUserPrivilegeByPrivilegeIdRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveUserPrivilegeByPrivilegeIdRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveUserPrivilegeByPrivilegeNameRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveUserPrivilegeByPrivilegeNameRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveUserPrivilegesRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveUserPrivilegesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveUserQueuesRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveUserQueuesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveUserSetOfPrivilegesByIdsRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveUserSetOfPrivilegesByIdsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveUserSetOfPrivilegesByNamesRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveUserSetOfPrivilegesByNamesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveUserSettingsSystemUserRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveUserSettingsSystemUserRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveUsersPrivilegesThroughTeamsRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveUsersPrivilegesThroughTeamsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRetrieveVersionRequest, () => new Microsoft.Crm.Sdk.Messages.RetrieveVersionRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRevertProductRequest, () => new Microsoft.Crm.Sdk.Messages.RevertProductRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmReviseQuoteRequest, () => new Microsoft.Crm.Sdk.Messages.ReviseQuoteRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRevokeAccessRequest, () => new Microsoft.Crm.Sdk.Messages.RevokeAccessRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRevokeSharedLinkRequest, () => new Microsoft.Crm.Sdk.Messages.RevokeSharedLinkRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRollupRequest, () => new Microsoft.Crm.Sdk.Messages.RollupRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmRouteToRequest, () => new Microsoft.Crm.Sdk.Messages.RouteToRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSearchByBodyKbArticleRequest, () => new Microsoft.Crm.Sdk.Messages.SearchByBodyKbArticleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSearchByKeywordsKbArticleRequest, () => new Microsoft.Crm.Sdk.Messages.SearchByKeywordsKbArticleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSearchByTitleKbArticleRequest, () => new Microsoft.Crm.Sdk.Messages.SearchByTitleKbArticleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSearchRequest, () => new Microsoft.Crm.Sdk.Messages.SearchRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSendBulkMailRequest, () => new Microsoft.Crm.Sdk.Messages.SendBulkMailRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSendEmailFromTemplateRequest, () => new Microsoft.Crm.Sdk.Messages.SendEmailFromTemplateRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSendEmailRequest, () => new Microsoft.Crm.Sdk.Messages.SendEmailRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSendFaxRequest, () => new Microsoft.Crm.Sdk.Messages.SendFaxRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSendTemplateRequest, () => new Microsoft.Crm.Sdk.Messages.SendTemplateRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSetAutoNumberSeed1Request, () => new Microsoft.Crm.Sdk.Messages.SetAutoNumberSeed1Request());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSetAutoNumberSeedRequest, () => new Microsoft.Crm.Sdk.Messages.SetAutoNumberSeedRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSetBusinessEquipmentRequest, () => new Microsoft.Crm.Sdk.Messages.SetBusinessEquipmentRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSetBusinessSystemUserRequest, () => new Microsoft.Crm.Sdk.Messages.SetBusinessSystemUserRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSetFeatureStatusRequest, () => new Microsoft.Crm.Sdk.Messages.SetFeatureStatusRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSetLocLabelsRequest, () => new Microsoft.Crm.Sdk.Messages.SetLocLabelsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSetParentBusinessUnitRequest, () => new Microsoft.Crm.Sdk.Messages.SetParentBusinessUnitRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSetParentSystemUserRequest, () => new Microsoft.Crm.Sdk.Messages.SetParentSystemUserRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSetParentTeamRequest, () => new Microsoft.Crm.Sdk.Messages.SetParentTeamRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSetPreferredSolutionRequest, () => new Microsoft.Crm.Sdk.Messages.SetPreferredSolutionRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSetProcessRequest, () => new Microsoft.Crm.Sdk.Messages.SetProcessRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSetRelatedRequest, () => new Microsoft.Crm.Sdk.Messages.SetRelatedRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSetReportRelatedRequest, () => new Microsoft.Crm.Sdk.Messages.SetReportRelatedRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSetStateRequest, () => new Microsoft.Crm.Sdk.Messages.SetStateRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmStageAndUpgradeAsyncRequest, () => new Microsoft.Crm.Sdk.Messages.StageAndUpgradeAsyncRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmStageAndUpgradeRequest, () => new Microsoft.Crm.Sdk.Messages.StageAndUpgradeRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmStageSolutionRequest, () => new Microsoft.Crm.Sdk.Messages.StageSolutionRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmSyncBulkOperationRequest, () => new Microsoft.Crm.Sdk.Messages.SyncBulkOperationRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmTransformImportRequest, () => new Microsoft.Crm.Sdk.Messages.TransformImportRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmTriggerServiceEndpointCheckRequest, () => new Microsoft.Crm.Sdk.Messages.TriggerServiceEndpointCheckRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmUninstallSampleDataRequest, () => new Microsoft.Crm.Sdk.Messages.UninstallSampleDataRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmUninstallSolutionAsyncRequest, () => new Microsoft.Crm.Sdk.Messages.UninstallSolutionAsyncRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmUnlockInvoicePricingRequest, () => new Microsoft.Crm.Sdk.Messages.UnlockInvoicePricingRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmUnlockSalesOrderPricingRequest, () => new Microsoft.Crm.Sdk.Messages.UnlockSalesOrderPricingRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmUnpublishDuplicateRuleRequest, () => new Microsoft.Crm.Sdk.Messages.UnpublishDuplicateRuleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmUpdateFeatureConfigRequest, () => new Microsoft.Crm.Sdk.Messages.UpdateFeatureConfigRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmUpdateProductPropertiesRequest, () => new Microsoft.Crm.Sdk.Messages.UpdateProductPropertiesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmUpdateRibbonClientMetadataRequest, () => new Microsoft.Crm.Sdk.Messages.UpdateRibbonClientMetadataRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmUpdateSolutionComponentRequest, () => new Microsoft.Crm.Sdk.Messages.UpdateSolutionComponentRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmUpdateUserSettingsSystemUserRequest, () => new Microsoft.Crm.Sdk.Messages.UpdateUserSettingsSystemUserRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmUploadBlockRequest, () => new Microsoft.Crm.Sdk.Messages.UploadBlockRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmUtcTimeFromLocalTimeRequest, () => new Microsoft.Crm.Sdk.Messages.UtcTimeFromLocalTimeRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmValidateAppRequest, () => new Microsoft.Crm.Sdk.Messages.ValidateAppRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmValidateFetchXmlExpressionRequest, () => new Microsoft.Crm.Sdk.Messages.ValidateFetchXmlExpressionRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmValidateRecurrenceRuleRequest, () => new Microsoft.Crm.Sdk.Messages.ValidateRecurrenceRuleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmValidateRequest, () => new Microsoft.Crm.Sdk.Messages.ValidateRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmValidateSavedQueryRequest, () => new Microsoft.Crm.Sdk.Messages.ValidateSavedQueryRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmValidateUnpublishedRequest, () => new Microsoft.Crm.Sdk.Messages.ValidateUnpublishedRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmWhoAmIRequest, () => new Microsoft.Crm.Sdk.Messages.WhoAmIRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmWinOpportunityRequest, () => new Microsoft.Crm.Sdk.Messages.WinOpportunityRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.CrmWinQuoteRequest, () => new Microsoft.Crm.Sdk.Messages.WinQuoteRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmAssociateRequest, () => new Microsoft.Xrm.Sdk.Messages.AssociateRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmCanBeReferencedRequest, () => new Microsoft.Xrm.Sdk.Messages.CanBeReferencedRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmCanBeReferencingRequest, () => new Microsoft.Xrm.Sdk.Messages.CanBeReferencingRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmCanManyToManyRequest, () => new Microsoft.Xrm.Sdk.Messages.CanManyToManyRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmConvertDateAndTimeBehaviorRequest, () => new Microsoft.Xrm.Sdk.Messages.ConvertDateAndTimeBehaviorRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmCreateAsyncJobToRevokeInheritedAccessRequest, () => new Microsoft.Xrm.Sdk.Messages.CreateAsyncJobToRevokeInheritedAccessRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmCreateAttributeRequest, () => new Microsoft.Xrm.Sdk.Messages.CreateAttributeRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmCreateCustomerRelationshipsRequest, () => new Microsoft.Xrm.Sdk.Messages.CreateCustomerRelationshipsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmCreateEntityKeyRequest, () => new Microsoft.Xrm.Sdk.Messages.CreateEntityKeyRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmCreateEntityRequest, () => new Microsoft.Xrm.Sdk.Messages.CreateEntityRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmCreateManyToManyRequest, () => new Microsoft.Xrm.Sdk.Messages.CreateManyToManyRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmCreateMultipleRequest, () => new Microsoft.Xrm.Sdk.Messages.CreateMultipleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmCreateOneToManyRequest, () => new Microsoft.Xrm.Sdk.Messages.CreateOneToManyRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmCreateOptionSetRequest, () => new Microsoft.Xrm.Sdk.Messages.CreateOptionSetRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmCreateRequest, () => new Microsoft.Xrm.Sdk.Messages.CreateRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmDeleteAttributeRequest, () => new Microsoft.Xrm.Sdk.Messages.DeleteAttributeRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmDeleteEntityKeyRequest, () => new Microsoft.Xrm.Sdk.Messages.DeleteEntityKeyRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmDeleteEntityRequest, () => new Microsoft.Xrm.Sdk.Messages.DeleteEntityRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmDeleteOptionSetRequest, () => new Microsoft.Xrm.Sdk.Messages.DeleteOptionSetRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmDeleteOptionValueRequest, () => new Microsoft.Xrm.Sdk.Messages.DeleteOptionValueRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmDeleteRelationshipRequest, () => new Microsoft.Xrm.Sdk.Messages.DeleteRelationshipRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmDeleteRequest, () => new Microsoft.Xrm.Sdk.Messages.DeleteRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmDisassociateRequest, () => new Microsoft.Xrm.Sdk.Messages.DisassociateRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmExecuteAsyncRequest, () => new Microsoft.Xrm.Sdk.Messages.ExecuteAsyncRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmExecuteMultipleRequest, () => new Microsoft.Xrm.Sdk.Messages.ExecuteMultipleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmExecuteTransactionRequest, () => new Microsoft.Xrm.Sdk.Messages.ExecuteTransactionRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmGetValidManyToManyRequest, () => new Microsoft.Xrm.Sdk.Messages.GetValidManyToManyRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmGetValidReferencedEntitiesRequest, () => new Microsoft.Xrm.Sdk.Messages.GetValidReferencedEntitiesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmGetValidReferencingEntitiesRequest, () => new Microsoft.Xrm.Sdk.Messages.GetValidReferencingEntitiesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmInsertOptionValueRequest, () => new Microsoft.Xrm.Sdk.Messages.InsertOptionValueRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmInsertStatusValueRequest, () => new Microsoft.Xrm.Sdk.Messages.InsertStatusValueRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmIsDataEncryptionActiveRequest, () => new Microsoft.Xrm.Sdk.Messages.IsDataEncryptionActiveRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmOrderOptionRequest, () => new Microsoft.Xrm.Sdk.Messages.OrderOptionRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmReactivateEntityKeyRequest, () => new Microsoft.Xrm.Sdk.Messages.ReactivateEntityKeyRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmRetrieveAllEntitiesRequest, () => new Microsoft.Xrm.Sdk.Messages.RetrieveAllEntitiesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmRetrieveAllManagedPropertiesRequest, () => new Microsoft.Xrm.Sdk.Messages.RetrieveAllManagedPropertiesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmRetrieveAllOptionSetsRequest, () => new Microsoft.Xrm.Sdk.Messages.RetrieveAllOptionSetsRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmRetrieveAttributeRequest, () => new Microsoft.Xrm.Sdk.Messages.RetrieveAttributeRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmRetrieveDataEncryptionKeyRequest, () => new Microsoft.Xrm.Sdk.Messages.RetrieveDataEncryptionKeyRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmRetrieveEntityChangesRequest, () => new Microsoft.Xrm.Sdk.Messages.RetrieveEntityChangesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmRetrieveEntityKeyRequest, () => new Microsoft.Xrm.Sdk.Messages.RetrieveEntityKeyRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmRetrieveEntityRequest, () => new Microsoft.Xrm.Sdk.Messages.RetrieveEntityRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmRetrieveManagedPropertyRequest, () => new Microsoft.Xrm.Sdk.Messages.RetrieveManagedPropertyRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmRetrieveMetadataChangesRequest, () => new Microsoft.Xrm.Sdk.Messages.RetrieveMetadataChangesRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmRetrieveMultipleRequest, () => new Microsoft.Xrm.Sdk.Messages.RetrieveMultipleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmRetrieveOptionSetRequest, () => new Microsoft.Xrm.Sdk.Messages.RetrieveOptionSetRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmRetrieveRelationshipRequest, () => new Microsoft.Xrm.Sdk.Messages.RetrieveRelationshipRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmRetrieveRequest, () => new Microsoft.Xrm.Sdk.Messages.RetrieveRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmRetrieveTimestampRequest, () => new Microsoft.Xrm.Sdk.Messages.RetrieveTimestampRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmSetDataEncryptionKeyRequest, () => new Microsoft.Xrm.Sdk.Messages.SetDataEncryptionKeyRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmUpdateAttributeRequest, () => new Microsoft.Xrm.Sdk.Messages.UpdateAttributeRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmUpdateEntityRequest, () => new Microsoft.Xrm.Sdk.Messages.UpdateEntityRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmUpdateMultipleRequest, () => new Microsoft.Xrm.Sdk.Messages.UpdateMultipleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmUpdateOptionSetRequest, () => new Microsoft.Xrm.Sdk.Messages.UpdateOptionSetRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmUpdateOptionValueRequest, () => new Microsoft.Xrm.Sdk.Messages.UpdateOptionValueRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmUpdateRelationshipRequest, () => new Microsoft.Xrm.Sdk.Messages.UpdateRelationshipRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmUpdateRequest, () => new Microsoft.Xrm.Sdk.Messages.UpdateRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmUpdateStateValueRequest, () => new Microsoft.Xrm.Sdk.Messages.UpdateStateValueRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmUpsertMultipleRequest, () => new Microsoft.Xrm.Sdk.Messages.UpsertMultipleRequest());
            _FactoryByName.Add(WKOrganizationRequestKind.XrmUpsertRequest, () => new Microsoft.Xrm.Sdk.Messages.UpsertRequest());
        }
        if (_FactoryByName.TryGetValue(typeName, out var func) && (func is not null)) { return func(); }
        return null;
    }

    [Parameter(Mandatory = true, Position = 0)]
    public WKOrganizationRequestKind? OrganizationRequestKind { get; set; }

    protected override void BeginProcessing() {
        if (!this.OrganizationRequestKind.HasValue) { throw new ArgumentException(nameof(NewWKOrganizationRequestCmdlet.OrganizationRequestKind)); }

        var result = GetOrganizationRequestByName(this.OrganizationRequestKind.Value);
        if (result is not null) {
            this.WriteObject(result);
        } else {
            throw new ArgumentException($"OrganizationRequestKind:{this.OrganizationRequestKind.Value} is unknown.");
        }
    }
}
