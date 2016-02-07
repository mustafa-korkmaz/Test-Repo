using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Pjax.Mvc5;

namespace PjaxExample.Controllers
{
    [Pjax]
    public class HomeController : Controller, IPjax
    {
        public bool IsPjaxRequest { get; set; }

        public string PjaxVersion { get; set; }

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Page1()
        {
            WebRequest request = WebRequest.Create("http://www.w3schools.com/xml/cd_catalog.xml");
            var webResponse = request.GetResponse();
            for (int i = 0; i < 1000; i++)
            {
                webResponse = request.GetResponse();
                Stream receiveStream1 = webResponse.GetResponseStream();
                StreamReader readStream1 = new StreamReader(receiveStream1, Encoding.UTF8);

                string webResponseData1 = readStream1.ReadToEnd();
            }

            // Get the stream associated with the response.
            Stream receiveStream = webResponse.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            string webResponseData = readStream.ReadToEnd();


            webResponse.Close();
            readStream.Close();
            return View();
        }

        public ActionResult Page2()
        {
            return View();
        }

        public ActionResult Page3()
        {
            return View();
        }
    }
}