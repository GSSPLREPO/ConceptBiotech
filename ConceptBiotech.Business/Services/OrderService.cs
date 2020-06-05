using AutoMapper;
using ConceptBiotech.Data;
using ConceptBiotech.UIEntity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.Business
{
    public class OrderService : IDisposable, IOrderService
    {
        private readonly UnitOfWorkSql _unitOfWork;

        public OrderService()
        {
            _unitOfWork = new UnitOfWorkSql();
        }

        public Tuple<List<OrderUI>, long> GetAll(long UserID)
        {
            var strquery = "exec uspOrderGetAll @PK_Id";
            var parameters = new[]
            {
                new SqlParameter("PK_Id", UserID)
            };

            //VoucherMasterViewModel vmViewModel = _unitOfWork.VoucherMastersRepository.MultiResultSetSqlQuery(strquery, parameters);

            var multiResultSet = new MultiResultSetReader(_unitOfWork.getContext(), strquery, parameters);

            List<OrderUI> orderui = new List<OrderUI>();
            List<OrderDetailUI> Odetui = new List<OrderDetailUI>();

            orderui = multiResultSet.ResultSetFor<OrderUI>().ToList();
            Odetui = multiResultSet.ResultSetFor<OrderDetailUI>().ToList();

            for (int i = 0; i < orderui.Count(); i++)
            {
                orderui[i].ODet = Odetui.Where(a => a.OId == orderui[i].UIDN).ToList();
            }


            if (orderui != null)
            {
                return new Tuple<List<OrderUI>, long>(orderui, orderui.Count());

            }
            else
            {
                return new Tuple<List<OrderUI>, long>(null, 0);
            }
        }

        public OrderUI GetById(long Id)
        {
            var task = _unitOfWork.OrderRepository.GetByID(Id);
            if (task != null)
            {
                var taskModel = Mapper.Map<Order, OrderUI>(task);
                return taskModel;
            }
            else
            {
                return null;
            }
        }


        public OrderUI Add(OrderUI Entity, long companyid)
        {
            var Order = Mapper.Map<OrderUI, Order>(Entity);
            Order.OrderDate = DateTime.Now;
            _unitOfWork.OrderRepository.Insert(Order);
            _unitOfWork.Save();
            if (Order != null)
            {
                var taskModel = Mapper.Map<Order, OrderUI>(Order);
                return taskModel;
            }
            else
            {
                return null;
            }
        }

        public OrderUI Update(long id, OrderUI Entity, long companyid)
        {

            var requestModel = Mapper.Map<OrderUI, Order>(Entity);
            requestModel.PK_Id = id;

            _unitOfWork.OrderRepository.Update(requestModel);
            _unitOfWork.Save();
            if (requestModel != null)
            {
                var taskModel = Mapper.Map<Order, OrderUI>(requestModel);
                return taskModel;
            }
            else
            {
                return null;
            }
        }

        public bool Delete(long Id, string basePath, OrderUI Entity, long companyid)
        {
            if (Id > 0)
            {
                //_unitOfWork.bank.Delete(Id);
                var Order = _unitOfWork.OrderRepository.GetByID(Id);
                Order.ModifiedBy = Entity.MBy;
                Order.ModifiedDate = Entity.MDt;
                Order.Status = RecordStatus.Deleted;
                _unitOfWork.OrderRepository.Update(Order);
                _unitOfWork.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsDuplicatePromotionCode(string PromotionCode)
        {
            var IsDuplicate = _unitOfWork.OrderRepository.ExecuteQuery<long>("exec uspAvailablePromotionCode @PromotionCode",
             new SqlParameter("PromotionCode", PromotionCode)
             );
            if (IsDuplicate[0] == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<OrderUserData> GetAllUserCommission(long UserID, long UserPromotionId)
        {
            var strquery = "exec uspGetUserCommission @PK_Id,@UserPromotionId";
            var parameters = new[]
            {
                new SqlParameter("PK_Id", UserID),
                 new SqlParameter("UserPromotionId", UserPromotionId)
            };

            //VoucherMasterViewModel vmViewModel = _unitOfWork.VoucherMastersRepository.MultiResultSetSqlQuery(strquery, parameters);

            var multiResultSet = new MultiResultSetReader(_unitOfWork.getContext(), strquery, parameters);

            List<OrderUserData> order = new List<OrderUserData>();

            order = multiResultSet.ResultSetFor<OrderUserData>().ToList();

            if (order != null)
            {
                return order;
            }
            else
            {
                return null;
            }
        }

        public List<OrderUserData> GetAllUserTotalCommission(long UserID)
        {
            var strquery = "exec uspGetUserTotalComission @PK_Id";
            var parameters = new[]
            {
                new SqlParameter("PK_Id", UserID)
            };

            //VoucherMasterViewModel vmViewModel = _unitOfWork.VoucherMastersRepository.MultiResultSetSqlQuery(strquery, parameters);

            var multiResultSet = new MultiResultSetReader(_unitOfWork.getContext(), strquery, parameters);

            List<OrderUserData> order = new List<OrderUserData>();

            order = multiResultSet.ResultSetFor<OrderUserData>().ToList();

            if (order != null)
            {
                return order;
            }
            else
            {
                return null;
            }
        }

        public void Dispose()
        {
            _unitOfWork.closeConnection();
        }
    }
}
