using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TrabalhoCD.Models;
/*
 * 
 * Autores do projecto: Luis Esteves/16960 || Sérgio Ribeiro/18858 || João Riberio/17214;
 * Disciplina: Comunicação de dados;
 * Projecto II;
 * Propósito do trabalho: Criar uma API de gerência de utilizadores e de mensagens
 *
 */

    //Controller dos Files
namespace TrabalhoCD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : Controller
    {
        public static IWebHostEnvironment _webHosEnvironment;
        public FilesController(IWebHostEnvironment webHosEnvironment)
        {
            _webHosEnvironment = webHosEnvironment;
        }

        [HttpPost]
        public async Task<string> Post([FromForm] CommandFile fileUpload)
        {
            try
            {
                if (fileUpload.files.Length > 0)
                {
                    string path = _webHosEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + fileUpload.files.FileName))
                    {
                        fileUpload.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Upload Done";
                    }
                }
                else
                {
                    return "Failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet("{FileName}")]
        public async Task <IActionResult> Get([FromRoute] string FileName)
        {
            string path = _webHosEnvironment.WebRootPath + "\\uploads\\";
            var filePath = path + FileName + ".png";

            if (System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);
                return File(b, "image/png");
            }
            var filePath2 = path + FileName + ".jpg";
            if (System.IO.File.Exists(filePath2))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath2);
                return File(b, "image/jpg");
            }
            return null;
        }

        [HttpDelete("{FileName}")]
        public async Task<IActionResult> Delete([FromRoute] string FileName)
        {
            string path = _webHosEnvironment.WebRootPath + "\\uploads\\";
            var filePath = path + FileName + ".png";

            if (System.IO.File.Exists(filePath))
            {
    
                System.IO.File.Delete(filePath);
                return Ok();
            }
            var filePath2 = path + FileName + ".jpg";
            if (System.IO.File.Exists(filePath2))
            {
                System.IO.File.Delete(filePath2);
                return Ok();
            }
            return NotFound();
        }

    }
}