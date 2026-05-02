# Trabalho Prático Semestral
## Disciplina: Arquitetura de Aplicações Web — 2026.1

---

## Visão Geral

O objetivo é desenvolver uma aplicação web completa que demonstre os conceitos fundamentais estudados ao longo do semestre: design de APIs REST, persistência em banco de dados NoSQL, documentação técnica e consumo assíncrono de dados no frontend.

**Apresentações:** Semana 15 — 01/06 a 05/06/2026 (conforme cronograma da disciplina).

---

## Tema

O tema é de **livre escolha**. O aluno define o domínio da aplicação (exemplos: e-commerce, biblioteca, clínica, sistema de reservas, controle de estoque, plataforma de avaliações, etc.).

O importante é que o domínio possua pelo menos **duas entidades relacionadas** com operações de CRUD significativas.

---

## Stack Tecnológica

A stack é de **livre escolha**, mas a recomendada é:

| Camada    | Recomendação              | Alternativas aceitas           |
|-----------|---------------------------|--------------------------------|
| Backend   | **.NET 10 (C#)**          | Node.js + Express, Python + FastAPI |
| Banco     | **MongoDB**               | Qualquer banco NoSQL           |
| Frontend  | HTML + JavaScript (fetch) | React, Vue, Angular ou similar |

> Independente da escolha, todos os requisitos técnicos descritos abaixo devem ser atendidos.

---

## Requisitos Obrigatórios

### 1. REST API

- Implemente endpoints para pelo menos **duas entidades** do domínio escolhido.
- Cada entidade deve ter as operações **CRUD completas**: `GET` (listar e buscar por ID), `POST`, `PUT`/`PATCH`, `DELETE`.
- Respeite as boas práticas REST: verbos HTTP corretos, códigos de status adequados (`200`, `201`, `204`, `400`, `404`, `500`), e URLs com substantivos no plural (ex: `/produtos`, `/clientes`).

### 2. Banco de Dados NoSQL

- Utilize um banco NoSQL (preferencialmente **MongoDB**) para persistir os dados.
- Não utilize banco em memória ou arquivos JSON como substituto ao banco.
- A string de conexão deve ser configurável via variável de ambiente (não hardcoded no código).

### 3. Documentação da API (OpenAPI/Swagger)

- Todos os endpoints devem estar documentados via **Swagger/OpenAPI**.
- A interface do Swagger deve estar acessível ao rodar a aplicação localmente (ex: `http://localhost:5000/swagger`).
- Inclua descrições, parâmetros, corpo das requisições e exemplos de resposta.

### 4. README

O repositório deve conter um `README.md` na raiz com, no mínimo:

- Descrição do projeto e do domínio escolhido.
- Pré-requisitos de instalação (versão da linguagem/runtime, ferramentas necessárias).
- Passo a passo para executar o projeto localmente.
- Como acessar a documentação Swagger.
- Variáveis de ambiente necessárias (com exemplos, sem expor valores reais).

### 5. Página Web com Navegação Assíncrona

- Implemente ao menos **uma página web** que consuma a API desenvolvida.
- A página deve realizar chamadas assíncronas, **sem recarregar o navegador**.
- A navegação entre diferentes "visões" (ex: lista de itens → detalhe do item → formulário de cadastro) deve ocorrer de forma assíncrona, atualizando apenas o conteúdo da página.

---

## Requisitos Bônus

Os bônus podem elevar a nota.

### Bônus A — JWT e Autenticação

- Implemente endpoints de **registro** e **login** de usuários.
- O login deve retornar um **JSON Web Token (JWT)** válido.
- Endpoints protegidos devem exigir o token no header `Authorization: Bearer <token>`.
- O token deve ter expiração configurada.

### Bônus B — Autorização com Perfis (RBAC)

- Defina pelo menos **dois perfis** de usuário (ex: `admin` e `usuario`).
- Endpoints sensíveis (ex: deletar, editar qualquer registro) devem ser restritos ao perfil `admin`.
- O perfil deve estar presente no payload do JWT e ser validado no servidor.

### Bônus C — Testes Unitários

- Implemente testes unitários para a camada de **serviço/regras de negócio** da API.
- Cubra ao menos **dois cenários de sucesso** e **dois cenários de erro** (ex: criação com dados válidos vs. dados inválidos, busca por ID existente vs. inexistente).
- Utilize um framework de testes adequado à stack escolhida (ex: xUnit/.NET, Jest/Node.js, pytest/Python).
- Os testes devem ser executáveis via um único comando documentado no README (ex: `dotnet test`, `npm test`, `pytest`).

### Bônus D — Princípios SOLID

- Aplique ao menos **três dos cinco princípios SOLID** no código do backend:
  - **S** — Single Responsibility Principle
  - **O** — Open/Closed Principle
  - **L** — Liskov Substitution Principle
  - **I** — Interface Segregation Principle
  - **D** — Dependency Inversion Principle
- No README (ou em um arquivo `SOLID.md` na raiz do repositório), **indique para cada princípio aplicado**:
  - Qual princípio foi utilizado.
  - Em qual arquivo/classe/trecho do código ele aparece.
  - Uma breve justificativa de como o código atende ao princípio.
- A aplicação dos princípios será verificada durante a apresentação — o aluno deve ser capaz de explicar as decisões tomadas.

---

## Critérios de Avaliação

| Critério                                |
|-----------------------------------------|
| REST API funcional com CRUD (2+ entidades) |
| Banco de dados NoSQL integrado          |
| Documentação OpenAPI/Swagger completa   |
| README com instruções claras            |
| Página com navegação assíncrona         |

| **Bônus**                |
|-----------------------------------------|
| Bônus A: JWT + Autenticação             |
| Bônus B: Autorização RBAC               |
| Bônus C: Testes Unitários               |
| Bônus D: Princípios SOLID               |

### Critérios de desclassificação

- Projeto entregue como arquivo `.zip` (sem repositório Git com histórico de commits).
- Realize os commits frequentemente para garantir o histórico de commits. 
- Banco de dados em memória ou arquivo local no lugar de um banco NoSQL real.
- Código gerado integralmente por IA sem evidência de autoria ou entendimento (será verificado na apresentação).

---

## Entregáveis

1. **Repositório GitHub** (público ou com acesso ao professor) — enviar o link pelo formulário indicado até **30/05/2026**.
2. **Apresentação presencipal** na semana 15 (01/06–05/06/2026): demonstração ao vivo da aplicação rodando localmente + perguntas técnicas sobre o código.

> O professor poderá fazer perguntas sobre qualquer parte do código durante a apresentação. Não saber responder sobre trechos do próprio projeto impacta a avaliação.

---

## Dicas

- Comece pelo modelo de dados e pelos endpoints antes de pensar no frontend.
- Use o `docker-compose` para subir o MongoDB localmente — facilita a configuração e demonstra conhecimento de containerização.
- Aproveite o Swagger para testar seus endpoints antes de construir o frontend.
- Commits frequentes e mensagens descritivas fazem parte da avaliação da organização do projeto.
