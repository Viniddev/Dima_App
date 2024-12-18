using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dima.Core.Response
{
    public class BaseResponse<TData>
    {

        private readonly int _StatusCode;
        //TData é um tipo generico que é atribuido sempre que instanciamos o BaseResponse
        public TData? Data { get; set; }

        public string? Message { get; set; } = string.Empty;

        [JsonIgnore]
        public bool IsSuccess => _StatusCode is >= 200 and <= 299;

        public BaseResponse(TData? data, string? message = null, int code = Configuration.DefaultStatusCode) 
        {
            Data = data;
            Message = message;
            _StatusCode = code;
        }

        //um construtor sem parametros para evitar erros de serialização
        [JsonConstructor]
        public BaseResponse() => _StatusCode = Configuration.DefaultStatusCode;
    }
}
