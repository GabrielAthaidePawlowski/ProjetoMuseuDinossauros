# DinoMuseum API 🦖 🇧🇷

Projeto desenvolvido para a disciplina de **Arquitetura de Aplicações Web (2026.1)**. O DinoMuseum é uma plataforma interativa de catálogo e documentação de dinossauros que habitaram o território brasileiro, integrando informações geológicas e árvores genealógicas.

## 📝 Visão Geral do Domínio

O sistema gerencia duas entidades principais relacionadas:

1.  **Era Geológica:** Representa os períodos de tempo (Triássico, Jurássico, Cretáceo) com suas respectivas épocas e intervalos de milhões de anos.
    
2.  **Dinossauro:** Contém dados sobre os espécimes, como nome, espécie, região de descoberta e a associação obrigatória com uma **Era**.
    

## 🛠 Stack Tecnológica

-   **Backend:** .NET 10 (C#) com ASP.NET Core
    
-   **Banco de Dados:** MongoDB Atlas (NoSQL)
    
-   **Documentação:** Swagger/OpenAPI 3.0
    
-   **Frontend:** HTML5, CSS3 e JavaScript (Consumo Assíncrono via Fetch API)
    

----------

## ⚙️ Pré-requisitos

Para rodar este projeto localmente, você precisará de:

-   [.NET 10 SDK](https://dotnet.microsoft.com/download)
    
-   [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)
    
-   Uma conta no [MongoDB Atlas](https://www.mongodb.com/cloud/atlas) (ou MongoDB instalado localmente)
    

----------

## 🚀 Como Executar o Projeto

### 1. Clonar o Repositório

Bash

```
git clone https://github.com/seu-usuario/dinomuseum-api.git
cd dinomuseum-api

```

### 2. Configurar Variáveis de Ambiente

Por questões de segurança e seguindo as boas práticas de arquitetura, a string de conexão do banco de dados **não** está fixada no código. Você deve configurá-la no seu sistema:

**No Windows (PowerShell):**

PowerShell

```
$env:MONGODB_URI="mongodb+srv://seu_usuario:sua_senha@cluster.mongodb.net/MuseuDinoDB"

```



_Alternativamente, você pode inserir a URI no arquivo `appsettings.json` local, mas certifique-se de não realizar o commit com suas credenciais expostas._

### 3. Executar a API

Bash

```
dotnet run

```

A API estará disponível em: `http://localhost:5180` (ou na porta indicada no console).

### 4. Acessar o Frontend

Basta abrir o arquivo `index.html` localizado na pasta `/Frontend` em qualquer navegador moderno.

----------

## 📖 Documentação da API (Swagger)

A documentação interativa OpenAPI pode ser acessada enquanto a aplicação estiver rodando através do link: 👉 **[http://localhost:5180/swagger](https://www.google.com/search?q=http://localhost:5180/swagger)**

No Swagger, você encontrará:

-   Descrições detalhadas de todos os endpoints CRUD.
    
-   Exemplos de corpos de requisição (JSON).
    
-   Esquemas de resposta e códigos de status HTTP (200, 201, 204, 404).
