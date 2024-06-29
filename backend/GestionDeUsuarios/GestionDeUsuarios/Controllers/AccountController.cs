using Commons.Authentication.Token;
using GestionDeUsuarios.Authentication.Models;
using DatabaseManager.ContextEntities;
using GestionDeUsuarios.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GestionDeUsuarios.Authentication;

namespace GestionDeUsuarios.Controllers
{
    public class AccountController:AppBaseController
    {

   
        private readonly GestionDataContext db;
        private readonly ILogger<AccountController> logger;
        private readonly LoginHelper login;
        public AccountController( ILogger<AccountController> _logger, GestionDataContext _db)

        {
            this.logger = _logger;
            this.db = _db;
            login = new LoginHelper(db);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(typeof(RequestResult), 400)]
        [ProducesResponseType(typeof(RequestResult), 200)]
        public async Task<ActionResult<RequestResult>> Login([FromBody, FromForm] UserModel model)
        {
            try
            {
                
                var user = login.Login(model);
                if (user != null)
                {
                    var token = await TokenUtility.CreateToken(user, GetUserDatetimeFromOffset()); 
                    return Ok(new RequestResult
                    {
                        Success = true,
                        Message = "Success",
                        Result = token
                    });
                }
                return BadRequest(new RequestResult());
            }
            catch (Exception ex)
            {
                return BadRequest(new RequestResult());
            }
        }


        [HttpPost("refresh-token")]
        public async Task<ActionResult<RequestResult>> RefreshToken([FromBody] TokenModel model)
        {
            try
            {
                if (!this.ModelState.IsValid) return BadRequest(new RequestResult
                {
                    Success = false,
                    Result = new 
                    {
                        Message = "No data in body"
                    }
                });

                var refreshed = await TokenUtility.RefreshToken(model.Token, GetUserDatetimeFromOffset()); //tokenUser.RefreshToken(model.Token, GetUserDatetimeFromOffset());

                if (refreshed == null)
                {
                    return BadRequest();
                }
                return Ok(new RequestResult
                {
                    Success = true,
                    Result = refreshed
                });
            }
            catch (Exception )
            {
                return BadRequest();
            }
        }


        //[ProducesResponseType(typeof(RequestResult), 400)]
        //[ProducesResponseType(typeof(RequestResult), 200)]
        //[SuperAdmin]
        //[HttpPost("register")]
        //public async Task<ActionResult<RequestResult>> Register([FromBody, FromForm] RegisterModel model)
        //{
        //    try
        //    {
        //        var user = new AppUser
        //        {
        //            UserName = model.Username,
        //            Email = model.Email,
        //            PhoneNumber = model.PhoneNumber,
        //        };

        //        bool exist = appUser.ExistUser(user);
        //        if (exist)
        //        {
        //            return BadRequest();
        //        }

        //        var result = await appUser.Register(model);
        //        if (result.Succeeded)
        //        {
        //            if (AutoAddToRol)
        //            {
        //                bool r = await appUser.AddToRol(model.Username, "Guest");
        //            }
        //            return Ok(new RequestResult
        //            {
        //                Success = true,
        //                Message = "User created"
        //            });
        //        }

        //        return BadRequest(new RequestResult
        //        {
        //            Result = new 
        //            {
        //                Details = result.Errors
        //            }
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }
        //}



        [HttpPost("change-password")]
        public async Task<ActionResult<RequestResult>> ChangePassword(PasswordChange model)
        {
            try
            {
                bool result = login.changePassword(model);
                if (result)
                {
                    return Ok(new RequestResult { Success = true });
                }
                return BadRequest(new RequestResult
                {
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
