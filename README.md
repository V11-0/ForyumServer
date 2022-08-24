# Foryum Server

Esse repositório contém o código da API da Aplicação Foryum.

Esse é o nome que dei ao projeto desenvolvido para meu TCC do curso de Análise e Desenvolvimento de Sistemas.

O projeto consiste em criar uma aplicação com tecnologias e ferramentas usadas em projetos reais. Além disso, será criado uma documentação em formato de Wiki nesse repositório, o objetivo é ter uma aplicação e uma documentação que ajude estudantes e iniciantes na área de desenvolvimento a ver como pode ser um sistema que poderia ser aplicado em uma situação real.

<!-- Caso queria aprender mais como funciona o sistema tecnicamente, consulte a [Wiki](https://github.com/V11-0/ForyumServer/wiki). -->

Esse é o repositório do lado do Back-End, o repositório da aplicação Front-End feita com Vue.js pode ser encontrada [aqui](https://github.com/V11-0/ForyumWeb).

## Uso

* Clone esse repositório

* Configure o Banco

A Aplicação depende de um banco de dados SQL configurado, caso possua Docker instalado, você pode criar uma instância do MySQL executando o comando:
```console
docker run --name mysql -e MYSQL_ROOT_PASSWORD=1234 -d mysql
```

Com um banco de dados disponível, abra o arquivo `Infrastructure/AppDbContext.cs` e altere a variável `connectionString` com as informações do seu banco de dados (ip, usuário, senha e database, respectivamente).

```cs
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    var connectionString = "server=172.17.0.4; uid=root; pwd=1234; database=Foryum";
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

    optionsBuilder.UseMySql(connectionString, serverVersion);
}
```
Caso deseje usar outros bancos
 de dados, dê uma olhada sobre [Provedores de Banco de Dados do EF Core](https://docs.microsoft.com/pt-br/ef/core/providers/?tabs=dotnet-core-cli).

Com o banco vazio, precisamos criar a estrutura das tabelas. Isso pode ser feito através de migrations do EF Core com o comando:
```console
dotnet ef database update --project ./Infrastructure/Infrastructure.csproj
```

Caso deseje, você pode executar o arquivo `seed.sql` da pasta `Infrastructure/SQL` para inserir dados de exemplo nas tabelas.

* Agora podemos iniciar a API. Na pasta da aplicação, execute:
```console
dotnet run --project ForyumAPI/ForyumAPI.csproj
```

Com a API rodando, você pode explorar os endpoints atráves do Swagger na URL http://localhost:5139/swagger/index.html