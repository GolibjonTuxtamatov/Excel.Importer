//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Microsoft.AspNetCore.Mvc;

namespace Excel.Importer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get() =>
            Ok("Hammasi Okkey");
    }
}
