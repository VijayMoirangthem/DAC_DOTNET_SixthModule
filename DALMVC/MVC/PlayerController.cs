using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class PlayerController : Controller
    {

        PlayerREP PREP = new PlayerREP();   
        // GET: Player
        public ActionResult getPlayer()
        {
            ViewBag.PlayerList = new List<PlayerModel>();
            ViewBag.PlayerList = PREP.getPlayer();
            return View();
        }

        [HttpPost]
        public ActionResult deletePlayer(string PlayerID)
        {
            PREP.deletePlayer(PlayerID);
            return RedirectToAction("getPlayer");
        }

        [HttpPost]
        public ActionResult insertPlayer(string PlayerID, string PlayerName, string PlayerDept)
        {
            PREP.insertPlayer(PlayerID, PlayerName, PlayerDept);
            return RedirectToAction("getPlayer");
        }
    }

}