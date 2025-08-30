using Domain.Interfaces;
using Minio;
using Minio.DataModel;
using Minio.DataModel.Args;
using Minio.DataModel.Encryption;

namespace Infrastructure.Services;

public class BlobStorageService(IMinioClient minioClient): IBlobStorageService
{
    public async Task<bool> IsBucketExistsAsync(string bucketName)
    {
        var args = new BucketExistsArgs().WithBucket(bucketName);
        return await minioClient.BucketExistsAsync(args);
    }
    public async Task<PutImageResponse> PutFile(string bucketName,
        string objectName,
        Stream fileStream,
        IProgress<ProgressReport>? progress = null,
        IServerSideEncryption? sse = null,
        CancellationToken cancellationToken = default)
    {
        if (!await IsBucketExistsAsync(bucketName))
            return new PutImageResponse(false, "Bucket doesn't exists", null);
        
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