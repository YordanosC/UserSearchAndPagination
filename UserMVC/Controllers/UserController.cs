using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using UserMVC.Response;
using System.Net.Http;
using System.Net.Http.Headers;

namespace UserMVC.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {

        }

        [HttpGet]
        public ActionResult UserData()
        {

            //List<UserRes> userList = new List<UserRes>() {
            //    new UserRes {Id=1,FirstName = "Yordanos", LastName = "Chekole", EmailId = "yc@gmail.com", Address = "ET" },
            //    new UserRes {Id=2,FirstName = "Yordanos", LastName = "Chekole", EmailId = "yc@gmail.com", Address = "ET" },
            //    new UserRes {Id=3,FirstName = "Yordanos", LastName = "Chekole", EmailId = "yc@gmail.com", Address = "ET" }
            //};
            IEnumerable<UserRes> userList = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7159/api/");
                //HTTP GET
                var responseTask = client.GetAsync("users");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<UserRes>>();
                    readTask.Wait();

                    userList = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    userList = Enumerable.Empty<UserRes>();

                    ModelState.AddModelError(string.Empty, "Server error");
                }
            }
            return Json(new { data = userList });

        }
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
