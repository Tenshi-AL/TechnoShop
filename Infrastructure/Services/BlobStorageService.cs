using Domain.Interfaces;
using Minio;
using Minio.DataModel;
using Minio.DataModel.Args;
using Minio.DataModel.Encryption;
using Minio.DataModel.Response;
using Minio.DataModel.Result;

namespace Infrastructure.Services;


public class BlobStorageService(IMinioClient minioClient): IBlobStorageService
{
    public async Task<PutImageResponse> PutFile(string bucketName,
        string objectName,
        Stream fileStream,
        IProgress<ProgressReport>? progress = null,
        IServerSideEncryption? sse = null,
        CancellationToken cancellationToken = default)
    {
        var args = new PutObjectArgs()
            .WithBucket(bucketName)
            .WithObject(objectName)
            .WithStreamData(fileStream)
            .WithObjectSize(fileStream.Length)
            .WithContentType("application/octet-stream")
            .WithProgress(progress)
            .WithServerSideEncryption(sse);
        
        var response =  await minioClient.PutObjectAsync(args, cancellationToken: cancellationToken);
        return new PutImageResponse(true, null, response);
    }
}