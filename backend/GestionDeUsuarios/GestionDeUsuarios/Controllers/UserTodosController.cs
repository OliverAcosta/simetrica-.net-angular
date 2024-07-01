using DatabaseManager.ContextEntities;
using DatabaseManager.Entities;
using GestionDeUsuarios.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace GestionDeUsuarios.Controllers
{
    
    public class UserTodosController : AppBaseController
    {
        public readonly GestionDataContext db;
        public readonly ILogger<UserTodosController> logger;
        public UserTodosController(ILogger<UserTodosController> logger, GestionDataContext db)
        {
            this.logger = logger;
            this.db = db;
        }
        

        [HttpPost("Add")]
        public async Task<ActionResult<RequestResult>> Add(UserTodosModel model)
        {
            try
            {
                model.Id = 0;
                model.UserId = GetUserId();            
                var entity = model.ToEntity();
                db.UserTodos.Add(entity);
                await db.SaveChangesAsync();

                return Ok(new RequestResult
                {
                    Success = true,
                    Result = entity.ToModel(),
                    Message = "entity added"
                });
            }
            catch (Exception ex)
            {

                logger.LogError(ex.ToString());
                return BadRequest(new RequestResult
                {
                    Message = "some error in the server contact the developer"
                });
            }

        }

        [HttpPost("update")]
        public async Task<ActionResult<RequestResult>> Update(UserTodosModel model)
        {
            try
            {
                var entity = await db.UserTodos.AsNoTracking()
                    .Where(m => m.UserId == GetUserId() && m.Id == model.Id).FirstOrDefaultAsync();

                if (entity == null)
                    return NotFound(new RequestResult());

                db.UserTodos.Update(model.ToEntity());
                await db.SaveChangesAsync();

                return Ok(new RequestResult
                {
                    Success = true,
                    Result = entity.ToModel(),
                    Message = "entity added"
                });
            }
            catch (Exception ex)
            {

                logger.LogError(ex.ToString());
                return BadRequest(new RequestResult
                {
                    Message = "some error in the server contact the developer"
                });
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<RequestResult>> Delete(UserTodosModel model)
        {
            try
            {
                var entity = await db.UserTodos.Where(m => m.UserId == GetUserId() && m.Id == model.Id).FirstOrDefaultAsync();
                if (entity == null) return NotFound(new RequestResult());
                db.UserTodos.Remove(entity);
                await db.SaveChangesAsync();
                return Ok(new RequestResult
                {
                    Success = true,
                    Result = entity.ToModel(),
                    Message = $"entity {entity.Id} has been removed"
                });
            }
            catch (Exception ex)
            {

                logger.LogError(ex.ToString());
                return BadRequest(new RequestResult
                {
                    Message = "some error in the server contact the developer"
                });
            }
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<RequestResult>> Get(int id)
        {
            try
            {
                var model = await db.UserTodos.Where(m => m.UserId == GetUserId() && m.Id == id).FirstOrDefaultAsync();
                if (model == null) return NotFound(new RequestResult());
                return Ok(new RequestResult
                {
                    Success = true,
                    Result = model.ToModel()
                });
            }
            catch (Exception ex)
            {

                logger.LogError(ex.ToString());
                return BadRequest(new RequestResult
                {
                    Message = "some error in the server contact the developer"
                });
            }
        }

        [HttpGet("paginate/{page}/{pagesize}")]
        public async Task<ActionResult<RequestResult>> Paginate(int page = 0, int pagesize = 10)
        {
            try
            {
                int userid = GetUserId();
                var total = db.UserTodos.Where(m => m.UserId == userid).Count();
                var result = await db.UserTodos.Where(m => m.UserId == userid).Skip(page * pagesize).Take(pagesize).Select(m=> m.ToModel()).ToArrayAsync();
                if (result.Length == 0)
                    return NotFound(new RequestResult());

                return Ok(new RequestResult
                {
                    Success = true,
                    Result = new
                    {
                        datos = result,
                        total
                    }
                });
            }
            catch (Exception ex)
            {

                logger.LogError(ex.ToString());
                return BadRequest(new RequestResult
                {
                    Message = "some error in the server contact the developer"
                });
            }
        }
    }
}
