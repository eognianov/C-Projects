using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PandaWebApp.Models
{
    public class Receipt
    {
        public int Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn  { get; set; } = DateTime.Now;


        [ForeignKey("Recipient")]
        public int UserId { get; set; }

        public virtual User Recipient { get; set; }


        [ForeignKey("Package")]
        public int PackageId { get; set; }

        public virtual Package Package { get; set; }

    }
}
