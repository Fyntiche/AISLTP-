using AISLTP.Entities;
using AISLTP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AISLTP.Controllers.Sp
{
    public class CourtController : Controller
    {
        // GET: Court
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetCourt(string sidx , string sort , int page , int rows , bool _search , string searchField , string searchOper , string searchString)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            sort = sort ?? "";
            int pageIndex = Convert.ToInt32( page ) - 1;
            int pageSize = rows;

            var CourtList = db.Courts.Select(
                    t => new
                    {
                        t.ID ,
                        t.Txt ,
                        t.Prim ,
                    } );
            if (_search)
            {
                switch (searchField)
                {
                    case "Txt":
                        CourtList = CourtList.Where( t => t.Txt.Contains( searchString ) );
                        break;
                    case "Prim":
                        CourtList = CourtList.Where( t => t.Prim.Contains( searchString ) );
                        break;
                }
            }
            int totalRecords = CourtList.Count();
            var totalPages = ( int ) Math.Ceiling( ( float ) totalRecords / ( float ) rows );
            if (sort.ToUpper() == "DESC")
            {
                CourtList = CourtList.OrderByDescending( t => t.Txt );
                CourtList = CourtList.Skip( pageIndex * pageSize ).Take( pageSize );
            }
            else
            {
                CourtList = CourtList.OrderBy( t => t.Txt );
                CourtList = CourtList.Skip( pageIndex * pageSize ).Take( pageSize );
            }
            var jsonData = new
            {
                total = totalPages ,
                page ,
                records = totalRecords ,
                rows = CourtList
            };
            return Json( jsonData , JsonRequestBehavior.AllowGet );
        }

        [HttpPost]
        public string Create([Bind( Exclude = "Id" )] Court Model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Model.ID = Guid.NewGuid().ToString();
                    db.Courts.Add( Model );
                    db.SaveChanges();
                    msg = "Сохранено успешно";
                }
                else
                {
                    msg = "Данные не прошли проверку ввода";
                }
            }
            catch (Exception ex)
            {
                msg = "Произошла ошибка:" + ex.Message;
            }
            return msg;
        }
        public string Edit(Court Model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry( Model ).State = EntityState.Modified;
                    db.SaveChanges();
                    msg = "Сохранено успешно";
                }
                else
                {
                    msg = "Данные не прошли проверку ввода";
                }
            }
            catch (Exception ex)
            {
                msg = "Произошла ошибка:" + ex.Message;
            }
            return msg;
        }
        public string Delete(string Id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Court Court = db.Courts.Find( Id );
            db.Courts.Remove( Court );
            db.SaveChanges();
            return "Удалено успешно";
        }

    }
}
