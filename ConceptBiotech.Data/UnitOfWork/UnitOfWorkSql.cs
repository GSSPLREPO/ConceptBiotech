using System;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ConceptBiotech.Data
{
    public class UnitOfWorkSql : IDisposable
    {
        #region Private member variables...
        public bool IsUnit = false;

        private ConceptBiotech _context = null;


        private GenericRepository<User> _UsersRepository;
        private GenericRepository<Token> _TokensRepository;
        private GenericRepository<CategorysMaster> _CategorysMasterRepository;
        private GenericRepository<SubCategorysMaster> _SubCategorysMasterRepository;
        private GenericRepository<ShopMaster> _ShopMasterRepository;
        private GenericRepository<ProductMaster> _ProductMasterRepository;
        private GenericRepository<Order> _OrderRepository;
        private GenericRepository<OrderDetail> _OrderDetailRepository;


        #endregion

        public UnitOfWorkSql()
        {
            _context = new ConceptBiotech();
        }

        public void closeConnection()
        {
            if (_context.Database.Connection.State == ConnectionState.Open)
            {
                _context.Database.Connection.Close();
            }
        }

        /// <summary>
        /// Disable auto detect
        /// </summary>
        public void DisableAutoDetect()
        {
            _context.Configuration.AutoDetectChangesEnabled = false;
        }
        /// <summary>
        /// enable auto detect
        /// </summary>
        public void EnableAutoDetect()
        {
            _context.Configuration.AutoDetectChangesEnabled = true;
            _context.ChangeTracker.DetectChanges();
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this._UsersRepository == null)
                    this._UsersRepository = new GenericRepository<User>(_context);
                return _UsersRepository;
            }
        }

        public ConceptBiotech getContext()
        {
            return _context;
        }

        public GenericRepository<Token> TokensRepository
        {
            get
            {
                if (this._TokensRepository == null)
                    this._TokensRepository = new GenericRepository<Token>(_context);
                return _TokensRepository;
            }
        }

        public GenericRepository<CategorysMaster> CategorysMasterRepository
        {
            get
            {
                if (this._CategorysMasterRepository == null)
                    this._CategorysMasterRepository = new GenericRepository<CategorysMaster>(_context);
                return _CategorysMasterRepository;
            }
        }

        public GenericRepository<SubCategorysMaster> SubCategorysMasterRepository
        {
            get
            {
                if (this._SubCategorysMasterRepository == null)
                    this._SubCategorysMasterRepository = new GenericRepository<SubCategorysMaster>(_context);
                return _SubCategorysMasterRepository;
            }
        }

        public GenericRepository<ShopMaster> ShopMastersRepository
        {
            get
            {
                if (this._ShopMasterRepository == null)
                    this._ShopMasterRepository = new GenericRepository<ShopMaster>(_context);
                return _ShopMasterRepository;
            }
        }

        public GenericRepository<ProductMaster> ProductMastersRepository
        {
            get
            {
                if (this._ProductMasterRepository == null)
                    this._ProductMasterRepository = new GenericRepository<ProductMaster>(_context);
                return _ProductMasterRepository;
            }
        }


        public GenericRepository<OrderDetail> OrderDetailRepository
        {
            get
            {
                if (this._OrderDetailRepository == null)
                    this._OrderDetailRepository = new GenericRepository<OrderDetail>(_context);
                return _OrderDetailRepository;
            }
        }


        public GenericRepository<Order> OrderRepository
        {
            get
            {
                if (this._OrderRepository == null)
                    this._OrderRepository = new GenericRepository<Order>(_context);
                return _OrderRepository;
            }
        }

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
