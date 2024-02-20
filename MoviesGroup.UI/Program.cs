using AutoMapper;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MoviesGroup.UI;
using MoviesGroup.UI.Services;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using MoviesGroup.UI.Storage.Services;

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
    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}
