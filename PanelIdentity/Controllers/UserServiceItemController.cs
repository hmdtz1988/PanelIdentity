using BusinessLogic.Action;  
using Microsoft.AspNetCore.Mvc;  
using BusinessModel;  
using Core.Utilities.Results;  
using Core.Extensions;  
using IResult = Core.Utilities.Results.IResult;  
namespace PanelIdentity.Controllers  
{  
    [Route("api/UserServiceItem/[action]")]  
    public class UserServiceItemController : BaseApiController  
    {  
        private UserServiceItemAction action = new UserServiceItemAction();  
        [HttpGet("{id}")]  
       public async Task<IResult> Get(Int64 id)   
       {   
           try   
           {   
               var data = await action.Get(id);   
               return new SuccessDataResult<UserServiceItemBusinessModel>(data, 1);  
           }   
           catch (Exception ex)   
           {   
               return new ErrorDataResult<UserServiceItemBusinessModel>(message: ServerException(ex).Message);  
           }   
       }   
        [HttpPost]    
        public async Task<IResult> Get([FromBody] DataFilterWithPaging model)    
        {    
            try    
            {    
                var data = HasPaging(model)    
                    ? await action.GetAll(model.PageNumber, model.PageSize, GetFilterExpression<UserServiceItemBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperies)    
                    : await action.GetAll(GetFilterExpression<UserServiceItemBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperies);    
                var count = await Count(model);  
                return new SuccessDataResult<IList<UserServiceItemBusinessModel>>(data, count);  
            }    
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<UserServiceItemBusinessModel>>(message: ServerException(ex).Message);  
            }    
        }    
        [HttpPost]    
        public async Task<IResult> Suggestion([FromBody] DataFilterWithPaging model)    
        {    
            try    
            {    
                var data = HasPaging(model)    
                    ? await action.GetAll(model.PageNumber, model.PageSize, GetSuggestionExpression<UserServiceItemBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperies)    
                    : await action.GetAll(GetSuggestionExpression<UserServiceItemBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperies);    
                var count = await Count(model);    
                return new SuccessDataResult<IList<UserServiceItemBusinessModel>>(data, count);  
            }    
            catch (Exception ex)    
            {    
                return new ErrorDataResult<IList<UserServiceItemBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpGet]    
        public async Task<IResult> GetAll()    
        {    
            try    
            {    
                var data = await action.GetAll(null, "");    
                return new SuccessDataResult<IList<UserServiceItemBusinessModel>>(data, data.Count);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<UserServiceItemBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPost]    
        public IResult Post([FromBody] UserServiceItemBusinessModel input)    
        {    
            try    
            {  
                action.Add(input);  
                return new SuccessDataResult<UserServiceItemBusinessModel>(input, 1);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<UserServiceItemBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPut("{id}")]    
        public IResult Put( Int64 id, [FromBody] UserServiceItemBusinessModel input)    
        {    
            try    
            {    
                action.Modify(input);  
                return new SuccessDataResult<UserServiceItemBusinessModel>(input, 1);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<UserServiceItemBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpDelete("{id}")]    
        public IResult Delete(Int64 id)    
        {    
            try    
            {    
                var action = new UserServiceItemAction();    
                action.Remove(id);  
                return new SuccessResult();  
            }  
            catch (Exception ex)    
            {    
                return new ErrorDataResult<UserServiceItemBusinessModel>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPost]    
        private async Task<long> Count([FromBody] DataFilterWithPaging input)    
        {    
            try    
            {    
                var action = new UserServiceItemAction();    
                return await action.GetAllCount(GetFilterExpression<UserServiceItemBusinessModel>(input.Filters));    
            }    
            catch (Exception ex)    
            {    
                throw ServerException(ex);    
            }    
        }    
    }  
}  
