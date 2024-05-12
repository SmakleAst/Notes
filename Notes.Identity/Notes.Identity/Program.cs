using IdentityServer4.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityServer()
    .AddInMemoryApiResources(new List<ApiResource>())
    .AddInMemoryIdentityResources(new List<IdentityResource>())
    .AddInMemoryApiScopes(new List<ApiScope>())
    .AddInMemoryClients(new List<Client>())
    .AddDeveloperSigningCredential();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseIdentityServer();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
