using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly MovieContext _context;
        public CreateCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async void Handle(CreateCategoryCommand command)
        {
            var category = new Category
            {
                
                CategoryName = command.CategoryName
               
            };
            _context.Categories.Add(category);
            await  _context.SaveChangesAsync();
        }

    }
}
