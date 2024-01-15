using System;
using Microsoft.EntityFrameworkCore.Internal;
using System.Runtime.CompilerServices;
using System.Security.Principal;


namespace MoviesGroup.API.Extensions;

public static class HttpExtensions
{
    public static void AddEndpoint<TEntity, TPostDto, TPutDto, TGetDTO>(this WebApplication app)
    where TEntity : class, IEntity where TPostDto : class where TPutDto : class where TGetDTO : class
    {
        var node = typeof(TEntity).Name.ToLower();
        //app.MapGet($"/api/{node}s/" + "{id}", HttpSingleAsync < TEntity, TGetDTO);
        app.MapGet($"/api/{node}s", HttpGetAsync<TEntity, TGetDTO>);
        //app.MapGet($"/api/{node}s", HttpPostAsync<TEntity, TPostDto>);
        //app.MapGet($"/api/{node}s", + "{id}", HttpPutAsync<TEntity, TPutDto>);
        //app.MapDelete($"/api/{node}s" + "{id}", HttpDeleteAsync<TEntity>);
    }

    public static async Task<IResult> HttpGetAsync<TEntity, TDto>(/*this IDbService db*/)
        where TEntity : class where TDto : class =>
        Results.Ok(/*await db.GetAsync<TEntity, TDto>()*/);
}