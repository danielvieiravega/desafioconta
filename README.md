# Desafio Conta Corrente Remunerada

  - Para o desenvolvimento desse projeto foi utilizado .NET Core 3.1.
  - O backend é acessível através de uma WebAPI (DesafioConta.API)
  - O frontend é um MVC usando bootstrap.
  - O banco de dados utilizado é o SQL Server, é usado o EF Core como ORM.

O projeto foi estruturado e projetado utilizando DDD. Tentei utilizar muito das boas práticas que são apresentados pela equipe da Microsoft nesse repositório https://github.com/dotnet-architecture/eShopOnContainers, desse excelente curso que fiz https://desenvolvedor.io/curso-online-asp-net-core-enterprise-applications e de outros cursos e vivência do dia-a-dia :P

É possível simular operações de **depósito**, **resgate** e **pagamento** de boletos através da API.
Essas operações são possíveis de serem realizadas através do frontend que também mostra o histórico das últimas operações realizadas pelo cliente. Além disso é apresentado o saldo total que a pessoa possui em conta e o rendimento de sua conta remunerada. Ao invés de criar um serviço em separado para cuidar da remuneração das contas, acabei deixando isso nessa única API, onde é definido dentro da entidade [CheckingAccount](https://gitlab.com/danielvieiravega/desafioconta/-/blob/master/src/services/DesafioConta.Domain/Accounts/CheckingAccount.cs) a taxa de remuneração diária a ser aplicada (Deixei definida a taxa SELIC do dia 16/11/2020).

Para que seja possível ver que a remuneração está funcionando corretamente, defini no *IHostedService* implementado no [MonetizationService.cs](https://gitlab.com/danielvieiravega/desafioconta/-/blob/master/src/services/DesafioConta.API/Services/MonetizationService.cs) que a remuneração é feita a **cada 30 segundos** e não a cada **24 horas**.

## Debugando no Visual Studio
Para que seja possível testar no Visual Studio é necessário seguir os seguintes passos:
  - Na propriedade da solution, definir como **Multiple startup projects** os projetos **DesafioConta.API** e **DesafioConta.WebApp.MVC**
  - Executar o comando **update-database** a partir do **Package Manager Console** sendo definido como **Default Project** o projeto **DesafioConta.Infra**
  - Deixei criada a classe [ModelBuilderExtensions.cs](https://gitlab.com/danielvieiravega/desafioconta/-/blob/master/src/services/DesafioConta.Infra/Data/ModelBuilderExtensions.cs) que faz o seed do banco de dados com as informações que são utilizadas para testes. 

## Rodando no Docker
Para rodar a aplicação sem usar o Visual Studio disponibilizei um [docker-compose.yml](https://gitlab.com/danielvieiravega/desafioconta/-/blob/master/docker/docker-compose.yml) que sobe toda a infra necessária e código para que a aplicação funcione independentemente no Docker.
Acessar a pasta docker e executar o docker-compose:
```sh
$ cd docker/
$ docker-compose up
```
Executando esse comando, irá subir 4 containers:
  - a API (localhost:5011)
  - o SQL Server já com dados cadastrados  (localhost:1433)
  - o frontend MVC (localhost:5001)
  - e proxy ngnix que fica a frente do MVC (localhost:80 e localhost:443)
  
Pelo fato do certificado ser auto-assinado, na hora de acessar pelo navegador vai dar erro que a conexão não é privada (ERR_CERT_AUTHORITY_INVALID), só ignorar e acessar. 

Só acessar o navegador no https://localhost/ (acesso através do proxy) ou http://localhost:5001/ (acesso direto ao container mvc). Obs.: Deixei exposta as portas de todos os containers para poderem serem acessadas diretamente. Se fosse um ambiente de produção, somente o container de nginx teria as portas 80 e 443 expostas para o mundo e o restante dos outros containers conversariam entre si através da rede privada do próprio docker.

Foi configurado o swagger na API. Para usar e testar os endpoints da API só acessar:
 -  https://localhost:5011/swagger (se rodando no Docker) 
 - https://localhost:44344/swagger (se debugando no Visual Studio)
