using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Minio;
using Minio.DataModel;
using Minio.DataModel.Response;
using TechnoShop.Models;

namespace TechnoShop.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController(IBlobStorageService blobStorageService,IMinioClient minioClient): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(PostFileRequest request, CancellationToken cancellationToken = default)
    {
        var result = new List<FileOperationResponse<PutObjectResponse>>();
        foreach (var file in request.Files)
        {
            var putResult = await blobStorageService.PutFile(bucketName: $"products-images",
                //objectName: $"{request.ProductId}/{request.ProductId}-preview-{index++}{Path.GetExtension(file.FileName)}",
                objectName: $"preview-{request.ProductId}-{file.FileName}",
                fileStream: file.OpenReadStream(),
                cancellationToken: cancellationToken);
            result.Add(putResult);
        }

        return Ok(result);
    }
    
    [HttpGet("List")]
    public IAsyncEnumerable<Item>? List(string bucketName, string? prefix = null, bool recursive = true,
        bool versions = false, CancellationToken cancellationToken = default)
    {
        var result = blobStorageService.ListObjects(bucketName, prefix, recursive, versions, cancellationToken).Result;
        return result.Success ? result.ResponseObject : null;
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string objectName, string bucketName, CancellationToken cancellationToken = default)
    {
        await blobStorageService.RemoveObject(objectName, bucketName, cancellationToken);
        return Ok();
    }
}