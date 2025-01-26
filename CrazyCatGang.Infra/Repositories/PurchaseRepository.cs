using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyCatGang.Domain.DTO;
using CrazyCatGang.Domain.Interfaces;
using CrazyCatGang.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CrazyCatGang.Infra.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {

        private readonly AppDbContext _context;
        public PurchaseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Purchase> GetPurchaseById(int id)
        {
            return await _context.Purchases.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Purchase> GetPurchaseByNumber(string purchaseNumber)
        {
            return await _context.Purchases.FirstOrDefaultAsync(x => x.PurchaseNumber == purchaseNumber);
        }

        public async Task<List<Purchase>> GetPurchases()
        {
            return await _context.Purchases.ToListAsync();
        }

        public async Task<PurchasePostAndPutDTO> UpdatePurchase(int purchaseID, PurchasePostAndPutDTO purchaseDTO)
        {
            var purchase = _context.Purchases.FirstOrDefault(x => x.Id == purchaseID);

            purchase.PurchaseNumber = purchaseDTO.PurchaseNumber;
            purchase.ItemType = purchaseDTO.ItemType;
            purchase.ItemName = purchaseDTO.ItemName;
            purchase.ItemDescription = purchaseDTO.ItemDescription;
            purchase.ItemPrice = purchaseDTO.ItemPrice;
            purchase.BuyerCPF = purchaseDTO.BuyerCPF;
            purchase.PurchaseDate = purchaseDTO.PurchaseDate;
            purchase.DeliveryDate = purchaseDTO.DeliveryDate;



            _context.Purchases.Update(purchase);
            await _context.SaveChangesAsync();


            return purchaseDTO;
        }

        public async Task<PurchasePostAndPutDTO> CreatePurchase(PurchasePostAndPutDTO purchaseDTO)
        {
            if (string.IsNullOrEmpty(purchaseDTO.ItemName) || purchaseDTO.ItemPrice <= 0)
            {
                throw new ArgumentException("Nome do item e preço devem ser válidos.");
            }

            var purchase = new Purchase
            {
                PurchaseNumber = GeneratePurchaseNumber(),
                ItemType = purchaseDTO.ItemType,
                ItemName = purchaseDTO.ItemName,
                ItemDescription = purchaseDTO.ItemDescription,
                ItemPrice = purchaseDTO.ItemPrice,
                BuyerCPF = purchaseDTO.BuyerCPF,
                PurchaseDate = DateTime.UtcNow,
                DeliveryDate = purchaseDTO.DeliveryDate,
            };

            try
            {
                _context.Purchases.Add(purchase);
                await _context.SaveChangesAsync();

                return new PurchasePostAndPutDTO
                {
                    Id = purchase.Id,
                    PurchaseNumber = purchase.PurchaseNumber,
                    ItemType = purchase.ItemType,
                    ItemName = purchase.ItemName,
                    ItemDescription = purchase.ItemDescription,
                    ItemPrice = purchase.ItemPrice,
                    BuyerCPF = purchase.BuyerCPF,
                    PurchaseDate = purchase.PurchaseDate,
                    DeliveryDate = purchase.DeliveryDate
                };
            }
            catch (Exception ex)
            {
                // Log do erro (exemplo: ILogger)
                throw new Exception("Erro ao criar a compra.", ex);
            }
        }


        public async Task<Purchase> DeletePurchaseByID(int id)
        {
            var purchase = await _context.Purchases.FindAsync(id);

            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync();

            return purchase;
        }

        public async Task<Purchase> DeletePurchaseByNumber(string purchaseNumber)
        {
            var purchase = await _context.Purchases.FirstOrDefaultAsync(p => p.PurchaseNumber == purchaseNumber);

            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync();

            return purchase;
        }


        private string GeneratePurchaseNumber()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper();
        }
    }
}
