using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DataAccess.EntityFramework;
using BusinessModel;
using System.Linq.Expressions;
using Core.Extensions;
using Core;

namespace DataAccess.EntityFramework.MS_SQL
{
    public class DaoBaseClass<T, TBusinessModel>
        where T : class
        where TBusinessModel : BusinessModelBase, new()
        
    {
        private string _idPropery;
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;
        private readonly GenericRepository<T> _repository;

        protected TBusinessModel GetObject()
        {
            return new TBusinessModel();
        }

        public DaoBaseClass(DbContext context, string idProperty)
        {
            _repository = new GenericRepository<T>(context);
            _dbContext = context;
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });
            _mapper = mapperConfig.CreateMapper();
            _idPropery = idProperty;
        }
        public async Task<TBusinessModel> Create(TBusinessModel input)
        {
            CharacterCorrector.ReplacePersianCodePages(input);
            var obj = _mapper.Map<T>(input);
            _repository.Insert(obj);
            _repository.Context.SaveChanges();
            return _mapper.Map<TBusinessModel>(obj);
        }

        public void Delete(Int64 input)
        {
            var entityToDelete = Get(input);
            if (entityToDelete != null)
            {
                _repository.Delete(entityToDelete);
                _repository.Context.SaveChanges();
            }
        }
        public void Delete(TBusinessModel input)
        {
            Delete((Int64)input.GetPropertyValue(_idPropery));
        }
        public void Update(TBusinessModel input)
        {
            if (((Int64?)input.GetPropertyValue(_idPropery)).HasValue)
            {
                CharacterCorrector.ReplacePersianCodePages(input);
                var entityToUpdate = Get((Int64)input.GetPropertyValue(_idPropery));
                if (entityToUpdate != null)
                {
                    var obj = _mapper.Map<T>(input);
                    _repository.Update(entityToUpdate, obj);
                    _repository.Context.SaveChanges();
                }
            }
        }
        public async Task<IList<TBusinessModel>> GetAll(Expression<Func<TBusinessModel, bool>>? filter = null, string orderBy = "", string? includeProperties = "")
        {
            var result = await GetQueryable(filter, orderBy, includeProperties).ToListAsync();
            return _mapper.Map<IList<TBusinessModel>>(result);
        }
        public async Task<IList<TBusinessModel>> GetAll(int pageNumber, int pageSize, Expression<Func<TBusinessModel, bool>>? filter = null, string orderBy = "", string? includeProperties = "")
        {
            var result = await GetQueryable(filter, orderBy, includeProperties).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return _mapper.Map<IList<TBusinessModel>>(result);
        }
        public async Task<int> GetAllCount(Expression<Func<TBusinessModel, bool>>? filter = null)
        {
            return await GetQueryable(filter).CountAsync();
        }
        public async Task<TBusinessModel?> GetByKey(Int64 input, string? includeProperties = "")
        {
            var result = Get(input, includeProperties);
            return _mapper.Map<TBusinessModel>(result);
        }
        private T? Get(Int64? input, string? includeProperties = "")
        {

             
            var parameterExpression = Expression.Parameter(typeof(TBusinessModel), "m");
            var property = Expression.Property(parameterExpression, _idPropery);
            
            Expression where = Expression.Equal(property, Expression.Convert(Expression.Constant(input), property.Type));
            var lambda = Expression.Lambda<Func<TBusinessModel, bool>>(where, parameterExpression);

            includeProperties = DaoMapper.Map(typeof(TBusinessModel), includeProperties);
            return GetQueryable(lambda, null, includeProperties).FirstOrDefault();
        }
        private IQueryable<T> GetQueryable(Expression<Func<TBusinessModel, bool>>? filter = null, string orderBy = "", string? includeProperties = "")
        {
            Expression<Func<T, bool>>? filterExpr = Extensions.ConvertExpression<TBusinessModel, T>(filter);
            includeProperties = DaoMapper.Map(typeof(TBusinessModel), includeProperties);
            IQueryable<T> query = _repository.Get(filterExpr, null, includeProperties);
            query = Extensions.OrderBy<T>(orderBy, query);
            return query;
        }
    }
}
