var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQL Server Service Registration
builder.Services.AddDbContext<MoviesGroupContext>(
    options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("MoviesGroupConnection")));

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsAllAccessPolicy", opt =>
        opt.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod());
});

RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

RegisterEndpoints();

app.UseCors("CorsAllAccessPolicy");

app.Run();

void RegisterEndpoints()
{
    app.AddEndpoint<Genre, GenrePostDTO, GenrePutDTO, GenreGetDTO>();
    //app.MapGet($"/api/categorieswithdata", async (IDbService db) =>
    //{
    //    try
    //    {
    //        return Results.Ok(await ((GenreDbService)db).GetGenresWithAllRelatedDataAsync());
    //    }
    //    catch
    //    {
    //    }

    //    return Results.BadRequest($"Couldn't get the requested products of type {typeof(Movie).Name}.");
    //});
}
void RegisterServices()
{
    ConfigureAutoMapper();
    builder.Services.AddScoped<IDbService, GenreDbService>();

}

void ConfigureAutoMapper()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Genre, GenrePostDTO>().ReverseMap();
        cfg.CreateMap<Genre, GenrePutDTO>().ReverseMap();
        cfg.CreateMap<Genre, GenreGetDTO>().ReverseMap();
        cfg.CreateMap<Genre, GenreSmallGetDTO>().ReverseMap();
        cfg.CreateMap<MovieGenre, MovieGenreDTO>().ReverseMap();

        //cfg.CreateMap<Filter, FilterGetDTO>().ReverseMap();
        //cfg.
    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}