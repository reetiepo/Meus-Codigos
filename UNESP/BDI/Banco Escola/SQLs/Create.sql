CREATE TABLE `aluno` (
  `alu_cod` INTEGER(11) NOT NULL,
  `alu_nome` VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL,
  `alu_CPF` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `alu_RG` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `alu_nomeResp` VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL,
  `alu_foneResp` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `alu_situacao` CHAR(1) COLLATE latin1_swedish_ci NOT NULL,
  `alu_cidade` VARCHAR(100) COLLATE latin1_swedish_ci NOT NULL,
  `alu_CEP` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `alu_endereco` VARCHAR(500) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`alu_cod`) COMMENT ''
)ENGINE=InnoDB
AVG_ROW_LENGTH=5461 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

CREATE TABLE `especialidade` (
  `esp_cod` INTEGER(11) NOT NULL,
  `esp_nome` VARCHAR(30) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`esp_cod`) COMMENT ''
)ENGINE=InnoDB
AVG_ROW_LENGTH=3276 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

CREATE TABLE `funcionario` (
  `fun_cod` INTEGER(11) NOT NULL,
  `fun_nome` VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL,
  `fun_CPF` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `fun_RG` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `fun_cargo` CHAR(1) COLLATE latin1_swedish_ci NOT NULL,
  `fun_salario` FLOAT(10,2) NOT NULL,
  `fun_situacao` CHAR(1) COLLATE latin1_swedish_ci NOT NULL,
  `fun_cidade` VARCHAR(100) COLLATE latin1_swedish_ci NOT NULL,
  `fun_CEP` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `fun_endereco` VARCHAR(500) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`fun_cod`) COMMENT ''
)ENGINE=InnoDB
AVG_ROW_LENGTH=2730 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

CREATE TABLE `professor` (
  `pro_cod` INTEGER(11) NOT NULL,
  `fun_cod` INTEGER(11) NOT NULL,
  `esp_cod` INTEGER(11) NOT NULL,
  PRIMARY KEY USING BTREE (`pro_cod`, `fun_cod`, `esp_cod`) COMMENT '',
   INDEX `fun_cod` USING BTREE (`fun_cod`) COMMENT '',
   INDEX `esp_cod` USING BTREE (`esp_cod`) COMMENT '',
   INDEX `pro_cod` USING BTREE (`pro_cod`) COMMENT '',
  CONSTRAINT `professor_fk1` FOREIGN KEY (`fun_cod`) REFERENCES `funcionario` (`fun_cod`),
  CONSTRAINT `professor_fk2` FOREIGN KEY (`esp_cod`) REFERENCES `especialidade` (`esp_cod`)
)ENGINE=InnoDB
AVG_ROW_LENGTH=4096 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

CREATE TABLE `serie` (
  `ser_cod` INTEGER(11) NOT NULL,
  `ser_descricao` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`ser_cod`) COMMENT ''
)ENGINE=InnoDB
AVG_ROW_LENGTH=1820 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

CREATE TABLE `materia` (
  `mat_cod` INTEGER(11) NOT NULL,
  `pro_cod` INTEGER(11) NOT NULL,
  `ser_cod` INTEGER(11) NOT NULL,
  `esp_cod` INTEGER(11) NOT NULL,
  `mat_nome` VARCHAR(30) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`mat_cod`, `ser_cod`) COMMENT '',
   INDEX `pro_cod` USING BTREE (`pro_cod`) COMMENT '',
   INDEX `ser_cod` USING BTREE (`ser_cod`) COMMENT '',
   INDEX `esp_cod` USING BTREE (`esp_cod`) COMMENT '',
   INDEX `mat_cod` USING BTREE (`mat_cod`) COMMENT '',
  CONSTRAINT `materia_fk1` FOREIGN KEY (`pro_cod`) REFERENCES `professor` (`pro_cod`),
  CONSTRAINT `materia_fk2` FOREIGN KEY (`ser_cod`) REFERENCES `serie` (`ser_cod`),
  CONSTRAINT `materia_fk3` FOREIGN KEY (`esp_cod`) REFERENCES `especialidade` (`esp_cod`)
)ENGINE=InnoDB
AVG_ROW_LENGTH=2730 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

CREATE TABLE `situacao_aluno` (
  `sit_cod` INTEGER(11) NOT NULL,
  `alu_cod` INTEGER(11) NOT NULL,
  `mat_cod` INTEGER(11) NOT NULL,
  `ser_cod` INTEGER(11) NOT NULL,
  `sit_situacao` CHAR(1) COLLATE latin1_swedish_ci NOT NULL,
  `sit_media` FLOAT(10,2) NOT NULL,
  `sit_frequencia` FLOAT(10,2) NOT NULL,
  PRIMARY KEY USING BTREE (`sit_cod`, `alu_cod`, `mat_cod`, `ser_cod`) COMMENT '',
   INDEX `sit_cod` USING BTREE (`sit_cod`) COMMENT '',
   INDEX `alu_cod` USING BTREE (`alu_cod`) COMMENT '',
   INDEX `mat_cod` USING BTREE (`mat_cod`) COMMENT '',
   INDEX `ser_cod` USING BTREE (`ser_cod`) COMMENT '',
  CONSTRAINT `situacao_aluno_fk1` FOREIGN KEY (`alu_cod`) REFERENCES `aluno` (`alu_cod`),
  CONSTRAINT `situacao_aluno_fk2` FOREIGN KEY (`mat_cod`) REFERENCES `materia` (`mat_cod`),
  CONSTRAINT `situacao_aluno_fk3` FOREIGN KEY (`ser_cod`) REFERENCES `serie` (`ser_cod`)
)ENGINE=InnoDB
AVG_ROW_LENGTH=2048 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

CREATE TABLE `notas` (
  `not_cod` INTEGER(11) NOT NULL,
  `not_bimestre` INTEGER(1) NOT NULL,
  `not_tipo` INTEGER(1) NOT NULL,
  `sit_cod` INTEGER(11) NOT NULL,
  `not_nota` FLOAT(10,2) NOT NULL,
  PRIMARY KEY USING BTREE (`not_cod`) COMMENT '',
   INDEX `sit_cod` USING BTREE (`sit_cod`) COMMENT '',
  CONSTRAINT `notas_fk1` FOREIGN KEY (`sit_cod`) REFERENCES `situacao_aluno` (`sit_cod`)
)ENGINE=InnoDB
AVG_ROW_LENGTH=2048 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;