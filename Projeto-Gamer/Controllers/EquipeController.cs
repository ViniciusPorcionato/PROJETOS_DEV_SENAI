using Microsoft.AspNetCore.Mvc;
using Projeto_Gamer.Infra;
using Projeto_Gamer.Models;

namespace Projeto_Gamer.Controllers
{
    [Route("[controller]")]
    public class EquipeController : Controller
    {
        private readonly ILogger<EquipeController> _logger;

        public EquipeController(ILogger<EquipeController> logger)
        {
            _logger = logger;
        }
        // Instância do objeto da classe Context : Acessa o banco de dados
        Context context = new Context();
        //Controller/Action
        [Route("Listar")] // https://localhost/Equipe/Listar
        public IActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            // A ViewBag é uma "bolsa" para guardar instâncias do objeto Equipe, como uma lista
            ViewBag.Equipe = context.Equipe.ToList();
            // Retorna a View de equipe
            return View();
        }


        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe = new Equipe();

            novaEquipe.Nome = form["Nome"].ToString();

            // vem como string, o que precisamos é imagem
            // novaEquipe.Imagem = form["Imagem"].ToString();

            // lógica do upload de imagem
            if (form.Files.Count > 0)
            {
                var file = form.Files[0];
                // variavel criando combinações de caminhos
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipe");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(folder, file.FileName);

                // using é o bloco de codigo onde após de terminar ele se encerra
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                novaEquipe.Imagem = file.FileName;

            }
            else
            {
                novaEquipe.Imagem = "default.png";
            }
            // fima da lógica de upload

            context.Equipe.Add(novaEquipe);
            // c.Add(novaEquipe) - Isso também funciona

            context.SaveChanges();

            return LocalRedirect("~/Equipe/Listar");

        }

        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            // procurar o id na lista de equipes, pega nome, id e imagem e remove
            Equipe e = context.Equipe.First(e => e.IdEquipe == id);
            context.Equipe.Remove(e);
            context.SaveChanges();

            return LocalRedirect("~/Equipe/Listar");
        }


        [Route("Editar/{id}")]
        // Pegar o objeto(time) e disponibilizar em outra tela
        public IActionResult Editar(int id)
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            Equipe e = context.Equipe.First(e => e.IdEquipe == id);

            ViewBag.Equipe = e;

            return View("Edit");

        }


        [Route("Atualizar")]
        public IActionResult Atualizar(IFormCollection form, Equipe e)
        {

            Equipe novaEquipe = new Equipe();
            novaEquipe.Nome = e.Nome;
            Equipe equipe = context.Equipe.First(x => x.IdEquipe == e.IdEquipe);

            // upload da imagem na equipe nova(atualizada)
            if (form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipe");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }


                novaEquipe.Imagem = file.FileName;

                equipe.Imagem = novaEquipe.Imagem;
            }

            equipe.Nome = novaEquipe.Nome;


            context.Equipe.Update(equipe);
            context.SaveChanges();

            return LocalRedirect("~/Equipe/Listar");

        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}