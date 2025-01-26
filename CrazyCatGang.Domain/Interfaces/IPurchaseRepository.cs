using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyCatGang.Domain.DTO;
using CrazyCatGang.Domain.Models;

namespace CrazyCatGang.Domain.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<List<Purchase>> GetPurchases();

        Task<Purchase> GetPurchaseById(int id);

        Task<Purchase> GetPurchaseByNumber(string purchaseNumber);

        Task<PurchasePostAndPutDTO> CreatePurchase(PurchasePostAndPutDTO purchaseDTO);

        Task<PurchasePostAndPutDTO> UpdatePurchase(int purchaseID, PurchasePostAndPutDTO purchaseDTO);

        Task<Purchase> DeletePurchaseByID(int id);

        Task<Purchase> DeletePurchaseByNumber(string purchaseNumber);


    }
}
