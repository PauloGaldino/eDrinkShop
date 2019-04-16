﻿// <auto-generated />
using System;
using Infra.Data.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Data.Migrations
{
    [DbContext(typeof(ContextoGeral))]
    [Migration("20190416035510_ProfissaoCliente1")]
    partial class ProfissaoCliente1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Contatos.Contato", b =>
                {
                    b.Property<int>("ContatoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmailId");

                    b.Property<int>("EnderecoId");

                    b.Property<int>("PessoaId");

                    b.Property<int>("TelefoneId");

                    b.HasKey("ContatoId");

                    b.HasIndex("EmailId");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("PessoaId");

                    b.HasIndex("TelefoneId");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("Domain.Entities.Contatos.Email", b =>
                {
                    b.Property<int>("EmailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EnderecoEmail")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("EmailId");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("Domain.Entities.Contatos.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar (200)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("varchar (15)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar (200)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar (100)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("char (2)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar (200)");

                    b.HasKey("EnderecoId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Domain.Entities.Contatos.EnderecoPessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnderecoId");

                    b.Property<int>("PessoaId");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("PessoaId");

                    b.ToTable("EnderecoPessoa");
                });

            modelBuilder.Entity("Domain.Entities.Contatos.Telefone", b =>
                {
                    b.Property<int>("TelefoneId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<int>("TelefoneTipoId");

                    b.HasKey("TelefoneId");

                    b.HasIndex("TelefoneTipoId")
                        .IsUnique();

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("Domain.Entities.Contatos.TelefoneTipo", b =>
                {
                    b.Property<int>("TelefoneTipoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("TelefoneTipoId");

                    b.ToTable("TelefoneTipo");
                });

            modelBuilder.Entity("Domain.Entities.Estoques.Operacao", b =>
                {
                    b.Property<int>("OperacaoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.HasKey("OperacaoId");

                    b.ToTable("Operacao");
                });

            modelBuilder.Entity("Domain.Entities.Estoques.Preco", b =>
                {
                    b.Property<int>("ProdutoId");

                    b.Property<int>("Id");

                    b.Property<decimal>("Precos")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProdutoId");

                    b.ToTable("Preco");
                });

            modelBuilder.Entity("Domain.Entities.Estoques.Produto", b =>
                {
                    b.Property<int>("ProdutoId");

                    b.Property<DateTime>("DataFabricacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("DataValidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Lote")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("ProdutoTipoId");

                    b.HasKey("ProdutoId");

                    b.HasIndex("ProdutoTipoId")
                        .IsUnique();

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Domain.Entities.Estoques.ProdutoTipo", b =>
                {
                    b.Property<int>("ProdutoTipoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("ProdutoTipoId");

                    b.ToTable("ProdutoTipo");
                });

            modelBuilder.Entity("Domain.Entities.Pessoas.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<int>("PessoaId");

                    b.HasKey("ClienteId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Domain.Entities.Pessoas.Fisica", b =>
                {
                    b.Property<int>("FisicaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .IsUnicode(true);

                    b.Property<DateTime>("DataNascimento");

                    b.Property<int>("PessoaId");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("varchar (15)");

                    b.HasKey("FisicaId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Fisica");
                });

            modelBuilder.Entity("Domain.Entities.Pessoas.Juridica", b =>
                {
                    b.Property<int>("JuridicaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("DataFundacao");

                    b.Property<string>("InscricaoEstadual")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("varchar (200)");

                    b.Property<int>("PessoaId");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("Varchar (200)");

                    b.HasKey("JuridicaId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Juridica");
                });

            modelBuilder.Entity("Domain.Entities.Pessoas.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar (100)");

                    b.Property<int>("PessoaTipoId");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("PessoaId");

                    b.HasIndex("PessoaTipoId");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("Domain.Entities.Pessoas.PessoaTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar (10)");

                    b.HasKey("Id");

                    b.ToTable("PessoaTipo");
                });

            modelBuilder.Entity("Domain.Entities.Pessoas.Profissoes.Profissao", b =>
                {
                    b.Property<int>("ProfissaoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CBO")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("ProfissaoId");

                    b.ToTable("Profissao");
                });

            modelBuilder.Entity("Domain.Entities.Pessoas.Profissoes.ProfissaoCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<int>("PessoaId");

                    b.Property<int>("ProfissaoId");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PessoaId");

                    b.HasIndex("ProfissaoId");

                    b.ToTable("ProfissaoCliente");
                });

            modelBuilder.Entity("Domain.Entities.Pessoas.Profissoes.ProfissaoPessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PessoaId");

                    b.Property<int>("ProfissaoId");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.HasIndex("ProfissaoId");

                    b.ToTable("ProfissaoPessoa");
                });

            modelBuilder.Entity("Domain.Entities.Contatos.Contato", b =>
                {
                    b.HasOne("Domain.Entities.Contatos.Email", "Email")
                        .WithMany("Contatos")
                        .HasForeignKey("EmailId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Entities.Contatos.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Pessoas.Pessoa", "Pessoa")
                        .WithMany("Contatos")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Contatos.Telefone", "Telefone")
                        .WithMany("Contato")
                        .HasForeignKey("TelefoneId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Entities.Contatos.EnderecoPessoa", b =>
                {
                    b.HasOne("Domain.Entities.Contatos.Endereco", "Endereco")
                        .WithMany("EnderecosPessoas")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Entities.Pessoas.Pessoa", "Pessoa")
                        .WithMany("EnderecosPessoas")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Entities.Contatos.Telefone", b =>
                {
                    b.HasOne("Domain.Entities.Contatos.TelefoneTipo", "TelefoneTipo")
                        .WithOne("Telefone")
                        .HasForeignKey("Domain.Entities.Contatos.Telefone", "TelefoneTipoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Entities.Estoques.Produto", b =>
                {
                    b.HasOne("Domain.Entities.Estoques.Preco", "Preco")
                        .WithOne("Produto")
                        .HasForeignKey("Domain.Entities.Estoques.Produto", "ProdutoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Entities.Estoques.ProdutoTipo", "ProdutoTipo")
                        .WithOne("Produto")
                        .HasForeignKey("Domain.Entities.Estoques.Produto", "ProdutoTipoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Entities.Pessoas.Cliente", b =>
                {
                    b.HasOne("Domain.Entities.Pessoas.Pessoa", "Pessoa")
                        .WithMany("Clientes")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Entities.Pessoas.Fisica", b =>
                {
                    b.HasOne("Domain.Entities.Pessoas.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Pessoas.Juridica", b =>
                {
                    b.HasOne("Domain.Entities.Pessoas.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Pessoas.Pessoa", b =>
                {
                    b.HasOne("Domain.Entities.Pessoas.PessoaTipo", "PessoaTipo")
                        .WithMany("Pessoas")
                        .HasForeignKey("PessoaTipoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Pessoas.Profissoes.ProfissaoCliente", b =>
                {
                    b.HasOne("Domain.Entities.Pessoas.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Pessoas.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Pessoas.Profissoes.Profissao", "Profissao")
                        .WithMany()
                        .HasForeignKey("ProfissaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Pessoas.Profissoes.ProfissaoPessoa", b =>
                {
                    b.HasOne("Domain.Entities.Pessoas.Pessoa", "Pessoa")
                        .WithMany("ProfissaoPessoa")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Pessoas.Profissoes.Profissao", "Profissao")
                        .WithMany("ProfissaoPessoa")
                        .HasForeignKey("ProfissaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
