using Mr.ManoelStore.DTOs;
using Mr.ManoelStore.Models;

namespace Mr.ManoelStore.Services
{
    public class PedidoService : IPedidoService
    {
        private List<CaixaDisponivel> caixasDisponiveis = new()
        {
            new CaixaDisponivel { CaixaId = "Caixa 1", Dimensoes = new Dimensoes { Altura = 30, Largura = 40, Comprimento = 80 } },
            new CaixaDisponivel { CaixaId = "Caixa 2", Dimensoes = new Dimensoes { Altura = 80, Largura = 50, Comprimento = 40 } },
            new CaixaDisponivel { CaixaId = "Caixa 3", Dimensoes = new Dimensoes { Altura = 50, Largura = 80, Comprimento = 60 } }
        };


        public PedidoResponseDto Empacotar(PedidoRequestDto request)
        {
            var resposta = new PedidoResponseDto();

            foreach (var pedido in request.Pedidos)
            {
                var pedidoResposta = new PedidoRespostaItemDto { PedidoId = pedido.PedidoId };

                //Ordena os produtos por volume, priorizando empacotar os produtos maiores primeiro.
                var produtosRestantes = pedido.Produtos.OrderByDescending(p => p.Volume).ToList();

                // Enquanto ainda houver produtos a empacotar. 
                while (produtosRestantes.Any())
                {
                    //Escolhe uma caixa disponível que caiba pelo menos um dos produtos restantes
                    var caixaUsada =
                        caixasDisponiveis
                        .FirstOrDefault(caixa => produtosRestantes.Any(p => p.Dimensoes.CabeEm(caixa.Dimensoes)));


                    // Se nenhum produto cabe em nenhuma caixa
                    if (caixaUsada == null)
                    {
                        pedidoResposta.Caixas.Add(new CaixaRespostaDto
                        {
                            CaixaId = null,
                            Produtos = produtosRestantes.Select(p => p.ProdutoId).ToList(),
                            Observacao = "Produto não cabe em nenhuma caixa disponível."
                        });
                        break;
                    }

                    // Tenta colocar os produtos que cabem na caixa selecionada
                    var produtosNaCaixa = new List<Produto>();
                    foreach (var produto in produtosRestantes)
                    {
                        if (produto.Dimensoes.CabeEm(caixaUsada.Dimensoes))
                        {
                            produtosNaCaixa.Add(produto);
                        }
                    }

                    // Remove esses produtos da lista de produtos restantes
                    produtosNaCaixa.ForEach(p => produtosRestantes.Remove(p));

                    // Adiciona a caixa com os produtos empacotados à resposta
                    pedidoResposta.Caixas.Add(new CaixaRespostaDto
                    {
                        CaixaId = caixaUsada.CaixaId,
                        Produtos = produtosNaCaixa.Select(p => p.ProdutoId).ToList()
                    });
                }

                //Adiciona o resultado do pedido à resposta final
                resposta.Pedidos.Add(pedidoResposta);
            }

            return resposta;
        }
    }
}
