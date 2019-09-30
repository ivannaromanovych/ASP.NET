using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    [Table("tblCity")]
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [ForeignKey("CountryOf")]
        public int CountryId { get; set; }
        public Country CountryOf { get; set; }
    }
}
