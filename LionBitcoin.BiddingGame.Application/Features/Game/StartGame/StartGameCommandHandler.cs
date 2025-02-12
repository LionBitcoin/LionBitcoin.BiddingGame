using LionBitcoin.BiddingGame.Application.Models;
using MediatR;

namespace LionBitcoin.BiddingGame.Application.Features.Game.StartGame;

public class StartGameCommandHandler : IRequestHandler<StartGameCommand, StartGameResponse>
{
    private readonly RequestMetadata _requestMetadata;

    public StartGameCommandHandler(RequestMetadata requestMetadata)
    {
        _requestMetadata = requestMetadata;
    }

    public Task<StartGameResponse> Handle(StartGameCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}