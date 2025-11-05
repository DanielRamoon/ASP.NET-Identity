# ASP.NET Identity API

API de autenticação e autorização usando ASP.NET Core Identity com Entity Framework Core e SQL Server.

## 🚀 Tecnologias

- **.NET 8.0**
- **ASP.NET Core Identity** - Sistema de autenticação e autorização
- **Entity Framework Core 9.0** - ORM para acesso ao banco de dados
- **SQL Server** - Banco de dados relacional
- **Swagger/OpenAPI** - Documentação interativa da API

## 📋 Pré-requisitos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) (ou Docker com SQL Server)
- [dotnet-ef](https://docs.microsoft.com/ef/core/cli/dotnet) - Ferramenta de linha de comando do Entity Framework

## ⚙️ Configuração

### 1. Clone o repositório

```bash
git clone https://github.com/DanielRamoon/ASP.NET-Identity.git
cd "ASP.NET Identity/ASP"
```

### 2. Configure a connection string

Edite o arquivo `Program.cs` e atualize a connection string na linha 8:

```csharp
builder.Services.AddDbContext<AppDBContext>(options => 
    options.UseSqlServer("server=localhost;database=ASP;user id=sa;password=SUA_SENHA;TrustServerCertificate=True;")
);
```

### 3. Instale o Entity Framework CLI (se ainda não tiver)

```bash
dotnet tool install --global dotnet-ef
```

### 4. Execute as migrations

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## 🎯 Como Executar

```bash
dotnet run
```

A aplicação estará disponível em: `http://localhost:5205`

O Swagger estará disponível em: `http://localhost:5205/swagger`

## 📚 Endpoints Disponíveis

### Autenticação (Identity API)

A aplicação usa o `MapIdentityApi<User>()` que fornece automaticamente os seguintes endpoints:

- **POST** `/register` - Registrar novo usuário
  ```json
  {
    "email": "usuario@exemplo.com",
    "password": "Senha@123"
  }
  ```

- **POST** `/login` - Login de usuário
  ```json
  {
    "email": "usuario@exemplo.com",
    "password": "Senha@123"
  }
  ```

- **POST** `/refresh` - Renovar token de acesso

- **GET** `/confirmEmail` - Confirmar email

- **POST** `/resendConfirmationEmail` - Reenviar email de confirmação

- **POST** `/forgotPassword` - Solicitar redefinição de senha

- **POST** `/resetPassword` - Redefinir senha

- **POST** `/manage/2fa` - Configurar autenticação de dois fatores

- **GET** `/manage/info` - Informações do usuário

- **POST** `/manage/info` - Atualizar informações do usuário

### Endpoints Customizados

- **GET** `/pattem` - Retorna o nome do usuário autenticado (requer autenticação)
  - Headers: `Authorization: Bearer {token}`

- **POST** `/logout` - Realizar logout

## 🗄️ Banco de Dados

**Nome do banco:** `ASP`

**Tabelas principais:**
- `AspNetUsers` - Usuários
- `AspNetRoles` - Papéis/Funções
- `AspNetUserRoles` - Relacionamento usuários e papéis
- `AspNetUserClaims` - Claims dos usuários
- `AspNetUserLogins` - Logins externos
- `AspNetUserTokens` - Tokens de usuários

### Ferramentas para Visualização do Banco

Você pode usar qualquer uma dessas ferramentas para visualizar o banco de dados:

1. **Azure Data Studio** (Recomendado para Linux)
   - Gratuito e multiplataforma
   - Download: https://docs.microsoft.com/sql/azure-data-studio/download

2. **DBeaver**
   - Gratuito e open-source
   - Download: https://dbeaver.io/download/

3. **SQL Server Management Studio (SSMS)**
   - Apenas Windows
   - Download: https://aka.ms/ssmsfullsetup

**Credenciais de conexão:**
- Server: `localhost`
- Database: `ASP`
- User: `sa`
- Password: (conforme configurado na connection string)

## 📁 Estrutura do Projeto

```
ASP/
├── Data/
│   └── app.DBcontext.cs      # Contexto do Entity Framework
├── Models/
│   └── User.cs                # Modelo de usuário
├── Migrations/                # Migrations do EF Core
├── Program.cs                 # Configuração e endpoints da aplicação
├── appsettings.json           # Configurações da aplicação
└── ASP.csproj                 # Arquivo de projeto
```

## 🔐 Segurança

- As senhas são hash usando o Identity com algoritmos seguros
- Tokens JWT são usados para autenticação
- A conexão com o banco usa `TrustServerCertificate=True` (apenas para desenvolvimento)

⚠️ **Importante**: Antes de fazer deploy em produção:
- Mova a connection string para `appsettings.json` ou variáveis de ambiente
- Use certificados SSL válidos
- Configure políticas de senha fortes
- Ative HTTPS

## 🛠️ Comandos Úteis

```bash
# Restaurar dependências
dotnet restore

# Compilar o projeto
dotnet build

# Executar a aplicação
dotnet run

# Criar nova migration
dotnet ef migrations add NomeDaMigration

# Atualizar banco de dados
dotnet ef database update

# Remover última migration
dotnet ef migrations remove
```

## 📝 Licença

Este projeto está sob a licença MIT.

## 👤 Autor

**Daniel Ramon**
- GitHub: [@DanielRamoon](https://github.com/DanielRamoon)
