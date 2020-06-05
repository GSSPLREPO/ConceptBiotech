#region Using Namespaces...

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

#endregion

namespace ConceptBiotech.Data
{
    /// <summary>
    /// Generic Repository class for Entity Operations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericRepository<TEntity> where TEntity : class
    {
        #region Private member variables...
        internal ConceptBiotech Context;
        internal DbSet<TEntity> DbSet;

        #endregion

        #region Public Constructor...
        /// <summary>
        /// Public Constructor,initializes privately declared local variables.
        /// </summary>
        /// <param name="context"></param>
        public GenericRepository(ConceptBiotech context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }
        #endregion

        #region Public member methods...

        /// <summary>
        /// generic Get method for Entities
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = DbSet;
            return query.ToList();
        }

        /// <summary>
        /// Generic get method on the basis of id for Entities.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetByID(object id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// generic Insert method for the entities
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }
        /// <summary>
        /// generic Insert method for the entities
        /// </summary>
        /// <param name="entity"></param>
        public virtual void InsertRange(IEnumerable<TEntity> entity)
        {
            DbSet.AddRange(entity);
        }

        /// <summary>
        /// Generic Delete method for the entities
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Generic Delete method for the entities
        /// </summary>
        /// <param name="entityToDelete"></param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// Generic update method for the entities
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        /// <summary>
        /// generic method to get many record on the basis of a condition.
        /// </summary>-
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where(where).ToList();
        }

        /// <summary>
        /// generic method to get many record on the basis of a condition but query able.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        //public virtual IQueryable<TEntity> GetManyQueryable(Func<TEntity, bool> where)
        //{
        //    return DbSet.Where(where).AsQueryable();
        //}
        public virtual IQueryable<TEntity> GetManyQueryable()
        {
            return DbSet.AsQueryable();
        }
        public virtual IQueryable<TEntity> GetManyNoTrackQueryableInclude(params string[] include)
        {
            var data = DbSet.AsNoTracking().AsQueryable();
            data = include.Aggregate(data, (current, inc) => current.Include(inc));
            return data;
        }
        public virtual IQueryable<TEntity> GetManyNoTrackQueryable()
        {
            return DbSet.AsNoTracking().AsQueryable();
        }
        /// <summary>
        /// generic get method , fetches data for the entities on the basis of condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public TEntity Getnotrack(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.AsNoTracking().Where(where).FirstOrDefault<TEntity>();
        }
        public TEntity Get(Expression<Func<TEntity, bool>> where = null)
        {
            return DbSet.Where(where).FirstOrDefault<TEntity>();
        }
        /// <summary>
        /// generic delete method , deletes data for the entities on the basis of condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public void Delete(Func<TEntity, Boolean> where)
        {
            IQueryable<TEntity> objects = DbSet.Where<TEntity>(where).AsQueryable();
            DbSet.RemoveRange(objects);
            //foreach (TEntity obj in objects)
            //    DbSet.Remove(obj);
        }

        /// <summary>
        /// Delete All data from table
        /// </summary>
        /// <returns></returns>
        public void DeleteAll()
        {
            IQueryable<TEntity> objects = DbSet;
            DbSet.RemoveRange(objects);
        }

        /// <summary>
        /// generic method to fetch all the records from db
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual Tuple<List<TEntity>, long> GetFilteredList(Expression<Func<TEntity, bool>> where = null, string sortby = null, bool IsDescenting = false, int currentPage = 1, int pageSize = 0, bool isTotalCountRequired = false, params string[] include)
        {
            IQueryable<TEntity> data = null;

            if (where != null)
            {
                data = DbSet.Where(where).AsQueryable();
            }
            else
            {
                data = DbSet.AsQueryable();
            }

            if (sortby != null)
            {
                //var pi = typeof(TEntity).GetProperty(sortby);
                data = data.OrderByField(sortby, IsDescenting);

            }
            if (pageSize == 0)
            {
                if (include != null && include.Length > 0)
                {
                    data = include.Aggregate(data, (current, inc) => current.Include(inc));
                }
                var finaldata = data.ToList();
                return new Tuple<List<TEntity>, long>(finaldata, finaldata.Count());
            }
            else
            {
                long totalCnt = data.Count();
                data = data.Skip((currentPage - 1) * pageSize).Take(pageSize);
                if (include != null && include.Length > 0)
                {
                    data = include.Aggregate(data, (current, inc) => current.Include(inc));
                }
                return new Tuple<List<TEntity>, long>(data.ToList(), totalCnt);
            }
        }

        public virtual Tuple<IQueryable<TEntity>, long> GetFilteredQueryList(Expression<Func<TEntity, bool>> where = null, string sortby = null, bool IsDescenting = false, int currentPage = 1, int pageSize = 0, bool isTotalCountRequired = false)
        {
            IQueryable<TEntity> data = null;

            if (where != null)
            {
                data = DbSet.Where(where).AsQueryable();
            }
            else
            {
                data = DbSet.AsQueryable();
            }

            if (sortby != null)
            {
                //var pi = typeof(TEntity).GetProperty(sortby);
                data = data.OrderByField(sortby, IsDescenting);

            }
            if (pageSize == 0)
            {
                //return data;
                var finaldata = data.Count();
                return new Tuple<IQueryable<TEntity>, long>(data, finaldata);
            }
            else
            {
                //return data.Skip((currentPage - 1) * pageSize).Take(pageSize);
                long totalCnt = data.Count();
                return new Tuple<IQueryable<TEntity>, long>(data.Skip((currentPage - 1) * pageSize).Take(pageSize), totalCnt);
            }


        }

        private Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
        }

        /// <summary>
        /// Inclue multiple
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetWithInclude(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, params string[] include)
        {
            IQueryable<TEntity> query = this.DbSet;
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate);
        }

        /// <summary>
        /// Inclue multiple
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public TEntity GetWithIncludeNoTrack(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, params string[] include)
        {
            IQueryable<TEntity> query = this.DbSet.AsNoTracking();
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate).FirstOrDefault<TEntity>();
        }

        /// <summary>
        /// Generic method to check if entity exists
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public bool Exists(object primaryKey)
        {
            return DbSet.Find(primaryKey) != null;
        }

        public void ExecureNonQuery(string query, params object[] queryparams)
        {
            if (queryparams != null)
                Context.Database.ExecuteSqlCommand(query, queryparams);
            else
                Context.Database.ExecuteSqlCommand(query);
        }

        public long SQLQuery(string query, params object[] queryparams)
        {
            long result = Context.Database.SqlQuery<long>(query, queryparams).FirstOrDefault();
            //int i = Context.Database.ExecuteSqlCommand(query, queryparams);
            return result;
        }
        /// <summary>
        /// Gets a single record by the specified criteria (usually the unique identifier)
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record that matches the specified criteria</returns>
        public TEntity GetSingle(Func<TEntity, bool> predicate)
        {
            return DbSet.Single<TEntity>(predicate);
        }

        /// <summary>
        /// The first record matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record containing the first record matching the specified criteria</returns>
        public TEntity GetFirst(Func<TEntity, bool> predicate)
        {
            return DbSet.First<TEntity>(predicate);
        }

        public List<T> ExecuteQuery<T>(string query, params object[] queryparams)
        {
            var res = Context.Database.SqlQuery<T>(query, queryparams).ToList();
            return res;
        }

        public List<LedgerHierarchy> GetLedgerHierarchy(long ParentId)
        {
            SqlParameter parentParameter = new SqlParameter("ParentLedgerId", ParentId);
            var LedgerHierarchy = Context.Database.SqlQuery<LedgerHierarchy>("exec GetChildLedgers @ParentLedgerId", new SqlParameter("ParentLedgerId", ParentId)).ToList();
            return LedgerHierarchy;
        }


        //public DbDataReader GetReaderMultiResultSet(string commandText,string parameter)
        //{

        //    // Create a SQL command to execute the sproc
        //    var cmd = Context.Database.Connection.CreateCommand();
        //    cmd.CommandText = commandText;

        //    Context.Database.Connection.Open();
        //    // Run the sproc
        //    var reader = cmd.ExecuteReader();

        //    return reader;

        //}

        //public VoucherMasterViewModel MultiResultSetSqlQuery(string query, params SqlParameter[] parameters)
        //{
        //    var multiResultSet = new MultiResultSetReader(Context, query, parameters);
        //    List<VoucherMaster> VM = new List<VoucherMaster>();
        //    List<VoucherDetail> vDet = new List<VoucherDetail>();
        //    List<BankDetails> bDet = new List<BankDetails>();
        //    //List<ReferenceDet> rDet = new List<ReferenceDet>();

        //    VM = multiResultSet.ResultSetFor<VoucherMaster>().ToList();
        //    vDet = multiResultSet.ResultSetFor<VoucherDetail>().ToList();
        //    bDet = multiResultSet.ResultSetFor<BankDetails>().ToList();
        //    //rDet = multiResultSet.ResultSetFor<ReferenceDet>().ToList();
        //    VoucherMasterViewModel obj = new VoucherMasterViewModel();

        //    obj.VM = VM;
        //    obj.VDet = vDet;
        //    obj.bDet = bDet;
        //    //obj.rDet = rDet;

        //    return obj;
        //}
        #endregion
    }

    public class MultiResultSetReader : IDisposable
    {
        private readonly ConceptBiotech _context;
        private readonly DbCommand _command;
        private bool _connectionNeedsToBeClosed;
        private DbDataReader _reader;

        public MultiResultSetReader(ConceptBiotech context, string query, SqlParameter[] parameters)
        {
            _context = context;
            _command = _context.Database.Connection.CreateCommand();
            _command.CommandText = query;

            if (parameters != null && parameters.Any()) _command.Parameters.AddRange(parameters);
        }
        public void Dispose()
        {
            if (_reader != null)
            {
                _reader.Dispose();
                _reader = null;
            }

            if (_connectionNeedsToBeClosed)
            {
                _context.Database.Connection.Close();
                _connectionNeedsToBeClosed = false;
            }
        }

        public ObjectResult<T> ResultSetFor<T>()
        {
            if (_reader == null)
            {
                _reader = GetReader();
            }
            else
            {
                _reader.NextResult();
            }

            var objContext = ((IObjectContextAdapter)_context).ObjectContext;

            return objContext.Translate<T>(_reader);
        }

        private DbDataReader GetReader()
        {
            if (_context.Database.Connection.State != ConnectionState.Open)
            {
                _context.Database.Connection.Open();
                _connectionNeedsToBeClosed = true;
            }

            return _command.ExecuteReader();
        }
    }

    public static class extensionmethods
    {
        public static IQueryable<T> OrderByField<T>(this IQueryable<T> q, string SortField, bool Descending)
        {
            //var param = Expression.Parameter(typeof(T), "p");
            //var prop = Expression.Property(param, SortField);
            //var exp = Expression.Lambda(prop, param);

            var exp = CreateExpression(typeof(T), SortField);
            string method = Descending ? "OrderByDescending" : "OrderBy";
            Type[] types = new Type[] { q.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<T>(mce);
        }
        static LambdaExpression CreateExpression(Type type, string propertyName)
        {
            var param = Expression.Parameter(type, "x");
            Expression body = param;
            foreach (var member in propertyName.Split('.'))
            {
                body = Expression.PropertyOrField(body, member);
            }
            return Expression.Lambda(body, param);
        }
    }
    public static class PredicateBuilder
    {
        /// <summary>    
        /// Creates a predicate that evaluates to true.    
        /// </summary>    
        public static Expression<Func<T, bool>> True<T>() { return param => true; }

        /// <summary>    
        /// Creates a predicate that evaluates to false.    
        /// </summary>    
        public static Expression<Func<T, bool>> False<T>() { return param => false; }

        /// <summary>    
        /// Creates a predicate expression from the specified lambda expression.    
        /// </summary>    
        public static Expression<Func<T, bool>> Create<T>(Expression<Func<T, bool>> predicate) { return predicate; }

        /// <summary>    
        /// Combines the first predicate with the second using the logical "and".    
        /// </summary>    
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.AndAlso);
        }

        /// <summary>    
        /// Combines the first predicate with the second using the logical "or".    
        /// </summary>    
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.OrElse);
        }

        /// <summary>    
        /// Negates the predicate.    
        /// </summary>    
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
        {
            var negated = Expression.Not(expression.Body);
            return Expression.Lambda<Func<T, bool>>(negated, expression.Parameters);
        }

        /// <summary>    
        /// Combines the first expression with the second using the specified merge function.    
        /// </summary>    
        static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // zip parameters (map from parameters of second to parameters of first)    
            var map = first.Parameters
                .Select((f, i) => new { f, s = second.Parameters[i] })
                .ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with the parameters in the first    
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // create a merged lambda expression with parameters from the first expression    
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        class ParameterRebinder : ExpressionVisitor
        {
            readonly Dictionary<ParameterExpression, ParameterExpression> map;

            ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
            {
                this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
            }

            public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
            {
                return new ParameterRebinder(map).Visit(exp);
            }

            protected override Expression VisitParameter(ParameterExpression p)
            {
                ParameterExpression replacement;

                if (map.TryGetValue(p, out replacement))
                {
                    p = replacement;
                }

                return base.VisitParameter(p);
            }
        }


    }
    public class LedgerHierarchy
    {
        public long Pk_Id { get; set; }
        public long? ParentId { get; set; }
    }

}
