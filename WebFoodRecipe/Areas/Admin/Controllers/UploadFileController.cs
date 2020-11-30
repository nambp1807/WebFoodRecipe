using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFoodRecipe.Areas.Admin.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: Admin/UploadFile
        [HttpPost]
        public ActionResult UploadAvatar(HttpPostedFileBase file)
        {
            String path = Server.MapPath("~/Upload/Avatar");

            var fileUpload = UploadFile.Upload(file, path, file.FileName);
            if (fileUpload.Code == 1)
            {
                ViewBag.Mss = fileUpload.Mss;
            }
            else
            {
                ViewBag.Mss = fileUpload.Mss;
            }

            return Content("ok");
        }
    }

    internal class UploadFile
    {
        public static Messenger Upload(HttpPostedFileBase file, String filePath, String fileName)
        {
            Messenger messenger = new Messenger();

            try
            {
                var typeFile = file.ContentType;

                if (typeFile.Contains("image"))
                {
                    if (file.ContentLength > 0)
                    {
                        if (!Directory.Exists(filePath))
                        {
                            Directory.CreateDirectory(filePath);
                        }

                        try
                        {
                            file.SaveAs(Path.Combine(filePath, fileName));
                            messenger.Code = 1;
                            messenger.Mss = fileName;

                            return messenger;
                        }
                        catch (Exception e)
                        {
                            messenger.Mss = String.Format("Tải lên thất bại!, {0}", e);
                            messenger.Code = 0;

                            return messenger;
                        }
                    }

                    messenger.Mss = "Có lỗi tải lên";
                    messenger.Code = 0;

                    return messenger;
                }

                messenger.Mss = "Định dạng file không đúng";
                messenger.Code = 0;

                return messenger;

            }
            catch (Exception e)
            {
                messenger.Mss = "Có lỗi: " + e;
                messenger.Code = 0;

                return messenger;
            }
        }
    }

    public class Messenger
    {
        private int code;
        private String mss;


        public Messenger()
        {
            code = -1;
            mss = null;
        }

        public int Code
        {
            get => code;
            set => code = value;
        }

        public string Mss
        {
            get => mss;
            set => mss = value;
        }
    }
}