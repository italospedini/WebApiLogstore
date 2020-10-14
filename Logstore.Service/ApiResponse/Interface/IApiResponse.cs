using System;
using System.Collections.Generic;
using System.Text;

namespace Logstore.Service.ApiResponse.Interface
{
    public interface IApiResponse
    {
        int statusCode { get; }
        string mensagem { get; }

    }
}
