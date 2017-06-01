using System;

namespace BA.Domains
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CategoryDescription { get; private set; }

        public Category()
        {
            
        }

        public Category(string name, string description)
        {
            Name = name;
            CategoryDescription = description;

            NameValidation(name);
            DescriptionValidation(description);
        }

        public void NameValidation(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (name.Length > 20)
                    throw new InvalidOperationException("name is too long");
                else
                    Name = name;
        }

        public void DescriptionValidation(string description)
        {
            if (description == null)
                throw new ArgumentNullException(nameof(description));

            if (description.Length > 30)
                    throw new InvalidOperationException("description to long");
                else
                    CategoryDescription = description;
        }

        public void Update(string name, string description)
        {
            Name = name;
            CategoryDescription = description;
        }
    }
}
