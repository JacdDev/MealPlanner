﻿using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            return Problem();
        }
    }
}
