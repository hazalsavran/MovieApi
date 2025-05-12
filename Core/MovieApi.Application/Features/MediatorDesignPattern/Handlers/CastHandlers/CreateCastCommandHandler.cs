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
    public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
    {
        private readonly MovieContext _context;
        public CreateCastCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {
            _context.Casts.Add(new Domain.Entities.Cast
            {
                Name = request.Name,
                Surname = request.Surname,
                Title = request.Title,
                Overwiev = request.Overwiev,
                ImageUrl = request.ImageUrl,
                Biography = request.Biography
            });
            await _context.SaveChangesAsync(cancellationToken);

        }
    }
}
