CREATE DATABASE [locadora]
GO

USE [locadora]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[classificacao](
	[cla_cod] [int] IDENTITY(1,1) NOT NULL,
	[cla_descricao] [varchar](20) NOT NULL,
	[cla_valor] [decimal](4, 2) NOT NULL,
	[cla_tempo] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cla_cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[genero](
	[gen_cod] [int] IDENTITY(1,1) NOT NULL,
	[gen_descricao] [varchar](20) NOT NULL,
	[gen_prateleira] [char](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[gen_cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cliente](
	[cli_cod] [int] IDENTITY(1,1) NOT NULL,
	[cli_nome] [varchar](50) NOT NULL,
	[cli_CPF] [varchar](15) NOT NULL,
	[cli_rua] [varchar](60) NOT NULL,
	[cli_numero] [varchar](10) NULL,
	[cli_CEP] [varchar](10) NOT NULL,
	[cli_bairro] [varchar](30) NOT NULL,
	[cli_cidade] [varchar](30) NOT NULL,
	[cli_uf] [varchar](2) NOT NULL,
	[cli_complemento] [varchar](30) NULL,
	[cli_telefone] [varchar](16) NOT NULL,
	[cli_email] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[cli_cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[dvd](
	[dvd_cod] [int] IDENTITY(1,1) NOT NULL,
	[dvd_nome] [varchar](50) NOT NULL,
	[dvd_sinopse] [varchar](300) NULL,
	[dvd_diretor] [varchar](50) NULL,
	[dvd_anoLancamento] [char](4) NULL,
	[dvd_situacao] [tinyint] NOT NULL,
	[gen_cod] [int] NOT NULL,
	[cla_cod] [int] NOT NULL,
 CONSTRAINT [PK_dvdd] PRIMARY KEY CLUSTERED 
(
	[dvd_cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[dvd]  WITH CHECK ADD  CONSTRAINT [FK_dvd_classificacao] FOREIGN KEY([cla_cod])
REFERENCES [dbo].[classificacao] ([cla_cod])
GO

ALTER TABLE [dbo].[dvd] CHECK CONSTRAINT [FK_dvd_classificacao]
GO

ALTER TABLE [dbo].[dvd]  WITH CHECK ADD  CONSTRAINT [FK_dvd_genero] FOREIGN KEY([gen_cod])
REFERENCES [dbo].[genero] ([gen_cod])
GO

ALTER TABLE [dbo].[dvd] CHECK CONSTRAINT [FK_dvd_genero]
GO

CREATE TABLE [dbo].[locacao](
	[dvd_cod] [int] NOT NULL,
	[loc_dataLocacao] [datetime] NOT NULL,
	[loc_dataPrevistaDevolucao] [datetime] NOT NULL,
	[loc_dataDevolucao] [datetime] NULL,
	[loc_valorMulta] [decimal](4, 2) NULL,
	[loc_situacao] [tinyint] NOT NULL,
	[cli_cod] [int] NOT NULL,
 CONSTRAINT [PK__locacao__dvd_cod_dataLocacao] PRIMARY KEY CLUSTERED 
(
	[dvd_cod] ASC,
	[loc_dataLocacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[locacao]  WITH CHECK ADD  CONSTRAINT [FK_locacao_cliente] FOREIGN KEY([cli_cod])
REFERENCES [dbo].[cliente] ([cli_cod])
GO

ALTER TABLE [dbo].[locacao] CHECK CONSTRAINT [FK_locacao_cliente]
GO

ALTER TABLE [dbo].[locacao]  WITH CHECK ADD  CONSTRAINT [FK_locacao_dvd] FOREIGN KEY([dvd_cod])
REFERENCES [dbo].[dvd] ([dvd_cod])
GO

ALTER TABLE [dbo].[locacao] CHECK CONSTRAINT [FK_locacao_dvd]
GO