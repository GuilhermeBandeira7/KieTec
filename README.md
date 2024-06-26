<h1 align="center"> KieTec Solution </h1>

## 🎯 Sobre o projeto
App web feito em .NET 8 com Blazor wasm e minimal API

## 🔨 Funcionalidades do projeto

O App lista produtos e fornecedores, nome, descrição e valor. Também, é possível cadastrar produtos e fornecedores. Os dados são todos salvos no SQLite

## 🛠️ Abrir e rodar o projeto

Para rodar o projeto é necessário a versão 8 do .NET SDK ou posterior, encontrada em <href> https://dotnet.microsoft.com/en-us/download/dotnet/8.0 </href>
Após baixar o projeto ou clonar o repositório, basta acessar a Pasta Kietec.Api pelo terminal e executar o comando 'dotnet run' para rodar a api.
Repetir o mesmo processo com a pasta Kietec.Web, que irá subir o frontend.
Feito isso, é só acessar a URL do front-end, que é http://localhost:5278

## 📚 Mais informações

A Api está toda documentada no Swagger, disponível em http://localhost:5278/swagger/index.html ao rodar a API

Um pouco sobre a arquitetura do projeto, escolhi criar uma class library chamada Kietec.Core que define os padrões e comportamentos de requests e responses.
Por meio de handlers implementados no core, a API mapeia e implementa seus endpoints e define como vai lidar com cada requisição, além de estabelecer as relações e gerenciar o banco de dados com EntityFramework.
Já o frontend feito em blazor wasm, implementa estes handlers com um HttpClient que faz todas as requisições para a API, que retorna por sua vez as respostas padronizadas.
