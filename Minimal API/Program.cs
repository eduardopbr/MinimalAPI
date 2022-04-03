using Microsoft.EntityFrameworkCore;
using Minimal_API.Contexto;
using Minimal_API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Contexto>
    (options => options.UseSqlServer("Server=tcp:apipratica.database.windows.net,1433;Initial Catalog=MinimalApi;Persist Security Info=False;User ID=eduardo@apipratica;Password=Edu32259570;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.MapPost("Adicionar Produto", async (Produto produto, Contexto contexto) =>
{
    contexto.Produtos.Add(produto);
    await contexto.SaveChangesAsync();
});
app.MapPost("Excluir Produto/{id}", async (int id, Contexto contexto) =>
{
    var produtoExcluir = await contexto.Produtos.FirstOrDefaultAsync(p => p.Id == id);
    if(produtoExcluir != null)
    {
        contexto.Produtos.Remove(produtoExcluir);
        await contexto.SaveChangesAsync();
    }
}
    );

app.MapPost("Listar Produtos", async (Contexto contexto) =>
{
    return await contexto.Produtos.ToListAsync();   
});

app.MapPost("Obter Produto/{id}", async (int id, Contexto contexto) =>
{
    return await contexto.Produtos.FirstOrDefaultAsync(p => p.Id == id);

}
    );

app.UseSwaggerUI();
app.Run();
