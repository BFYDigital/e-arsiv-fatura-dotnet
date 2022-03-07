using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFY.Fatura.Models
{
    class ErrorMessageModel
    {
        public string type { get; set; }
        public string text { get; set; }
    }

    class ErrorResponseModel
    {
        public string error { get; set; }
        public ErrorMessageModel[] messages;
    }
}
