using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MomlyWebAuth.Models;
using MomlyWebAuth.Data;
using System.Globalization;

namespace MomlyWebAuth.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<MomlyFriend> friends = new List<MomlyFriend>();
            RestService restService = new RestService();
            friends = await restService.RefreshMomlyFriends();

            string markers = GenerateMarkers(friends);
            ViewBag.Markers = markers;

            return View(friends);
        }

        public async Task<IActionResult> Map()
        {
            List<MomlyFriend> friends = new List<MomlyFriend>();
            RestService restService = new RestService();
            friends = await restService.RefreshMomlyFriends();

            string markers = GenerateMarkers(friends);
            ViewBag.Markers = markers;

            return View(friends);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string GenerateMarkers(List<MomlyFriend> friends)
        {
            int count = 1;
            string allMarkers = "[";

            foreach (var item in friends)
            {
                string latitude = FormatDouble(item.Latitude);
                string longtitude = FormatDouble(item.Longtitude);

                allMarkers += "[";
                allMarkers += string.Format("'{0}', ", item.UserName);
                allMarkers += string.Format("{0}, ", latitude);
                allMarkers += string.Format("{0}, ", longtitude);
                allMarkers += string.Format("{0}", count);
                allMarkers += "], ";
                count++;
            }
            allMarkers = allMarkers.TrimEnd().TrimEnd(',');
            allMarkers += "];";

            return allMarkers;
        }

        private string FormatDouble(double value)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            string x = value.ToString(nfi);
            return x;
        }
    }
}
