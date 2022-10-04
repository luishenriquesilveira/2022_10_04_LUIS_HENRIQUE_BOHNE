using RateMyAnimal.Domain.Entities;

namespace RateMyAnimal.Domain.Entities
{
    public class Animal
    {
        public Animal()
        {
            Date = DateTime.Now;
        }

        public int? Id { get; set; }
        public byte[] Image { get; set; }
        public DateTime? Date { get; set; }
        public virtual IEnumerable<AnimalCategory> AnimalCategories { get; set; }

        public Animal(byte[] image)
        {
            Image = image;
        }

        public void ChangeAnimal(Animal animal)
        {
            Date = animal.Date;
            AnimalCategories = animal.AnimalCategories;
        }

        public void SetDate()
        {
            Date = DateTime.Now;
        }
    }
}
