# 🎮 ArcadeScore API - Backend (.NET 9.0)

Este projeto é a API do ArcadeScore, construída em .NET 9. Ele expõe endpoints REST para registrar e consultar pontuações de jogadores.

---

## ✅ Pré-requisitos

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)
- (Opcional) [Postman](https://www.postman.com/) para testar a API
- (Opcional) Docker (caso deseje rodar em container)

---

## 🚀 Instalação

1. Clone o repositório:

```bash
git clone https://github.com/Aguedes83/arcade-score-backend.git
cd arcade-score-backend
```

2. Restaure os pacotes:

```bash
dotnet restore
```

3. Compile a aplicação:

```bash
dotnet build
```

---

## ▶️ Execução

Execute a API localmente com:

```bash
dotnet run
```

A API será exposta em:

```
http://localhost:5155
```

---

## 📡 Endpoints disponíveis

| Método | Rota                        | Descrição                        |
|--------|-----------------------------|----------------------------------|
| POST   | `/api/scores`              | Adiciona nova pontuação          |
| GET    | `/api/scores/top10`        | Retorna o top 10 jogadores       |
| GET    | `/api/scores/player/{name}`| Retorna estatísticas do jogador  |

---

## 🔄 CORS (Cross-Origin Resource Sharing)

A API está configurada para aceitar requisições do frontend Angular:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

app.UseCors("AllowAngularApp");
```

---

## 🧪 Testando com curl

```bash
curl -X POST http://localhost:5155/api/scores \
  -H "Content-Type: application/json" \
  -d '{"playerName": "Carlos", "points": 200, "playedAt": "2025-06-17"}'
```

---

## 📁 Estrutura do Projeto

```
ArcadeScore.Api/
├── Controllers/
│   └── ScoresController.cs
├── Models/
│   └── PlayerStatistics.cs
│   └── Score.cs
├── Repositories/
│   └── InMemoryScoreRepository.cs
├── Program.cs
```

---

## 🧼 Limpeza

Para limpar o build:

```bash
dotnet clean
```
---

## ✅ Melhorias Futuras

- Persistência em banco de dados (ex: MySql, SQLite, PostgreSQL, Oracle)
- Autenticação de usuários
- Paginação no ranking
- Testes unitários
- Deploy com Docker

---

## 📝 Licença

Este projeto é apenas para fins educacionais/teste. Nenhuma licença formal atribuída.

**Autor:** Antonio Guedes  
**Ano:** 2025

