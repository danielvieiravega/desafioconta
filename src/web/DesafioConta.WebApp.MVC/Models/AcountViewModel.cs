using System;
using System.Collections.Generic;

namespace DesafioConta.WebApp.MVC.Models
{
    public enum Operation
    {
        Deposito = 0,
        Saque = 1,
        Pagamento = 2
    }

    public class OperationsHistory
    {
        public decimal Amount { get; set; }
        public Operation Operation { get; set; }
        public DateTime DateTime { get; set; }
       
        public OperationsHistory()
        {
                
        }
    }

    public class AcountViewModel
    {
        public decimal Balance { get; set; }
        public decimal Yield { get; set; }
        public List<OperationsHistory> OperationsHistory { get; set; }
        public decimal OperationAmount { get; set; }
        public string BoletoCode { get; set; }
        public bool ShowSuccessOperation { get; set; }
        public AcountViewModel()
        {

        }

    }
}
