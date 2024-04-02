using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_medical_card.Models.Responses;
using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace student_medical_card.Controllers.studentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public studentImageController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPut]
        [Route("UploadImage/{studentcode}")]
        public IActionResult UploadImage( string studentcode, IFormFile formFile)
        {
            APIResponseFormat response = new ApiResponse();
            try
            {
                string Filepath = GetFilepath(studentcode);
                if (!Directory.Exists(Filepath))
                {
                    Directory.CreateDirectory(Filepath);
                }
                string imagepath = Path.Combine(Filepath, $"{studentcode}.png");

                // If the image already exists, delete it
                if (System.IO.File.Exists(imagepath))
                {
                    System.IO.File.Delete(imagepath);
                }

                // Save the new image
                using (FileStream stream = System.IO.File.Create(imagepath))
                {
                    formFile.CopyTo(stream);
                    response.ResponseCode = 200;
                    response.Result = "pass";
                }
            }
            catch (Exception ex)
            {
                response.Errormessage = ex.Message;
                return StatusCode(500, response); // Internal Server Error
            }

            return Ok(response);
        }


        [HttpGet]
        [Route("GetImage/{studentcode}")]
        //[HttpGet("GetImage")]
        public IActionResult GetImage(string studentcode)
        {
            string Imageurl = string.Empty;
            string hosturl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            try
            {
                string Filepath = GetFilepath(studentcode);
                string imagepath = Path.Combine(Filepath, $"{studentcode}.png");
                if (System.IO.File.Exists(imagepath))
                {
                    Imageurl = $"{hosturl}/upload/student/{studentcode}/{studentcode}.png";
                }
                else
                {
                    return Ok("Not Found");
                }
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
            }
            return Ok(new { image = Imageurl });
        }

        [NonAction]
        private string GetFilepath(string studentcode)
        {
            return Path.Combine(_webHostEnvironment.WebRootPath, "Upload", "student", studentcode);
        }
    }
}
