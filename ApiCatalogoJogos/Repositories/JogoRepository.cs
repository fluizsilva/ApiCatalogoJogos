using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("96d70b17-07b6-450d-b571-7c327c96c6fe"),new Jogo{id = Guid.Parse("96d70b17-07b6-450d-b571-7c327c96c6fe"), Nome = "Fifa 21", Produtora = "EA", Preco = 200 } },
            {Guid.Parse("7f8b02cf-73d1-48d8-97bd-13fe7d7ee617"),new Jogo{id = Guid.Parse("7f8b02cf-73d1-48d8-97bd-13fe7d7ee617"), Nome = "Fifa 20", Produtora = "EA", Preco = 190 } },
            {Guid.Parse("cc1bb216-70e5-4b8f-95a1-d9b794628ac4"),new Jogo{id = Guid.Parse("cc1bb216-70e5-4b8f-95a1-d9b794628ac4"), Nome = "Fifa 19", Produtora = "EA", Preco = 180 } },
            {Guid.Parse("37e675fe-ac58-45ec-b9a0-113f8798e772"),new Jogo{id = Guid.Parse("37e675fe-ac58-45ec-b9a0-113f8798e772"), Nome = "Fifa 18", Produtora = "EA", Preco = 170 } },
            {Guid.Parse("703e2dc5-7395-49bb-8270-5845d0fe6c3c"),new Jogo{id = Guid.Parse("703e2dc5-7395-49bb-8270-5845d0fe6c3c"), Nome = "stret Fighter V", Produtora = "Capcom", Preco = 80 } },
            {Guid.Parse("53e0a4df-13f0-42ea-a943-84c61aa0c3b0"),new Jogo{id = Guid.Parse("53e0a4df-13f0-42ea-a943-84c61aa0c3b0"), Nome = "Grand Theft Auto V", Produtora = "Rockstar", Preco = 190 } },
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina-1)*quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());

        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.id, jogo);
            return Task.CompletedTask;
        }


        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //fechar a conexao com o banco
        }


    }
}