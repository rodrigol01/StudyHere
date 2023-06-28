using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StudyHere.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    // todo: criar endpoint que authentica e loga no sistema
    //todo: configurar db context para gerar a tabela de user
}