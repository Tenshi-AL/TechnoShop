using Domain.Interfaces;
using Minio;
using Minio.DataModel;
using Minio.DataModel.Args;
using Minio.DataModel.Encryption;
using Minio.DataModel.Response;

namespace Infrastructure.Services;

public class BlobStorageService(IMinioClient minioClient): IBlobStorageService
{
    public async Task<bool> IsBucketExistsAsync(string bucketName, CancellationToken cancellationToken = default)
    {
        var args = new BucketExistsArgs().WithBucket(bucketName);
        return await minioClient.BucketExistsAsync(args, cancellationToken: cancellationToken);
    }
    
    
    public async Task RemoveObject(string objectName, string bucketName, CancellationToken cancellationToken = default)
    {
        var removeArguments = new RemoveObjectArgs()
            .WithBucket(bucketName)
            .WithObject(objectName);

        await minioClient.RemoveObjectAsync(removeArguments, cancellationToken: cancellationToken);
    } 
    
    public async Task<FileOperationResponse<IAsyncEnumerable<Item>>> ListObjects(string bucketName,
        string? prefix = null,
        bool recursive = true,
        bool versions = false,
        CancellationToken cancellationToken = default)
    {
        if (!await IsBucketExistsAsync(bucketName,cancellationToken))
            return new FileOperationResponse<IAsyncEnumerable<Item>>(false, "Bucket doesn't exists", null);
        
        var listArgs = new ListObjectsArgs()
            .WithBucket(bucketName)
            .WithPrefix(prefix)
            .WithRecursive(recursive)
            .WithVersions(versions);
        var items = minioClient.ListObjectsEnumAsync(listArgs, cancellationToken: cancellationToken);
        return new FileOperationResponse<IAsyncEnumerable<Item>>(true, null, items);
    }
    
    public async Task<FileOperationResponse<PutObjectResponse>> PutFile(string bucketName,
        string objectName,
        Stream fileStream,
        IProgress<ProgressReport>? progress = null,
        IServerSideEncryption? sse = null,
        CancellationToken cancellationToken = default)
    {
        if (!await IsBucketExistsAsync(bucketName,cancellationToken))
            return new FileOperationResponse<PutObjectResponse>(false, "Bucket doesn't exists", null);
        
        var args = new PutObjectArgs()
            .WithBucket(bucketName)
            .WithObject(objectName)
            .WithStreamData(fileStream)
            .WithObjectSize(fileStream.Length)
            .WithContentType("application/octet-stream")
            .WithProgress(progress)
            .WithServerSideEncryption(sse);
        
        var response =  await minioClient.PutObjectAsync(args, cancellationToken: cancellationToken);
        return new FileOperationResponse<PutObjectResponse>(true, null, response);
    }
}