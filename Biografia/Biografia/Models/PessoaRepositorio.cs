using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biografia.Models
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private List<Pessoa> pessoas = new List<Pessoa>();
        private int _nextId = 1;

        public PessoaRepositorio()
        {
            Add(new Pessoa { Nome = "Gumercindo", DataNascimento = Convert.ToDateTime("21/06/1992") , Biografia = "Nasceu e vive até hoje"});
            Add(new Pessoa { Nome = "Jurubela", DataNascimento = Convert.ToDateTime("18/12/1998"), Biografia = "Vivendo" });
            Add(new Pessoa { Nome = "Albertina", DataNascimento = Convert.ToDateTime("20/02/1996"), Biografia = "Mais para lá do que para cá" });
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return pessoas;
        }

        public Pessoa Get(int id)
        {
            return pessoas.Find(p => p.Id == id);
        }

        public Pessoa Add(Pessoa item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            pessoas.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            pessoas.RemoveAll(p => p.Id == id);
        }

        public bool Update(Pessoa item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = pessoas.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            pessoas.RemoveAt(index);
            pessoas.Add(item);
            return true;
        }
    }
}