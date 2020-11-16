using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesafioConta.WebApp.MVC.Models
{
    public enum Operation
    {
        [Description("Depósito")]
        Deposit = 0,
        [Description("Saque")]
        Withdraw = 1,
        [Description("Pagamento")]
        Payment = 2
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
        [DisplayFormat(DataFormatString = "{0:c0}")]
        public decimal Balance { get; set; }
        [DisplayFormat(DataFormatString = "{0:c0}")]
        public decimal Yield { get; set; }
        public List<OperationsHistory> OperationsHistory { get; set; }
        public decimal OperationAmount { get; set; }
        public string BoletoCode { get; set; }
        
        public bool WasSuccessfullOperation { get; set; }
        public bool ShowOperationModal { get; set; }

        public AcountViewModel()
        {
            WasSuccessfullOperation = false;
            ShowOperationModal = false;
        }
    }
}
