using ConceptBiotech.UIEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.Business
{
  public  interface ISubCategorysService : IDisposable
    {
        SubCategorysMasterUI GetById(long Id);

        Tuple<List<SubCategorysMasterUI>, long> GetAll(ListFilter filter);

        SubCategorysMasterUI Add(SubCategorysMasterUI Entity);

        SubCategorysMasterUI Update(long id, SubCategorysMasterUI Entity);

        bool IsDuplicateBuilding(SubCategorysMasterUI building);

        bool Delete(long Id, string basePath, SubCategorysMasterUI Entity);
    }
}
