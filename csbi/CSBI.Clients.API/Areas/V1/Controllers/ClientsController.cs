namespace CSBI.Clients.API.Areas.V1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net;
    using System.Threading.Tasks;
    using AutoMapper;
    using BLL.Contracts;
    using BLL.Models;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Newtonsoft.Json;

    [Produces("application/json")]
    [Route("clients")]
    public class ClientsController : Controller
    {
        private readonly IService _service;
        private readonly IMapper _mapper;

        public ClientsController(IService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] SearchModel model)
        {
            if (!ValidateOffsetAndLimit(model.Offset, model.Limit, out string errorMessage))
            {
                return CreateErrorResponse((HttpStatusCode)422, errorMessage);
            }

            var clients = await _service.GetClientsAsync(_mapper.Map<ClientsFilter>(model));
            if (clients == null)
            {
                return CreateErrorResponse(HttpStatusCode.NotFound, $"Clients for search model = {JsonConvert.SerializeObject(model)} not found");
            }

            var count = await _service.GetClientsCountAsync();
            HttpContext.Response.Headers[Constants.TotalCountHeader] = count.ToString(NumberFormatInfo.InvariantInfo);

            return Ok(_mapper.Map<IEnumerable<ClientModel>>(clients));
        }

        private static bool ValidateOffsetAndLimit(int offset, int limit, out string responseMessage)
        {
            if (offset < Constants.OffsetMinValue)
            {
                responseMessage = string.Format(ErrorMessages.InvalidOffset, Constants.OffsetMinValue);
                return false;
            }

            if (limit < Constants.LimitMinValue || limit > Constants.LimitMaxValue)
            {
                responseMessage = string.Format(ErrorMessages.InvalidLimit, Constants.LimitMinValue, Constants.LimitMaxValue);
                return false;
            }

            responseMessage = null;
            return true;
        }

        private ObjectResult CreateErrorResponse(HttpStatusCode statusCode, string errorMessage)
        {
            return StatusCode((int)statusCode, new { message = errorMessage });
        }
    }
}