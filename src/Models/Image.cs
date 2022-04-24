using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecryptTranslateApi.Models {
   [Table("Image")]
    public class Image {
        [Key]
        public int Guid {get; set;}
        public int Organization {get; set;}
        public string UserId {get; set;} = String.Empty;
        public DateTime UploadedTime { get; set; }

    }
}