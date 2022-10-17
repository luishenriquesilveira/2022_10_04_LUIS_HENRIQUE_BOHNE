# README

0. Instalação:
Visual Studio
.NET SDK 6.0
SQL Server

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





# DESCRIPTION

Your client wants to have a webpage (rate_my_animal.com) that shows random animals
and wants their users to categorize the animals.
Requirements:
• A user must be able to add new categories to the application.
• A user must be able to request a new image to be categorized.
• A user must be able to save the categorization done.
• A user must be able to see all the images previously categorized and their
categorization.
• A user must be able to see all the images previously categorized with a specific
category (filter by).
• A user must be able to edit a categorization from a previous image.
• The system must be able to randomly get the images from the following sources
o https://cataas.com/ (example: https://cataas.com/cat)
o https://place.dog/ (example: https://place.dog/300/200)
o http://shibe.online/ (example: http://shibe.online/api/shibes)
• All data must be persistent between server restarts.

Challenge information:
• Assume that the 3rd party endpoints will return a different image every time.
• Deliver the code with production quality.
