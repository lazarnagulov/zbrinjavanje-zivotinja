using PetCenter.Core.Stores;
using PetCenter.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.Domain.Enumerations;
using PetCenter.Repository;
using PetCenter.Domain.State;

namespace PetCenter.Core.Service
{
    public class OfferService(IOfferRepository offerRepository, AuthenticationStore authenticationStore, PostService postService)
    {
        public bool Insert(Offer offer) => offerRepository.Insert(offer);
        public bool Delete(Offer offer) => offerRepository.Delete(offer);
        public Offer? GetById(Guid id) => offerRepository.GetById(id);
        public List<Offer> GetAll() => offerRepository.GetAll();

        public bool UpdateOfferStatus(Guid offerId, Status newStatus)
        {
            var offerToUpdate = GetById(offerId);
            if (offerToUpdate != null)
            {
                offerToUpdate.Status = newStatus;

                return offerRepository.Update(offerToUpdate);
            }
            return false;
        }

        public List<Offer> GetAllIncluded() => offerRepository.GetAllIncluded();

        public List<Offer> GetAllOnHold()
            => offerRepository.GetAllIncluded().Where(o => o.Status == Status.OnHold).Where(o => postService.GetPostByOffer(o.Id)?.State is Accepted).ToList();
    }
}
