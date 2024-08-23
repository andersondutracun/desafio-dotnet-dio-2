using System;
using System.Collections.Generic;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite != null && hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else if (Suite == null)
            {
                throw new InvalidOperationException("A suíte não foi cadastrada.");
            }
            else
            {
                throw new ArgumentException("O número de hóspedes excede a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes != null ? Hospedes.Count : 0;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
            {
                throw new InvalidOperationException("A suíte não foi cadastrada.");
            }

            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valor *= 0.90m; // Aplica um desconto de 10%
            }

            return valor;
        }
    }
}
