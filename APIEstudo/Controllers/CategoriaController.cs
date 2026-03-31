using APIEstudo.Application.Commands.Categorias;
using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Queries.Categorias;
using APIEstudo.Application.Responses;
using APIEstudo.Application.Responses.Categorias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIEstudo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICommandHandler<CreateCategoriaCommand, MensagemResponse> _createHandler;
        private readonly ICommandHandler<UpdateCategoriaCommand, MensagemResponse> _updateHandler;
        private readonly ICommandHandler<DeleteCategoriaCommand, MensagemResponse> _deleteHandler;
        private readonly IQueryHandler<GetAllCategoriaQuery, List<GetAllCategoriaResponse>> _getAllCategoria;
        
        public CategoriaController(ICommandHandler<CreateCategoriaCommand, MensagemResponse> createHandler,
                                    IQueryHandler<GetAllCategoriaQuery, List<GetAllCategoriaResponse>> getAllCategoria,
                                    ICommandHandler<UpdateCategoriaCommand, MensagemResponse> updateHandler,
                                    ICommandHandler<DeleteCategoriaCommand, MensagemResponse> deleteHandler) 
        { 
            _createHandler = createHandler;
            _getAllCategoria = getAllCategoria;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
        }

        [Authorize]
        [HttpPost("criarCategoria")]
        public async Task<IActionResult> CreateCategoria([FromBody] CreateCategoriaCommand command)
        {
            try
            {
                var mensagem = await _createHandler.HandleAsync(command);
                return Ok(mensagem);
            }
            catch (Exception ex) 
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("obterCategorias")]
        public async Task<IActionResult> GetAllCategorias()
        {
            try
            {
                var result = await _getAllCategoria.HandleAsync(new GetAllCategoriaQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("updateCategoria")]
        public async Task<IActionResult> UpdateCategorias([FromBody] UpdateCategoriaCommand command)
        {
            try
            {
                var result = await _updateHandler.HandleAsync(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("deleteCategoria/{id}")]
        public async Task<IActionResult> DeleteCategorias(Guid id)
        {
            try
            {
                var idCategoria = new DeleteCategoriaCommand(id);

                var result = await _deleteHandler.HandleAsync(idCategoria);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}
