using Microsoft.AspNetCore.Mvc;
using PetrolWalletProject.BusinessLogic.Interface;
using PetrolWalletProject.Domain.Dtos;
using PetrolWalletProject.Domain.Dtos.Merchant;
using PetrolWalletProject.Domain.Models;

namespace PetrolWalletProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IMerchant _repo;

        public MerchantController(IMerchant repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<object> GetMerchant(int pageNumber, int pageSize)
        {
            var res = await _repo.GetMerchant(pageNumber, pageSize);
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
        public async Task<object> GetSingleMerchants(int Id)
        {
            var res = await _repo.GetSingleMerchant(Id);
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
        public async Task<ActionResult> CreateMerchant([FromBody] CreateMerchantDto request)
        {
            var res = await _repo.CreateMerchant(request);
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
        public async Task<ActionResult> UpdateMerchants([FromBody] UpdateMerchantDto request)
        {
            var res = await _repo.UpdateMerchant(request);
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
