# README

1. Abrir Package Manager Console no VS;
2. Selecionar Default Project: 'RateMyAnimal.Infrastructure';
3. Executar comando: 'Update-database' [Migrations já estão no projeto para facilitar];
4. Selecionar como projeto inicial: 'RateMyAnimal.Api' ou 'RateMyAnimal.Application';
5. Rodar o projeto;

RateMyAnimal.Api [unloaded]: Primeira versão do challenge, possui endpoints no swagger [descartado para evolução devido a tempo];
RateMyAnimal.Application: Versão WebApp, feita com ASP.NET MVC;


Importar Collection no Postman: https://documenter.getpostman.com/view/17189346/2s83zcRS5w
1. Abrir o link da documentação;
2. Clickar no botão 'Run in Postman' no canto superior direito;


# CONSIDERAÇÕES

Deixei de fora algumas coisas que gostaria de implementar nesta solução devido a demandas em outros projetos.
Escolhi desenvolver um WebApp para o desafio e com isso tive que voltar em algumas decisões em função do tempo.
Podemos entrar em detalhes sobre as decisões que deixei de fora em um próximo momento.

Um ponto que gostaria de ter entregue era a parte dos testes.
Desenvolvi uma solução pouco tempo atrás com a mesma arquitetura, na parte do front utilizei react (primeira vez).
Se possível avaliar, já vou deixar o acesso liberado para este outro repositório, onde implemento vários cenários de testes (unidade, serviço e integração).

https://github.com/luishenriquesilveira/2022_09_POSTCODE_CHALLENGE
