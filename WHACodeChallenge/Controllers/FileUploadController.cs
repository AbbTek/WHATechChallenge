using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WHACodeChallenge.Controllers
{
    public class FileUploadController : Controller
    {
        [HttpPost]
        public ContentResult Index(HttpPostedFileBase file)
        {
            var originalFilename = Path.GetFileName(file.FileName);
            var extension = Path.GetExtension(originalFilename);
            var rand = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
            var filename = DateTime.Now.ToString("yyyyMMddHHmm") + "-" + rand + extension;

            var path = new FileInfo(Path.Combine(Server.MapPath("~/App_Data/Uploads"), filename));

            if (!path.Directory.Exists)
                path.Directory.Create();

            file.SaveAs(path.FullName);
            return new ContentResult
            {
                ContentType = "text/plain",
                Content = "/App_Data/Uploads/" + filename,
                ContentEncoding = Encoding.UTF8
            };
        }
    }
}