using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _context;
        public UpdateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateMovieCommand command)
        {
            var movie = await _context.Movies.FindAsync(command.MovieId);
            if (movie != null)
            {
                movie.Title = command.Title;
                movie.Description = command.Description;
                movie.CoverImageUrl = command.CoverImageUrl;
                movie.Status = command.Status;
                movie.Rating = command.Rating;
                movie.Duration = command.Duration;
                movie.CreatedYear = command.CreatedYear;
                movie.ReleaseDate = command.ReleaseDate;

                _context.Movies.Update(movie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
