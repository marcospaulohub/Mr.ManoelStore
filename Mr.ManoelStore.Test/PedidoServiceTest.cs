using Mr.ManoelStore.DTOs;
using Mr.ManoelStore.Models;
using Mr.ManoelStore.Services;

namespace Mr.ManoelStore.Test
{
    public class PedidoServiceTest
    {
        [Fact]
        public void Empacotar_DeveRetornarCaixa_ParaProdutoQueCabe()
        {
            // Arrange
            var service = new PedidoService();

            var pedido = new Pedido
            {
                PedidoId = 1,
                Produtos = new List<Produto>
            {
                new Produto
                {
                    ProdutoId = "P1",
                    Dimensoes = new Dimensoes { Altura = 10, Largura = 10, Comprimento = 10 }
                }
            }
            };

            var request = new PedidoRequestDto
            {
                Pedidos = new List<Pedido> { pedido }
            };

            // Act
            var resultado = service.Empacotar(request);

            // Assert
            Assert.Single(resultado.Pedidos);
            var caixas = resultado.Pedidos[0].Caixas;
            Assert.Single(caixas);
            Assert.Contains("P1", caixas[0].Produtos);
            Assert.NotNull(caixas[0].CaixaId);
        }
        [Fact]
        public void Empacotar_DeveRetornarObservacao_QuandoProdutoNaoCabe()
        {
            var service = new PedidoService();

            var pedido = new Pedido
            {
                PedidoId = 2,
                Produtos = new List<Produto>
            {
                new Produto
                {
                    ProdutoId = "P2",
                    Dimensoes = new Dimensoes { Altura = 500, Largura = 500, Comprimento = 500 }
                }
            }
            };

            var request = new PedidoRequestDto { Pedidos = new List<Pedido> { pedido } };
            var resultado = service.Empacotar(request);

            var caixa = resultado.Pedidos[0].Caixas[0];
            Assert.Null(caixa.CaixaId);
            Assert.Contains("P2", caixa.Produtos);
            Assert.Equal("Produto não cabe em nenhuma caixa disponível.", caixa.Observacao);
        }
        [Fact]
        public void Empacotar_DeveDistribuirProdutosEmMultiplasCaixas_SeNecessario()
        {
            var service = new PedidoService();

            var pedido = new Pedido
            {
                PedidoId = 3,
                Produtos = new List<Produto>
            {
                new Produto { ProdutoId = "P3", Dimensoes = new Dimensoes { Altura = 30, Largura = 40, Comprimento = 80 } },
                new Produto { ProdutoId = "P4", Dimensoes = new Dimensoes { Altura = 80, Largura = 50, Comprimento = 40 } },
                new Produto { ProdutoId = "P5", Dimensoes = new Dimensoes { Altura = 50, Largura = 80, Comprimento = 60 } }
            }
            };

            var request = new PedidoRequestDto { Pedidos = new List<Pedido> { pedido } };
            var resultado = service.Empacotar(request);

            var caixas = resultado.Pedidos[0].Caixas;
            Assert.Equal(3, caixas.Count);
            var produtosEmpacotados = caixas.SelectMany(c => c.Produtos).ToList();
            Assert.Contains("P3", produtosEmpacotados);
            Assert.Contains("P4", produtosEmpacotados);
            Assert.Contains("P5", produtosEmpacotados);
        }
        [Fact]
        public void Empacotar_DeveRetornarListaVazia_QuandoNaoHaPedidos()
        {
            var service = new PedidoService();

            var request = new PedidoRequestDto { Pedidos = new List<Pedido>() };
            var resultado = service.Empacotar(request);

            Assert.Empty(resultado.Pedidos);
        }
        [Fact]
        public void Empacotar_DeveIgnorarProdutosSemDimensoes()
        {
            var service = new PedidoService();

            var pedido = new Pedido
            {
                PedidoId = 4,
                Produtos = new List<Produto>
            {
                new Produto { ProdutoId = "P6", Dimensoes = new Dimensoes { Altura = 0, Largura = 0, Comprimento = 0 } }
            }
            };

            var request = new PedidoRequestDto { Pedidos = new List<Pedido> { pedido } };
            var resultado = service.Empacotar(request);

            var caixas = resultado.Pedidos[0].Caixas;
            Assert.NotEmpty(caixas);
            Assert.Contains("P6", caixas[0].Produtos);
        }
    }
}