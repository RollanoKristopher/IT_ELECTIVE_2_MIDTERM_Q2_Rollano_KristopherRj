using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlaylistApp.Models.DTOs;

namespace PlaylistApp.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginDto());
        }

        [HttpPost]
        public IActionResult Login(LoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            string username = dto.Username?.Trim() ?? "";
            string password = dto.Password?.Trim() ?? "";

            if (username == "admin" && password == "password123")
            {
                HttpContext.Session.SetString("UserSession", username);
                return RedirectToAction("Index", "Playlist");
            }

            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return View(dto);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            // 1. Wipe out session data
            HttpContext.Session.Clear();

            // 2. Clear session cookie explicitly
            Response.Cookies.Delete(".AspNetCore.Session");

            // 3. Redirect to login
            return RedirectToAction("Login", "Auth");
        }
    }
}