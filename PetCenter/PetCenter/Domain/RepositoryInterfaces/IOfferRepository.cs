using PetCenter.Domain.Model;
using PetCenter.Repository;

namespace PetCenter.Domain.RepositoryInterfaces
{
    public interface IOfferRepository : ICrud<Offer>
    {
        List<Offer> GetAllIncluded();
    }
}
