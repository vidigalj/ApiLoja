using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public decimal TotalValue { get; set; }
    }
}
