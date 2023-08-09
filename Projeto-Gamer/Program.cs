//  Instalar os pacotes necessários para conectarmos o projeto ao banco de dados
// dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 7.0.6
// dotnet add package Microsoft.EntityFrameworkCore --version 8.0.0-preview.1.23111.4
// dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.0-preview.1.23111.4 
// dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.0-preview.1.23111.4  

// LINHA DE PROCESSOS
// 1 - rodar dotnet new mvc
// 2 - rodar dotnet run para verificar se tudo está funcionando
// 3 - Codar os models
// 4 - Baixar os pacotes (comandos no classroom)
// 5 - Se o Entity Framework não estiver instalado, executar o comando "dotnet tool install --global dotnet-ef"
// 6 - Executar o comando "dotnet ef migrations add InitialCreate"
// 7 - Executar o comando "dotnet ef database update"

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// configurando o estado da sessão (session service)
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    // tempo de duração da sessão
    options.IdleTimeout = TimeSpan.FromHours(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
