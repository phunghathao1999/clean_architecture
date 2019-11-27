using ApplicationCore.EF;

namespace ApplicationCore.Specifications
{
    public class MovieSpecification : Specification<Movie>
    {
        public MovieSpecification(int pageIndex, int pageSize)
            : base(m => true)
        {
            ApplyPaging(pageIndex, pageSize);
        }
    }
}
