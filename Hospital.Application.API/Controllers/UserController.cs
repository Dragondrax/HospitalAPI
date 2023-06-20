using Hospital.Application.API.Extensions;
using Hospital.Application.API.Model;
using Hospital.Application.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Serilog;
using System.Reflection;

namespace Hospital.Application.API.Controllers
{
    [ApiController]
    [Route("api")]
    //[Authorize]
    public class UserController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IIdentityServices _createRoles;
        private readonly IGenerateToken _generateToken;

        public UserController(SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager,
                              IIdentityServices createRoles, IGenerateToken generateToken)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _createRoles = createRoles;
            _generateToken = generateToken;
        }

        [HttpPost("NewUser")]
        public async Task<IActionResult> NewUser(UserRegisterModel data)
        {
            try
            {
                var user = new IdentityUser
                {
                    UserName = data.Email,
                    Email = data.Email,
                    EmailConfirmed = true,
                };

                var result = await _userManager.CreateAsync(user, data.Password);
                if (result.Succeeded)
                {
                    await _createRoles.CreateRolesAsync();
                    await _userManager.AddToRoleAsync(user, data.Role);
                    return Created("Login", data);
                }
                else
                {
                    return BadRequest(new ResponseMessage
                    {
                        Success = false,
                        Object = result.Errors,
                        Message = "Ocorreu um erro ao criar um usuário novo",
                        MessageError = ""
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error($"O Processo falhou na etapa: {this.ControllerContext.RouteData.Values["controller"].ToString()} - {MethodBase.GetCurrentMethod().DeclaringType.FullName} retornando o erro: {ex.Message} na linha: {ex.LineNumber()}");
                return BadRequest(new ResponseMessage
                {
                    Success = false,
                    Object = null,
                    Message = "Ops, parece que temos um problema! Tente novamente mais tarde ou contate um Administrador",
                    MessageError = ex.Message
                });
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginModel data)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(data.Email, data.Password, false, true);

                if (result.Succeeded)
                {
                    return Ok(new ResponseMessage
                    {
                        Success = true,
                        Object = await _generateToken.GerarJwt(data.Email),
                        Message = "Usuario Logado com Sucesso",
                        MessageError = ""
                    });
                }
                if (result.IsLockedOut)
                {
                    return Unauthorized();
                }

                return NotFound(new ResponseMessage
                {
                    Success = true,
                    Object = await _generateToken.GerarJwt(data.Email),
                    Message = "Usuario ou Senha Incorretos",
                    MessageError = ""
                });
            }
            catch (Exception ex)
            {
                Log.Error($"O Processo falhou na etapa: {this.ControllerContext.RouteData.Values["controller"].ToString()} - {MethodBase.GetCurrentMethod().DeclaringType.FullName} retornando o erro: {ex.Message} na linha: {ex.LineNumber()}");
                return BadRequest(new ResponseMessage
                {
                    Success = false,
                    Object = null,
                    Message = "Ops, parece que temos um problema! Tente novamente mais tarde ou contate um Administrador",
                    MessageError = ex.Message
                });
            }
        }
        [HttpPut("AlterUser")]
        public async Task<IActionResult> AlterUser(AlterUserModel data)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(data.Id);

                user.UserName = data.Email;
                user.Email = data.Email;

                var result =  await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return Ok(new ResponseMessage
                    {
                        Success = true,
                        Object = null,
                        Message = "Usuario Atualizado com Sucesso",
                        MessageError = ""
                    });
                }
                else
                {
                    return BadRequest(new ResponseMessage
                    {
                        Success = false,
                        Object = result.Errors,
                        Message = "Ocorreu um erro ao atualizar um usuário",
                        MessageError = ""
                    });
                }

            }
            catch (Exception ex)
            {
                Log.Error($"O Processo falhou na etapa: {this.ControllerContext.RouteData.Values["controller"].ToString()} - {MethodBase.GetCurrentMethod().DeclaringType.FullName} retornando o erro: {ex.Message} na linha: {ex.LineNumber()}");
                return BadRequest(new ResponseMessage
                {
                    Success = false,
                    Object = null,
                    Message = "Ops, parece que temos um problema! Tente novamente mais tarde ou contate um Administrador",
                    MessageError = ex.Message
                });
            }
        }
    }
}
