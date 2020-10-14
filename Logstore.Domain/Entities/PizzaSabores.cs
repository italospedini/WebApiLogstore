using Logstore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logstore.Domain.Entities
{
    public class PizzaSabores : IEntityBase
    {
        public int Id { get; private set; }

        public string NomeSabor { get; private set; }

        public decimal PrecoUnitario { get; private set; }

        /// <summary>
        /// Informa se a pizza está disponível no cardápio (ex: se possui todos os ingredientes para prepará-la no momento)
        /// se não estiver disponível pode aparecer esmaecida no front-end
        /// </summary>
        public bool Disponivel { get; set; }

        /// <summary>
        /// Indica se a pizza ainda é comercializada, não será apagada da base de dados para fins de histórico dos pedidos,
        /// porém não deverá mais ser exibida no cardápio
        /// </summary>
        public bool Ativa { get; set; }

        public PizzaSabores()
        {
            this.Disponivel = true;
            this.Ativa = true;
        }
    }
}
