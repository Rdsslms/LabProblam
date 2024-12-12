using Azure.Identity;
using CodeFirst;
using LabProblam1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace LabProblam1.Controllers
{
    public class UserController : Controller
    {

        public static List<UserDetail> userList = new List<UserDetail>();

        private readonly ApplicationDbContext _context;
        public IActionResult Index()
        {
            var userList = _context.Users.ToList();
            if (userList.Count == 0)
            {
                return View(userList);
            }

            return View();


        }

        public IActionResult Create(UserDetail obj)
        {
            return View();
        }

        public IActionResult Save(UserDetail obj)
        {
            UserEntity userDetail = new UserEntity
            {
                UserId = 1,
                UserName = obj.UserName,
                Email = obj.Email,

            };

            _context.Users.Add(userDetail);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {

            var userDetail = userList.FirstOrDefault(x => x.UserId == id);
            return View(userDetail);
        }

        public IActionResult UpdateData(UserDetail obj)
        {

            return RedirectToAction("Index");
        }

    }
}
