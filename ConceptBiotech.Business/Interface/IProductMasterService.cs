using ConceptBiotech.UIEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.Business
{
    public interface IProductMasterService : IDisposable
    {
        Tuple<List<ProductMasterUI>, long> GetAll();

        ProductMasterUI GetById(long ProductMasterId);

        ProductMasterUI Add(ProductMasterUI Entity, string basePath, long companyid);

        ProductMasterUI Update(long id, ProductMasterUI Entity, string basePath, long companyid);

        bool IsDuplicateProductMaster(ProductMasterUI Entity);

        bool Delete(long Id, ProductMasterUI Entity, string basePath, long companyid);
    }
}
