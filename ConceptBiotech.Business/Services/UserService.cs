using AutoMapper;
using ConceptBiotech.Data;
using ConceptBiotech.UIEntity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ConceptBiotech.Business
{
    public class UserService : IUserService, IDisposable
    {
        private readonly UnitOfWorkSql _unitOfWork;

        public UserService()
        {
            _unitOfWork = new UnitOfWorkSql();
        }


        /// <summary>
        /// Public method to authenticate user by user name and password.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserUI Authenticate(User userdata)
        {
            userdata.Password = HelperMethods.Encrypt(userdata.Password, true);

            User user = _unitOfWork.UserRepository.ExecuteQuery<User>("exec uspUserLogin @UserName, @Password",
             new SqlParameter("UserName", userdata.UserName),
             new SqlParameter("Password", userdata.Password)
            ).FirstOrDefault();

            if (user != null)
            {

                var userModel = Mapper.Map<User, UserUI>(user);
                return userModel;
            }
            return null;
        }


        public Tuple<List<UserUI>, long> GetAll()
        {
            var condition = PredicateBuilder.Create<User>(a => a.Status != RecordStatus.Deleted);

            Tuple<List<User>, long> userlist = null;
            userlist = _unitOfWork.UserRepository.GetFilteredList(condition);


            for (int i = 0; i < userlist.Item1.Count(); i++)
            {
                userlist.Item1[i].Password = HelperMethods.Decrypt(userlist.Item1[i].Password, true);
            }
            var users = Mapper.Map<List<User>, List<UserUI>>(userlist.Item1);
            return new Tuple<List<UserUI>, long>(users, userlist.Item2);
        }

        public UserUI GetById(long Id)
        {
            var user = _unitOfWork.UserRepository.GetWithInclude(a => a.PK_Id == Id).FirstOrDefault();
            if (user != null)
            {
                var userModel = Mapper.Map<User, UserUI>(user);
                return userModel;
            }
            else
            {
                return null;
            }
        }

        public UserUI Add(UserUI Entity)
        {
            Entity.Pwd = HelperMethods.Encrypt(Entity.Pwd, true);
            Entity.UT = UserTypeUI.Admin;
            var condition = PredicateBuilder.Create<User>(s => s.UserName == Entity.UN || s.Email == Entity.Eml && s.Status == RecordStatus.Active);
            var existsuser = _unitOfWork.UserRepository.GetFilteredList(condition).Item1;
            if (existsuser != null && existsuser.Any())
            {
                return Entity;
            }

            Entity.PC = "Concept_" + Entity.UN.Substring(0, 2).ToUpper() + Entity.FN.Substring(0, 2).ToUpper() + Entity.Mo.Substring(0, 2);
            //StringBuilder builder = new StringBuilder();
            //builder.Append(RandomNumber(1000, 9999));
            //builder.Append(RandomString(Entity.UN.Substring(0, 2).Count(), true));
            //builder.Append(RandomString(Entity.FN.Substring(0, 2).Count(), false));

            //Entity.PC = builder.ToString();
            var user = Mapper.Map<UserUI, User>(Entity);
            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Save();

            if (user != null)
            {
                var userModel = Mapper.Map<User, UserUI>(user);

                return userModel;
            }
            else
            {
                return null;
            }
        }

        // Generate a random number between two numbers    
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        // Generate a random string with a given size    
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }


        public UserUI Update(long id, UserUI Entity)
        {

            var requestModel = Mapper.Map<UserUI, User>(Entity);
            requestModel.PK_Id = id;
            requestModel.Password = HelperMethods.Encrypt(Entity.Pwd, true);
            _unitOfWork.UserRepository.Update(requestModel);

            _unitOfWork.Save();
            var userModel = Mapper.Map<User, UserUI>(requestModel);
            return userModel;

        }

        public bool IsDuplicateUser(UserUI Entity)
        {
            var condition = PredicateBuilder.Create<User>(s => s.Status == RecordStatus.Active &&
                                                               (s.UserName == Entity.UN
                                                                || s.Email == Entity.Eml));
            //|| s.Mobile == Entity.Mo
            if (Entity.UIDN > 0)
            {
                condition = condition.And(a => a.PK_Id != Entity.UIDN);
            }

            var existuser = _unitOfWork.UserRepository.Get(condition);
            if (existuser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(long Id, UserUI Entity, string basePath, long companyid)
        {
            if (Id > 0)
            {
                //_unitOfWork.user.Delete(Id);

                var user = _unitOfWork.UserRepository.GetByID(Id);
                user.ModifiedBy = Entity.MBy;
                user.ModifiedDate = Entity.MDt;
                user.Status = RecordStatus.Deleted;

                _unitOfWork.UserRepository.Update(user);
                _unitOfWork.Save();

                if (user != null)
                {

                    return true;
                }

                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public int IsDuplicatePromotionCode(string PromotionCode)
        {
            var IsDuplicate = _unitOfWork.UserRepository.ExecuteQuery<long>("exec uspUserCheckPromotionCode @PromotionCode",
             new SqlParameter("PromotionCode", PromotionCode)
             );
            if (IsDuplicate[0] > 0)
            {
                return Convert.ToInt32(IsDuplicate[0]);
            }
            else
            {
                return 0;
            }
        }

        public void Dispose()
        {
            _unitOfWork.closeConnection();
        }
    }
}
