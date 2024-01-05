using QuestEncrypter.Models;
using Microsoft.AspNetCore.Mvc;
using QuestEncrypter.Helpers;
using QuestEncrypter.Cyphers.Interfaces;

namespace EncrypterAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class EncrypterController : ControllerBase
    {
        [HttpPost("Encrypter")]
        public ActionResult<ICypherResult> Encrypt([FromBody]InputModel inputModel)
        {
            switch (inputModel.CypherMode)
            {
                case CypherMode.Encrypt:
                    return RequestProcessor.Encrypt(inputModel);
                case CypherMode.Decrypt:
                    return RequestProcessor.Decrypt(inputModel);
            }

            return BadRequest();
        }
    }
}
