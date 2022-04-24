using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecryptTranslateApi.Models {
   [Table("AspNetUsers")]
    public class Investigator {
        [Key]
        public string Id {get; set;}

        [Column("UserName")]
        public string Name {get; set;} = String.Empty;
        public string Email {get; set;}
        public string? PhoneNumber { get; set; }
    }
}