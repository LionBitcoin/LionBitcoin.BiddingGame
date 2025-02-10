using System.Threading.Tasks;
using LionBitcoin.BiddingGame.Application.Features.Game.StartGame;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LionBitcoin.BiddingGame.Controllers;

[ApiController]
[Route("api/game")]
public class GameController : ControllerBase
{
    private readonly IMediator _mediator;

    public GameController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("start")]
    public async Task<IActionResult> StartGame()
    {
        return Ok(await _mediator.Send(new StartGameCommand()));
    }
}