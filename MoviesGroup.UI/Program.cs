var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<UIService>();
builder.Services.AddBlazoredLocalStorageAsSingleton();
//builder.Services.AddBlazoredSessionStorageAsSingleton();
builder.Services.AddSingleton<IStorageService, LocalStorage>();
builder.Services.AddHttpClient<GenreHttpClient>();
builder.Services.AddHttpClient<MovieHttpClient>();

ConfigureAutoMapper();

await builder.Build().RunAsync();

void ConfigureAutoMapper()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<GenreGetDTO, LinkOption>().ReverseMap();
        cfg.CreateMap<MovieGetDTO, CartItemDTO>().ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors)).ReverseMap();
    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}
