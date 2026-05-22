# SOLID no Museu dos Dinossauros 🦕

Aqui você vai encontrar onde estão aplicados os conceitos de SOLID no projeto do Museu dos Dinossauros e o seu conceito.

## S - Single Responsibility Principle

"Princípio de responsabilidade única"

**Conceito:**
Cada classe deve ser responsável por apenas uma função, evitando mais de uma responsabilidade.

**Onde encontrar?**
Você encontrará esse conceito tanto em [`DinossauroController.cs`](./Controllers/DinossauroController.cs) quanto em [`MongoDbService.cs`](./Data/MongoDbService.cs). A explicação é simples:

**Dinossauro Controller:** é responsável pela mediação dos Endpoints HTTP (Get, Post, Put e Delete). Com isso, tem a única responsabilidade de criar essa comunicação entre o cliente e o servidor, requisição e resposta.

**MongoDBService:** é utilizado para a configuração da variável de ambiente a ser utilizada para a conexão ao MongoDB Atlas via nuvem. Com isso, antes da execução da aplicação, é necessário o usuário dar entrada na env com a url correta contendo as credenciais do banco a ser utilizado, sendo assim mais um exemplo de responsabilidade única.
    

## O - Open Closed Principle
"Aberto para extensão, fechado para modificação"

**Conceito:**
Deve-se adicionar novos comportamentos sem alterar o código base, apenas se estendendo para novas classes.

**Onde encontrar?**
Você encontrará esse conceito em [`Dinossauro.cs`](./Models/Dinossauro.cs).

O comportamento das operações de banco de dados na API está fechado para modificação, mas aberto para extensão. Se no futuro o domínio do sistema mudar e for decidido estender os tipos de dinossauros (criando subclasses) por meio das suas espécies, assim estratificando ou mudando a metodologia a sua base se manteria, mas mudaria a ideia.
    
## L - Liskov Substitution Principle
"Subtipos devem ser usados no lugar do tipo base sem quebrar o programa"

**Conceito:**
Se uma classe filha estende uma classe pai, ela não deve alterar o comportamento esperado.

**Onde se encontra?**
Você encontrará esse conceito tanto em [`DinossauroController.cs`](./Controllers/DinossauroController.cs) quanto em [`ErasController.cs`](./Controllers/ErasController.cs). 

Ambas as classes herdam da classe base (`ControllerBase`) do próprio framework .NET. Com isso, elas utilizam a estrutura sem haver alterações nos métodos base (como retornar NotFound, Ok, etc.), substituindo a classe pai perfeitamente sem quebrar o programa.


## I - Interface Segregation Principle

"Preferir várias interfaces específicas a uma genérica"

**Conceito:**
Interfaces devem ser executadas e conter somente o que é relevante para quem as implementa.

**Onde se encontra?**
Uso da interface `IMongoCollection<Dinossauro>` nos controllers: [`DinossauroController.cs`](./Controllers/DinossauroController.cs), [`ErasController.cs`](./Controllers/ErasController.cs).

Aqui é possível ver a utilização prática desse conceito: em vez de os nossos Controllers dependerem de uma interface gigante do MongoDB, eles dependem exclusivamente da interface segregada `IMongoCollection`. Essa interface entrega apenas o essencial (métodos de busca, inserção e deleção) focado em uma entidade específica (Dinossauro ou Era). Com isso, mesmo tendo a base dos métodos de banco trazidos pelo Mongo, podemos adicionar as nossas próprias lógicas e regras HTTP no Controller, seguindo a ideia de que cada entidade aplique sua própria regra baseada nessa interface genérica, sem ser forçada a depender de operações que não utiliza.

## D - Dependency Inversion Principle

"Dependa de abstrações, não de implementações concretas"

**Conceito:**
Ao invés de depender diretamente de uma classe (new), dependa de interfaces ou abstrações.

**Onde se encontra?**

Encontramos esse conceito no construtor dos nossos controllers ([`DinossauroController.cs`](./Controllers/DinossauroController.cs) e [`ErasController.cs`](./Controllers/ErasController.cs)), nas interfaces do Mongo e em conjunto com o arquivo [`Program.cs`](./Program.cs).

Em vez de os nossos Controllers criarem diretamente a conexão com o banco de dados instanciando um `new MongoDbService()`, eles apenas declaram em seus construtores que necessitam desse serviço para funcionar. O próprio container de Injeção de Dependência (DI) nativo do .NET se encarrega de injetar essa instância pronta. Além disso, as dependências de banco se dão por meio de abstrações (como a interface `IMongoCollection`). Como já justificamos no Princípio I (Segregação de Interfaces), a explicação se conecta aqui: dependemos dessa interface abstrata do Mongo para gerenciar os dados, e não de implementações concretas e engessadas, o que desacopla o nosso código por completo.