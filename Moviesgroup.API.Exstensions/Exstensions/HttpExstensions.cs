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
        app.MapGet($"/api/{node}s/" + "{id}", HttpSingleAsync<TEntity, TGetDTO>);
        app.MapGet($"/api/{node}s", HttpGetAsync<TEntity, TGetDTO>);
        app.MapGet($"/api/{node}s", HttpPostAsync<TEntity, TPostDto>);
        app.MapGet($"/api/{node}s" + "{id}", HttpPutAsync<TEntity, TPutDto>);
        app.MapDelete($"/api/{node}s" + "{id}", HttpDeleteAsync<TEntity>); // DOES NOT USE DTO, REMEMBER.
    }

    public static async Task<IResult> HttpGetAsync<TEntity, TDto>(this IDbService db)
        where TEntity : class where TDto : class =>
        Results.Ok(await db.GetAsync<TEntity, TDto>());

    public static async Task<IResult> HttpSingleAsync<TEntity, TDto>(this IDbService db, int id)
    where TEntity : class, IEntity where TDto : class
    {
        try
        { var entity = await db.GetSingleAsync<TEntity, TDto>(id);

            if (entity == null)
            {
                return Results.NotFound($"Entity with ID {id} not found");
            }
            return Results.Ok(entity);
        }

        catch (Exception ex)
        {
            return Results.StatusCode(StatusCodes.Status404NotFound);
        }
    }

    public static async Task<IResult> HttpPostAsync<TEntity, TPostDto>(this IDbService db, TPostDto dto)
        where TEntity : class, IEntity where TPostDto : class
    { 
        try
        {
            var entity = await db.AddAsync<TEntity, TPostDto>(dto);
            if (await db.SaveChangesAsync())
            {
                var node = typeof(IEntity).Name.ToLower();
                return Results.Created($"/{node}s/{entity.Id}", entity);
            }
        }
        catch
        {
        }
        return Results.BadRequest($"Couldn't add the {typeof(TEntity).Name} entity.");
    }


    public static async Task<IResult> HttpPutAsync<TEntity, TPutDto>(this IDbService db, TPutDto dto)
    where TEntity : class, IEntity where TPutDto : class
    {
        try
        {
            db.Update<TEntity, TPutDto>(dto);
            if (await db.SaveChangesAsync()) return Results.NoContent();
        }
        catch
        {
        }

        return Results.BadRequest($"Couldn't update the {typeof(TEntity).Name} entity.");
    }


    public static async Task<IResult> HttpDeleteAsync<TEntity>(this IDbService db, int id)
    where TEntity : class, IEntity
    {
        try
        {
            if (!await db.DeleteAsync<TEntity>(id)) return Results.NotFound();

            if (await db.SaveChangesAsync()) return Results.NoContent();
        }
        catch
        {
        }

        return Results.BadRequest($"Couldn't delete the {typeof(TEntity).Name} entity.");
    }

}




