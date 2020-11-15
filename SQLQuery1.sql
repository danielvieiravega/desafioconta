use DesafioContaDB

select  *from customers

select * from CheckingAccounts

select * from OperationsHistory order by CreationDate

select * from customers join CheckingAccounts on customers.CheckingAccountId = CheckingAccounts.id

update CheckingAccounts set Balance = 500 where id = '911D8B02-5732-407B-AC42-201305BACFB3'