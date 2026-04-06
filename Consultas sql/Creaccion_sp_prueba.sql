CREATE TABLE SubsidioEspecie_Test
(
    IdCCF VARCHAR(20),
    TipoIdentificacionAfiliado VARCHAR(50),
    NumeroIdentificacionAfiliado VARCHAR(50),
    Categoria VARCHAR(50),
    TipoIdentificacionPersonaCargo VARCHAR(50),
    NumeroIdentificacionPersonaCargo VARCHAR(50),
    TipoSubsidio VARCHAR(100),
    ValorSubsidio VARCHAR(20)
);
go
INSERT INTO SubsidioEspecie_Test VALUES
('CCF01', 'CC', '123456789', 'A', 'TI', '987654321', 'Educación', '50000'),
('CCF02', 'CC', '111111111', 'B', 'RC', '222222222', 'Salud', '75000'),
('CCF03', 'CE', '999999999', 'C', 'TI', '333333333', 'Alimentación', '30000');
go
CREATE PROCEDURE SPR_OBTENER_SUBSIDIO_ESPECIE_TEST
    @ANIO_MES INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        IdCCF,
        TipoIdentificacionAfiliado,
        NumeroIdentificacionAfiliado,
        Categoria,
        TipoIdentificacionPersonaCargo,
        NumeroIdentificacionPersonaCargo,
        TipoSubsidio,
        ValorSubsidio
    FROM SubsidioEspecie_Test;
END

EXEC SPR_OBTENER_SUBSIDIO_ESPECIE_TEST @ANIO_MES = 202401;



	INSERT INTO SubsidioEspecie_Test VALUES
('CCF04', 'CC', '444444444', 'A', 'TI', '555555555', 'Vivienda', '90000'),
('CCF05', 'CE', '666666666', 'B', 'RC', '777777777', 'Educación', '120000'),
('CCF06', 'CC', '888888888', 'C', 'TI', '999999999', 'Salud', '45000');