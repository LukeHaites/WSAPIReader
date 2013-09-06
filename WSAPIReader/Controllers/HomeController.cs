using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using WSAPIReader.Models;

namespace WSAPIReader.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ReferenceTypes model = null;
            var client = new HttpClient();
            var task = client.GetAsync("http://luke7/wholesaleapi/referencetypes?requestpersonid=101031")
                .ContinueWith((taskwithresponse) =>
                {
                    
                    XmlSerializer serializer = new XmlSerializer(typeof(ReferenceTypes));
                  
                    
                    
                    var response = taskwithresponse.Result;
                    //var contents = response.Content.ReadAsStringAsync().Result;
                    model = (ReferenceTypes)serializer.Deserialize(response.Content.ReadAsStreamAsync().Result);
                    //var readtask = response.Content.ReadAsAsync<ReferenceTypes>();
                    //readtask.Wait();
                    //model = readtask.Result;
                });
            task.Wait();
            return View(model.refs);
        }

        //public ActionResult Index()
        //{
        //    IEnumerable<Product> model = null;
        //    var client = new HttpClient();
        //    var task = client.GetAsync("http://productapi.apphb.com/api/products")
        //        .ContinueWith((taskwithresponse) =>
        //        {
        //            var response = taskwithresponse.Result;
        //            //var readtask = response.Content.ReadAsStringAsync();
        //            var readtask = response.Content.ReadAsAsync<IEnumerable<Product>>();
        //            readtask.Wait();
        //            model = readtask.Result;
        //        });
        //    task.Wait();
        //    return View(model);
        //}

    }
}
