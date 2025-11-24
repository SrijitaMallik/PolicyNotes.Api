using Microsoft.EntityFrameworkCore;
using PolicyNotes.Api.Data;
using PolicyNotes.Api.Repositories;
using PolicyNotes.Api.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<NotesDbContext>(options =>
    options.UseInMemoryDatabase("DevDb"));

builder.Services.AddScoped<IPolicyNoteRepository, PolicyNoteRepository>();
builder.Services.AddScoped<IPolicyNoteService, PolicyNoteService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

public partial class Program { }
