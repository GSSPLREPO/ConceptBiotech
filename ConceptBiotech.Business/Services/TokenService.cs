using AutoMapper;
using ConceptBiotech.Data;
using ConceptBiotech.UIEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.Business
{
    public class TokenService : ITokenService, IDisposable
    {
        #region private property

        private readonly UnitOfWorkSql _unitOfWork;

        #endregion private property

        #region Constructor

        /// <summary>
        /// Constructor to get unit of work
        /// </summary>
        /// <param name="unitOfWork"></param>

        //public TokenService(UnitOfWorkSql unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        public TokenService()
        {
            _unitOfWork = new UnitOfWorkSql();
        }

        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Delete Token by UserId
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>returns true if token deleted successfully</returns>
        public bool DeleteByUserId(long userId)
        {
            _unitOfWork.TokensRepository.Delete(a => a.UserId == userId);
            _unitOfWork.Save();
            return true;
        }

        public bool DeleteAllToken()
        {
            _unitOfWork.TokensRepository.DeleteAll();
            _unitOfWork.Save();
            return true;
        }

        //public bool DeleteByCompanyId(long CompanyId)
        //{
        //    _unitOfWork.TokensRepository.Delete(a => a.CompanyId == CompanyId);
        //    _unitOfWork.Save();
        //    return true;
        //}
        //public bool DeleteByRoleId(long RoleId)
        //{
        //    if (RoleId > 0)
        //    {
        //        _unitOfWork.TokensRepository.Delete(a => a.RoleId == RoleId);
        //        _unitOfWork.Save();
        //    }
        //    return true;
        //}
        //public bool DeleteBySignupId(long SignUpId)
        //{
        //    _unitOfWork.TokensRepository.Delete(a => a.UserId == SignUpId);
        //    _unitOfWork.Save();
        //    return true;
        //}

        /// <summary>
        /// Generate token for the user for specific period of time
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>returns Generated token details</returns>
        public TokenUI GenerateToken(long userId)
        {
            //string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            UserService userService = new UserService();
            UserUI userUI = userService.GetById(userId);
            User user = Mapper.Map<UserUI, User>(userUI);
            DateTime expiredOn = DateTime.Now.AddSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));

            //if (user.UserImages != null && user.UserImages.Count() > 0)
            //{
            //    Photo = user.UserImages[0].name;
            //}

            var tokendomain = new Token
            {
                UserId = userId,
                UserType = user.UserType,
                AuthToken = string.Empty,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn,
                UserName = user.UserName
            };


            _unitOfWork.TokensRepository.Insert(tokendomain);
            _unitOfWork.Save();

            var tokenModel = new TokenUI()
            {
                UIDN = tokendomain.PK_Id,
                UI = userId,
                UT = userUI.UT,
                IsOn = issuedOn,
                ExOn = expiredOn,
                AT = string.Empty,
                UN = tokendomain.UserName
            };

            return tokenModel;
        }

        /// <summary>
        /// Kill the token by token if
        /// </summary>
        /// <param name="tokenId">token id</param>
        /// <returns>Returns true of token is deleted</returns>
        public bool Kill(long tokenId)
        {
            _unitOfWork.TokensRepository.Delete(tokenId);
            _unitOfWork.Save();
            var isNotDeleted = _unitOfWork.TokensRepository.GetByID(tokenId);
            if (isNotDeleted != null) { return false; }
            return true;
        }

        /// <summary>
        /// Validate current token with the logged in user
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        public TokenUI ValidateToken(long tokenId)
        {
            var token = _unitOfWork.TokensRepository.GetWithInclude(a => a.PK_Id == tokenId, "RoleMaster").FirstOrDefault();
            if (token != null && !(DateTime.Now > token.ExpiresOn))
            {
                token.ExpiresOn = token.ExpiresOn.AddSeconds(
                                              Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
                _unitOfWork.TokensRepository.Update(token);
                _unitOfWork.Save();
                return Mapper.Map<Token, TokenUI>(token);
            }
            return null;
        }

        //public TokenUI UpdateTokenCompany(long tokenId, long companyId)
        //{
        //    //string token = Guid.NewGuid().ToString();
        //    var token = _unitOfWork.TokensRepository.GetByID(tokenId);
        //    if (token.UserType != UserType.SuperAdmin)
        //    {
        //        UserRoleService userRole = new UserRoleService();
        //        UserRoleUI userRoleUI = userRole.GetByCompanyId(companyId, token.UserId);

        //        if (userRoleUI != null)
        //        {
        //            RoleMasterService role = new RoleMasterService();
        //            RoleMaster roleMaster = role.GetByRole(userRoleUI.RI);
        //            token.RoleMaster = roleMaster;
        //            token.RoleId = userRoleUI.RI;
        //            token.RoleData_PK_Id = roleMaster.PK_Id;
        //        }
        //        else
        //        {
        //            token.RoleMaster = null;
        //            token.RoleId = 0;
        //        }
        //    }
        //    token.CompanyId = companyId;
        //    _unitOfWork.TokensRepository.Update(token);
        //    _unitOfWork.Save();

        //    return Mapper.Map<Token, TokenUI>(token);
        //}

        #endregion Public Methods


        public void Dispose()
        {
            _unitOfWork.closeConnection();
        }
    }
}
