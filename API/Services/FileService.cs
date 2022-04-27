using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using API.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace API.Services
{
    public class FileService : IFileService
    {
        private readonly Cloudinary _cloudinary;

        public FileService(IOptions<CloudinarySettings> config)
        {
              var acc = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );
            _cloudinary=new Cloudinary(acc);
        }

        public async Task<RawUploadResult> AddFileAsync(IFormFile file)
        {
            var uploadResult=new RawUploadResult();
            if(file.Length>0){
                using var stream= file.OpenReadStream();
                var uploadParams = new RawUploadParams(){  
                    File = new FileDescription(file.FileName,stream),
                    
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }
          public async Task<ImageUploadResult> AddPDFFileAsync(IFormFile file)
        {
            var uploadResult=new ImageUploadResult();
            if(file.Length>0){
                using var stream= file.OpenReadStream();
                var uploadParams= new ImageUploadParams{
                    File=new FileDescription(file.FileName,stream),
                    Transformation= new Transformation().Flags("attachment")
            };
                uploadResult= await _cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        public async Task<DeletionResult> DeleteFileAsync(string publicId)
        {
             var deleteParams= new DeletionParams(publicId);
            var result= await _cloudinary.DestroyAsync(deleteParams);
            return result;
        }
    }
}