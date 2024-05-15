using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly OpeningTimeOption _option;
        public ProjectsController(IOptions<OpeningTimeOption> option)
        {
            _option = option.Value;
        }
        // api/projects?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            //buscar todos ou filtrar
            return Ok();
        }

        // api/projects/599 - consultar um project especifico
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            //Buscar o projeto
            // return NotFound();
            return Ok();
        }

        [HttpPost]

        public IActionResult Post([FromBody] CreateProjectModel createProject)
        {
            // return BadRequest()
            if (createProject.Title.Length > 50)
            {
                return BadRequest();
            }

            // Cadastrar o projeto
            return CreatedAtAction(nameof(GetById), new {id = createProject.Id}, createProject);
        }

        // api.projects/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProject)
        {
            if (updateProject.Description.Length > 200)
            {
                return BadRequest();
            }

            // Atualiza o objeto
            return NoContent ();
        }

        // api/projects/3 DELETE
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            //Buscar, se não existir, retorna NotFound

            //Remover
            return NoContent();
        }


        //Cadastrar um comentário no projeto
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentModel createComment)
        {
            return NoContent();
        }

        //Inicializacao do projeto
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }


        //api para finalizar projeto
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            return NoContent();
        }
    }
}
