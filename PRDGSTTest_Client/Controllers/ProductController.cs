using PRDGSTest.ViewModels;
using PRDGSTTest_Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRDGSTTest_Client.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public ActionResult Index()
        {
            ProductClient pc = new ProductClient();
            ViewBag.listProducts = pc.findAll();           
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            ProductClient pc = new ProductClient();
            ProductViewModel pvm = new ProductViewModel();
            pvm.Product = pc.Create();
            return View("Create", pvm);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel pvm, HttpPostedFileBase file)
        {
            pvm.Product.ModifiedDate = DateTime.Now;
            pvm.Product.rowguid = Guid.NewGuid();
            if (!ModelState.IsValid)
            {
                ProductClient pc = new ProductClient();
                pc.FillList(pvm.Product);
                return View("Create", pvm);
            }
            else
            {

             
                if (file != null && file.ContentLength > 0)
                {
                    pvm.Product.ThumbNailPhoto = GetByte(file.InputStream);
                    pvm.Product.ThumbnailPhotoFileName = file.FileName;
                }
                ProductClient pc = new ProductClient();
                pc.Create(pvm.Product);
                return RedirectToAction("Index");
            }
        }

        private byte[] GetByte(System.IO.Stream stream)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

    
        public ActionResult Delete(int id)
        {
          
            ProductClient pc = new ProductClient();
            pc.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            ProductClient pc = new ProductClient();
            ProductViewModel pvm = new ProductViewModel();
            pvm.Product = pc.Find(id);
          

            return View("Edit", pvm);
        }
        [HttpPost]
        public ActionResult Edit(ProductViewModel pvm, HttpPostedFileBase file)
        {
            pvm.Product.ModifiedDate = DateTime.Now;            
            if (!ModelState.IsValid)
            {
                ProductClient pc = new ProductClient();
                pc.FillList(pvm.Product);
                return View("Edit", pvm);
            }
            else
            {
                if (file != null && file.ContentLength > 0)
                {
                    pvm.Product.ThumbNailPhoto = GetByte(file.InputStream);
                    pvm.Product.ThumbnailPhotoFileName = file.FileName;
                }

                ProductClient pc = new ProductClient();
                pc.Edit(pvm.Product);
                return RedirectToAction("Index");
            }
        }

	}
}