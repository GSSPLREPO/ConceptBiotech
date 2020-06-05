using ConceptBiotech.Data;
using ConceptBiotech.UIEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.Business
{
    public interface IOrderService : IDisposable
    {
        OrderUI GetById(long Id);

        Tuple<List<OrderUI>, long> GetAll(long UserID);

        OrderUI Add(OrderUI Entity, long companyid);

        OrderUI Update(long id, OrderUI Entity, long companyid);

        bool Delete(long Id, string basePath, OrderUI Entity, long companyid);

        bool IsDuplicatePromotionCode(string PromotionCode);

        List<OrderUserData> GetAllUserCommission(long UserID, long UserPromotionId);

        List<OrderUserData> GetAllUserTotalCommission(long UserID);
    }
}
