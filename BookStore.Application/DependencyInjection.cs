
using BookStore.Application.Interfaces;
using BookStore.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPublisherService, PublisherService>();

            return services;
        }
    }
}
