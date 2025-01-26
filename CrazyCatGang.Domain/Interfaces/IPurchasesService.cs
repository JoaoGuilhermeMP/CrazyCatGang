using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyCatGang.Domain.DTO;
using CrazyCatGang.Domain.Models;

namespace CrazyCatGang.Domain.Interfaces
{
    public interface IPurchasesService
    {
        Task<CrazyCatGangResponse<List<Purchase>>> GetPurchases();

        Task<CrazyCatGangResponse<Purchase>> GetPurchaseById(int id);

        Task<CrazyCatGangResponse<Purchase>> GetPurchaseByNumber(string purchaseNumber);

        Task<CrazyCatGangResponse<PurchasePostAndPutDTO>> CreatePurchase(PurchasePostAndPutDTO purchase);

        Task<CrazyCatGangResponse<PurchasePostAndPutDTO>> UpdatePurchase(int purchaseID, PurchasePostAndPutDTO purchase);

        Task<CrazyCatGangResponse<Purchase>> DeletePurchaseByID(int id);

        Task<CrazyCatGangResponse<Purchase>> DeletePurchaseByNumber(string purchaseNumber);

    }
}
