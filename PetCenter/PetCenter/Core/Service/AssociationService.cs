using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Core.Service
{
    public class AssociationService(IAssociationRepository associationRepository)
    {
        public bool Insert(Association post) => associationRepository.Insert(post);
        public bool Delete(Association post) => associationRepository.Delete(post);
        public Association? GetById(Guid id) => associationRepository.GetById(id);
        public List<Association> GetAll() => associationRepository.GetAll();
        public Association? GetFirst() => associationRepository.GetFirst();
    }
}
