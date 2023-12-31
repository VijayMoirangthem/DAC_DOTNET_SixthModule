using MVC.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;


namespace MVC.Controllers
{
    public class CourseController : Controller
    {
        string apiURL = "https://localhost:44357/api/CourseApi";

        public ActionResult getCourse()
        {
            ViewBag.CourseList = new List<CourseModel>();
            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(apiURL).Result;
                ViewBag.CourseList = (new JavaScriptSerializer()).Deserialize<List<CourseModel>>(response.Content.ReadAsStringAsync().Result);
            }
            return View();
        }
        [HttpPost]
        public ActionResult insertCourse(string CID, string CName, int CDuration, int CFees)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post , $"{apiURL}?CID={CID}&CName={CName}&CDuration={CDuration}&CFees={CFees}");
                HttpResponseMessage response = client.SendAsync(request).Result;
                return RedirectToAction("getCourse");
            }
        }

        [HttpPost]
        public ActionResult deleteCourse(string CID)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, $"{apiURL}?CID={CID}");
                HttpResponseMessage response = client.SendAsync(request).Result;
                return RedirectToAction("getCourse");
            }
        }

        [HttpGet]
        public ActionResult getCourseByID(string CID)
        {
            CourseModel CMOD = new CourseModel();
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{apiURL}?CID={CID}");
                HttpResponseMessage response = client.SendAsync(request).Result;
                CMOD = (new JavaScriptSerializer()).Deserialize<CourseModel>(response.Content.ReadAsStringAsync().Result);
            }
            return Json(CMOD, JsonRequestBehavior.AllowGet);
        }
    }
}