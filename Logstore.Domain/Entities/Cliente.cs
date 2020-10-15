using Logstore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logstore.Domain.Entities
{
    public class Cliente : IEntityBase
    {
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public string Endereco_Entrega { get; private set; }

        public Cliente()
        {

        }

        public Cliente(string endereco)
        {
            this.Endereco_Entrega = endereco;
        }

    }
}
