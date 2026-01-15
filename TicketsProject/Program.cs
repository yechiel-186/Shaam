using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<TicketService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");

app.MapGet("/tickets", (TicketService service) =>
{
    return Results.Ok(service.GetAllTickets());
})
.WithName("GetTickets");

app.MapPost("/tickets", (TicketService service, [FromBody] CreateTicketRequest request) =>
{
    if (string.IsNullOrWhiteSpace(request.Subject))
    {
        return Results.BadRequest(new { error = "Subject is required" });
    }

    if (string.IsNullOrWhiteSpace(request.Description))
    {
        return Results.BadRequest(new { error = "Description is required" });
    }

    if (request.UserId <= 0)
    {
        return Results.BadRequest(new { error = "Valid UserId is required" });
    }

    var ticket = service.CreateTicket(request.UserId, request.Subject, request.Description);
    return Results.Created($"/tickets/{ticket.Id}", ticket);
})
.WithName("CreateTicket");

app.MapPut("/tickets/{id}/close", (TicketService service, int id, [FromBody] CloseTicketRequest request) =>
{
    var ticket = service.CloseTicket(id, request.IsClosed);

    if (ticket == null)
    {
        return Results.NotFound(new { error = $"Ticket {id} not found" });
    }

    return Results.Ok(ticket);
})
.WithName("CloseTicket");

app.Run();

public record CreateTicketRequest(int UserId, string Subject, string Description);

public record CloseTicketRequest(bool IsClosed);
