Teste Prático

<br />

## Microserviço - Transferência
Microserviço de Transferência é usado para efetuar as seguintes operações, em conjunto com a API de Conta Corrente:

<img width="1913" height="583" alt="image" src="https://github.com/user-attachments/assets/e82f54a3-f981-40a5-b246-2d2f0019abe3" />


## Visão Geral do Projeto
Conforme pode ser verificado abaixo, a API foi desenvolvida utilizando Clean Code e boas práticas. Para mais detalhe, verificar a implementação.

<img width="500" height="865" alt="image" src="https://github.com/user-attachments/assets/72f5a83e-67ad-49f5-b9ba-abd32d801061" />


## Arquivo docker-compose
A aplicação é multicontainer e levanta 2 aplicações: A API de Transferência e um banco de dados Postgres, com o qual a API se comunica:

<img width="858" height="737" alt="image" src="https://github.com/user-attachments/assets/9651ef72-f630-44b1-9ca9-c741b2066649" />


<br />

## Pré-Requisitos

Antes de executar este projeto, os seguintes itens deverão estar instalados no computador:

* Estar com o projeto da API levantado com docker-compose, conforme descrito no https://github.com/moisesfigueiredo/Ailos-ContaCorrente_v1
* Docker instalado no computador onde será executado
* Para fins de praticidade, recomendo utilizar o Visual Studio, 2022 por exemplo, para a execução do projeto

<br />

Passo a passo - Execução:

* Baixe o projeto para seu computador
* Para fins de praticidade, recomendo utilizar o Visual Studio para a execução
* Efetue Clean e em seguida rebuild do Projeto, antes de executar:
  <img width="320" height="337" alt="image" src="https://github.com/user-attachments/assets/3c045157-efd6-44f3-9d19-ced80cc816f1" />


* Defina o arquivo docker-compose como Startup Projetc:
  <img width="404" height="454" alt="image" src="https://github.com/user-attachments/assets/1ec6910a-0c19-4b43-a494-374a2fe416d2" />


* Clique no botão:
  <img width="933" height="80" alt="image" src="https://github.com/user-attachments/assets/207c07af-e272-45b0-84b3-3260c2c4675f" />

* Após alguns segundos, você deverá ver uma tela como esta:
  <img width="1913" height="583" alt="image" src="https://github.com/user-attachments/assets/e82f54a3-f981-40a5-b246-2d2f0019abe3" />
  
<br />

## Testando a API

1 - o primeiro passo é se autenticar na API de Transferência; para assim ter um login e poder se autenticar na API. Utilize o token obtido no passo de Login da API de Conta Corrente:
<img width="1499" height="402" alt="image" src="https://github.com/user-attachments/assets/c7d4a736-88eb-4d66-b1f1-b8a0e6c7c42c" />


2 - Vá até o endpoint "/api/Transferencia/TrasnfereEntreContasMesmaInstituicao" e efetue uma transferência, com base nos dados de Conta Corrente cadastrados anteriormente. A transferência será efetuada tendo como conta de origem o usuário logado, no caso o "Testador AP"

No banco de dados:
<img width="1339" height="226" alt="image" src="https://github.com/user-attachments/assets/aaada3e9-d217-43ab-bb35-b6ebf19b1a92" />

Na API
<img width="1465" height="936" alt="image" src="https://github.com/user-attachments/assets/2ffaaa25-8a61-4eb0-9622-e97f3bf03562" />

No banco de dados:
<img width="1226" height="152" alt="image" src="https://github.com/user-attachments/assets/b56c85b6-3486-42cc-b764-560ef6cffd8d" />





