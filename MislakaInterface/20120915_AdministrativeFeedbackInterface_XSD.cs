﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.0.30319.33440.
// 

namespace Feedback
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Mimshak
    {

        private MimshakKoteretKovetz koteretKovetzField;

        private MimshakYeshutGoremPoneLemislaka[] gufHamimshakField;

        /// <remarks/>
        public MimshakKoteretKovetz KoteretKovetz
        {
            get
            {
                return this.koteretKovetzField;
            }
            set
            {
                this.koteretKovetzField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("YeshutGoremPoneLemislaka", IsNullable = false)]
        public MimshakYeshutGoremPoneLemislaka[] GufHamimshak
        {
            get
            {
                return this.gufHamimshakField;
            }
            set
            {
                this.gufHamimshakField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MimshakKoteretKovetz
    {

        private int sUGMIMSHAKField;

        private MimshakKoteretKovetzMISPARGIRSATXML mISPARGIRSATXMLField;

        private string tAARICHBITZUAField;

        private int kODSVIVATAVODAField;

        private string mISPARHAKOVETZField;

        private System.Nullable<int> mISPARSIDURIField;

        private MimshakKoteretKovetzNetuneiGoremSholech netuneiGoremSholechField;

        private MimshakKoteretKovetzNetuneiGoremNimaan netuneiGoremNimaanField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SUG-MIMSHAK")]
        public int SUGMIMSHAK
        {
            get
            {
                return this.sUGMIMSHAKField;
            }
            set
            {
                this.sUGMIMSHAKField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MISPAR-GIRSAT-XML")]
        public MimshakKoteretKovetzMISPARGIRSATXML MISPARGIRSATXML
        {
            get
            {
                return this.mISPARGIRSATXMLField;
            }
            set
            {
                this.mISPARGIRSATXMLField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TAARICH-BITZUA")]
        public string TAARICHBITZUA
        {
            get
            {
                return this.tAARICHBITZUAField;
            }
            set
            {
                this.tAARICHBITZUAField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KOD-SVIVAT-AVODA")]
        public int KODSVIVATAVODA
        {
            get
            {
                return this.kODSVIVATAVODAField;
            }
            set
            {
                this.kODSVIVATAVODAField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MISPAR-HAKOVETZ")]
        public string MISPARHAKOVETZ
        {
            get
            {
                return this.mISPARHAKOVETZField;
            }
            set
            {
                this.mISPARHAKOVETZField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MISPAR-SIDURI", IsNullable = true)]
        public System.Nullable<int> MISPARSIDURI
        {
            get
            {
                return this.mISPARSIDURIField;
            }
            set
            {
                this.mISPARSIDURIField = value;
            }
        }

        /// <remarks/>
        public MimshakKoteretKovetzNetuneiGoremSholech NetuneiGoremSholech
        {
            get
            {
                return this.netuneiGoremSholechField;
            }
            set
            {
                this.netuneiGoremSholechField = value;
            }
        }

        /// <remarks/>
        public MimshakKoteretKovetzNetuneiGoremNimaan NetuneiGoremNimaan
        {
            get
            {
                return this.netuneiGoremNimaanField;
            }
            set
            {
                this.netuneiGoremNimaanField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public enum MimshakKoteretKovetzMISPARGIRSATXML
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("001")]
        Item001,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MimshakKoteretKovetzNetuneiGoremSholech
    {

        private int kODSHOLECHField;

        private int sUGMEZAHESHOLECHField;

        private string mISPARZIHUISHOLECHField;

        private string sHEMGOREMSHOLECHField;

        private string sHEMPRATIISHKESHERSHOLECHField;

        private string sHEMMISHPACHAISHKESHERSHOLECHField;

        private string mISPARTELEPHONEKAVIISHKESHERSHOLECHField;

        private string eMAILISHKESHERSHOLECHField;

        private string mISPARCELLULARIISHKESHERSHOLECHField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KOD-SHOLECH")]
        public int KODSHOLECH
        {
            get
            {
                return this.kODSHOLECHField;
            }
            set
            {
                this.kODSHOLECHField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SUG-MEZAHE-SHOLECH")]
        public int SUGMEZAHESHOLECH
        {
            get
            {
                return this.sUGMEZAHESHOLECHField;
            }
            set
            {
                this.sUGMEZAHESHOLECHField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MISPAR-ZIHUI-SHOLECH")]
        public string MISPARZIHUISHOLECH
        {
            get
            {
                return this.mISPARZIHUISHOLECHField;
            }
            set
            {
                this.mISPARZIHUISHOLECHField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SHEM-GOREM-SHOLECH")]
        public string SHEMGOREMSHOLECH
        {
            get
            {
                return this.sHEMGOREMSHOLECHField;
            }
            set
            {
                this.sHEMGOREMSHOLECHField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SHEM-PRATI-ISH-KESHER-SHOLECH")]
        public string SHEMPRATIISHKESHERSHOLECH
        {
            get
            {
                return this.sHEMPRATIISHKESHERSHOLECHField;
            }
            set
            {
                this.sHEMPRATIISHKESHERSHOLECHField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SHEM-MISHPACHA-ISH-KESHER-SHOLECH")]
        public string SHEMMISHPACHAISHKESHERSHOLECH
        {
            get
            {
                return this.sHEMMISHPACHAISHKESHERSHOLECHField;
            }
            set
            {
                this.sHEMMISHPACHAISHKESHERSHOLECHField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MISPAR-TELEPHONE-KAVI-ISH-KESHER-SHOLECH")]
        public string MISPARTELEPHONEKAVIISHKESHERSHOLECH
        {
            get
            {
                return this.mISPARTELEPHONEKAVIISHKESHERSHOLECHField;
            }
            set
            {
                this.mISPARTELEPHONEKAVIISHKESHERSHOLECHField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("E-MAIL-ISH-KESHER-SHOLECH")]
        public string EMAILISHKESHERSHOLECH
        {
            get
            {
                return this.eMAILISHKESHERSHOLECHField;
            }
            set
            {
                this.eMAILISHKESHERSHOLECHField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MISPAR-CELLULARI-ISH-KESHER-SHOLECH", IsNullable = true)]
        public string MISPARCELLULARIISHKESHERSHOLECH
        {
            get
            {
                return this.mISPARCELLULARIISHKESHERSHOLECHField;
            }
            set
            {
                this.mISPARCELLULARIISHKESHERSHOLECHField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MimshakKoteretKovetzNetuneiGoremNimaan
    {

        private int kODNIMAANField;

        private int sUGMEZAHENIMAANField;

        private string mISPARZIHUINIMAANField;

        private string mISPARZIHUIETZELYATZRANNIMAANField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KOD-NIMAAN")]
        public int KODNIMAAN
        {
            get
            {
                return this.kODNIMAANField;
            }
            set
            {
                this.kODNIMAANField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SUG-MEZAHE-NIMAAN")]
        public int SUGMEZAHENIMAAN
        {
            get
            {
                return this.sUGMEZAHENIMAANField;
            }
            set
            {
                this.sUGMEZAHENIMAANField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MISPAR-ZIHUI-NIMAAN")]
        public string MISPARZIHUINIMAAN
        {
            get
            {
                return this.mISPARZIHUINIMAANField;
            }
            set
            {
                this.mISPARZIHUINIMAANField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MISPAR-ZIHUI-ETZEL-YATZRAN-NIMAAN", IsNullable = true)]
        public string MISPARZIHUIETZELYATZRANNIMAAN
        {
            get
            {
                return this.mISPARZIHUIETZELYATZRANNIMAANField;
            }
            set
            {
                this.mISPARZIHUIETZELYATZRANNIMAANField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MimshakYeshutGoremPoneLemislaka
    {

        private System.Nullable<int> sUGPONEField;

        private System.Nullable<int> sUGKODMEZAHEPONEField;

        private string mISPARMEZAHEPONEField;

        private string sHEMGOREMPONEField;

        private string mISPARMEZAHEMETAFELField;

        private string sHEMPRATIPONELEMISLAKAField;

        private string sHEMMISHPACHAPONELEMISLAKAField;

        private string mISPARTELEPHONEKAVIPONELEMISLAKAField;

        private string eMAILPONELEMISLAKAField;

        private string mISPARCELLULARIField;

        private MimshakYeshutGoremPoneLemislakaSugMashov sugMashovField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SUG-PONE", IsNullable = true)]
        public System.Nullable<int> SUGPONE
        {
            get
            {
                return this.sUGPONEField;
            }
            set
            {
                this.sUGPONEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SUG-KOD-MEZAHE-PONE", IsNullable = true)]
        public System.Nullable<int> SUGKODMEZAHEPONE
        {
            get
            {
                return this.sUGKODMEZAHEPONEField;
            }
            set
            {
                this.sUGKODMEZAHEPONEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MISPAR-MEZAHE-PONE", IsNullable = true)]
        public string MISPARMEZAHEPONE
        {
            get
            {
                return this.mISPARMEZAHEPONEField;
            }
            set
            {
                this.mISPARMEZAHEPONEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SHEM-GOREM-PONE", IsNullable = true)]
        public string SHEMGOREMPONE
        {
            get
            {
                return this.sHEMGOREMPONEField;
            }
            set
            {
                this.sHEMGOREMPONEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MISPAR-MEZAHE-METAFEL", IsNullable = true)]
        public string MISPARMEZAHEMETAFEL
        {
            get
            {
                return this.mISPARMEZAHEMETAFELField;
            }
            set
            {
                this.mISPARMEZAHEMETAFELField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SHEM-PRATI-PONE-LEMISLAKA", IsNullable = true)]
        public string SHEMPRATIPONELEMISLAKA
        {
            get
            {
                return this.sHEMPRATIPONELEMISLAKAField;
            }
            set
            {
                this.sHEMPRATIPONELEMISLAKAField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SHEM-MISHPACHA-PONE-LEMISLAKA", IsNullable = true)]
        public string SHEMMISHPACHAPONELEMISLAKA
        {
            get
            {
                return this.sHEMMISHPACHAPONELEMISLAKAField;
            }
            set
            {
                this.sHEMMISHPACHAPONELEMISLAKAField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MISPAR-TELEPHONE-KAVI-PONE-LEMISLAKA", IsNullable = true)]
        public string MISPARTELEPHONEKAVIPONELEMISLAKA
        {
            get
            {
                return this.mISPARTELEPHONEKAVIPONELEMISLAKAField;
            }
            set
            {
                this.mISPARTELEPHONEKAVIPONELEMISLAKAField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("E-MAIL-PONE-LEMISLAKA", IsNullable = true)]
        public string EMAILPONELEMISLAKA
        {
            get
            {
                return this.eMAILPONELEMISLAKAField;
            }
            set
            {
                this.eMAILPONELEMISLAKAField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MISPAR-CELLULARI", IsNullable = true)]
        public string MISPARCELLULARI
        {
            get
            {
                return this.mISPARCELLULARIField;
            }
            set
            {
                this.mISPARCELLULARIField = value;
            }
        }

        /// <remarks/>
        public MimshakYeshutGoremPoneLemislakaSugMashov SugMashov
        {
            get
            {
                return this.sugMashovField;
            }
            set
            {
                this.sugMashovField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MimshakYeshutGoremPoneLemislakaSugMashov
    {

        private int sUGMIMSHAKLEGABAVMUAVARHIZUNCHOZERField;

        private string sHEMHAKOVETZField;

        private string mISPARHAKOVETZField;

        private int rAMATMASHOVField;

        private int sUGMASHOVField;

        private MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatKovetz mashovBeramatKovetzField;

        private MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatReshuma[] mashovBeramatReshumaField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SUG-MIMSHAK-LEGABAV-MUAVAR-HIZUN-CHOZER")]
        public int SUGMIMSHAKLEGABAVMUAVARHIZUNCHOZER
        {
            get
            {
                return this.sUGMIMSHAKLEGABAVMUAVARHIZUNCHOZERField;
            }
            set
            {
                this.sUGMIMSHAKLEGABAVMUAVARHIZUNCHOZERField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SHEM-HAKOVETZ")]
        public string SHEMHAKOVETZ
        {
            get
            {
                return this.sHEMHAKOVETZField;
            }
            set
            {
                this.sHEMHAKOVETZField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MISPAR-HAKOVETZ")]
        public string MISPARHAKOVETZ
        {
            get
            {
                return this.mISPARHAKOVETZField;
            }
            set
            {
                this.mISPARHAKOVETZField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RAMAT-MASHOV")]
        public int RAMATMASHOV
        {
            get
            {
                return this.rAMATMASHOVField;
            }
            set
            {
                this.rAMATMASHOVField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SUG-MASHOV")]
        public int SUGMASHOV
        {
            get
            {
                return this.sUGMASHOVField;
            }
            set
            {
                this.sUGMASHOVField = value;
            }
        }

        /// <remarks/>
        public MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatKovetz MashovBeramatKovetz
        {
            get
            {
                return this.mashovBeramatKovetzField;
            }
            set
            {
                this.mashovBeramatKovetzField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MashovBeramatReshuma")]
        public MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatReshuma[] MashovBeramatReshuma
        {
            get
            {
                return this.mashovBeramatReshumaField;
            }
            set
            {
                this.mashovBeramatReshumaField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatKovetz
    {

        private int kODSHGIHAField;

        private MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatKovetzPerutShgihaBeramatKovetz[] perutShgihaBeramatKovetzField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KOD-SHGIHA")]
        public int KODSHGIHA
        {
            get
            {
                return this.kODSHGIHAField;
            }
            set
            {
                this.kODSHGIHAField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PerutShgihaBeramatKovetz")]
        public MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatKovetzPerutShgihaBeramatKovetz[] PerutShgihaBeramatKovetz
        {
            get
            {
                return this.perutShgihaBeramatKovetzField;
            }
            set
            {
                this.perutShgihaBeramatKovetzField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatKovetzPerutShgihaBeramatKovetz
    {

        private string pERUTSHGIHABERAMATKOVETZField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PERUT-SHGIHA-BERAMAT-KOVETZ", IsNullable = true)]
        public string PERUTSHGIHABERAMATKOVETZ
        {
            get
            {
                return this.pERUTSHGIHABERAMATKOVETZField;
            }
            set
            {
                this.pERUTSHGIHABERAMATKOVETZField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatReshuma
    {

        private string mISPARMISLAKAField;

        private string mISPARMEZAHERESHUMAField;

        private MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatReshumaSTATUSRESHUMA sTATUSRESHUMAField;

        private System.Nullable<int> kODSHGIHABERAMATRESHUMAField;

        private MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatReshumaMaaneMiYazran[] maaneMiYazranField;

        private MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatReshumaPerutShgihaBeramatReshuma[] perutShgihaBeramatReshumaField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MISPAR-MISLAKA", IsNullable = true)]
        public string MISPARMISLAKA
        {
            get
            {
                return this.mISPARMISLAKAField;
            }
            set
            {
                this.mISPARMISLAKAField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MISPAR-MEZAHE-RESHUMA", IsNullable = true)]
        public string MISPARMEZAHERESHUMA
        {
            get
            {
                return this.mISPARMEZAHERESHUMAField;
            }
            set
            {
                this.mISPARMEZAHERESHUMAField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("STATUS-RESHUMA")]
        public MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatReshumaSTATUSRESHUMA STATUSRESHUMA
        {
            get
            {
                return this.sTATUSRESHUMAField;
            }
            set
            {
                this.sTATUSRESHUMAField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KOD-SHGIHA-BERAMAT-RESHUMA", IsNullable = true)]
        public System.Nullable<int> KODSHGIHABERAMATRESHUMA
        {
            get
            {
                return this.kODSHGIHABERAMATRESHUMAField;
            }
            set
            {
                this.kODSHGIHABERAMATRESHUMAField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MaaneMiYazran")]
        public MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatReshumaMaaneMiYazran[] MaaneMiYazran
        {
            get
            {
                return this.maaneMiYazranField;
            }
            set
            {
                this.maaneMiYazranField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PerutShgihaBeramatReshuma")]
        public MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatReshumaPerutShgihaBeramatReshuma[] PerutShgihaBeramatReshuma
        {
            get
            {
                return this.perutShgihaBeramatReshumaField;
            }
            set
            {
                this.perutShgihaBeramatReshumaField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public enum MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatReshumaSTATUSRESHUMA
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Item2,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3")]
        Item3,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4")]
        Item4,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5")]
        Item5,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("6")]
        Item6,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatReshumaMaaneMiYazran
    {

        private int mAANEBERAMATRESHUMAField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MAANE-BERAMAT-RESHUMA")]
        public int MAANEBERAMATRESHUMA
        {
            get
            {
                return this.mAANEBERAMATRESHUMAField;
            }
            set
            {
                this.mAANEBERAMATRESHUMAField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatReshumaPerutShgihaBeramatReshuma
    {

        private string pERUTSHGIHABERAMATRESHUMAField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PERUT-SHGIHA-BERAMAT-RESHUMA")]
        public string PERUTSHGIHABERAMATRESHUMA
        {
            get
            {
                return this.pERUTSHGIHABERAMATRESHUMAField;
            }
            set
            {
                this.pERUTSHGIHABERAMATRESHUMAField = value;
            }
        }
    }
}