using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using DataAccess;

[ApiController]
[Route("/api/v1/posts")]
public sealed class PostController : ControllerBase
{

    public PostController()
    {

    }
}