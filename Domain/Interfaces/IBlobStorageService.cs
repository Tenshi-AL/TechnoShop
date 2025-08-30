using Minio.DataModel;
using Minio.DataModel.Encryption;
using Minio.DataModel.Response;

namespace Domain.Interfaces;

public class FileOperationResponse<T>(bool success, string? message, T? responseObject)
{
    public bool Success { get; set; } = success;
    public string? Message { get; set; } = message;
    public T? ResponseObject { get; set; } = responseObject;
}
public interface IBlobStorageService
{
    Task<FileOperationResponse<string?>> GetObjectUrl(string objectName, string bucketName,
        CancellationToken cancellationToken = default);
    Task RemoveObject(string objectName, 
        string bucketName, 
        CancellationToken cancellationToken = default);
    Task<FileOperationResponse<IAsyncEnumerable<Item>>> ListObjects(string bucketName,
        string? prefix = null,
        bool recursive = true,
        bool versions = false,
        CancellationToken cancellationToken = default);
    
    Task<FileOperationResponse<PutObjectResponse>> PutFile(string bucketName,
        string objectName,
        Stream fileStream,
        IProgress<ProgressReport>? progress = null,
        IServerSideEncryption? sse = null,
        CancellationToken cancellationToken = default);
}