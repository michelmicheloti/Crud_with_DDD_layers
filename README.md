# Facens - Engenharia da Computação
---

O objetivo deste projeto é criar um projeto .net utilizando os conceitos de ***DDD (Domain Driven Design)*** é um conjunto de princípios com foco no domínio, exploração de modelos de forma criativa e definir e falar linguagem ubíqua, baseado no contexto delimitado.

Explicando, ***domínio*** é o coração do negócio em que estamos mexendo, baseado em um conjunto de ideias, conhecimento e processos do negócio, sendo possível comparar com as próprias Entites, onde possuem uma quantidade de regras que são essenciais a operação. 
Portanto, a ***Entidade do DDD*** e a ***Entidade do Clean Architecture*** estão na camada do ***Domínio/Entidade*** em ambas.

Já a camada de ***aplicação*** seria o ***Use Case do Clean Architecture***. De acordo com o Uncle Bob seriam as features principais da aplicação.
Já no DDD representaria a camada de comandos como criação, receber, atualizar, etc.

A linguagem ubíqua é a uma linguagem acordada e utilizada no dia a dia, para facilitar a comunicação da equipe e até mesmo com o cliente.

A camada de ***interface*** é a camada onde é feita a ***conversão de dados para a forma mais conveniente*** para envio ou armazenamento no banco de dados.

A camada de ***Frameworks/Drivers*** é a camada onde ocorre o envio das informações seja para web ou para o banco de dados.

___
### Detalhes do Projeto
Você deve ter instalado o ***__.net 6.0 SDK__***

##### _Passo 1_
Clone o Projeto
```sh
git clone https://github.com/michelmicheloti/Crud_with_DDD_layers.git
```

##### _Passo 2_
Uma boa prática quando você acaba de clonar um projeto é limpar os arquivos de cache e dependências.
```sh
dotnet clean
```

##### _Passo 3_
Baixe as dependências do projeto.
```sh
dotnet restore
```

##### _Passo 4_
Entre no diretório da Aplicação.
```sh
cd Application
```

##### _Passo 5_
Rode o projeto.
```sh
dotnet run
```

Se não aconteceu nenhum erro na hora da compilação, abra o navegador e pegar a url gerada e acrescentar /swagger para visualizar todas as requisições da API.
```sh
https://localhost:7122/swagger/
```


___

### _Instruções para os Testes_


##### _Passo 1_
Para criar o projeto de teste, crie com um nome similar ao que sera testado e acrescente .Tests
```sh
dotnet new xunit -o Project.Tests
```
##### _Passo 2_
Adicione o projeto de testes na solução do projeto
```sh
dotnet sln add ./Project.Tests
```

##### _Passo 3_
Adicione a referencia do projeto em seu projeto de teste
```sh
dotnet add ./Project.Tests/Project.Tests.csproj reference ./Project/Project.csproj
```

## Alunos - Desenvolvedores

Dillinger is currently extended with the following plugins.
Instructions on how to use them in your own application are linked below.

| RA     | Nome                | Github User                            |
| ------ | ------------------- | -------------------------------------- |
| 180057 | Alex Sander         | https://github.com/AllexFelicio        |
| 180016 | Fernando Dias Motta | https://github.com/fernando2dias       |
| 180831 | Guilherme Hoffman   | https://github.com/guilhermehoffmann27 |
| 180998 | Marcelo Zaguette    | https://github.com/m-zaguette          |
| 181003 | Michel Michelotti   | https://github.com/michelmicheloti     |
| 180184 | Vinicius Bonatti    | https://github.com/vbonatti            |

### Professora Andreia Leles
***__Disciplina: Engenharia de Software__***


