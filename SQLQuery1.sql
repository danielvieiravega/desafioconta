use DesafioContaDB

select  *from customers

select * from CheckingAccounts

select * from OperationsHistory

select * from customers join CheckingAccounts on customers.CheckingAccountId = CheckingAccounts.id