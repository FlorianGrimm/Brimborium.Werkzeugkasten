namespace Brimborium.Werkzeugkasten;

public class WKDataverseConnection {

    internal WKDataverseConnection(ServiceClient serviceClient, WKAppHost wkAppHost) {
        this.ServiceClient = serviceClient;
        this.WKAppHost = wkAppHost;
    }

    public bool IsConnected => (this.ServiceClient is { } serviceClient) ? serviceClient.IsReady : false;

    public ServiceClient ServiceClient { get; }

    public WKAppHost WKAppHost { get; }

    /// <summary>
    /// Total Count of all Execute calls.
    /// </summary>
    public int ExecuteCount { get; set; }

    /// <summary>
    /// Total Duration of all Execute calls.
    /// </summary>
    public System.TimeSpan ExecuteDuration { get; set; }

    /// <summary>
    /// Executes a general organization request
    /// </summary>
    /// <param name="request">the request</param>
    /// <returns>the response</returns>
    public OrganizationResponse Execute(OrganizationRequest request) {
        var start = System.DateTimeOffset.UtcNow;
        try {
            return this.ServiceClient.Execute(request);
        } finally {
            var stop = System.DateTimeOffset.UtcNow;
            _ = this.ExecuteDuration.Add(stop - start);
            this.ExecuteCount += 1;
        }
    }

    /// <summary>
    /// Retrieve multiple records based on query.
    /// </summary>
    /// <param name="query">the query</param>
    /// <returns>A collection of Entity.</returns>
    public EntityCollection RetrieveMultiple(QueryBase query) {
        var start = System.DateTimeOffset.UtcNow;
        try {
            return this.ServiceClient.RetrieveMultiple(query);
        } finally {
            var stop = System.DateTimeOffset.UtcNow;
            _ = this.ExecuteDuration.Add(stop - start);
            this.ExecuteCount += 1;
        }
    }

    /// <summary>
    /// Retrieve a record.
    /// </summary>
    /// <param name="entityName">the logicalName</param>
    /// <param name="id">the id</param>
    /// <param name="columnSet">the columns to retrieve.</param>
    /// <returns>the Entity or null</returns>
    public Entity? Retrieve(string entityName, Guid id, ColumnSet columnSet) {
        var start = System.DateTimeOffset.UtcNow;
        try {
            return this.ServiceClient.Retrieve(entityName, id, columnSet);
        } finally {
            var stop = System.DateTimeOffset.UtcNow;
            _ = this.ExecuteDuration.Add(stop - start);
            this.ExecuteCount += 1;
        }
    }

    /// <summary>
    /// Get MetaEntity for EntityLogicalname
    /// </summary>
    /// <param name="entityLogicalname">the Logicalname for entity.</param>
    /// <returns>the <see cref="T:MetaEntity"/> or null if not found.</returns>
    public WKMetaEntity? GetMetaEntity(string entityLogicalname) {
        if (string.IsNullOrEmpty(entityLogicalname)) { return null; }
        var entityMetadata = this.ServiceClient.GetEntityMetadata(entityLogicalname, EntityFilters.All);
        if (entityMetadata == null) { return null; }
        var listAttribute = this.ServiceClient.GetAllAttributesForEntity(entityLogicalname);
        if (listAttribute == null) { return null; }
        var result = WKMetaEntity.Create(entityMetadata, listAttribute);
        return result;
    }
}
