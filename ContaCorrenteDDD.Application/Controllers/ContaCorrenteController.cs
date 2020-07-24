using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContaCorrenteDDD.Domain.Entities;
using ContaCorrenteDDD.Service.Services;
using ContaCorrenteDDD.Service.Validators;

namespace ContaCorrenteDDD.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        private BaseService<ContaCorrente> service = new BaseService<ContaCorrente>();

        [HttpPost]
        public IActionResult Post([FromBody] ContaCorrente item)
        {
            try
            {
                service.Post<ContaCorrenteValidator>(item);

                return new ObjectResult(item.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]        
        public IActionResult Put([FromBody] ContaCorrente item)
        {
            try
            {
                string mensagemValidacaoOperacao = item.ValidarOperacao(item.ValorDebito, item.ValorCredito);

                if (string.IsNullOrEmpty(mensagemValidacaoOperacao ))
                {                                     
                    service.Put<ContaCorrenteValidator>(item);
                    return new ObjectResult(item);
                }
                else
                    throw new Exception(mensagemValidacaoOperacao);              
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
   

                [HttpDelete("{id}")]
                public IActionResult Delete(int id)
                {
                    try
                    {
                        service.Delete(id);

                        return new NoContentResult();
                    }
                    catch (ArgumentException ex)
                    {
                        return NotFound(ex);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex);
                    }
                }

                [HttpGet]
                public IActionResult Get()
                {
                    try
                    {
                        return new ObjectResult(service.Get());
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex);
                    }
                }

                [HttpGet("{id}", Name = "Get")]
                public IActionResult Get(int id)
                {
                    try
                    {
                        return new ObjectResult(service.Get(id));
                    }
                    catch (ArgumentException ex)
                    {
                        return NotFound(ex);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex);
                    }
                }
        
    }
}