using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecryptTranslateApi.Models {
   [Table("Image")]
    public class Image {
        [Key]
        public int Id { get; set; }
        public Guid Guid {get; set;}
        public int Case {get; set;}
        public string Container {get; set;}

    }
}