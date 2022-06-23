using System.ComponentModel.DataAnnotations;

namespace ParsonApi.Models
{
    public class Parson
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [MinLength(1,ErrorMessage = "Min length is 1")]
        [MaxLength(10,ErrorMessage = "Max langth 10")]
        public string Name { get; set; }
    }
}