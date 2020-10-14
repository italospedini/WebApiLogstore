using Logstore.Service.ApiResponse.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logstore.Service.ApiResponse
{
    public class ApiResponse : IApiResponse
    {   
        public int statusCode { get; }
        public string mensagem { get; }

        public ApiResponse(int statusCode, string mensagem)
        {
            this.statusCode = statusCode;
            this.mensagem = mensagem;
        }
    }
}
