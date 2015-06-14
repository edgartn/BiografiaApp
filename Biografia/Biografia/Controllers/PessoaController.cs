using Biografia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Biografia.Controllers
{
    public class PessoaController : ApiController
    {
        static readonly IPessoaRepositorio repository = new PessoaRepositorio();
        //
        // GET: /Pessoa/    
        public IEnumerable<Pessoa> Get()
        {
            return repository.GetAll();
        }

        public Pessoa GetPessoa(int id)
        {
            Pessoa item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public HttpResponseMessage PostPessoa(Pessoa item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Pessoa>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }


        public void PutPessoa(int id, Pessoa Pessoa)
        {
            Pessoa.Id = id;
            if (!repository.Update(Pessoa))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeletePessoa(int id)
        {
            Pessoa item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(id);
        }
    }
}
