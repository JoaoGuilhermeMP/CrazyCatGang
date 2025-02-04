using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CrazyCatGang.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Value { get; set; }

        public int Quantity { get; set; }

        public byte[]? Image { get; set; }


    }
}
