#aguardando 90 segundos para aguardar o provisionamento e start do banco
sleep 90s

#rodar o comando para criar o banco
/opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U SA -P "MeuDB@123" -Q "restore database DesafioContaDB from disk='/usr/work/DesafioContaDB.bak' with move 'DesafioContaDB' to '/var/opt/mssql/data/DesafioContaDB.mdf', move 'DesafioContaDB_log' to '/var/opt/mssql/data/DesafioContaDB_log.ldf', replace, stats=10"
