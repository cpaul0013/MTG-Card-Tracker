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
    public class WantCardsController : ControllerBase
    {
        public mtg_card_trackerContext WantCardsContext;
        public WantCardsController(mtg_card_trackerContext _context)
        {
            WantCardsContext = _context;
        }

        [HttpGet("allWantCards")]
        public List<WantCards> wantCards()
        {
            List<WantCards> wishList = new List<WantCards>();
            ClaimsPrincipal currentUser = this.User;
            string currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            wishList = WantCardsContext.WantCards.Where(F => F.UserId == currentUserID).ToList();
            return wishList;


        }

        [HttpPost("addWantCards")]
        public WantCards addToWantCards(string cardId, decimal price)
        {
            ClaimsPrincipal currentUser = this.User;
            string currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            WantCards wantCard = new WantCards()
            {
                UserId = currentUserID,
                CardId = cardId,
                BuyPrice = price

            };

            List<WantCards> wishList = WantCardsContext.WantCards.ToList();

            foreach (WantCards S in wishList)
                if (S.CardId == cardId)
                    if (S.UserId == currentUserID)
                        return wantCard;

            WantCardsContext.Add(wantCard);
            WantCardsContext.SaveChanges();

            return wantCard;

        }

        [HttpDelete("removeFromWantCards")]
        public SellCards removeFromWantCards(string cardId)
        {
            ClaimsPrincipal currentUser = this.User;
            string currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            SellCards deletedCard = WantCardsContext.SellCards.Where(F => F.CardId == cardId && F.UserId == currentUserID).First();
            WantCardsContext.SellCards.Remove(deletedCard);
            WantCardsContext.SaveChanges();
            return deletedCard;

        }

        [HttpPatch("updateBuyPrice")]
        public WantCards updateBuyPrice(decimal price, string cardId)
        {
            ClaimsPrincipal currentUser = this.User;
            string currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            WantCards updatedCard = WantCardsContext.WantCards.Where(F => F.CardId == cardId && F.UserId == currentUserID).First();
            updatedCard.UserId = currentUserID;
            updatedCard.CardId = cardId;
            updatedCard.BuyPrice = price;
            return updatedCard;


        }
    }
}

