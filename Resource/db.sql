USE sistemafolhadepagamento;

CREATE TABLE TabelaIR (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    FaixaInicial DECIMAL(10, 2),
    FaixaFinal DECIMAL(10, 2),
    Aliquota DECIMAL(5, 2),
    Deducao DECIMAL(10, 2)
);
-- Inserir a primeira faixa
INSERT INTO TabelaIR (FaixaInicial, FaixaFinal, Aliquota, Deducao)
VALUES (0, 2112.00, NULL, NULL);

-- Inserir a segunda faixa
INSERT INTO TabelaIR (FaixaInicial, FaixaFinal, Aliquota, Deducao)
VALUES (2112.01, 2826.65, 7.50, 158.40);

-- Inserir a terceira faixa
INSERT INTO TabelaIR (FaixaInicial, FaixaFinal, Aliquota, Deducao)
VALUES (2826.66, 3751.05, 15.00, 370.40);

-- Inserir a quarta faixa
INSERT INTO TabelaIR (FaixaInicial, FaixaFinal, Aliquota, Deducao)
VALUES (3751.06, 4664.68, 22.50, 651.73);

-- Inserir a quinta faixa
INSERT INTO TabelaIR (FaixaInicial, FaixaFinal, Aliquota, Deducao)
VALUES (4664.69, NULL, 27.50, 884.96);


--INSS

USE sistemafolhadepagamento; 

CREATE TABLE TabelaINSS (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    FaixaInicial DECIMAL(10, 2),
    FaixaFinal DECIMAL(10, 2),
    Aliquota DECIMAL(5, 2)
);
USE sistemafolhadepagamento; 

-- Inserir a primeira faixa
INSERT INTO TabelaINSS (FaixaInicial, FaixaFinal, Aliquota)
VALUES (0, 1320.00, 7.50);

-- Inserir a segunda faixa
INSERT INTO TabelaINSS (FaixaInicial, FaixaFinal, Aliquota)
VALUES (1320.01, 2571.29, 9.00);

-- Inserir a terceira faixa
INSERT INTO TabelaINSS (FaixaInicial, FaixaFinal, Aliquota)
VALUES (2571.30, 3856.94, 12.00);

-- Inserir a quarta faixa
INSERT INTO TabelaINSS (FaixaInicial, FaixaFinal, Aliquota)
VALUES (3856.95, 7507.49, 14.00);
