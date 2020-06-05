using ConceptBiotech.UIEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.Business
{
    public interface IShopMasterService : IDisposable
    {
        ShopMasterUI GetById(long Id);

        Tuple<List<ShopMasterUI>, long> GetAll(ListFilter filter, long userId);

        ShopMasterUI Add(ShopMasterUI Entity, string basePath);

        ShopMasterUI Update(long id, string basePath, ShopMasterUI Entity);

        bool Delete(long Id, string basePath, ShopMasterUI Entity);

        bool IsDuplicateShop(ShopMasterUI Entity);

       // TokenUI SelectCompanyById(long tokenId, long companyId);
    }
}