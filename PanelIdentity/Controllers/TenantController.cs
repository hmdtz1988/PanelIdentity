using BusinessLogic.Action;  
using Microsoft.AspNetCore.Mvc;  
using BusinessModel;  
using Core.Utilities.Results;  
using Core.Extensions;  
using IResult = Core.Utilities.Results.IResult;  
namespace PanelIdentity.Controllers  
{  
    [Route("api/Tenant/[action]")]  
    public class TenantController : BaseApiController  
    {  
        private TenantAction action = new TenantAction();  
        [HttpGet("{id}")]  
       public async Task<IResult> Get(Int64 id)   
       {   
           try   
           {   
               var data = await action.Get(id);   
               return new SuccessDataResult<TenantBusinessModel>(data, 1);  
           }   
           catch (Exception ex)   
           {   
               return new ErrorDataResult<TenantBusinessModel>(message: ServerException(ex).Message);  
           }   
       }   
        [HttpPost]    
        public async Task<IResult> Get([FromBody] DataFilterWithPaging model)    
        {    
            try    
            {    
                var data = HasPaging(model)    
                    ? await action.GetAll(model.PageNumber, model.PageSize, GetFilterExpression<TenantBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperies)    
                    : await action.GetAll(GetFilterExpression<TenantBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperies);    
                var count = await Count(model);  
                return new SuccessDataResult<IList<TenantBusinessModel>>(data, count);  
            }    
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<TenantBusinessModel>>(message: ServerException(ex).Message);  
            }    
        }    
        [HttpPost]    
        public async Task<IResult> Suggestion([FromBody] DataFilterWithPaging model)    
        {    
            try    
            {    
                var data = HasPaging(model)    
                    ? await action.GetAll(model.PageNumber, model.PageSize, GetSuggestionExpression<TenantBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperies)    
                    : await action.GetAll(GetSuggestionExpression<TenantBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperies);    
                var count = await Count(model);    
                return new SuccessDataResult<IList<TenantBusinessModel>>(data, count);  
            }    
            catch (Exception ex)    
            {    
                return new ErrorDataResult<IList<TenantBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpGet]    
        public async Task<IResult> GetAll()    
        {    
            try    
            {    
                var data = await action.GetAll(null, "");    
                return new SuccessDataResult<IList<TenantBusinessModel>>(data, data.Count);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<TenantBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPost]    
        public IResult Post([FromBody] TenantBusinessModel input)    
        {    
            try    
            {  
                action.Add(input);  
                return new SuccessDataResult<TenantBusinessModel>(input, 1);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<TenantBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPut("{id}")]    
        public IResult Put( Int64 id, [FromBody] TenantBusinessModel input)    
        {    
            try    
            {    
                action.Modify(input);  
                return new SuccessDataResult<TenantBusinessModel>(input, 1);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<TenantBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpDelete("{id}")]    
        public IResult Delete(Int64 id)    
        {    
            try    
            {    
                var action = new TenantAction();    
                action.Remove(id);  
                return new SuccessResult();  
            }  
            catch (Exception ex)    
            {    
                return new ErrorDataResult<TenantBusinessModel>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPost]    
        private async Task<long> Count([FromBody] DataFilterWithPaging input)    
        {    
            try    
            {    
                var action = new TenantAction();    
                return await action.GetAllCount(GetFilterExpression<TenantBusinessModel>(input.Filters));    
            }    
            catch (Exception ex)    
            {    
                throw ServerException(ex);    
            }    
        }    
    }  
}  
