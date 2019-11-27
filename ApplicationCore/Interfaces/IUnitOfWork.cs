
namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWork
    {
        IMovieRepository Movies { get; }
        IPeopleRepository People { get; }
        int Complete();
    }
}