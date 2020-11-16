use DesafioContaDB

select  *from customers

select * from CheckingAccounts

select * from OperationsHistory order by CreationDate

--select * from customers join CheckingAccounts on customers.CheckingAccountId = CheckingAccounts.id

update CheckingAccounts set Balance=100.0, Yield = 0