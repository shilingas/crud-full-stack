using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crudd_backend.Models
{
    public class PhoneModel : IEquatable<PhoneModel>
    {
        private int count;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column("varchar(50)")]
        public string? CompanyName { get; set; }
        [Required]
        [Column("varchar(50)")]
        public string? Model { get; set; }
        [Required]
        [Column("integer(50)")]
        public int ReleaseYear { get; set; }
        [Required]
        [Column("integer(50)")]
        public int Price { get; set; }

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = 0;
            }
        }
        public PhoneModel(int Id, string CompanyName, string Model, int ReleaseYear, int Price)
        {
            this.Id = Id;
            this.CompanyName = CompanyName;
            this.Model = Model;
            this.ReleaseYear = ReleaseYear;
            this.Price = Price;
        }
        public bool Equals(PhoneModel model)
        {
            return this.Id == model.Id && this.CompanyName == model.CompanyName &&
                this.ReleaseYear == model.ReleaseYear && this.Price == model.Price;
        }
    }
}
