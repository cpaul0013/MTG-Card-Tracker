using Card_Price_Tracker.Data;
using Card_Price_Tracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Card_Price_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyBinderController : ControllerBase
    {
        public mtg_card_trackerContext MyBinderContext;
        public MyBinderController(mtg_card_trackerContext _context)
        {
            MyBinderContext = _context;
        }

        [HttpGet("allCards")]
        public List<MyBinder> allCards()
        {
            List<MyBinder> Binder = new List<MyBinder>();
            ClaimsPrincipal currentUser = this.User;
            string currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            Binder = MyBinderContext.MyBinder.Where(F => F.UserId == currentUserID).ToList();
            return Binder;


        }

        [HttpPost("addToBinder")]
        public MyBinder addToBinder(string cardId)
        {
            ClaimsPrincipal currentUser = this.User;
            string currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            MyBinder newCard = new MyBinder()
            {
                UserId = currentUserID,
                CardId = cardId

            };

            List<MyBinder> MyBinder = MyBinderContext.MyBinder.ToList();

            foreach (MyBinder B in MyBinder)
                if (B.CardId == cardId)
                    if (B.UserId == currentUserID)
                        return newCard;

            MyBinderContext.Add(newCard);
            MyBinderContext.SaveChanges();

            return newCard;

        }

        [HttpDelete("removeFromBinder")]
        public MyBinder removeFromBinder(string cardId)
        {
            ClaimsPrincipal currentUser = this.User;
            string currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            MyBinder deletedCard = MyBinderContext.MyBinder.Where(F => F.CardId == cardId && F.UserId == currentUserID).First();
            MyBinderContext.MyBinder.Remove(deletedCard);
            MyBinderContext.SaveChanges();
            return deletedCard;

        }
    }
}
