using Microsoft.EntityFrameworkCore;
using NSwag.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CDNUserDb>(opt => 
    opt.UseMySQL("server=localhost;user=myuser;password=mypass;database=crud"));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "CDNWebAPI";
    config.Title = "CDNWebAPI v1";
    config.Version = "v1";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "CDNWebAPI";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

var cdnuserItems = app.MapGroup("/cdnusers");

cdnuserItems.MapGet("/", GetAllUser);
cdnuserItems.MapGet("/{id}", GetUser); 
cdnuserItems.MapPost("/", CreateUser);
cdnuserItems.MapPut("/{id}", UpdateUser);
cdnuserItems.MapDelete("/{id}", DeleteUser);

app.UseDefaultFiles();
app.UseStaticFiles();
app.Run();

static async Task<IResult> GetAllUser(CDNUserDb db)
 { 
    return TypedResults.Ok(await db.CDNUsers.Select(x => new CDNUserDTO(x)).ToArrayAsync());
 }   

static async Task<IResult> GetUser(int id, CDNUserDb db) 
 {   
    return await db.CDNUsers.FindAsync(id)
        is CDNUser cdnuser
            ? TypedResults.Ok(new CDNUserDTO(cdnuser))
            : TypedResults.NotFound();
 }

static async Task<IResult> CreateUser(CDNUserDTO cdnuserDTO, CDNUserDb db)
{
    var cdnuser = new CDNUser
    {
        Username = cdnuserDTO.Username,
        Email = cdnuserDTO.Email,
        Phone = cdnuserDTO.Phone,
        Skill = cdnuserDTO.Skill,
        Hobby = cdnuserDTO.Hobby
    };
    
    db.CDNUsers.Add(cdnuser);
    await db.SaveChangesAsync();

    return TypedResults.Created($"/cdnusers/{cdnuser.Id}", cdnuserDTO);
}

static async Task<IResult> UpdateUser(int id, CDNUserDTO cdnuserDTO, CDNUserDb db) 
{
    var cdnuser = await db.CDNUsers.FindAsync(id);

    if (cdnuser is null) return Results.NotFound();

    cdnuser.Username = cdnuserDTO.Username;
    cdnuser.Email = cdnuserDTO.Email;
    cdnuser.Phone = cdnuserDTO.Phone;
    cdnuser.Skill = cdnuserDTO.Skill;
    cdnuser.Hobby = cdnuserDTO.Hobby;

    await db.SaveChangesAsync();

    return TypedResults.NoContent();
};

static async Task<IResult> DeleteUser(int id, CDNUserDb db)
{
    if (await db.CDNUsers.FindAsync(id) is CDNUser cdnuser)
    {
        db.CDNUsers.Remove(cdnuser);
        await db.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    return TypedResults.NotFound();
};


