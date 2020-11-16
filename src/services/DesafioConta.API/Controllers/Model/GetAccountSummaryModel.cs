using System;
using System.Collections.Generic;

namespace DesafioConta.API.Controllers.Model
{
    public class GetAccountSummaryModel
    {
        public decimal Balance { get; set; }
        public decimal Yield { get; set; }
        public List<OperationsHistoryModel> OperationsHistory { get; set; }
    }

    public class OperationsHistoryModel
    {
        public decimal Amount { get; set; }
        public int Operation { get; set; }
        public DateTime DateTime { get; set; }
    }
}
