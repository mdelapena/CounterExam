using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleWebApplicationButtonSave.Models;

namespace SampleWebApplicationButtonSave.Controllers
{
    public class CounterController : Controller
    {
        
        DbCounterEntities1 db = new DbCounterEntities1();
        
        public ActionResult CounterSaving(int id = 2)
        {

            db.Database.Connection.Open();

            //Checking if having a data in the database
            if (db.tblCounters.Count() <= 0)
            {
                tblCounter dbInsert = new tblCounter();
                dbInsert.CounterCnt = 0;
                db.tblCounters.Add(dbInsert);
                db.SaveChanges();
            }
            //Querying to the employee table
            Models.tblCounter counterView = db.tblCounters.Single();
            return View(counterView);
        }


        //POST: CounterSaving

        [HttpPost]
        public ActionResult CounterSaving()
        {
            try
            {

              
                Models.tblCounter counterChecking = db.tblCounters.Single();
                
                //Setting of count limit to 10
                if(counterChecking.CounterCnt.Value < 10)
                {
                    Models.tblCounter counterUpdate = db.tblCounters.Single();
                    counterUpdate.CounterCnt += 1;
                    db.SaveChanges();
                }
                else
                {
                    Models.tblCounter counterUpdate = db.tblCounters.Single();
                    counterUpdate.CounterCnt = 0;
                    db.SaveChanges();
                }
                //Querying to the employee table
                Models.tblCounter counterView = db.tblCounters.Single();
                return View(counterView);
               
            }
            catch
            {
                return View();
            }
        }



    }
}