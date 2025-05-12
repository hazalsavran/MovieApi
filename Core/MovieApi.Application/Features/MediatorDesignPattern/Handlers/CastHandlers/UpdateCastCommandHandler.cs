using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
    {
        private readonly MovieContext _context;
        public UpdateCastCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
        {
            var cast = await _context.Casts.FindAsync(request.CastId);
            if (cast != null)
            {
                cast.Name = request.Name;
                cast.Surname = request.Surname;
                cast.Title = request.Title;
                cast.Overwiev = request.Overwiev;
                cast.ImageUrl = request.ImageUrl;
                cast.Biography = request.Biography;
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
    
}
