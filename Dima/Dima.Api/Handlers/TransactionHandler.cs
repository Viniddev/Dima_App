using Dima.Api.Data;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Transactions;
using Dima.Core.Response;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers
{
    public class TransactionHandler(AppDbContext context) : ITransactionHandler
    {
        public async Task<BaseResponse<Transaction?>> CreateTransaction(CreateTransactionRequest request)
        {
            try
            {
                Transaction? transaction = new()
                {
                    Title = request.Title,
                    Amount = request.Amount,
                    PaidOrReceivedAt = request.PaydOrRecivedAt,
                    CategoryId = request.CategoryId,
                    UserId = request.UserId,
                };

                await context.Transactions.AddAsync(transaction);
                await context.SaveChangesAsync();

                return new BaseResponse<Transaction?>(transaction);
            }
            catch (Exception ex) 
            {
                return new BaseResponse<Transaction?>(null, ex.Message.ToString(), 500);
            } 
        }

        public async Task<BaseResponse<Transaction?>> DeleteTransaction(DeleteTransactionRequest request)
        {
            BaseResponse<Transaction?> transaction = await GetTransactionById(new GetTransactionByIdRequest() { Id = request.Id, UserId = request.UserId });

            if (transaction.Data != null)
            {
                transaction.Data.DisableEntity();
                await context.SaveChangesAsync();

                return new BaseResponse<Transaction?>(transaction.Data);
            }

            return new BaseResponse<Transaction?>(null, "Transaction not found", 500);

        }

        public async Task<PagedResponse<List<Transaction?>>> GetAllTransactions(GetAllTransactionsRequest request)
        {
            try
            {
                IQueryable<Transaction?> transactions = context.Transactions.Where(x => x.Active && x.UserId == request.UserId);

                int total = await transactions.CountAsync();

                List<Transaction?> result = await transactions
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                return new PagedResponse<List<Transaction?>>(result, total, request.PageSize, request.PageNumber);
            }
            catch (Exception ex) 
            {
                return new PagedResponse<List<Transaction?>>(null, 500, ex.Message.ToString());
            }
        }

        public async Task<BaseResponse<Transaction?>> GetTransactionById(GetTransactionByIdRequest request)
        {
            try
            {
                Transaction? transaction = await context.Transactions.FirstAsync(x => x.Id == request.Id && x.UserId == request.UserId && x.Active);

                if (transaction != null)
                {
                    return new BaseResponse<Transaction?>(transaction);
                }

                return new BaseResponse<Transaction?>(null, "Transaction not found", 500);
            }
            catch (Exception ex) 
            {
                return new BaseResponse<Transaction?>(null, ex.Message.ToString(), 400);
            }

        }

        public async Task<PagedResponse<List<Transaction?>>> GetTransactionsByPeriod(GetTransactionsByPeriodRequest request)
        {
            try
            {
                if(request.StartDate > request.EndDate)
                    return new PagedResponse<List<Transaction?>>(null, 500, "Start date could not be bigger than end date");

                IQueryable<Transaction?> transactions = context.Transactions.Where(x => x.Active && x.UserId == request.UserId && (x.CreationDate >= request.StartDate && x.CreationDate <= request.EndDate));

                int total = await transactions.CountAsync();

                List<Transaction?> result = await transactions
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .OrderByDescending(x => x.CreationDate)
                    .ToListAsync();

                return new PagedResponse<List<Transaction?>>(result, total, request.PageSize, request.PageNumber);
            }
            catch (Exception ex)
            {
                return new PagedResponse<List<Transaction?>>(null, 500, ex.Message.ToString());
            }
        }

        public async Task<BaseResponse<Transaction?>> UpdateTransaction(UpdateTransactionRequest request)
        {
            BaseResponse<Transaction?> transaction = await GetTransactionById(new GetTransactionByIdRequest() { Id = request.Id, UserId = request.UserId });

            if (transaction.Data != null) 
            {
                Transaction Temp = transaction.Data;

                if(!string.IsNullOrEmpty(request.PaydOrRecivedAt.ToString()))
                    Temp.PaidOrReceivedAt = request.PaydOrRecivedAt;

                if(!string.IsNullOrEmpty(request.Title))
                    Temp.Title = request.Title;

                Temp.CategoryId = request.CategoryId;
                Temp.Amount = request.Amount;
                Temp.Title = request.Title;
                Temp.Type = request.Type;

                Temp.UpdateValues();
                context.Transactions.Update(Temp);
                await context.SaveChangesAsync();

                return new BaseResponse<Transaction?>(Temp);
            }

            return new BaseResponse<Transaction?>(null, "Transaction not found", 500);
        }
    }
}
