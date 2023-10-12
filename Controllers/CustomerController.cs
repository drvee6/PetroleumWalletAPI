using Microsoft.AspNetCore.Mvc;
using PetrolWalletProject.BusinessLogic.Interface;
using PetrolWalletProject.Domain.Dtos;
using PetrolWalletProject.Domain.Models;

namespace PetrolWalletProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _repo;

        public CustomerController(ICustomer repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<object> GetCustomers(int pageNumber, int pageSize)
        {
            var res = await _repo.GetCustomers(pageNumber, pageSize);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else if (res.Code.Equals("01"))
            {
                return NotFound(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse() { Code = res.Code, description = res.Description });
            }
        }

        [HttpGet]
        public async Task<object> GetSingleCustomers(int Id)
        {
            var res = await _repo.GetSingleCustomers(Id);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else if (res.Code.Equals("01"))
            {
                return NotFound(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse() { Code = res.Code, description = res.Description });
            }
        }


        [HttpPost]
        public async Task<ActionResult> CreateCustomers ([FromBody] CreateCustomerDto request)
        {
            var res = await _repo.CreateCustomers (request);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else if (res.Code.Equals("06"))
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse() { Code = res.Code, description = res.Description });
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomers ([FromBody] UpdateCustomerDto request)
        {
            var res = await _repo.UpdateCustomers(request);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse() { Code = res.Code, description = res.Description });
            }
        }
    }
}
