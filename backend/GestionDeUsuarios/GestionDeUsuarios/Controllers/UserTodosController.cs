using DatabaseManager.ContextEntities;
using DatabaseManager.Entities;
using GestionDeUsuarios.Authentication.Filters.Roles.Dynamics.Users;
using GestionDeUsuarios.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDeUsuarios.Controllers
{
    [AuthorizeApp]
    public class UserTodosController : AppBaseController
    {
        public readonly GestionDataContext db;
        public readonly ILogger<UserTodosController> logger;
        public UserTodosController(ILogger<UserTodosController> logger, GestionDataContext db)
        {
            this.logger = logger;
            this.db = db;
        }

        [HttpPost("add")]
        public async Task<ActionResult<RequestResult>> Add(UserTodos entity)
        {
            try
            {
                db.UserTodos.Add(entity);
                await db.SaveChangesAsync();

                return Ok(new RequestResult
                {
                    Success = true,
                    Result = entity,
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
        public async Task<ActionResult<RequestResult>> Update(UserTodos entity)
        {
            try
            {
                var model = await db.UserTodos.AsNoTracking()
                    .Where(m => m.UserId == GetUserId() && m.Id == entity.Id).FirstOrDefaultAsync();

                if (model == null)
                    return NotFound(new RequestResult());

                db.UserTodos.Update(entity);
                await db.SaveChangesAsync();

                return Ok(new RequestResult
                {
                    Success = true,
                    Result = entity,
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
        public async Task<ActionResult<RequestResult>> Delete(UserTodos entity)
        {
            try
            {
                var model = await db.UserTodos.Where(m => m.UserId == GetUserId() && m.Id == entity.Id).FirstOrDefaultAsync();
                if (model == null) return NotFound(new RequestResult());
                db.UserTodos.Remove(model);
                await db.SaveChangesAsync();
                return Ok(new RequestResult
                {
                    Success = true,
                    Result = model,
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
                    Result = model
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
                var result = await db.UserTodos.Where(m => m.UserId == GetUserId()).Skip(page * pagesize).Take(pagesize).ToArrayAsync();
                if (result.Length == 0)
                    return NotFound(new RequestResult());

                return Ok(new RequestResult
                {
                    Success = true,
                    Result = result
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
