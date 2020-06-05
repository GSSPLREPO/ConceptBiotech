using ConceptBiotech.Data;
using ConceptBiotech.UIEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.Business
{
    public interface ICategoryService : IDisposable
    {
        CategorysMasterUI GetById(long Id);

        Tuple<List<CategorysMasterUI>, long> GetAll(ListFilter filter);

        CategorysMasterUI Add(CategorysMasterUI Entity);

        CategorysMasterUI Update(long id, CategorysMasterUI Entity);

        bool IsDuplicateBuilding(CategorysMasterUI building);

        bool Delete(long Id, string basePath, CategorysMasterUI Entity);
    }
}
