namespace MoviesGroup.Data.Context;

public class MoviesGroupContext(DbContextOptions<MoviesGroupContext> builder) : DbContext(builder)
{
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Filter> Filters => Set<Filter>();
    public DbSet<Actor> Actors => Set<Actor>();
    public DbSet<AgeLimit> AgeLimits => Set<AgeLimit>();
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<ReleaseYear> ReleaseYears => Set<ReleaseYear>();
    public DbSet<StreamingService> StreamingServices => Set<StreamingService>();
    public DbSet<GenreFilter> GenreFilters => Set<GenreFilter>();
    public DbSet<MovieGenre> MovieGenres => Set<MovieGenre>();
    public DbSet<MovieActor> MovieActors => Set<MovieActor>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Composite Keys
        builder.Entity<MovieActor>()
            .HasKey(ma => new { ma.MovieId, ma.ActorId });
        builder.Entity<MovieGenre>()
            .HasKey(mg => new { mg.MovieId, mg.GenreId });
        builder.Entity<GenreFilter>()
            .HasKey(gf => new { gf.GenreId, gf.FilterId });
        #endregion

        #region GenreFilter Many-to-Many Relationship

        builder.Entity<Genre>()
            .HasMany(g => g.Filters)
            .WithMany(f => f.Genres)
            .UsingEntity<GenreFilter>();
        #endregion

        #region MovieGenre Many-to-Many Relationship
        builder.Entity<Movie>()
            .HasMany(m => m.Genres)
            .WithMany(g => g.Movies)
            .UsingEntity<MovieGenre>();
        #endregion

        #region MovieActor Many-to-Many Relationship
        builder.Entity<Movie>()
            .HasMany(m => m.Actors)
            .WithMany(a => a.Movies)
            .UsingEntity<MovieActor>();
        #endregion
    }
}
