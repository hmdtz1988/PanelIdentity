using BusinessLogic.Action;  
using Microsoft.AspNetCore.Mvc;  
using BusinessModel;  
using Core.Utilities.Results;  
using Core.Extensions;  
using IResult = Core.Utilities.Results.IResult;  
namespace PanelIdentity.Controllers  
{  
    [Route("api/Project/[action]")]  
    public class ProjectController : BaseApiController  
    {  
        private ProjectAction action = new ProjectAction();  
        [HttpGet("{id}")]  
       public async Task<IResult> Get(Int64 id, string includeProperties)   
       {   
           try   
           {   
               var data = await action.Get(id, includeProperties);   
               return new SuccessDataResult<ProjectBusinessModel>(data, 1);  
           }   
           catch (Exception ex)   
           {   
               return new ErrorDataResult<ProjectBusinessModel>(message: ServerException(ex).Message);  
           }   
       }   
        [HttpPost]    
        public async Task<IResult> Get([FromBody] DataFilterWithPaging model)    
        {    
            try    
            {    
                var data = HasPaging(model)    
                    ? await action.GetAll(model.PageNumber, model.PageSize, GetFilterExpression<ProjectBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperties)    
                    : await action.GetAll(GetFilterExpression<ProjectBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperties);    
                var count = await Count(model);  
                return new SuccessDataResult<IList<ProjectBusinessModel>>(data, count);  
            }    
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<ProjectBusinessModel>>(message: ServerException(ex).Message);  
            }    
        }    
        [HttpPost]    
        public async Task<IResult> Suggestion([FromBody] DataFilterWithPaging model)    
        {    
            try    
            {    
                var data = HasPaging(model)    
                    ? await action.GetAll(model.PageNumber, model.PageSize, GetSuggestionExpression<ProjectBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperties)    
                    : await action.GetAll(GetSuggestionExpression<ProjectBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperties);    
                var count = await Count(model);    
                return new SuccessDataResult<IList<ProjectBusinessModel>>(data, count);  
            }    
            catch (Exception ex)    
            {    
                return new ErrorDataResult<IList<ProjectBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpGet]    
        public async Task<IResult> GetAll()    
        {    
            try    
            {    
                var data = await action.GetAll(null, "");    
                return new SuccessDataResult<IList<ProjectBusinessModel>>(data, data.Count);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<ProjectBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPost]    
        public async Task<IResult> Post([FromBody] ProjectBusinessModel input)    
        {    
            try    
            {  
                input = await action.Add(input);  
                return new SuccessDataResult<ProjectBusinessModel>(input, 1);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<ProjectBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPut("{id}")]    
        public IResult Put( Int64 id, [FromBody] ProjectBusinessModel input)    
        {    
            try    
            {    
                action.Modify(input);  
                return new SuccessDataResult<ProjectBusinessModel>(input, 1);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<ProjectBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpDelete("{id}")]    
        public IResult Delete(Int64 id)    
        {    
            try    
            {    
                var action = new ProjectAction();    
                action.Remove(id);  
                return new SuccessResult();  
            }  
            catch (Exception ex)    
            {    
                return new ErrorDataResult<ProjectBusinessModel>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPost]    
        private async Task<long> Count([FromBody] DataFilterWithPaging input)    
        {    
            try    
            {    
                var action = new ProjectAction();    
                return await action.GetAllCount(GetFilterExpression<ProjectBusinessModel>(input.Filters));    
            }    
            catch (Exception ex)    
            {    
                throw ServerException(ex);    
            }    
        }    
    }  
}  
