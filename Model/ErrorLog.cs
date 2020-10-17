using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoutiqueWin.Model
{
    public class ErrorLog
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public String Libelle { get; set; }

        //[MaxLength(1000)]
        public String Description { get; set; }

        public DateTime dateErreur { get; set; }

        public ErrorLog()
        {
            dateErreur = DateTime.Now;
        }
    }
}