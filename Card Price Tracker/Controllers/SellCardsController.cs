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
    public class SellCardsController : ControllerBase
    {
        public mtg_card_trackerContext SellCardsContext;
        public SellCardsController(mtg_card_trackerContext _context)
        {
            SellCardsContext = _context;
        }

        [HttpGet("allSellCards")]
        public List<SellCards> sellCards()
        {
            List<SellCards> forSale  = new List<SellCards>();
            ClaimsPrincipal currentUser = this.User;
            string currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            forSale = SellCardsContext.SellCards.Where(F => F.UserId == currentUserID).ToList();
            return forSale;


        }

        [HttpGet("cardByID")]
        public SellCards cardById(string cardId)
        {
            ClaimsPrincipal currentUser = this.User;
            string currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            SellCards result = new SellCards();
            result = SellCardsContext.SellCards.Where(F => F.CardId == cardId && F.UserId == currentUserID).First();


            return result;

        }

        [HttpPost("addSellCards")]
        public SellCards addToSellCards(string cardId, decimal price)
        {
            ClaimsPrincipal currentUser = this.User;
            string currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            SellCards sellCard = new SellCards()
            {
                UserId = currentUserID,
                CardId = cardId,
                SellPrice = price

            };

            List<SellCards> forSale = SellCardsContext.SellCards.ToList();

            foreach (SellCards S in forSale)
                if (S.CardId == cardId)
                    if (S.UserId == currentUserID)
                        return sellCard;

            SellCardsContext.Add(sellCard);
            SellCardsContext.SaveChanges();

            return sellCard;

        }

        [HttpDelete("removeFromSellCards")]
        public SellCards removeFromSellCards(string cardId)
        {
            ClaimsPrincipal currentUser = this.User;
            string currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            SellCards deletedCard = SellCardsContext.SellCards.Where(F => F.CardId == cardId && F.UserId == currentUserID).First();
            SellCardsContext.SellCards.Remove(deletedCard);
            SellCardsContext.SaveChanges();
            return deletedCard;

        }

        [HttpPatch("updateSellPrice")]
        public SellCards updateSellPrice(decimal price, string cardId)
        {
            ClaimsPrincipal currentUser = this.User;
            string currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            SellCards updatedCard = SellCardsContext.SellCards.Where(F => F.CardId == cardId && F.UserId == currentUserID).First();
            updatedCard.UserId = currentUserID;
            updatedCard.CardId = cardId;
            updatedCard.SellPrice = price;
            return updatedCard;


        }
    }
}
