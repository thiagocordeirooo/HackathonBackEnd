using HackathonBackEnd.Data.Models;
using HackathonBackEnd.Data.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace HackathonBackEnd.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            TesteRepository repo = new TesteRepository(Models.Colecoes.Teste);
            TesteDocument model = new TesteDocument() { Nome = "Teste1", value = 1 };

            repo.Insere(model);

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
