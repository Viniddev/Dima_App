# Dima - Controle Financeiro

![Badge Status](https://img.shields.io/badge/status-Em%20Desenvolvimento-yellow)
![.NET](https://img.shields.io/badge/.NET-%3E%3D%206.0-blue)
![Licença](https://img.shields.io/badge/licen%C3%A7a-MIT-green)

Esse projeto está sendo desenvolvido durante o curso de desenvolvimento full stack da plataforma Balta.Io. Nesse curso, estamos utilizando as tecnologias C# para desenvolver tanto o Front-End quanto o Back-End da aplicação. Pretendo usar esse curso como base para o desenvolvimento de futuras aplicações pessoais de forma robusta e segura.

## 📋 Índice

- [Sobre o Projeto](#sobre-o-projeto)
- [Pré-requisitos](#pré-requisitos)
- [Instalação](#instalação)
- [Como Usar](#como-usar)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Contribuição](#contribuição)
- [Licença](#licença)
- [Contato](#contato)

---

## 🚀 Sobre o Projeto

Este é um projeto de controle financeiro que visa a organização e o display de como gerenciar as rendas e os gastos.


## 🛠Pré-requisitos

Antes de começar, certifique-se de ter o seguinte instalado:

- [.NET SDK 9](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/)
- Editor de Código, como [Visual Studio Code](https://code.visualstudio.com/) ou [Visual Studio](https://visualstudio.microsoft.com/)
- [Azure Data Studio](https://learn.microsoft.com/pt-br/azure-data-studio/download-azure-data-studio?tabs=win-install%2Cwin-user-install%2Credhat-install%2Cwindows-uninstall%2Credhat-uninstall)
- [Docker](https://blog.balta.io/docker-instalacao-configuracao-e-primeiros-passos/)
- [Sql Server Docker](https://blog.balta.io/sql-server-docker/)
- [WSL](https://www.youtube.com/watch?v=o1_E4PBl30s)

## 📦 Instalação

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/seu-projeto.git
   
2. Adicione os user-secrets:
   ```bash
   dotnet user-secrets init
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "[your connection string]"


## 📦 Criação do projeto

1. Clone o repositório:
   ```bash
   dotnet new sln -n Dima
   dotnet new classlib -o Dima.Core
   dotnet sln add ./Dima.Core