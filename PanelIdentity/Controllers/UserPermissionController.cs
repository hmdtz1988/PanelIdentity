using BusinessLogic.Action;  
using Microsoft.AspNetCore.Mvc;  
using BusinessModel;  
using Core.Utilities.Results;  
using Core.Extensions;  
using IResult = Core.Utilities.Results.IResult;  
namespace PanelIdentity.Controllers  
{  
    [Route("api/UserPermission/[action]")]  
    public class UserPermissionController : BaseApiController  
    {  
        private UserPermissionAction action = new UserPermissionAction();  
        [HttpGet("{id}")]  
       public async Task<IResult> Get(Int64 id, string includeProperties)   
       {   
           try   
           {   
               var data = await action.Get(id, includeProperties);   
               return new SuccessDataResult<UserPermissionBusinessModel>(data, 1);  
           }   
           catch (Exception ex)   
           {   
               return new ErrorDataResult<UserPermissionBusinessModel>(message: ServerException(ex).Message);  
           }   
       }   
        [HttpPost]    
        public async Task<IResult> Get([FromBody] DataFilterWithPaging model)    
        {    
            try    
            {    
                var data = HasPaging(model)    
                    ? await action.GetAll(model.PageNumber, model.PageSize, GetFilterExpression<UserPermissionBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperties)    
                    : await action.GetAll(GetFilterExpression<UserPermissionBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperties);    
                var count = await Count(model);  
                return new SuccessDataResult<IList<UserPermissionBusinessModel>>(data, count);  
            }    
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<UserPermissionBusinessModel>>(message: ServerException(ex).Message);  
            }    
        }    
        [HttpPost]    
        public async Task<IResult> Suggestion([FromBody] DataFilterWithPaging model)    
        {    
            try    
            {    
                var data = HasPaging(model)    
                    ? await action.GetAll(model.PageNumber, model.PageSize, GetSuggestionExpression<UserPermissionBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperties)    
                    : await action.GetAll(GetSuggestionExpression<UserPermissionBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperties);    
                var count = await Count(model);    
                return new SuccessDataResult<IList<UserPermissionBusinessModel>>(data, count);  
            }    
            catch (Exception ex)    
            {    
                return new ErrorDataResult<IList<UserPermissionBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpGet]    
        public async Task<IResult> GetAll()    
        {    
            try    
            {    
                var data = await action.GetAll(null, "");    
                return new SuccessDataResult<IList<UserPermissionBusinessModel>>(data, data.Count);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<UserPermissionBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPost]    
        public async Task<IResult> Post([FromBody] UserPermissionBusinessModel input)    
        {    
            try    
            {  
                input = await action.Add(input);  
                return new SuccessDataResult<UserPermissionBusinessModel>(input, 1);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<UserPermissionBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPut("{id}")]    
        public IResult Put( Int64 id, [FromBody] UserPermissionBusinessModel input)    
        {    
            try    
            {    
                action.Modify(input);  
                return new SuccessDataResult<UserPermissionBusinessModel>(input, 1);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<UserPermissionBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpDelete("{id}")]    
        public IResult Delete(Int64 id)    
        {    
            try    
            {    
                var action = new UserPermissionAction();    
                action.Remove(id);  
                return new SuccessResult();  
            }  
            catch (Exception ex)    
            {    
                return new ErrorDataResult<UserPermissionBusinessModel>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPost]    
        private async Task<long> Count([FromBody] DataFilterWithPaging input)    
        {    
            try    
            {    
                var action = new UserPermissionAction();    
                return await action.GetAllCount(GetFilterExpression<UserPermissionBusinessModel>(input.Filters));    
            }    
            catch (Exception ex)    
            {    
                throw ServerException(ex);    
            }    
        }    
    }  
}  
