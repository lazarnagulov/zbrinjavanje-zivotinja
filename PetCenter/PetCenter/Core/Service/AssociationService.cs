using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Core.Service
{
    public class AssociationService(IAssociationRepository associationRepository)
    {
        public bool Insert(Association association) => associationRepository.Insert(association);
        public bool Delete(Association association) => associationRepository.Delete(association);
        public Association? GetById(Guid id) => associationRepository.GetById(id);
        public List<Association> GetAll() => associationRepository.GetAll();
        public bool Update(Association association) => associationRepository.Update(association);
        public Association? GetFirst() => associationRepository.GetFirst();

        public bool UpdateById(Guid id, Association newAssociation)
        {
            var association = GetById(id);
            Trace.Assert(association is not null);
            association.Update(newAssociation);
            return Update(association);
        }
    }
}
