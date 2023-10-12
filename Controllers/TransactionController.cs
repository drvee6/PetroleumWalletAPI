using Microsoft.AspNetCore.Mvc;
using PetrolWalletProject.BusinessLogic.Interface;
using PetrolWalletProject.Domain.Dtos;
using PetrolWalletProject.Domain.Dtos.Transaction;
using PetrolWalletProject.Domain.Models;

namespace PetrolWalletProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransaction _repo;

        public TransactionController(ITransaction repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<object> GetTransactions(int pageNumber, int pageSize)
        {
            var res = await _repo.GetTransactions(pageNumber, pageSize);
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
        public async Task<object> GetSingleTransactions(int Id)
        {
            var res = await _repo.GetSingleTransactions(Id);
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
        public async Task<ActionResult> PostTransactions ([FromBody] PostTransactionDto request)
        {
            var res = await _repo.PostTransactions(request);
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

       
    }
}
