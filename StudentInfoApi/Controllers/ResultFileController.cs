using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace StudentInfoAPI.Controllers
{
    [Route("api/student/resultFile")]
    [ApiController]
    public class ResultFileController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileContentTypeProvider;

        public ResultFileController(FileExtensionContentTypeProvider fileContentTypeProvider)
        {
            _fileContentTypeProvider = fileContentTypeProvider ?? 
                throw new System.ArgumentException(nameof(fileContentTypeProvider));
        }

        [HttpGet]
        public ActionResult GetResultPDF()
        {
            var pathToFile = "Zadok_Joshua_Resume.pdf";

            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound("File not found");
            }

            if (!_fileContentTypeProvider.TryGetContentType(pathToFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = System.IO.File.ReadAllBytes(pathToFile);

            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }
    }
}
