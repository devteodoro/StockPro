using StockPro.Data;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddControllers()//Serve para dizer a aplicação que serão usadas contorllers
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;//inibi a validação automatica do ModelState do ASP.NET, a partir disso o asp.net não vai mais validar os objetos automaticamente
    });//Configurar o comportamento da api


builder.Services.AddDbContext<StockProDataContext>();//Deixar o datacontext disponivel para todos as controllers


var app = builder.Build();
app.MapControllers();
app.Run();
