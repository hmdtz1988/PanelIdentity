using BusinessLogic.Action;  
using Microsoft.AspNetCore.Mvc;  
using BusinessModel;  
using Core.Utilities.Results;  
using Core.Extensions;  
using IResult = Core.Utilities.Results.IResult;  
namespace PanelIdentity.Controllers  
{  
    [Route("api/ProjectAccountType/[action]")]  
    public class ProjectAccountTypeController : BaseApiController  
    {  
        private ProjectAccountTypeAction action = new ProjectAccountTypeAction();  
        [HttpGet("{id}")]  
       public async Task<IResult> Get(Int64 id, string includeProperties)   
       {   
           try   
           {   
               var data = await action.Get(id, includeProperties);   
               return new SuccessDataResult<ProjectAccountTypeBusinessModel>(data, 1);  
           }   
           catch (Exception ex)   
           {   
               return new ErrorDataResult<ProjectAccountTypeBusinessModel>(message: ServerException(ex).Message);  
           }   
       }   
        [HttpPost]    
        public async Task<IResult> Get([FromBody] DataFilterWithPaging model)    
        {    
            try    
            {    
                var data = HasPaging(model)    
                    ? await action.GetAll(model.PageNumber, model.PageSize, GetFilterExpression<ProjectAccountTypeBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperties)    
                    : await action.GetAll(GetFilterExpression<ProjectAccountTypeBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperties);    
                var count = await Count(model);  
                return new SuccessDataResult<IList<ProjectAccountTypeBusinessModel>>(data, count);  
            }    
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<ProjectAccountTypeBusinessModel>>(message: ServerException(ex).Message);  
            }    
        }    
        [HttpPost]    
        public async Task<IResult> Suggestion([FromBody] DataFilterWithPaging model)    
        {    
            try    
            {    
                var data = HasPaging(model)    
                    ? await action.GetAll(model.PageNumber, model.PageSize, GetSuggestionExpression<ProjectAccountTypeBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperties)    
                    : await action.GetAll(GetSuggestionExpression<ProjectAccountTypeBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperties);    
                var count = await Count(model);    
                return new SuccessDataResult<IList<ProjectAccountTypeBusinessModel>>(data, count);  
            }    
            catch (Exception ex)    
            {    
                return new ErrorDataResult<IList<ProjectAccountTypeBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpGet]    
        public async Task<IResult> GetAll()    
        {    
            try    
            {    
                var data = await action.GetAll(null, "");    
                return new SuccessDataResult<IList<ProjectAccountTypeBusinessModel>>(data, data.Count);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<ProjectAccountTypeBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPost]
        public async Task<IResult> Post([FromBody] ProjectAccountTypeBusinessModel input)    
        {    
            try    
            {  
                input = await action.Add(input);  
                return new SuccessDataResult<ProjectAccountTypeBusinessModel>(input, 1);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<ProjectAccountTypeBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPut("{id}")]    
        public IResult Put( Int64 id, [FromBody] ProjectAccountTypeBusinessModel input)    
        {    
            try    
            {    
                action.Modify(input);  
                return new SuccessDataResult<ProjectAccountTypeBusinessModel>(input, 1);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<ProjectAccountTypeBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpDelete("{id}")]    
        public IResult Delete(Int64 id)    
        {    
            try    
            {    
                var action = new ProjectAccountTypeAction();    
                action.Remove(id);  
                return new SuccessResult();  
            }  
            catch (Exception ex)    
            {    
                return new ErrorDataResult<ProjectAccountTypeBusinessModel>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPost]    
        private async Task<long> Count([FromBody] DataFilterWithPaging input)    
        {    
            try    
            {    
                var action = new ProjectAccountTypeAction();    
                return await action.GetAllCount(GetFilterExpression<ProjectAccountTypeBusinessModel>(input.Filters));    
            }    
            catch (Exception ex)    
            {    
                throw ServerException(ex);    
            }    
        }    
    }  
}  
