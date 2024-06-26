<h1 align="center"> KieTec Solution </h1>

## 🎯 Sobre o projeto
 App web feito em .NET 8 com Blazor wasm e minimal API

## 🔨 Funcionalidades do projeto

 O App lista produtos e fornecedores, nome, descrição e valor. Também, é possível cadastrar produtos e fornecedores. Os dados são todos salvos no SQLite

## 🛠️ Abrir e rodar o projeto

 Para rodar o projeto é necessário a versão 8 do .NET SDK ou posterior, encontrada em <href> https://dotnet.microsoft.com/en-us/download/dotnet/8.0 </href>
Após baixar o projeto ou clonar o repositório, basta acessar a Pasta Kietec.Api pelo terminal e executar o comando 'dotnet run' para rodar a api, a URL
da API será mostrada no terminal. Repetir o mesmo processo com a pasta Kietec.Web, que irá subir o frontend. Feito isso, é só acessar a URL do front-end 
que será mostrada no terminal também. O terminal irá mostrar as URLs corretas de cada projeto.

 As configurações das URLs usadas para rodar a solução estão presentes no arquivo appsettings.json na pasta Kietec.Api
De preferência checar as URLs do terminal. Os padrões configurados na solução são: <br>
Backend app (BackendUrl): https://localhost:7076 (fallback: http://localhost:5217)
Frontend app (FrontendUrl): https://localhost:7007 (fallback: http://localhost:5278) 
<br>
Você pode usar ou atualizar URLs no appsettings.json na pasta Kietec.Api para cada proejto coom novas BackendUrl e FrontendUrl endpoints

## 📚 Documentação e arquitetura

 Ao subir a API e acessar o URL, o usuário será direcionado ao browser com a mensagem "OK" de health-check.
A Api está documentada no Swagger, que pode ser acessada colocando /swagger no final da URL do localhost. <br>

 Um pouco sobre a arquitetura do projeto, escolhi criar uma class library chamada Kietec.Core que define os padrões e comportamentos de requests e responses.
Por meio de handlers implementados no core, a API mapeia e implementa seus endpoints e define como vai lidar com cada requisição, além de estabelecer as relações e gerenciar o banco de dados com EntityFramework. 

<br>
Já o é frontend feito em blazor wasm e componentes do MudBlazor, implementa os handlers do Core com um HttpClient que faz todas as requisições para a API, que retorna por sua vez as respostas padronizadas.
