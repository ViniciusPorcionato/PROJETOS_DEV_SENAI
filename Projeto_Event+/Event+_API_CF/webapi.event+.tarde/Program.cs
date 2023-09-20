using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Adiciona serviço de autenticação JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

//Define os parametros de validação do token
.AddJwtBearer("JwtBearer", options =>
{

    options.TokenValidationParameters = new TokenValidationParameters
    {
        //Valida quem esta solicitando
        ValidateIssuer = true,

        //Valida quem esta recebendo
        ValidateAudience = true,

        //Define se o tempo de expiração do token sera validado
        ValidateLifetime = true,

        //Forma de criptografia e ainda validação da chave de autenticação
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("event-chave-autenticacao-webapi-dev")),

        //Valida o tempo de expiração do token
        ClockSkew = TimeSpan.FromMinutes(10),

        //De onde esta vindo (issuer)
        ValidIssuer = "webapi.event_.tarde",

        //Para onde está indo (audience)
        ValidAudience = "webapi.event_.tarde"
    };
});

//Adicione o gerador do Swagger à coleção de serviços
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Event Plus",
        Description = "API para gerenciamento de eventos - Backend API ",
        Contact = new OpenApiContact
        {
            Name = "Vinicius Porcionato",
            Url = new Uri("https://github.com/ViniciusPorcionato")
        },
    });

    //Configure o Swagger para usar o arquivo XML
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    //Usando a autenticação de segurança no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {

        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT"

    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }

            },
            new string[] {}
        }
    });

});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Para atender à interface do usuário do Swagger na raiz do aplicativo 
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
