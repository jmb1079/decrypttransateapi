using System.ComponentModel.DataAnnotations;

namespace DecryptTranslateApi.Models {
    public class CaseItem {
        [Key]
        public int Number {get; set;}
        public string Organization {get; set;} = String.Empty;
        public string UserId {get; set;} = String.Empty;

    }
}