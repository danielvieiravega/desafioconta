using System;

namespace DesafioConta.Domain.Accounts
{
    public class OperationsHistory
    {
        public DateTime DateTime { get; set; }
        public Operation Operation { get; set; }
        public decimal Amount { get; set; }
    }
}
