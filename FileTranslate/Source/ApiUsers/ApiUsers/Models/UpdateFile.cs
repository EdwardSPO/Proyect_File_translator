using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace ApiUsers.Models
{
    public class UpdateFile
    {
        [Key]
        public int Id { get; set; }
        public string NameFile { get; set; }
        public string Link { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean Status { get; set; }
        [ForeignKey("User")]
        public int IdUser { get; set; }
        public virtual User User { get; set; }
    }
}
