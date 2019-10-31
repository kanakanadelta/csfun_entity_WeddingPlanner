using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        // Dependency Injection
        WeddingContext dbContext;
        public HomeController(WeddingContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            string name = HttpContext.Session.GetString("UserName");
            if(name == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.UserName = name;

            int? userId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = userId;

            List<Wedding> weddings = dbContext
                .Weddings
                .Include(w => w.Associations)
                .Include(w => w.Planner)
                .ToList();
            
            List<Wedding> userEvents = dbContext
                .Associations
                .Where(a => a.UserId == userId)
                .Select(a => a.Wedding)
                .ToList();
            
            ViewBag.UserEvents = userEvents;
            ViewBag.Weddings = weddings;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // // // //
        // ERROR //
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        // // // // // //
        // LOGIN / REG //
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                // Invalid Email //
                if(dbContext.Users.Any(u => u.Email == user.Email))
                {

                    ModelState.AddModelError("Email", "This Email is already in use!");
                    // return the view
                    return View("Index");
                }

                // invalid Password //
                if(user.Password != user.Confirm)
                {
                    // Manually add a ModelState error to the Email field, with provided
                    // error message
                    ModelState.AddModelError("Password", "Password confirmation was not the same password.");
                    // return the view
                    return View("Index");
                }

                // // // // // // // // // //
                // hash the given password:

                // Initialize the hasher object
                var hasher = new PasswordHasher<User>();

                user.Password = hasher.HashPassword(user, user.Password);
                dbContext.Add(user);
                dbContext.SaveChanges();

                HttpContext.Session.SetString("UserName", user.FirstName);
                HttpContext.Session.SetInt32("UserId", user.UserId);
                return RedirectToAction("Dashboard");
            }
            else
            return View("Index");
        }

        [HttpPost("loginconfirm")]
        public IActionResult LoginConfirm(LoginUser userSubmission)
        {
            if(ModelState.IsValid)
            {
                // If inital ModelState is valid, query for a user with provided email
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
                // If no user exists with provided email
                if(userInDb == null)
                {
                    // Add an error to ModelState and return to View!
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Login");
                }
                // Initialize hasher object
                var hasher = new PasswordHasher<LoginUser>();
                
                // verify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                
                // result can be compared to 0 for failure
                if(result == 0)
                {
                    // handle failure (this should be similar to how "existing email" is handled)
                    ModelState.AddModelError("Password", "Invalid Email/Password");
                    return View("Login");
                }
                else
                {
                    HttpContext.Session.SetString("UserName", userInDb.FirstName);
                    HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                    return RedirectToAction("Dashboard");
                }
                
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("LogOut")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        // // // // //
        // Wedding //
        [HttpGet("NewWedding")]
        public IActionResult NewWedding()
        {

            int? userId = HttpContext.Session.GetInt32("UserId");
            string userName = HttpContext.Session.GetString("UserName");
            ViewBag.UserId = userId;
            ViewBag.UserName = userName;
            
            if(userName == null)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost("CreateWedding")]
        public IActionResult CreateWedding(Wedding wedding, int userId)
        {
            User planner = dbContext.Users.FirstOrDefault(u => u.UserId == userId);
            wedding.Planner = planner;
            System.Console.WriteLine(userId);
            if(ModelState.IsValid)
            {
                dbContext.Add(wedding);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                string userName = HttpContext.Session.GetString("UserName");
                ViewBag.UserId = userId;
                ViewBag.UserName = userName;
                System.Console.WriteLine("NOT VALID");
                return View("NewWedding");
            }
        }

        [HttpPost("Weddings/{weddingId}/Rsvp")]
        public IActionResult Rsvp(int weddingId, int userId)
        {
            User user = dbContext
                .Users
                .FirstOrDefault(u => u.UserId == userId);
            
            Wedding wedding = dbContext
                .Weddings
                .FirstOrDefault(w => w.WeddingId == weddingId);
            
            Association rsvp = new Association(user, userId, wedding, weddingId);
            dbContext.Add(rsvp);
            dbContext.SaveChanges();
            
            ViewBag.UserId = userId;
            ViewBag.UserName = user.FirstName;
            return RedirectToAction("Dashboard");
        }

        [HttpPost("Weddings/{weddingId}/UnRsvp")]
        public IActionResult UnRsvp(int weddingId, int userId)
        {
            User user = dbContext
                .Users
                .FirstOrDefault(u => u.UserId == userId);
            
            Wedding wedding = dbContext
                .Weddings
                .FirstOrDefault(w => w.WeddingId == weddingId);

            Association rsvp = dbContext
                .Associations
                .FirstOrDefault(a => (a.WeddingId == weddingId && a.UserId == userId));
            
            dbContext.Remove(rsvp);
            dbContext.SaveChanges();
            
            ViewBag.UserId = userId;
            ViewBag.UserName = user.FirstName;
            return RedirectToAction("Dashboard");
        }

        [HttpPost("Weddings/{weddingId}/Delete")]
        public IActionResult Delete(int weddingId, int userId)
        {
            User user = dbContext
                .Users
                .FirstOrDefault(u => u.UserId == userId);

            Wedding wedding = dbContext
                .Weddings
                .FirstOrDefault(w => w.WeddingId == weddingId);
            
            dbContext.Remove(wedding);
            dbContext.SaveChanges();
            
            ViewBag.UserId = userId;
            ViewBag.UserName = user.FirstName;
            return RedirectToAction("Dashboard");
        }
    }
}
