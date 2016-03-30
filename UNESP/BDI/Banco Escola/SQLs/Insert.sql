INSERT INTO `serie` (`ser_cod`, `ser_descricao`) VALUES
  (1, '1º ano'),
  (2, '2º ano'),
  (3, '3º ano'),
  (4, '4º ano'),
  (5, '5º ano'),
  (6, '6º ano'),
  (7, '7º ano'),
  (8, '8º ano'),
  (9, '9º ano');

INSERT INTO `especialidade` (`esp_cod`, `esp_nome`) VALUES
  (1, 'Exatas'),
  (2, 'Humanas'),
  (3, 'Biologicas'),
  (4, 'Artes'),
  (5, 'Esportes');
  
INSERT INTO `funcionario` (`fun_cod`, `fun_nome`, `fun_CPF`, `fun_RG`, `fun_cargo`, `fun_salario`, `fun_situacao`, `fun_cidade`, `fun_CEP`, `fun_endereco`) VALUES
  (1, 'Mauricio de Sousa', '39290728400', '2977269', '1', 3000.00, '1', 'Vale do sol', '17048-556', 'Alameda das borboletas 19-02, Jd. Feliz'),
  (2, 'Roberta Silva', '83313337210', '403289440', '2', 1200.00, '1', 'Vale do sol', '17047-001', 'Rua numero zero, Jd. Azul, Condominio Leon'),
  (3, 'Paulo Pedroso', '96738571569', '418757896', '2', 1200.00, '1', 'Vale do sol', '17047-001', 'Rua numero zero, Jd. Azul, Condominio Rosa'),
  (4, 'Claudio Araujo', '52348473658', '429434121', '2', 1200.00, '1', 'Vale da Lua', '17055-251', 'Rua Jose Arruda 15-23, Altos, Casa amarela'),
  (5, 'Bruna Fernandes', '85161401214', '29756854', '2', 1200.00, '1', 'Vale do Sol', '17047-043', 'Alameda azul 10-10, Jd. Azul'),
  (6, 'Paloma Oliveira', '56489755971', '429433453', '3', 1000.00, '1', 'Vale do Sol', '17047-032', 'Rua Sebastiao, Jd. Feliz, Bloco verde');
  
INSERT INTO `professor` (`pro_cod`, `fun_cod`, `esp_cod`) VALUES
  (1, 2, 1),
  (2, 3, 5),
  (3, 4, 2),
  (4, 5, 3); 

INSERT INTO `aluno` (`alu_cod`, `alu_nome`, `alu_CPF`, `alu_RG`, `alu_nomeResp`, `alu_foneResp`, `alu_situacao`, `alu_cidade`, `alu_CEP`, `alu_endereco`) VALUES
  (1, 'Renata Tiepo', '41263097804', '4895360113', 'Neusa Tiepo', '1481252225', '1',  'Vila do Sol', '17458-252', 'Rua do gafanhoto 5-43, Jd. Feliz'),
  (2, 'Talissa Gaspareli', '41265487532', '5487523102', 'Camila Gaspareli', '1485569854', '1', 'Vila do Sol', '25655-002', 'Rua azul, Jd. Rosana, Condominio amarelo'),
  (3, 'Paulo Sousa', '23654885821', '255653215', 'Joana Sousa', '1485563256', '1', 'Vila do Sol', '223564-225', 'Alameda de barrro 12-32, Jd. Feliz');

INSERT INTO `materia` (`mat_cod`, `pro_cod`, `ser_cod`, `esp_cod`, `mat_nome`) VALUES
  (1, 2, 2, 5, 'Ed. Fisica'),
  (2, 3, 5, 2, 'Redaçao'),
  (3, 3, 4, 2, 'Lingua Portuguesa'),
  (4, 4, 5, 3, 'Biologia'),
  (5, 1, 4, 1, 'Matematica'),
  (6, 1, 5, 1, 'Geometria');

INSERT INTO `situacao_aluno` (`sit_cod`, `alu_cod`, `mat_cod`, `ser_cod`, `sit_situacao`, `sit_media`, `sit_frequencia`) VALUES
  (1, 1, 2, 5, '0', 0, 0),
  (2, 1, 4, 5, '0', 0, 0),
  (3, 1, 6, 5, '0', 0, 0),
  (4, 2, 2, 5, '0', 0, 0),
  (5, 2, 4, 5, '0', 0, 0),
  (6, 2, 6, 5, '0', 0, 0),
  (7, 3, 3, 4, '2', 5.3, 80),
  (8, 3, 5, 4, '1', 8.6, 95); 
  
INSERT INTO `notas` (`not_cod`, `not_bimestre`, `not_tipo`, `sit_cod`, `not_nota`) VALUES
  (1, 1, 1, 7, 6),
  (2, 1, 1, 8, 10),
  (3, 2, 1, 7, 5),
  (4, 2, 1, 8, 8),
  (5, 3, 1, 7, 6),
  (6, 3, 1, 8, 9),
  (7, 4, 1, 7, 6),
  (8, 4, 1, 8, 9),
  (9, 1, 2, 7, 4.5),
  (10, 1, 2, 8, 10),
  (11, 2, 2, 7, 5),
  (12, 2, 2, 8, 8),
  (13, 3, 2, 7, 4),
  (14, 3, 2, 8, 6.5),
  (15, 4, 2, 7, 6),
  (16, 4, 2, 8, 8),
  (17, 1, 2, 7, 4),
  (18, 1, 2, 8, 5),
  (19, 3, 2, 7, 5.5),
  (20, 3, 2, 8, 8);