using Azure;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TestWebApiCore.Const;
using TestWebApiCore.Interfaces;
using TestWebApiData.Models;

namespace TestTrabajo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {

        private readonly ILogger _logger;
        private IServiceClient _IServiceClient;

        public ClientController(ILogger<ClientController> logger, IServiceClient IServiceUsuario)
        {
            _IServiceClient = IServiceUsuario;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _IServiceClient.GetAll();
                this._logger.LogInformation("Success get all Clients");
                return Json(new { success = true, data = response });
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error : " + ex.Message);
                return Json(new { success = false, data = ex.Message });
            }

        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = await _IServiceClient.Get(id);
                if (response == null) return Json(new { success = true, data = TestConst.CLIENT_NOT_EXIST });
                this._logger.LogInformation("Success get Client");
                return Json(new { success = true, data = response });
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error : " + ex.Message);
                return Json(new { success = false, data = ex.Message });
            }
        }

        [HttpGet]
        [Route("Search/{name}")]
        public async Task<IActionResult> Search(string name)
        {
            try
            {
                var response = await _IServiceClient.Search(name);
                if (response == null) return Json(new { success = true, data = TestConst.CLIENT_NOT_EXIST });
                this._logger.LogInformation("Success Search Client : " + name);
                return Json(new { success = true, data = response });
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error : " + ex.Message);
                return Json(new { success = false, data = ex.Message });
            }
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Client? client = (Client?)await _IServiceClient.Get(id);
                if (client == null) return Json(new { success = true, data = TestConst.CLIENT_NOT_EXIST });
                var response = await _IServiceClient.Delete(id);
                this._logger.LogInformation("Success delete Client : " + id);
                return Json(new { success = true, data = string.Format(TestConst.CANT_SUCCESS_ROW, response)});
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error : " + ex.Message);
                return Json(new { success = false, data = ex.Message });
            }
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert([FromBody] Client client)
        {
            try
            {
                var response = await _IServiceClient.Insert(client);
                this._logger.LogInformation("Success Insert Client");
                return Json(new { success = true, data = string.Format(TestConst.CANT_SUCCESS_ROW, response) });
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error : " + ex.Message);
                return Json(new { success = false, data = ex.Message });
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Client client)
        {
            try
            {
                Client? clientFind = await _IServiceClient.Get(client.id);
                if (clientFind == null) return Json(new { success = true, data = TestConst.CLIENT_NOT_EXIST });

                clientFind.Nombre = client.Nombre;
                clientFind.Apellido = client.Apellido;
                clientFind.Cuit = client.Cuit;
                clientFind.domicilio = client.domicilio;
                clientFind.Celular = client.Celular;
                clientFind.Email = client.Email;

                var response = await _IServiceClient.Update(clientFind);
                this._logger.LogInformation("Success Insert Client : " + client.id);
                return Json(new { success = true, data = string.Format(TestConst.CANT_SUCCESS_ROW, response) });
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error : " + ex.Message);
                return Json(new { success = false, data = ex.Message });
            }
        }

    }
}
