Repositório que contem o teste para etapa do processo seletivo para empresa Genesis Consulting

Pre-Requisítos

.NET Core 8.0
.Node 20.14.0
Angular Cli 18.0

1.Instale o .net core 8.0 que pode ser encontrado neste link. https://dotnet.microsoft.com/pt-br/download
   1.1. Para verificar se o .NET foi corretamente instalado use o comando dotnet --version

2.Instale o nodeJS 24.14.0 que pode ser encontrado neste link https://nodejs.org/en
   2.1. Para Verificar se o node foi corretamente instalado use o comando node --version

3.Após o node instalado, agora é a hora de instalar o angular cli use o coando no console
  npm install -g @angular/cli
  este comando deverá instalar a versão 18.0 que é versão usada neste projeto.

4.No IDE Visual studio clicar com botão direito na solution no solution Explorer, selecionar o menu de contexto 'Configure Startup Projects...' 

5.Na janela que se abrir selecione 'common properties -> Startup Project' na parte direita da janela, marque o radio button para 'multiple startup project', marque os projetos TesteB3App.Server e testeb3app.client para start. 
Em seguida o projeto pode ser executado clicando no botão start do IDE visual studio.

OBS: Caso ocorra algum erro de compilação no projeto angular, basta apenas executar o commando npm install na pasta do projeto angular. Executando no visual studio não é necessário fazer isso,
Pois o mesmo executa quando clica no botão start no IDE, Isso só é necessário se for usar Visual studio code.

Segue um link com video mostrando como realizar esta configuração.

https://drive.google.com/file/d/1BNayEJO8R5C8eheHLlmHFZ-I8rNNGi1g/view?usp=drive_link 
