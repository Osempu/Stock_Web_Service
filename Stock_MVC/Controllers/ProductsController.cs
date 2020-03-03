using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stock_MVC.Models;

namespace Stock_MVC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            var webClient = new System.Net.WebClient();
            var url = "http://localhost:56068/api/products/";

            //Calling the API and downloading the data.
            var res = webClient.DownloadString(url);

            //Deserializae Json and convert to an array of Products.
            List<Products> data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Products>>(res);

            return View(data);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var webClient = new System.Net.WebClient();
            var url = $"http://localhost:56068/api/products/{id}";

            var res = webClient.DownloadString(url);

            Products data = Newtonsoft.Json.JsonConvert.DeserializeObject<Products>(res);

            return View(data);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products product)
        {
            try
            {
                var webClient = new System.Net.WebClient();
                var url = "http://localhost:56068/api/products/";

                //Serializing the product object to JSON format.
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(product);

                //Configuring web client to send JSON data.
                webClient.Headers.Add("Content-Type", "application/json");

                //Upload the product to the web service.
                webClient.UploadString(url, json);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            var webClient = new System.Net.WebClient();
            var url = $"http://localhost:56068/api/products/{id}";

            var res = webClient.DownloadString(url);

            Products data = Newtonsoft.Json.JsonConvert.DeserializeObject<Products>(res);

            return View(data);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Products product)
        {
            try
            {
                var webClient = new System.Net.WebClient();
                var url = $"http://localhost:56068/api/products/{id}";

                //Serializing the product object to JSON format.
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(product);

                //Configuring web client to send JSON data.
                webClient.Headers.Add("Content-Type", "application/json");

                //Send JSON data to web service via PUT method.
                webClient.UploadString(url, "PUT", json);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            var webClient = new System.Net.WebClient();
            var url = $"http://localhost:56068/api/products/{id}";

            var res = webClient.DownloadString(url);

            Products data = Newtonsoft.Json.JsonConvert.DeserializeObject<Products>(res);

            return View(data);
        }

        // POST: Products/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Products product)
        {
            try
            {
                var webClient = new System.Net.WebClient();

                var url = $"http://localhost:56068/api/products/{id}";

                //Upload the product to the web service.
                webClient.UploadString(url, "DELETE", "");

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}