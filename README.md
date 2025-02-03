# Projeto Destiny - Teste Técnico Sinqia

## Introdução
O projeto Destiny foi desenvolvido como parte de um teste técnico para o processo seletivo de uma vaga na Sinqia, uma empresa de tecnologia que oferece soluções para o setor financeiro. O objetivo principal do teste foi avaliar competências técnicas, organização de código, boas práticas de desenvolvimento e capacidade de resolução de problemas.

## Objetivo do Projeto
O desafio do Destiny consistiu em criar uma aplicação para gerenciamento de destinos turísticos. A solução deveria permitir:

- Cadastro de destinos com informações detalhadas.
- Consulta de destinos.
- Filtragem e organização dos registros.

## Tecnologias Utilizadas
- **Backend:** ASP\.NET Core com Entity Framework.
- **Frontend:** React para interface de usuário.
- **Banco de Dados:** SQL Server.
- **Testes:** XUnit para testes unitários.
- **Arquitetura:** Clean Architecture com separação clara entre camadas de domínio, aplicação e infraestrutura.

# Guia de Configuração do Projeto Destiny

Este tópico descreve os passos necessários para configurar e executar o projeto Destiny.

## Requisitos

- Node.js instalado (recomendado: versão LTS).
- .NET SDK (recomendado: versão 6.0 ou superior).
- Banco de dados SQL Server.
- Ferramenta `dotnet-ef` instalada.

### Instalando a Ferramenta `dotnet-ef`
Antes de rodar as migrações, é necessário, caso ainda não tenha feito, instalar a ferramenta dotnet-ef, que é usada para gerenciar migrações do Entity Framework. Para instalá-la, execute o seguinte comando no terminal:

```bash
 dotnet tool install --global dotnet-ef
```

Para verificar se a instalação foi bem-sucedida, execute:

```bash
 dotnet ef --version
```

Se a versão for exibida corretamente, a ferramenta está pronta para uso.

## Configuração do Frontend (React)

1. Navegue até o diretório do frontend:
   ```bash
   cd ./Frontend
   ```

2. Instale as dependências do projeto:
   ```bash
   npm install
   ```

3. Execute a aplicação React:
   ```bash
   npm run dev
   ```

A aplicação React estará disponível em `http://localhost:3000` por padrão.

> **Aviso:** Certifique-se de que a API backend está rodando na porta `5000`. Se não estiver, você precisará alterar a configuração no frontend para apontar para a porta correta. Para isso, abra o arquivo localizado em `./Frontend/src/utils/api.js` e modifique o valor da variável `apiUrl` para a nova porta desejada.

Exemplo:
```javascript
const apiUrl = "http://localhost:YOUR_NEW_PORT";
```

## Configuração do Backend (.NET Core)

1. Navegue até o diretório do backend:
   ```bash
   cd ./Backend/TouristSpot
   ```

2. Configure a string de conexão no arquivo `appsettings.json`. Substitua `YOUR_CONNECTION_STRING` com a string de conexão adequada ao seu ambiente:

   ```json
   {
     "ConnectionStrings": {
       "Connection": "YOUR_CONNECTION_STRING"
     }
   }
   ```

   Exemplo de string de conexão para SQL Server local:

   ```json
   "Data Source=localhost;Initial Catalog=touristspot;User ID=YOUR_USER;Password=YOUR_PASSWORD;Trusted_Connection=True; Encrypt=True; TrustServerCertificate=True;"
   ```

3. Execute as migrações do banco de dados:
   ```bash
   dotnet ef database update -p TouristSpot.Infrastructure -s TouristSpot.Api
   ```

   Este comando criará as tabelas necessárias no banco de dados.

4. Execute a aplicação backend:
   ```bash
   dotnet run
   ```

## Testando o Projeto

1. Abra o navegador e acesse `http://localhost:3000` para visualizar a aplicação.
2. Certifique-se de que o backend está funcionando corretamente em `http://localhost:5000/touristspot`.
 
## Conclusão
Seguindo esses passos, você será capaz de configurar, rodar e testar o projeto Destiny com sucesso. Para quaisquer problemas, revise as configurações de conexão e certifique-se de que todas as dependências estão instaladas.













