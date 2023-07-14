using BusinessLogic.Action;  
using Microsoft.AspNetCore.Mvc;  
using BusinessModel;  
using Core.Utilities.Results;  
using Core.Extensions;  
using IResult = Core.Utilities.Results.IResult;  
namespace PanelIdentity.Controllers  
{  
    [Route("api/TenentProject/[action]")]  
    public class TenentProjectController : BaseApiController  
    {  
        private TenentProjectAction action = new TenentProjectAction();  
        [HttpGet("{id}")]  
       public async Task<IResult> Get(Int64 id)   
       {   
           try   
           {   
               var data = await action.Get(id);   
               return new SuccessDataResult<TenantProjectBusinessModel>(data, 1);  
           }   
           catch (Exception ex)   
           {   
               return new ErrorDataResult<TenantProjectBusinessModel>(message: ServerException(ex).Message);  
           }   
       }   
        [HttpPost]    
        public async Task<IResult> Get([FromBody] DataFilterWithPaging model)    
        {    
            try    
            {    
                var data = HasPaging(model)    
                    ? await action.GetAll(model.PageNumber, model.PageSize, GetFilterExpression<TenantProjectBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperies)    
                    : await action.GetAll(GetFilterExpression<TenantProjectBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperies);    
                var count = await Count(model);  
                return new SuccessDataResult<IList<TenantProjectBusinessModel>>(data, count);  
            }    
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<TenantProjectBusinessModel>>(message: ServerException(ex).Message);  
            }    
        }    
        [HttpPost]    
        public async Task<IResult> Suggestion([FromBody] DataFilterWithPaging model)    
        {    
            try    
            {    
                var data = HasPaging(model)    
                    ? await action.GetAll(model.PageNumber, model.PageSize, GetSuggestionExpression<TenantProjectBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperies)    
                    : await action.GetAll(GetSuggestionExpression<TenantProjectBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperies);    
                var count = await Count(model);    
                return new SuccessDataResult<IList<TenantProjectBusinessModel>>(data, count);  
            }    
            catch (Exception ex)    
            {    
                return new ErrorDataResult<IList<TenantProjectBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpGet]    
        public async Task<IResult> GetAll()    
        {    
            try    
            {    
                var data = await action.GetAll(null, "");    
                return new SuccessDataResult<IList<TenantProjectBusinessModel>>(data, data.Count);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<TenantProjectBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPost]    
        public IResult Post([FromBody] TenantProjectBusinessModel input)    
        {    
            try    
            {  
                action.Add(input);  
                return new SuccessDataResult<TenantProjectBusinessModel>(input, 1);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<TenantProjectBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPut("{id}")]    
        public IResult Put( Int64 id, [FromBody] TenantProjectBusinessModel input)    
        {    
            try    
            {    
                action.Modify(input);  
                return new SuccessDataResult<TenantProjectBusinessModel>(input, 1);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<TenantProjectBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpDelete("{id}")]    
        public IResult Delete(Int64 id)    
        {    
            try    
            {    
                var action = new TenentProjectAction();    
                action.Remove(id);  
                return new SuccessResult();  
            }  
            catch (Exception ex)    
            {    
                return new ErrorDataResult<TenantProjectBusinessModel>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPost]    
        private async Task<long> Count([FromBody] DataFilterWithPaging input)    
        {    
            try    
            {    
                var action = new TenentProjectAction();    
                return await action.GetAllCount(GetFilterExpression<TenantProjectBusinessModel>(input.Filters));    
            }    
            catch (Exception ex)    
            {    
                throw ServerException(ex);    
            }    
        }    
    }  
}  
