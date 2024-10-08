﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApplication.Application.Extensions
{
    public static class FileExtension
    {
        public static string Save(this IFormFile file, string root, string folder)
        {
            string newFileName = Guid.NewGuid().ToString() + file.FileName;
            string path = Path.Combine(root, "wwwroot", folder, newFileName);
            using FileStream fileStream = new FileStream(path, FileMode.Create);
            file.CopyTo(fileStream);
            return newFileName;
        }
    }
}
