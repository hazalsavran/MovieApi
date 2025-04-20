using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly MovieContext _context;
        public UpdateCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async void Handle(UpdateCategoryCommand command)
        {
            var category = await _context.Categories.FindAsync(command.CategoryId);
            if (category != null)
            {
                category.CategoryName = command.CategoryName;
               
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
