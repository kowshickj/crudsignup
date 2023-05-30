
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudSignup.Repository;
using CrudSignup.Models;

namespace CrudSignup.Controllers
{
    public class SignupController : Controller
    {
        SignupRepository signup1 = new SignupRepository();
        public ActionResult Index()
        {
            var ns = signup1.GetUserById();
            if (ns.Count == 0)
            {
                TempData["InfoMessage"] = "Currently name is not Available in Database...";
            }
            return View(ns);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertUser(Signup_page sign)
        {
            bool IsInserted = false;
            try
            {
                if (ModelState.IsValid)
                {
                    IsInserted = signup1.InsertUser(sign);
                    if (IsInserted)
                    {
                        TempData["SuccessMessage"] = "Inserted successfully...";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Name is Already Exit";
                    }

                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        public ActionResult UpdateUser(int id)
        {

            var signup = signup1.GetaUserById(id).FirstOrDefault();
            if (signup == null)
            {
                TempData["InfoMessage"] = "Name not available either Id" + id.ToString();
                return RedirectToAction("Index");
            }
            return View(signup);
        }


        [HttpPost, ActionName("Edit")]
        public ActionResult UpdateUser(Signup_page sign)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool IsUpdated = signup1.UpdateUser(sign);
                    if (IsUpdated)
                    {
                        TempData["SuccessMessage"] = "Details Updated Successfully";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Name is already available/Unable to update";
                    }
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        public ActionResult DeleteUser(int id)
        {
            try
            {
                var signup = signup1.GetaUserById(id).FirstOrDefault();
                if (signup == null)
                {
                    TempData["InfoMessage"] = "Name not available with Id" + id.ToString();
                    return RedirectToAction("Index");
                }
                return View(signup);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteUsers(int id)
        {
            try
            {
                string result = signup1.DeleteUser(id);
                if (result.Contains("deleted"))
                {
                    TempData["SuccessMessage"] = "Details Deleted Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Details not available";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }

        }

        public ActionResult GetDetails(int id)
        {
            try
            {
                var signup = signup1.GetaUserById(id).FirstOrDefault();
                if (signup == null)
                {
                    TempData["InfoMessage"] = "Name not available with Id" + id.ToString();
                    return RedirectToAction("Index");
                }
                return View(signup);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        public ActionResult Sign_in()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Sign_in (Signup_page signup)
        {
            bool IsInserted = false;
            try
            {
                if (ModelState.IsValid)
                {
                    IsInserted = signup1.login(signup);
                    if (IsInserted)
                    {
                        TempData["SuccessMessage"] = "Login successfully...";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Username is Already Exit";
                    }

                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
