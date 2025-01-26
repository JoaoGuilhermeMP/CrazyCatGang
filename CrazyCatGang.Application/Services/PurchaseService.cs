using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyCatGang.Domain.DTO;
using CrazyCatGang.Domain.Interfaces;
using CrazyCatGang.Domain.Models;
using CrazyCatGang.Infra.Repositories;

namespace CrazyCatGang.Application.Services
{
    public class PurchaseService : IPurchasesService

    {

        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

  
        public async Task<CrazyCatGangResponse<Purchase>> GetPurchaseById(int id)
        {
            CrazyCatGangResponse<Purchase> response = new CrazyCatGangResponse<Purchase>();

            try
            {
                var purchase = await _purchaseRepository.GetPurchaseById(id);

                if (purchase == null)
                {
                    response.Mensagem = "Purchase is Null";
                    response.status = false;
                    response.StatusCode = 404;
                    return response;
                }

                response.Data = purchase;

                response.Mensagem = "Purchase found";

                response.status = true;

                response.StatusCode = 200;

                return response;

            }
            catch
            {
                response.Mensagem = "Error to get Purchase By ID";

                response.status = false;

                response.StatusCode = 500;

                return response;
            }
        }

        public async Task<CrazyCatGangResponse<Purchase>> GetPurchaseByNumber(string purchaseNumber)
        {
            CrazyCatGangResponse<Purchase> response = new CrazyCatGangResponse<Purchase>();

            try
            {
                var purchase = await _purchaseRepository.GetPurchaseByNumber(purchaseNumber);

                if (purchase == null)
                {
                    response.Mensagem = "Purchase is Null";
                    response.status = false;
                    response.StatusCode = 404;
                    return response;
                }

                response.Data = purchase;

                response.Mensagem = "Purchase found";

                response.status = true;

                response.StatusCode = 200;

                return response;

            }
            catch
            {
                response.Mensagem = "Error to get Purchase By Number";

                response.status = false;

                response.StatusCode = 500;

                return response;
            }
        }

        public async Task<CrazyCatGangResponse<List<Purchase>>> GetPurchases()
        {
            CrazyCatGangResponse<List<Purchase>> response = new CrazyCatGangResponse<List<Purchase>>();

            try
            {
                var purchase = await _purchaseRepository.GetPurchases();

                if (purchase == null)
                {
                    response.Mensagem = "Purchases is Null";
                    response.status = false;
                    response.StatusCode = 404;
                    return response;
                }

                response.Data = purchase;

                response.Mensagem = "Purchases Found";

                response.status = true;

                response.StatusCode = 200;

                return response;

            }
            catch
            {
                response.Mensagem = "Error to get Purchases";

                response.status = false;

                response.StatusCode = 500;

                return response;
            }
        }

        public async Task<CrazyCatGangResponse<PurchasePostAndPutDTO>> UpdatePurchase(int purchaseID, PurchasePostAndPutDTO purchase)
        {
            CrazyCatGangResponse<PurchasePostAndPutDTO> response = new CrazyCatGangResponse<PurchasePostAndPutDTO>();

            try
            {

                
                var purchaseUpdated = await _purchaseRepository.UpdatePurchase(purchaseID, purchase);

                if (purchaseUpdated == null)
                {
                    response.Mensagem = "Purchase is Null";
                    response.status = false;
                    response.StatusCode = 404;
                    return response;
                }

                response.Data = purchaseUpdated;
                response.Mensagem = "Purchase Updated";
                response.status = true;
                response.StatusCode = 200;

                return response;

            }
            catch
            {
                response.Mensagem = "Error to Update Purchase";
                response.status = false;
                response.StatusCode = 500;
                return response;
            }
        }

        public async Task<CrazyCatGangResponse<PurchasePostAndPutDTO>> CreatePurchase(PurchasePostAndPutDTO purchase)
        {
            CrazyCatGangResponse<PurchasePostAndPutDTO> response = new CrazyCatGangResponse<PurchasePostAndPutDTO>();

            try
            {


                var purchaseUpdated = await _purchaseRepository.CreatePurchase(purchase);

                if (purchaseUpdated == null)
                {
                    response.Mensagem = "Purchase is Null";
                    response.status = false;
                    response.StatusCode = 404;
                    return response;
                }

                response.Data = purchaseUpdated;
                response.Mensagem = "Purchase Created";
                response.status = true;
                response.StatusCode = 200;

                return response;

            }
            catch
            {
                response.Mensagem = "Error to Create Purchase";
                response.status = false;
                response.StatusCode = 500;
                return response;
            }
        }

        public async Task<CrazyCatGangResponse<Purchase>> DeletePurchaseByID(int id)
        {
            CrazyCatGangResponse<Purchase> response = new CrazyCatGangResponse<Purchase>();

            try
            {


                var purchaseUpdated = await _purchaseRepository.DeletePurchaseByID(id);

                if (purchaseUpdated == null)
                {
                    response.Mensagem = "Purchase is Null";
                    response.status = false;
                    response.StatusCode = 404;
                    return response;
                }

                response.Data = purchaseUpdated;
                response.Mensagem = "Purchase Deleted";
                response.status = true;
                response.StatusCode = 200;

                return response;

            }
            catch
            {
                response.Mensagem = "Error to Delete Purchase";
                response.status = false;
                response.StatusCode = 500;
                return response;
            }
        }

        public async Task<CrazyCatGangResponse<Purchase>> DeletePurchaseByNumber(string purchaseNumber)
        {
            CrazyCatGangResponse<Purchase> response = new CrazyCatGangResponse<Purchase>();

            try
            {


                var purchaseUpdated = await _purchaseRepository.DeletePurchaseByNumber(purchaseNumber);

                if (purchaseUpdated == null)
                {
                    response.Mensagem = "Purchase is Null";
                    response.status = false;
                    response.StatusCode = 404;
                    return response;
                }

                response.Data = purchaseUpdated;
                response.Mensagem = "Purchase Deleted";
                response.status = true;
                response.StatusCode = 200;

                return response;

            }
            catch
            {
                response.Mensagem = "Error to Delete Purchase";
                response.status = false;
                response.StatusCode = 500;
                return response;
            }
        }
    }
}
