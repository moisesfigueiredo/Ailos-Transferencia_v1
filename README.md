<img width="1339" height="226" alt="image" src="https://github.com/user-attachments/assets/b5346266-8e2c-4286-94ed-b90f9b475c94" /># Ailos - Transferência

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
<img width="1460" height="1065" alt="image" src="https://github.com/user-attachments/assets/92c2d924-b9a4-4e28-8908-b96e043f11bf" />

No banco de dados:
<img width="1272" height="234" alt="image" src="https://github.com/user-attachments/assets/ffb362ee-85a8-43cf-a32e-a76f7096f8ef" />


3 - Vá até o endpoint "/ContaCorrente/Logar" e informe os dados de acesso, conforme cadastrados no passo anterior. Você deverá receber o token JWT:
<img width="1590" height="923" alt="image" src="https://github.com/user-attachments/assets/4c4bc847-ef46-410a-a6f9-71bef0109fd8" />

4 - Vá até "Authorize" e se autentique na API, informando o token recebido no passo anterior:
<img width="1469" height="340" alt="image" src="https://github.com/user-attachments/assets/b0a5f415-e4a3-4b3e-a037-c0f68ae71037" />

5 - Guarde o token em algum editor de textos, pois ele será usado para se autenticar também na outra API (Transferência)

6 - Vá até o endpoint "/ContaCorrente/MovimentacaoContaCorrente" e crie um movimento, semelhante ao descrito:
<img width="1450" height="943" alt="image" src="https://github.com/user-attachments/assets/524260ae-222f-4b49-8c07-76167b3b699e" />

No banco de dados:
<img width="1198" height="213" alt="image" src="https://github.com/user-attachments/assets/b6b50c3b-a5f2-4f96-be37-08b863ed4bee" />

7 - Vá até o endpoint "/ContaCorrente/SaldoContaCorrente" e crie um consulte o saldo. O resultado será algo conforme abaixo:
<img width="1438" height="888" alt="image" src="https://github.com/user-attachments/assets/249ec2d7-15f4-4cd5-b41f-282ad6515a9b" />

8 - Vá até o endpoint "/ContaCorrente/CadastrarConta" e entre com os dados. Esta Conta Corrente será usada para receber transferências a partir da API de Transferência:
<img width="1455" height="1066" alt="image" src="https://github.com/user-attachments/assets/725f0953-5038-4745-b037-b9893475b71e" />

No banco de dados:
<img width="1354" height="210" alt="image" src="https://github.com/user-attachments/assets/b88b9228-fd77-427a-8a07-436aefe3649f" />

9 - Deste ponto em diante, você pode seguir para o repositório (https://github.com/moisesfigueiredo/Ailos-Transferencia_v1) e seguir as instruções para levantar a API de Transferência, que se comunica com esta API (Conta Corrente)





