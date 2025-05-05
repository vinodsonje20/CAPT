using Application.Commands;
using Application.DTOs;
using Application.Queries;
using Infrastructure.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CAPT_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous] // <---- THIS
    public class MasterController : Controller
    {
        private readonly IMediator _mediator;
        public MasterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{type}")]
        public async Task<IActionResult> AddMaster(string type, [FromBody] MasterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = type.ToLower() switch
            {
                "businesstype" => await _mediator.Send(new AddMasterCommand<MasterDto, BusinessType>(dto)),
                "checkstatus" => await _mediator.Send(new AddMasterCommand<MasterDto, CheckStatus>(dto)),
                "dispositiontype" => await _mediator.Send(new AddMasterCommand<MasterDto, DispositionType>(dto)),
                "location" => await _mediator.Send(new AddMasterCommand<MasterDto, Location>(dto)),
                "transactiontype" => await _mediator.Send(new AddMasterCommand<MasterDto, TransactionType>(dto)),
                "servicetype" => await _mediator.Send(new AddMasterCommand<MasterDto, ServiceType>(dto)),
                _ => throw new ArgumentException("Invalid master type.")
            };
            
            return Ok(new { Id = result });
        }

        [HttpPut("{type}")]
        public async Task<IActionResult> UpdateMaster(string type, [FromBody] MasterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = type.ToLower() switch
            {
                "businesstype" => await _mediator.Send(new UpdateMasterCommand<BusinessType>(dto)),
                "checkstatus" => await _mediator.Send(new UpdateMasterCommand<CheckStatus>(dto)),
                "dispositiontype" => await _mediator.Send(new UpdateMasterCommand<DispositionType>(dto)),
                "location" => await _mediator.Send(new UpdateMasterCommand<Location>(dto)),
                "transactiontype" => await _mediator.Send(new UpdateMasterCommand<TransactionType>(dto)),
                "servicetype" => await _mediator.Send(new UpdateMasterCommand<ServiceType>(dto)),
                _ => throw new ArgumentException("Invalid master type.")
            };

            return Ok(new { Success = result });
        }

        [HttpDelete("{type}/{id}")]
        public async Task<IActionResult> DeleteMaster(string type, int id)
        {
            var result = type.ToLower() switch
            {
                "businesstype" => await _mediator.Send(new DeleteMasterCommand<BusinessType>(id)),
                "checkstatus" => await _mediator.Send(new DeleteMasterCommand<CheckStatus>(id)),
                "dispositiontype" => await _mediator.Send(new DeleteMasterCommand<DispositionType>(id)),
                "location" => await _mediator.Send(new DeleteMasterCommand<Location>(id)),
                "transactiontype" => await _mediator.Send(new DeleteMasterCommand<TransactionType>(id)),
                "servicetype" => await _mediator.Send(new DeleteMasterCommand<ServiceType>(id)),
                _ => throw new ArgumentException("Invalid master type.")
            };

            return Ok(new { Success = result });
        }

        [HttpGet("{type}/{id}")]
        public async Task<IActionResult> GetById(string type, int id)
        {
            var result = type.ToLower() switch
            {
                "businesstype" => await _mediator.Send(new GetMasterByIdQuery<BusinessType>(id)),
                "checkstatus" => await _mediator.Send(new GetMasterByIdQuery<CheckStatus>(id)),
                "dispositiontype" => await _mediator.Send(new GetMasterByIdQuery<DispositionType>(id)),
                "location" => await _mediator.Send(new GetMasterByIdQuery<Location>(id)),
                "transactiontype" => await _mediator.Send(new GetMasterByIdQuery<TransactionType>(id)),
                "servicetype" => await _mediator.Send(new GetMasterByIdQuery<ServiceType>(id)),
                _ => throw new ArgumentException("Invalid master type.")
            };

            return Ok(result);
        }

        [HttpGet("{type}")]
        public async Task<IActionResult> GetAll(string type)
        {
            var result = type.ToLower() switch
            {
                "businesstype" => await _mediator.Send(new GetAllMastersQuery<BusinessType>()),
                "checkstatus" => await _mediator.Send(new GetAllMastersQuery<CheckStatus>()),
                "dispositiontype" => await _mediator.Send(new GetAllMastersQuery<DispositionType>()),
                "location" => await _mediator.Send(new GetAllMastersQuery<Location>()),
                "transactiontype" => await _mediator.Send(new GetAllMastersQuery<TransactionType>()),
                "servicetype" => await _mediator.Send(new GetAllMastersQuery<ServiceType>()),
                _ => throw new ArgumentException("Invalid type")
            };

            return Ok(result);
        }
    }
}
