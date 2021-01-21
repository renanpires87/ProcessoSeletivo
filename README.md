# Processo Seletivo

Projeto feito para **processo seletivo - teste prático**

## Projeto Back-end

Acesse a solução do projeto pelo **Visual Studio**. Clique com o botão direito do mouse na solução e clique em **Restore Nuget Packages**. Isso fará com que todas as dependências sejam instaladas.

No **Package Manager Console** rode os seguintes comandos:

**Update-Database -Context MeuDbContext**
**Update-Database -Context ApplicationDbContext**

Isso criará o **bando de dados** e preencherá a **Tabela Banco** com todos os bancos citados na lista do **Febraban**

Aplicação estará pronta para iniciar.

## Projeto Front-end

Acesse o projeto pelo **VS Code**. Na pasta do projeto rode o seguinte comando: **npm install**. Isso fará com que as dependências sejam instaladas.
Para rodar o projeto rode o seguinte comando: **ng serve -o**. Lembre-se de estar com o projeto back-end rodando.

## Dependências

Certifique-se de ter instalado em sua máquina as seguintes aplicações:
SQL LocalDB - Com uma instância **mssqllocaldb**.
NodeJs 14+
Angular 9+
SDK .Core 3.1

## USO
Para usar a aplicação. Registre um usuário no botão que se encontra do lado direito superior.
Examplo de registro de usuário:
**usuario: teste@teste.com.br**
**senha: Teste@123**

Após o registro será redirecionado para tela Home já Logado.

No Menu superior clique em Contas Bancárias. Lá você poderá adicionar, editar e excluir uma nova conta.
Somente em modo edição é possível Ativar ou Inativar uma conta.
