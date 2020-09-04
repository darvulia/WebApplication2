using System;
using System.Collections.Generic;

namespace WebApplication2.EFModels
{
    public partial class Sumas
    {
        public int Id { get; set; }
        public decimal? Valor1 { get; set; }
        public decimal? Valor2 { get; set; }
        public decimal? Resultado { get; set; }
    }
}
