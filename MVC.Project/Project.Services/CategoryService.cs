namespace Project.Services
{
    using Project.Data;
    using Project.Models.EntityModels;
    using System.Linq;
    using Interfaces;
    using System.Collections.Generic;
    using Project.Models.ViewModels;

    public class CategoryService : Service, ICategoryService
    {
        public CategoryService(SportsSystemContext context) 
            : base(context)
        {
        }

        public Category Create(string name)
        {
            var categoryExists = this.Context
                .Categories
                .FirstOrDefault(c => c.Name == name);

            if (categoryExists != null)
            {
                return null;
            }

            var category = new Category
            {
                Name = name
            };

            this.Context.Categories.Add(category);
            this.Context.SaveChanges();

            return category;
        }

        public ICollection<CategoriesViewModel> GetCategories()
        {
            var categories = this.Context
                .Categories
                .Select(c => new CategoriesViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

            return categories;
        }

        public ICollection<ArticlesViewModel> GetCategoryArticles(int id)
        {
            var articles = this.Context
                .Articles
                .Where(a => a.CategoryId == id)
                .Select(a => new ArticlesViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Category = this.Context.Categories.FirstOrDefault(c => c.Id == id).Name
                })
                .ToList();

            return articles;
        }

        public bool Delete(int id)
        {
            var category = this.Context
                .Categories
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return false;
            }

            this.Context.Categories.Remove(category);
            this.Context.SaveChanges();

            return true;
        }
    }
}