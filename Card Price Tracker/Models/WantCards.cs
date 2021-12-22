using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Card_Price_Tracker.Models
{
    public partial class WantCards
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CardId { get; set; }
        public decimal BuyPrice { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
