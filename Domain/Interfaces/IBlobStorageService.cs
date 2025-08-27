using Minio.DataModel;
using Minio.DataModel.Encryption;
using Minio.DataModel.Response;

namespace Domain.Interfaces;

public record PutImageResponse(bool Success, string? Message, PutObjectResponse? MinIoPutObjectResponse);
public interface IBlobStorageService
{
    Task<PutImageResponse> PutFile(string bucketName,
        string objectName,
        Stream fileStream,
        IProgress<ProgressReport>? progress = null,
        IServerSideEncryption? sse = null,
        CancellationToken cancellationToken = default);
}