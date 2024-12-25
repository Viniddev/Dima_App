using Dima.Core.Models;
using Dima.Core.Request.Transactions;
using Dima.Core.Response;


namespace Dima.Core.Handlers
{
    public interface ITransactionHandler
    {
        Task<PagedResponse<List<Transaction?>>> GetAllTransactions(GetAllTransactionsRequest request);
        Task<BaseResponse<Transaction?>> GetTransactionById(GetTransactionByIdRequest request);
        Task<BaseResponse<Transaction?>> CreateTransaction(CreateTransactionRequest request);
        Task<BaseResponse<Transaction?>> UpdateTransaction(UpdateTransactionRequest request);
        Task<BaseResponse<Transaction?>> DeleteTransaction(DeleteTransactionRequest request);
    }
}
