# 📦 Mr.ManoelStore

API para empacotamento inteligente de pedidos em caixas disponíveis, usando regras de dimensionamento e otimização de volume. Ideal para sistemas de logística, e-commerces ou qualquer aplicação que precise alocar produtos de forma eficiente.

## 🧾 Descrição do Problema

Seu Manoel tem uma loja de jogos online e deseja automatizar o processo de embalagem dos pedidos. Ele precisa de uma API que, dado um conjunto de pedidos com produtos e suas dimensões, retorne quais caixas devem ser usadas para cada pedido e quais produtos irão em cada caixa.

### Descrição:

Desenvolva uma API WEB que receba, em formato JSON, uma lista de pedidos. Cada pedido contém uma lista de produtos, cada um com suas dimensões (altura, largura, comprimento). A API deve processar cada pedido e determinar a melhor forma de embalar os produtos, selecionando uma ou mais caixas para cada pedido e especificando quais produtos vão em cada caixa.

### Caixas Disponíveis:

Seu Manoel possui os seguintes tamanhos de caixas pré-fabricadas (altura, largura, comprimento):

- Caixa 1: 30 x 40 x 80
- Caixa 2: 80 x 50 x 40
- Caixa 3: 50 x 80 x 60

### Entrada e Saída do Endpoint:

**Entrada:** A API deve aceitar um JSON contendo N pedidos diferentes. Cada pedido deve ter entre N produtos. Cada produto deve incluir suas dimensões em centímetros (altura, largura, comprimento).

**Processamento:** Para cada pedido, a API deve calcular a melhor forma de empacotar os produtos, podendo usar uma ou mais caixas disponíveis. Deve considerar a otimização do espaço, tentando minimizar o número de caixas usadas.

**Saída:** A API deve retornar um JSON que, para cada pedido, lista as caixas usadas e quais produtos foram colocados em cada caixa.

---

## 🚀 Tecnologias Utilizadas

- ASP.NET Core 8
- Docker & Docker Compose
- SQL Server (via Docker)
- Autenticação JWT
- Swagger (API Docs)
- xUnit (testes unitários)

---

## 📁 Estrutura do Projeto

```
├── Auth/
├── Controllers/
│   ├── AuthController.cs
│   └── PedidoController.cs
├── DTOs/
├── Infra/
├── Models/
├── Repositories/
├── Services/
├── Program.cs
├── Dockerfile
├── docker-compose.yml
└── README.md
```

---

## ⚙️ Como Executar

### Pré-requisitos

- Docker e Docker Compose instalados

### 1. Clonar o repositório

```bash
git clone https://github.com/marcospaulohub/Mr.ManoelStore.git
cd Mr.ManoelStore
```

### 2. Executar com Docker

```bash
docker-compose up --build
```

> A API estará disponível em: [http://localhost:5000/swagger](http://localhost:5000/swagger)

---

## 🔐 Autenticação

A API está protegida com JWT. Para acessar os endpoints protegidos:

### 1. Faça login

POST `/api/auth/login`

```json
{
  "username": "admin",
  "password": "1234"
}
```

### 2. Copie o token retornado

### 3. No Swagger, clique em **Authorize** e cole o token:

```
Bearer {seu_token}
```

---

## 🧪 Testes Unitários

### Executar testes com .NET CLI

```bash
dotnet test
```

Os testes estão localizados no projeto `Mr.ManoelStore.Test` e cobrem:

- Empacotamento com produtos que cabem em caixas
- Produtos que não cabem em nenhuma caixa
- Múltiplos pedidos e caixas
- Casos extremos (vazio, dimensões inválidas)

---

## 📬 Endpoint principal

### POST `/api/Pedido/empacotar`

Envia pedidos com produtos e retorna as caixas recomendadas.

**Exemplo de requisição:**

```json
{
  "pedidos": [
    {
      "pedidoId": 1,
      "produtos": [
        {
          "produtoId": "p1",
          "dimensoes": {
            "altura": 10,
            "largura": 20,
            "comprimento": 30
          }
        }
      ]
    }
  ]
}
```

**Resposta:**

```json
{
  "pedidos": [
    {
      "pedidoId": 1,
      "caixas": [
        {
          "caixaId": "Caixa 1",
          "produtos": ["p1"]
        }
      ]
    }
  ]
}
```

---

## 🧠 Lógica de Negócio

- Os produtos são ordenados por volume (decrescente).
- Cada produto é alocado na menor caixa que comporte suas dimensões.
- Se não houver caixa disponível, é adicionada uma observação no retorno (Produto não cabe em nenhuma caixa disponível).

---

## 📄 Licença

MIT

---

> Desenvolvido por [Marcos Paulo](https://github.com/marcospaulohub)
