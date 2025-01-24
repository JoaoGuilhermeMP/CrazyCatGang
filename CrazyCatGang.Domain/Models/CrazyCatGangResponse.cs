using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyCatGang.Domain.Models
{
    public class CrazyCatGangResponse<T>
    {
        public string Mensagem { get; set; } = string.Empty;

        public int StatusCode { get; set; } = 200;

        public T? Data { get; set; }


        public bool status { get; set; } = true;


    }
}
