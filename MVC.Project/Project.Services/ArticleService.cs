namespace Project.Services
{
    using Interfaces;
    using Project.Data;
    using Project.Models.BindingModels;
    using Project.Models.EntityModels;
    using Project.Models.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArticleService : Service, IArticleService
    {
        public ArticleService(SportsSystemContext context) 
            : base(context)
        {
        }

        public List<string> PrepareCategories()
        {
            var categories = this.Context
                .Categories
                .Select(c => c.Name)
                .ToList();

            return categories;
        }

        public Article Create(string title, string content, string category, string authorId, string url)
        {
            var articleExists = this.Context
                .Articles
                .FirstOrDefault(a => a.Title == title);

            if (articleExists != null)
            {
                return null;
            }

            var article = new Article
            {
                Title = title,
                Content = content,
                AuthorId = authorId,
                ImageUrl = url,
                CreatedOn = DateTime.UtcNow,
                CategoryId = this.Context.Categories.First(c => c.Name == category).Id,
                Upvotes = 0
            };

            this.Context.Articles.Add(article);
            this.Context.SaveChanges();

            return article;
        }

        public List<ArticlesViewModel> GetArticles()
        {
            var articles = this.Context
                .Articles
                .Select(a => new ArticlesViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Category = this.Context.Categories.FirstOrDefault(c => c.Id == a.CategoryId).Name
                })
                .ToList();

            return articles;
        }

        public bool Delete(int id)
        {
            var article = this.Context
                .Articles
                .FirstOrDefault(c => c.Id == id);

            if (article == null)
            {
                return false;
            }

            this.Context.Articles.Remove(article);
            this.Context.SaveChanges();

            return true;
        }

        public EditArticleBindingModel GetEditModel(int id)
        {
            var article = this.Context
                .Articles
                .FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                return null;
            }

            var categoryName = this.Context
                .Categories
                .FirstOrDefault(c => c.Id == article.CategoryId)
                .Name;

            var categories = this.Context
                .Categories
                .Select(c => c.Name)
                .ToList();

            var model = new EditArticleBindingModel
            {
                Id = article.Id,
                Title = article.Title,
                Category = categoryName,
                Content = article.Content,
                Categories = categories,
                ImageUrl = article.ImageUrl
            };

            return model;
        }

        public void Edit(int id, string title, string content, string category, string url)
        {
            var article = this.Context
                .Articles
                .FirstOrDefault(a => a.Id == id);

            var categoryId = this.Context
                .Categories
                .FirstOrDefault(c => c.Name == category)
                .Id;

            article.Title = title;
            article.Content = content;
            article.CategoryId = categoryId;
            article.ImageUrl = url;

            this.Context.SaveChanges();
        }

        public ArticleDetailsViewModel GetDetails(int id, string userId)
        {
            var article = this.Context
                .Articles
                .FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                return null;
            }

            var author = this.Context
                .Users
                .FirstOrDefault(u => u.Id == article.AuthorId);

            var hasVoted = this.Context
                .UsersArticles
                .Any(ua => ua.ArticleId == article.Id && ua.UserId == userId);

            var articleModel = new ArticleDetailsViewModel
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                Author = author.UserName,
                CreatedOn = article.CreatedOn,
                Upvotes = article.Upvotes,
                ImageUrl = article.ImageUrl,
                HasVoted = hasVoted
            };

            return articleModel;
        }

        public int Upvote(int id, string userId)
        {
            var article = this.Context
                .Articles
                .FirstOrDefault(a => a.Id == id);

            article.Upvotes++;

            var usersArticles = new UsersArticles
            {
                UserId = userId,
                ArticleId = article.Id
            };

            if (!this.Context.UsersArticles.Any(ua => ua.ArticleId == article.Id && ua.UserId == userId))
            {
                this.Context.UsersArticles.Add(usersArticles);
                this.Context.SaveChanges();
            }

            return article.Upvotes;
        }

        public List<IndexViewModel> TopArticles()
        {
            var articles = this.Context
                .Articles
                .OrderByDescending(a => a.Upvotes)
                .Take(3)
                .Select(a => new IndexViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    ImageUrl = a.ImageUrl
                })
                .ToList();

            return articles;
        }
    }
}