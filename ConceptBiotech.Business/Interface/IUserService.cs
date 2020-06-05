using ConceptBiotech.Data;
using ConceptBiotech.UIEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.Business
{
    public interface IUserService : IDisposable
    {
        UserUI Authenticate(User user);

        Tuple<List<UserUI>, long> GetAll();

        UserUI GetById(long UserId);

        UserUI Add(UserUI Entity);

        UserUI Update(long id, UserUI Entity);

        bool IsDuplicateUser(UserUI Entity);

        int IsDuplicatePromotionCode(string PromotionCode); 

        bool Delete(long Id, UserUI Entity, string basePath, long companyid);
    }
}
