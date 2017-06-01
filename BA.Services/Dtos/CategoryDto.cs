namespace BA.Services.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryDescription { get; set; }

        public CategoryDto()
        {
        }

        public CategoryDto(int id, string name, string categoryDescription)
        {
            Id = id;
            Name = name;
            CategoryDescription = categoryDescription;
        }
    }
}
