using CrazyCatGang.Application.Services;
using CrazyCatGang.Domain.DTO;
using CrazyCatGang.Domain.Interfaces;
using CrazyCatGang.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrazyCatGang.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {

        private readonly IPurchasesService _purchaseService;

        public PurchasesController(IPurchasesService purchasesService)
        {
            _purchaseService = purchasesService;
        }

        [HttpGet("GetPurchases")]
        public async Task<ActionResult<CrazyCatGangResponse<List<Purchase>>>> GetPurchases()
        {
            var purchases = await _purchaseService.GetPurchases();

            if (purchases.StatusCode == 200)
            {
                return Ok(purchases);
            }
            else if (purchases.StatusCode == 404)
            {
                return NotFound(purchases);
            }
            else if (purchases.StatusCode == 500)
            {
                return StatusCode(500, purchases);
            }

            return BadRequest(purchases);

        }

        [HttpGet("GetPurchaseByID/{purchaseId}")]
        public async Task<ActionResult<CrazyCatGangResponse<Purchase>>> GetPurchaseByID(int purchaseId)
        {
            var purchases = await _purchaseService.GetPurchaseById(purchaseId);

            if (purchases.StatusCode == 200)
            {
                return Ok(purchases);
            }
            else if (purchases.StatusCode == 404)
            {
                return NotFound(purchases);
            }
            else if (purchases.StatusCode == 500)
            {
                return StatusCode(500, purchases);
            }

            return BadRequest(purchases);

        }

        [HttpGet("GetPurchaseByNumber/{purchaseNumber}")]
        public async Task<ActionResult<CrazyCatGangResponse<Purchase>>> GetPurchaseByNumber(string purchaseNumber)
        {
            var purchases = await _purchaseService.GetPurchaseByNumber(purchaseNumber);

            if (purchases.StatusCode == 200)
            {
                return Ok(purchases);
            }
            else if (purchases.StatusCode == 404)
            {
                return NotFound(purchases);
            }
            else if (purchases.StatusCode == 500)
            {
                return StatusCode(500, purchases);
            }

            return BadRequest(purchases);

        }

        [HttpPost("CreatePurchase")]
        public async Task<ActionResult<CrazyCatGangResponse<Purchase>>> CreatePurchase(PurchasePostAndPutDTO purchase)
        {
            var createdPurchase = await _purchaseService.CreatePurchase(purchase);

            if (createdPurchase.StatusCode == 200)
            {
                return Ok(createdPurchase);
            }
            else if (createdPurchase.StatusCode == 404)
            {
                return NotFound(createdPurchase);
            }
            else if (createdPurchase.StatusCode == 500)
            {
                return StatusCode(500, createdPurchase);
            }

            return BadRequest(createdPurchase);
        }

        [HttpPut("UpdatePurchase/{purchaseID}")]
        public async Task<ActionResult<CrazyCatGangResponse<Purchase>>> UpdatePurchase(int purchaseID, PurchasePostAndPutDTO purchase)
        {
            var createdPurchase = await _purchaseService.UpdatePurchase(purchaseID, purchase);

            if (createdPurchase.StatusCode == 200)
            {
                return Ok(createdPurchase);
            }
            else if (createdPurchase.StatusCode == 404)
            {
                return NotFound(createdPurchase);
            }
            else if (createdPurchase.StatusCode == 500)
            {
                return StatusCode(500, createdPurchase);
            }

            return BadRequest(createdPurchase);
        }

        [HttpDelete("DeletePurchaseByID/{purchaseID}")]
        public async Task<ActionResult<CrazyCatGangResponse<Purchase>>> DeletePurchaseByID(int purchaseID)
        {
            var createdPurchase = await _purchaseService.DeletePurchaseByID(purchaseID);

            if (createdPurchase.StatusCode == 200)
            {
                return Ok(createdPurchase);
            }
            else if (createdPurchase.StatusCode == 404)
            {
                return NotFound(createdPurchase);
            }
            else if (createdPurchase.StatusCode == 500)
            {
                return StatusCode(500, createdPurchase);
            }

            return BadRequest(createdPurchase);
        }

        [HttpDelete("DeletePurchaseByNumber/{purchaseNumber}")]
        public async Task<ActionResult<CrazyCatGangResponse<Purchase>>> DeletePurchaseByNumber(string purchaseNumber)
        {
            var createdPurchase = await _purchaseService.DeletePurchaseByNumber(purchaseNumber);

            if (createdPurchase.StatusCode == 200)
            {
                return Ok(createdPurchase);
            }
            else if (createdPurchase.StatusCode == 404)
            {
                return NotFound(createdPurchase);
            }
            else if (createdPurchase.StatusCode == 500)
            {
                return StatusCode(500, createdPurchase);
            }

            return BadRequest(createdPurchase);
        }

    }
}
