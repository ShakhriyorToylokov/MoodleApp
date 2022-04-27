using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace API.Interfaces
{
    public interface IFileService
    {
         Task<RawUploadResult> AddFileAsync(IFormFile file);
        Task<DeletionResult> DeleteFileAsync(string publicId);
        Task<ImageUploadResult> AddPDFFileAsync(IFormFile file);
    }
}