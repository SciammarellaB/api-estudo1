# Api Estudo 1

<h2 align="start">(PT-BR)</h2>

* Sobre :

  - Desenvolvida no intuito de estudo de criação de API:
    * Postgress SQL como banco de dados.
    * OdataQuery para filtro de busca.
    * Swagger para documentação (EM BREVE)

  - ADICIONAR COMO FUNCIONA A API

- Como configurar:
  * Você deverá possuir o PostGress SQL instalado em sua máquina. Para mudar a senha ,usuário, host e porta de acesso ao banco basta ir para o arquivo "appsettings.json" dentro da pasta "ApiEstudo" e mudar os valores de "Principal" para os que você utiliza normalmente.
  * Feito a mudança na conexção com o banco, basta apertar em "Rodar" que automaticamente será criado a "Database".

- Como utilizar:
  * **USUÁRIO**
    * Para inicio, é necessário cadastrar um usuário por meio de um "POST" para o Endpoint de Usuário (Apenas esse endpoint permite comandos enquanto a sessão não estiver autenticada):
      * "http://localhost:5000/api/usuario"
        ```
        {
          "login": "123@teste.com.br",
          "senha": "123@mudar",
          "nome": "Teste"
        }
        ```

    * Feito o cadastro, basta fazer Login dando um "POST" para o Endpoint de Autenticação:
      * "http://localhost:5000/api/autenticador/usuario"
        ```
        {
          "login": "123@teste.com.br",
          "senha": "123@mudar"
        }
        ```

    * Com o usuário criado, é possível Listar todos os usuários dando um "GET":
      * "http://localhost:5000/api/usuario"
      * **NOTA:** A API possui um filtro global que permite o usuário apenas enchergar ele mesmo e/ou coisas referente à ele por conta de segurança. Mesmo tendo cadastrado diversos usuários, você só poderá enchergar registros referentes ao que está logado ao sistema.

    * Para alterções de informação do usuário, basta utilizar o "PATCH":
      * "http://localhost:5000/api/usuario/1"
        * **NOTA**: É necessário informar o ID do usuário sendo alterado => "usuario/1 ; usuario/2"
      ```
      [
        { "op": "replace", "path": "/nome", "value":"Trocando o nome do usuário"}
      ]
      ```
    * Para deletar o usuário basta utilizar o "DELETE" passando o id do usuário que deseja deletar:
      * "http://localhost:5000/api/usuario/1" 
    * Para alterar a senha do usuário basta mandar um "POST" para: (EM BREVE)
      * "http://localhost:5000/api/usuario/alterarSenha"
  * **CASA**
    * Para criar uma casa, basta dar um "POST":
      * "http://localhost:5000/api/casa"
      ```
      {
        "usuarioId": 1,
	      "nome": "Minha Casa 1",
	      "adminId": 1,
        "usuarioCasas":[
          {
            "usuarioId": 1
          }
        ]
      }
      ```
      * **NOTA** : "usuarioCasas" cria a relação de muito para muito entre Usuário e Casa basta passar em "usuarioId" o ID do usuário que estamos autenticados.
    
    * Podemos listar todas as casas em que estamos registrados mandando um "GET" para o endpoit:
      * "http://localhost:5000/api/casa"
      * **NOTA:** Lembrando que como existe um filtro global, apenas as casas em que o usuário autenticado estiver inserido aparecerão.

    * Para alterções de informação da casa, basta utilizar o "PATCH":
      * "http://localhost:5000/api/casa/1"
        * **NOTA**: É necessário informar o ID da casa sendo alterado => "casa/1 ; casa/2"
      ```
      [
        { "op": "replace", "path": "/nome", "value":"Trocando o nome da casa"}
      ]
      ```
    * Para deletar a casa basta utilizar o "DELETE" passando o id da casa que deseja deletar:
      * "http://localhost:5000/api/casa/1"
    