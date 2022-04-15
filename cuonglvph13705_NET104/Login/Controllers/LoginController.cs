using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Models;
using Microsoft.AspNetCore.Http;

namespace Login.Controllers
{
    public class LoginController : Controller
    {
        public readonly Context _context;
        public LoginController(Context context)
        {
            this._context = context;
        }
        public IActionResult Login(string username, string password)
        {
            if (!string.IsNullOrEmpty(username)&& !string.IsNullOrEmpty(password))
            {
                var account = _context.accounts.FirstOrDefault(p => p.Username == username && p.PassWord == password);
                if (account != null)//tìm đc tài khoản đúng
                {
                    HttpContext.Session.SetString("username", username);// lưu username vào session 
                    HttpContext.Session.SetString("password", password);
                    return RedirectToAction("Show"); //chuyển đến account show

                }
                else
                {
                    ViewData["Notfound"] = "Bạn đăng Nhập cái gì zậy !!!";
                }
            
            }
            return View();
        }
        public IActionResult Show()
        {
            string username = HttpContext.Session.GetString("username");// lấy data từ session 
          string password=  HttpContext.Session.GetString("password");
            ViewData["username"] = username;
            ViewData["password"] = password;
            return View();
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
