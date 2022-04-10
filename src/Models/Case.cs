using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecryptTranslateApi.Models {
   [Table("Case")]
    public class Case {
        [Key]
        public int Number {get; set;}
        public string Organization {get; set;} = String.Empty;
        public string UserId {get; set;} = String.Empty;

    }
}