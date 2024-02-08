using AutoMapper;

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
    //app.AddEndpoint<Genre, GenrePostDTO, GenrePutDTO, GenreGetDTO>(); Only in for testing purposes, not meant to be used here. Check API.Genre for the proper use.
    app.AddEndpoint<Movie, MoviePostDTO, MoviePutDTO, MovieGetDTO>();
    app.AddEndpoint<Actor, ActorPostDTO, ActorPutDTO, ActorGetDTO>();
    app.AddEndpoint<StreamingService, StreamingServicePostDTO, StreamingServicePutDTO, StreamingServiceGetDTO>();
    app.AddEndpoint<AgeLimit, AgeLimitPostDTO, AgeLimitPutDTO, AgeLimitGetDTO>();
    app.AddEndpoint<ReleaseYear, ReleaseYearPostDTO, ReleaseYearPutDTO, ReleaseYearGetDTO>();
    app.AddEndpoint<MovieActor, MovieActorPostDTO>();
    app.AddEndpoint<MovieGenre, MovieGenrePostDTO>();
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

void ConfigureAutoMapper()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Genre, GenrePostDTO>().ReverseMap();
        cfg.CreateMap<Genre, GenrePutDTO>().ReverseMap();
        cfg.CreateMap<Genre, GenreGetDTO>().ReverseMap();
        cfg.CreateMap<Genre, GenreSmallGetDTO>().ReverseMap();
        cfg.CreateMap<Movie, MoviePostDTO>().ReverseMap();
        cfg.CreateMap<Movie, MoviePutDTO>().ReverseMap();
        cfg.CreateMap<Movie, MovieGetDTO>().ReverseMap();
        cfg.CreateMap<Actor, ActorPostDTO>().ReverseMap();
        cfg.CreateMap<Actor, ActorPutDTO>().ReverseMap();
        cfg.CreateMap<Actor, ActorGetDTO>().ReverseMap();
        cfg.CreateMap<StreamingService, StreamingServicePostDTO>().ReverseMap();
        cfg.CreateMap<StreamingService, StreamingServicePutDTO>().ReverseMap();
        cfg.CreateMap<StreamingService, StreamingServiceGetDTO>().ReverseMap();
        cfg.CreateMap<AgeLimit, AgeLimitPostDTO>().ReverseMap();
        cfg.CreateMap<AgeLimit, AgeLimitPutDTO>().ReverseMap();
        cfg.CreateMap<AgeLimit, AgeLimitGetDTO>().ReverseMap();
        cfg.CreateMap<ReleaseYear, ReleaseYearPostDTO>().ReverseMap();
        cfg.CreateMap<ReleaseYear, ReleaseYearPutDTO>().ReverseMap();
        cfg.CreateMap<ReleaseYear, ReleaseYearGetDTO>().ReverseMap();
        cfg.CreateMap<MovieActor, MovieActorPostDTO>().ReverseMap();
        cfg.CreateMap<MovieActor, MovieActorDeleteDTO>().ReverseMap();
        cfg.CreateMap<MovieGenre, MovieGenrePostDTO>().ReverseMap();
        //cfg.CreateMap<MovieGenre, MovieGenreDeleteDTO>().ReverseMap();


        //cfg.CreateMap<Filter, FilterGetDTO>().ReverseMap();
        //cfg.
    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}

void RegisterServices()
{
    ConfigureAutoMapper();
    builder.Services.AddScoped<IDbService, MovieDbService>();

}


