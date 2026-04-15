using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportadorTxt.Domain.Entidades
{
    public class FondoLeyFoniñez2
    {
        public string Periodo_reportado { get; set; } = string.Empty;
        public string id_CCF { get; set; } = string.Empty;
        public string Nombre_CCF { get; set; } = string.Empty;
        public string desc_Tipo_Beneficiario_C020 { get; set; } = string.Empty;
        public string desc_Tipo_Documento_beneficiario { get; set; } = string.Empty;
        public string desc_Genero { get; set; } = string.Empty;
        public DateTime? FEC_NACIMIENTO_BENEFICIARIO { get; set; }
        public string Ciudad_Nacimiento_Beneficiario { get; set; } = string.Empty;
        public DateTime? FEC_VINCULACION_BENEFICIARIO { get; set; }
        public string Ciudad_Residencia_Beneficiario { get; set; } = string.Empty;
        public string area_geografica { get; set; } = string.Empty;
        public string DIR_RESIDENCIA_BENEFICIARIO { get; set; } = string.Empty;
        public string Tipo_Documento_Madre_Padre_Beneficiario { get; set; } = string.Empty;
        public string NUM_IDENTIFICACION_MADRE_PADRE_ACUDIENTE { get; set; } = string.Empty;
        public string PRI_NOMBRE_MADRE_PADRE_ACUDIENTE { get; set; } = string.Empty;
        public string SEG_NOMBRE_MADRE_PADRE_ACUDIENTE { get; set; } = string.Empty;
        public string PRI_APELLIDO_MADRE_PADRE_ACUDIENTE { get; set; } = string.Empty;
        public string SEG_APELLIDO_MADRE_PADRE_ACUDIENTE { get; set; } = string.Empty;
        public string TEL_MADRE_PADRE_ACUDIENTE { get; set; } = string.Empty;
        public string desc_Modalidad_AIN { get; set; } = string.Empty;
        public string Desc_Infraestructura { get; set; } = string.Empty;
        public string ID_Infraestructura { get; set; } = string.Empty;
        public string Nombre_Colegio { get; set; } = string.Empty;
        public string Nombre_Completo_estud { get; set; } = string.Empty;
        public string Numero_Documento_estud { get; set; } = string.Empty;
        public string PRI_APELLIDO_BENEFICIARIO { get; set; } = string.Empty;
        public string PRI_NOMBRE_BENEFICIARIO { get; set; } = string.Empty;
        public string SEG_APELLIDO_BENEFICIARIO { get; set; } = string.Empty;
        public string SEG_NOMBRE_BENEFICIARIO { get; set; } = string.Empty;
        public string modalidad_prestacion_servicios_sociales { get; set; } = string.Empty;
        public string PAI_NOMBRE_PAIS { get; set; } = string.Empty;
        public string PAI_COD_PAIS { get; set; } = string.Empty;
        public string PET_CDESCRIPCION { get; set; } = string.Empty;
        public string FVU_CDESCRIPCION { get; set; } = string.Empty;
        public string POB_CDESCRIPCION { get; set; } = string.Empty;
    }
}
