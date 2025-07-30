using APIEstudo.Application.Commands.Bancos;
using APIEstudo.Application.Commands.Bancos.Handlers;
using APIEstudo.Application.Commands.Logins;
using APIEstudo.Application.Commands.Logins.Handlers;
using APIEstudo.Application.Commands.Usuarios;
using APIEstudo.Application.Commands.Usuarios.Handlers;
using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Mappings;
using APIEstudo.Application.Queries.Bancos;
using APIEstudo.Application.Queries.Bancos.Handlers;
using APIEstudo.Application.Queries.Usuarios;
using APIEstudo.Application.Queries.Usuarios.Handlers;
using APIEstudo.Application.Responses;
using APIEstudo.Application.Responses.Bancos;
using APIEstudo.Application.Responses.Logins;
using APIEstudo.Application.Responses.Usuarios;
using APIEstudo.Domain.Interfaces.Bancos;
using APIEstudo.Domain.Interfaces.Logins;
using APIEstudo.Domain.Interfaces.Usuarios;
using APIEstudo.Infrastructure.AutenticationToken;
using APIEstudo.Infrastructure.Persistence;
using APIEstudo.Infrastructure.Repositories.Bancos;
using APIEstudo.Infrastructure.Repositories.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Estudo",
        Version = "v1"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT no campo: Bearer {seu_token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            Array.Empty<string>()
        }
    });
});

//Command Usuario
builder.Services.AddScoped<ICommandHandler<CreateUsuarioCommand, MensagemResponse>, CreateUsuarioHandler>();
builder.Services.AddScoped<ICommandHandler<UpdateUsuarioCommand, MensagemResponse>, UpdateUsuarioHandler>();
builder.Services.AddScoped<ICommandHandler<DeleteUsuarioCommand, MensagemResponse>, DeleteUsuarioHandler>();
//Query Usuario
builder.Services.AddScoped<IQueryHandler<GetUsuarioByIdQuery, GetUsuarioByIdResponse>, GetUsuarioByIdHandler>();
//Command Banco
builder.Services.AddScoped<ICommandHandler<CreateBancoCommand, MensagemResponse>, CreateBancoHandler>();
builder.Services.AddScoped<ICommandHandler<UpdateBancoCommand, MensagemResponse>, UpdateBancoHandler>();
builder.Services.AddScoped<ICommandHandler<DeleteBancoCommand, MensagemResponse>, DeleteBancoHandler>();

//Query Banco
builder.Services.AddScoped<IQueryHandler<GetAllBancoQuery, List<GetAllBancoResponse>>, GetAllBancoHandler>();
//Command Login
builder.Services.AddScoped<ICommandHandler<LoginCommand, LoginResponse>, LoginHandler>();

//Repositories
builder.Services.AddScoped<IUsuarioReadRepository, UsuarioReadRepository>();
builder.Services.AddScoped<IUsuarioWriteRepository, UsuarioWriteRepository>();
builder.Services.AddScoped<IBancoReadRepository, BancoReadRepository>();
builder.Services.AddScoped<IBancoWriteRepository, BancoWriteRepository>();

builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();

//builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 0)))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
