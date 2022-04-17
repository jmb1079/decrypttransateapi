using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecryptTranslateApi.Models {
   [Table("Organization")]
    public class Organization {
        [Key]
        public int Id {get; set;}
        public string Name {get; set;} = String.Empty;
        public string? ShortName {get; set;}
        public string Website { get; set; } = String.Empty;
    }
}