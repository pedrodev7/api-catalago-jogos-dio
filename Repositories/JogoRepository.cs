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
            {Guid.Parse("5ecac88f-2c20-4c16-926a-ff9c3d1c36f4"), new Jogo{ Id = Guid.Parse("5ecac88f-2c20-4c16-926a-ff9c3d1c36f4"), Nome = "FIFA 21", Produtora = "EA", Preco = 200} },
            {Guid.Parse("f5f0426b-d646-44a1-8bdb-b4d222a2bdb9"), new Jogo{ Id = Guid.Parse("f5f0426b-d646-44a1-8bdb-b4d222a2bdb9"), Nome = "FIFA 20", Produtora = "EA", Preco = 170} },
            {Guid.Parse("8564858c-a76e-469c-8bb1-dd2548992719"), new Jogo{ Id = Guid.Parse("8564858c-a76e-469c-8bb1-dd2548992719"), Nome = "FIFA 19", Produtora = "EA", Preco = 150} },
            {Guid.Parse("09b70a3a-e58a-482c-b28f-70cbafdb9386"), new Jogo{ Id = Guid.Parse("09b70a3a-e58a-482c-b28f-70cbafdb9386"), Nome = "GTA V", Produtora = "ROCKSTAR", Preco = 270} },
            {Guid.Parse("a1ad7b8f-f63c-4b06-abee-6e9a9d266283"), new Jogo{ Id = Guid.Parse("a1ad7b8f-f63c-4b06-abee-6e9a9d266283"), Nome = "GTA IV", Produtora = "ROCKSTAR", Preco = 120} },
            {Guid.Parse("fae12d1b-58d1-419a-bee5-cf94e8a5aa60"), new Jogo{ Id = Guid.Parse("fae12d1b-58d1-419a-bee5-cf94e8a5aa60"), Nome = "NEED FOR SPEED UNDERGROUND 3", Produtora = "EA", Preco = 500} }
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade) 
        { 
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
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

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora) 
        {
            var retorno = new List<Jogo>();

            foreach (var jogo in jogos.Values) 
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo) 
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }


        public Task Remover(Guid id) 
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose() 
        { 
            // Fechar conexão com o banco de dados
        }
    }
}
