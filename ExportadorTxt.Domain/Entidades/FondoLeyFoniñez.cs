using System;

namespace ExportadorTxt.Domain.Entidades
{
    public class FondoLeyFoniñez
    {
        public string wk_Mes { get; set; } = string.Empty;
        public string id_CCF { get; set; } = string.Empty;
        public string Nombre_CCF { get; set; } = string.Empty;
        public string Nombre_Completo { get; set; } = string.Empty;
        public string Numero_Documento { get; set; } = string.Empty;
        public string desc_Tipo_Documento { get; set; } = string.Empty;
        public string ID_CONVENIO_JEC { get; set; } = string.Empty;
        public string tipo_jornada { get; set; } = string.Empty;
        public string desc_Modalidad_JECO { get; set; } = string.Empty;
        public string Desc_Infraestructura { get; set; } = string.Empty;
        public string ID_Infraestructura { get; set; } = string.Empty;
        public string Nombre_Ciudad_infraestructura { get; set; } = string.Empty;
        public string Nombre_Colegio { get; set; } = string.Empty;
        public string id_Colegio { get; set; } = string.Empty;
        public string Modalidad_prestacion_serv_soc { get; set; } = string.Empty;
        public string Etnia { get; set; } = string.Empty;
        public string poblaciones { get; set; } = string.Empty;
        public string desc_Tipo_Beneficiario_C020 { get; set; } = string.Empty;
        public string desc_Genero { get; set; } = string.Empty;
        public string FEC_NACIMIENTO_BENEFICIARIO { get; set; }
        public string DIR_RESIDENCIA_BENEFICIARIO { get; set; } = string.Empty;
        public string Ciudad_Nacimiento_Beneficiario { get; set; } = string.Empty;
        public string Ciudad_Residencia_Beneficiario { get; set; } = string.Empty;
        public string area_geografica { get; set; } = string.Empty;
        public string Pais_Nacimiento_Beneficiario { get; set; } = string.Empty;
        public string desc_Sector { get; set; } = string.Empty;
    }
}