namespace crudd_backend.Models
{
    public class PhoneModel : IEquatable<PhoneModel>
    {
        private int count;
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Model { get; set; }
        public int ReleaseYear { get; set; }
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
