using System.Threading.Tasks;

namespace MyInfluxDbClient
{
    public interface IInfluxDbClient
    {
        WriteOptions DefaultWriteOptions { get; }

        void UseBasicAuth(string username, string password);

        Task CreateDatabaseAsync(string databaseName);
        Task DropDatabaseAsync(string databaseName);
        Task<bool> DatabaseExistsAsync(string databaseName);
        Task<Databases> GetDatabasesAsync();
        Task<string> GetDatabasesJsonAsync();

        Task CreateRetentionPolicyAsync(string databaseName, CreateRetentionPolicy policy);
        Task AlterRetentionPolicyAsync(string databaseName, AlterRetentionPolicy policy);
        Task DropRetentionPolicyAsync(string databaseName, string policyName);
        Task<RetentionPolicyItem[]> GetRetentionPoliciesAsync(string databaseName);
        Task<string> GetRetentionPoliciesJsonAsync(string databaseName);

        Task DropSeriesAsync(string databaseName, DropSeries command);
        Task<Series> GetSeriesAsync(string databaseName, ShowSeries command = null);
        Task<string> GetSeriesJsonAsync(string databaseName, ShowSeries command = null);

        Task<FieldKeys> GetFieldKeysAsync(string databaseName, string measurement = null);
        Task<string> GetFieldKeysJsonAsync(string databaseName, string measurement = null);

        Task<TagKeys> GetTagKeysAsync(string databaseName, string measurement = null);
        Task<string> GetTagKeysJsonAsync(string databaseName, string measurement = null);

        Task<Measurements> GetMeasurementsAsync(string databaseName, ShowMeasurements command = null);
        Task<string> GetMeasurementsJsonAsync(string databaseName, ShowMeasurements command = null);

        Task<QueryResult> SelectAsync(string databaseName, Select command);
        Task<string> SelectJsonAsync(string databaseName, Select command);

        Task WriteAsync(string databaseName, InfluxPoints points, WriteOptions options = null);
    }
}