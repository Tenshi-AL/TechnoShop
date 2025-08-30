using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Minio;
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
        var result = new List<PutImageResponse>();
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
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await minioClient.ListBucketsAsync());
    }
}