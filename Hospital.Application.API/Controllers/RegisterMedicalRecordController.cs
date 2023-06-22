using Hospital.Application.API.Extensions;
using Hospital.Application.API.Model;
using Hospital.Application.API.Services;
using Hospital.Application.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Reflection;

namespace Hospital.Application.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class RegisterMedicalRecordController : Controller
    {
        private readonly IMedicalRecordService _medicalRecordService;
        public RegisterMedicalRecordController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterMedicalRecord(RegisterMedicalRecordModel data)
        {
            try
            {
                if (!ValidatedValues.ValidatedCPF(data.CPF))
                    return BadRequest(new ResponseMessage
                    {
                        Success = false,
                        Object = null,
                        Message = "Ops, parece que o CPF nao e valido",
                        MessageError = ""
                    });

                var result = await _medicalRecordService.SaveAsync(data);

                if (result.Message == "Sucesso")
                    return Ok(new ResponseMessage
                    {
                        Success = true,
                        Object = result.Object,
                        Message = "Sucesso",
                        MessageError = ""
                    });
                else if (result.Message == "O CPF ja esta registrado no sistema")
                    return Conflict(new ResponseMessage
                    {
                        Success = true,
                        Object = null,
                        Message = "O CPF ja esta registrado no sistema",
                        MessageError = ""
                    });
                else
                    return BadRequest(new ResponseMessage
                    {
                        Success = false,
                        Object = null,
                        Message = "Ops, parece que temos um problema! Tente novamente mais tarde ou contate um Administrador",
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

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateMedicalRecord(UpdateMedicalRecordModel data)
        {
            try
            {
                if (!ValidatedValues.ValidatedCPF(data.CPF))
                    return BadRequest(new ResponseMessage
                    {
                        Success = false,
                        Object = null,
                        Message = "Ops, parece que o CPF nao e valido",
                        MessageError = ""
                    });

                var result = await _medicalRecordService.UpdateAsync(data);

                if (result.Message == "Sucesso")
                    return Ok(new ResponseMessage
                    {
                        Success = true,
                        Object = result.Object,
                        Message = "Sucesso",
                        MessageError = ""
                    });
                else if (result.Message == "Id Nao Encontrado")
                    return NotFound(new ResponseMessage
                    {
                        Success = true,
                        Object = null,
                        Message = "Id Nao Encontrado",
                        MessageError = ""
                    });
                else
                    return BadRequest(new ResponseMessage
                    {
                        Success = false,
                        Object = null,
                        Message = "Ops, parece que temos um problema! Tente novamente mais tarde ou contate um Administrador",
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

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteMedicalRecord(string Id)
        {
            try
            {
                var result = await _medicalRecordService.DeleteAsync(Id);

                if (result.Message == "Sucesso")
                    return Ok(new ResponseMessage
                    {
                        Success = true,
                        Object = result.Object,
                        Message = "Sucesso",
                        MessageError = ""
                    });
                else if (result.Message == "Id Nao Encontrado")
                    return NotFound(new ResponseMessage
                    {
                        Success = true,
                        Object = null,
                        Message = "Id Nao Encontrado",
                        MessageError = ""
                    });
                else
                    return BadRequest(new ResponseMessage
                    {
                        Success = false,
                        Object = null,
                        Message = "Ops, parece que temos um problema! Tente novamente mais tarde ou contate um Administrador",
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
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _medicalRecordService.GetAllAsync();

                if (result.Message == "Sucesso")
                    return Ok(new ResponseMessage
                    {
                        Success = true,
                        Object = result.Object,
                        Message = "Sucesso",
                        MessageError = ""
                    });
                else
                    return BadRequest(new ResponseMessage
                    {
                        Success = false,
                        Object = null,
                        Message = "Ops, parece que temos um problema! Tente novamente mais tarde ou contate um Administrador",
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
    }
}
