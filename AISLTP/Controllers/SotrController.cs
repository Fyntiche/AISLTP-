using AISLTP.Entities;
using AISLTP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AISLTP.Controllers
{
    public class SotrController : Controller
    {
        // GET: Sotr
        public ActionResult Index()
        {
            return View();
        }

        //получения информации о сотрудниках
        public JsonResult GetSotrs(string sidx , string sort , int page , int rows)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32( page ) - 1;
            int pageSize = rows;

            var SotrList = db.Sotrs.Select(
                    t => new
                    {   
                        t.Guid ,
                        t.Cod_sotr ,
                        t.Ima ,
                        t.Fio ,
                        t.Otc ,
                        t.Dr ,
                        t.Sex ,
                        t.Dvi
                    } );
            int totalRecords = SotrList.Count();
            var totalPages = ( int ) Math.Ceiling( ( float ) totalRecords / ( float ) rows );
            if (sort.ToUpper() == "DESC")
            {
                SotrList = SotrList.OrderByDescending( t => t.Fio );
                SotrList = SotrList.Skip( pageIndex * pageSize ).Take( pageSize );
            }
            else
            {
                SotrList = SotrList.OrderBy( t => t.Fio );
                SotrList = SotrList.Skip( pageIndex * pageSize ).Take( pageSize );
            }
            var jsonData = new
            {
                total = totalPages ,
                page ,
                records = totalRecords ,
                rows = SotrList
            };
            return Json( jsonData , JsonRequestBehavior.AllowGet );
        }

        /*Блог кода для создания, обновления и удаления.*/

        //Для создания
        [HttpPost]
        public string Create([Bind( Exclude = "Guid" )] SotrMaster Model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Model.Guid = Guid.NewGuid();
                    
                    db.Sotrs.Add( Model );
                    db.SaveChanges();
                    msg = "Успешно сохранено";
                }
                else
                {
                    msg = "Данные не прошли проверку";
                }
            }
            catch (Exception ex)
            {
                msg = "Произошла ошибка:" + ex.Message;
            }
            return msg;
        }

        //Для обновления
        public string Edit(SotrMaster Model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry( Model ).State = EntityState.Modified;
                    db.SaveChanges();
                    msg = "Успешно сохранено";
                }
                else
                {
                    msg = "Данные не прошли проверку";
                }
            }
            catch (Exception ex)
            {
                msg = "Произошла ошибка:" + ex.Message;
            }
            return msg;
        }

        //Для удаления
        public string Delete(string Guid)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            SotrMaster sotr = db.Sotrs.Find( Guid );
            db.Sotrs.Remove( sotr );
            db.SaveChanges();
            return "Удалено успешно";
        }
    }
}