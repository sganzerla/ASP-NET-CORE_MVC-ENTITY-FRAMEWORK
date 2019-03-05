<h3>Originalmente de ASP.NET Core: Aprendendo do zero ao avançado (v 1.1 e 2.0) de <br>
Stephany Henrique de Almeida Batista</h3>
<p>
Necessário ter instalado:
</p>
<ul>
  <li>
    .Net Core SDK 2.2 https://dotnet.microsoft.com/download/dotnet-core/2.2
  </li>  
  <li>
    MS SQL Server https://www.microsoft.com/pt-br/sql-server/sql-server-downloads
  </li>
  <li>
    Visual Studio Code https://code.visualstudio.com/ ou  Visual Studio https://visualstudio.microsoft.com/pt-br/
  </li>
 </ul>
<p>
Comandos pelo terminal
</p><p>
Criando Solução <br>
"dotnet new sln"
</p><p>
Criando projeto MVC <br>
"dotnet new mvc -o MVC"
</p><p>
Adicionando projeto a solução <br>
"dotnet sln add .\MVC\MVC.csproj"
</p><p>
Criando projeto com biblioteca de classes p/ domínio<br>
"dotnet new classlib -o Dominio"
</p><p>
Adicionando projeto a solução <br>
"dotnet sln add .\Dominio\Dominio.csproj"
</p><p>
Criando projeto de biblioteca de classes p/ dados<br>
"dotnet new classlib -o Dados"
</p><p>
Adicionando projeto a solução <br>
"dotnet sln add .\Dados\Dados.csproj"
</p><p>
Build da solução<br>
"dotnet build"
</p><p>
Adicionando dependências dentro projeto Dados<br>
"cd .\Dados\"
</p><p>
  EntityFramework Core ("cd .\Dados\")<br>
  "dotnet add package Microsoft.EntityFrameworkCore"
</p><p>
  Driver do SQLSERVER ("cd .\Dados\")<br>
  "dotnet add package Microsoft.EntityFrameworkCore.SqlServer"
</p><p>
  Tools Ferramenta p/ Migrations ("cd .\Dados\")<br>
  "dotnet add package Microsoft.EntityFrameworkCore.Tools"
  </p><p>
  Adicionando referência do projeto Domínio dentro do projeto Dados ("cd .\Dados\")<br>
  "dotnet add reference ..\Dominio\Dominio.csproj"
  </p><p>
Adicionando dependências dentro do projeto MVC<br>
"cd .\Mvc\"
</p><p>
  Adicionando referência do projeto Dados dentro do projeto Mvc ("cd .\Mvc\")<br>
  "dotnet add reference ..\Dados\Dados.csproj"
  </p><p>
Criando migration dentro Projeto Dados ("cd .\Dados\")<br>
Entidade Categoria
"dotnet ef --startup-project ..\Mvc\Mvc.csproj migrations add AdicionandoCategoria"
</p><p>
Atualizando Migrations ("cd .\Dados\")<br>
"dotnet ef --startup-project ..\Mvc\Mvc.csproj database update"
</p><p>
Entidade Produtos<br>
"dotnet ef --startup-project ..\Mvc\Mvc.csproj migrations add AdicionandoProduto"
</p><p>
Atualizando Migrations ("cd .\Dados\")<br>
"dotnet ef --startup-project ..\Mvc\Mvc.csproj database update"
</p><p>
Adicionando referência do projeto Domínio dentro do projeto Mvc ("cd .\Mvc\") <br>
"dotnet add reference ..\Dominio\Dominio.csproj"
</p><p>
Adicionando biblioteca auxiliar de ORM LazyLoadingProxies ("cd .\Dados\") <br>
"dotnet add package Microsoft.EntityFrameworkCore.Proxies"
</p>
