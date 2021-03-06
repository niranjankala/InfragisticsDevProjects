﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenStudioMeasuresViewer
{
    public class taxonomy
    {
        public List<Term> term { get; set; }
    }

    public class Term
    {
        public string tid { get; set; }
        public string vid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string format { get; set; }
        public string weight { get; set; }
        public string uuid { get; set; }
        public int depth { get; set; }
        public string[] parents { get; set; }
        public List<Term> term { get; set; }
        [JsonIgnore]
        public List<measure> Measures { get; set; }

    }

    public class SimulationMeasure
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public SimulationMeasureType Type { get; set; }
        public List<SimulationMeasure> Measures { get; set; }
    }

    public enum SimulationMeasureType
    {
        None,
        ModelMeasure,
        EnergyPlusMeasure,        
        ReportingMeasure
    }



    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class measure
    {

        private decimal schema_versionField;

        private string nameField;

        private string uidField;

        private string version_idField;

        private string version_modifiedField;

        private string xml_checksumField;

        private string class_nameField;

        private string display_nameField;

        private string descriptionField;

        private string modeler_descriptionField;

        private measureArgument[] argumentsField;

        private measureTags tagsField;

        private measureAttribute[] attributesField;

        private measureFile[] filesField;

        /// <remarks/>
        public decimal schema_version
        {
            get
            {
                return this.schema_versionField;
            }
            set
            {
                this.schema_versionField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string uid
        {
            get
            {
                return this.uidField;
            }
            set
            {
                this.uidField = value;
            }
        }

        /// <remarks/>
        public string version_id
        {
            get
            {
                return this.version_idField;
            }
            set
            {
                this.version_idField = value;
            }
        }

        /// <remarks/>
        public string version_modified
        {
            get
            {
                return this.version_modifiedField;
            }
            set
            {
                this.version_modifiedField = value;
            }
        }

        /// <remarks/>
        public string xml_checksum
        {
            get
            {
                return this.xml_checksumField;
            }
            set
            {
                this.xml_checksumField = value;
            }
        }

        /// <remarks/>
        public string class_name
        {
            get
            {
                return this.class_nameField;
            }
            set
            {
                this.class_nameField = value;
            }
        }

        /// <remarks/>
        public string display_name
        {
            get
            {
                return this.display_nameField;
            }
            set
            {
                this.display_nameField = value;
            }
        }

        /// <remarks/>
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public string modeler_description
        {
            get
            {
                return this.modeler_descriptionField;
            }
            set
            {
                this.modeler_descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("argument", IsNullable = false)]
        public measureArgument[] arguments
        {
            get
            {
                return this.argumentsField;
            }
            set
            {
                this.argumentsField = value;
            }
        }

        /// <remarks/>
        public measureTags tags
        {
            get
            {
                return this.tagsField;
            }
            set
            {
                this.tagsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("attribute", IsNullable = false)]
        public measureAttribute[] attributes
        {
            get
            {
                return this.attributesField;
            }
            set
            {
                this.attributesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("file", IsNullable = false)]
        public measureFile[] files
        {
            get
            {
                return this.filesField;
            }
            set
            {
                this.filesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class measureArgument
    {

        private string nameField;

        private string display_nameField;

        private string unitsField;

        private string descriptionField;

        private string typeField;

        private bool requiredField;

        private bool model_dependentField;

        private string default_valueField;

        private measureArgumentChoice[] choicesField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string display_name
        {
            get
            {
                return this.display_nameField;
            }
            set
            {
                this.display_nameField = value;
            }
        }

        /// <remarks/>
        public string units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }

        /// <remarks/>
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public bool required
        {
            get
            {
                return this.requiredField;
            }
            set
            {
                this.requiredField = value;
            }
        }

        /// <remarks/>
        public bool model_dependent
        {
            get
            {
                return this.model_dependentField;
            }
            set
            {
                this.model_dependentField = value;
            }
        }

        /// <remarks/>
        public string default_value
        {
            get
            {
                return this.default_valueField;
            }
            set
            {
                this.default_valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("choice", IsNullable = false)]
        public measureArgumentChoice[] choices
        {
            get
            {
                return this.choicesField;
            }
            set
            {
                this.choicesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class measureArgumentChoice
    {

        private string valueField;

        private string display_nameField;

        /// <remarks/>
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        public string display_name
        {
            get
            {
                return this.display_nameField;
            }
            set
            {
                this.display_nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class measureTags
    {

        private string tagField;

        /// <remarks/>
        public string tag
        {
            get
            {
                return this.tagField;
            }
            set
            {
                this.tagField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class measureAttribute
    {

        private string nameField;

        private string valueField;

        private string datatypeField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        public string datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class measureFile
    {

        private measureFileVersion versionField;

        private string filenameField;

        private string filetypeField;

        private string usage_typeField;

        private string checksumField;

        /// <remarks/>
        public measureFileVersion version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        public string filename
        {
            get
            {
                return this.filenameField;
            }
            set
            {
                this.filenameField = value;
            }
        }

        /// <remarks/>
        public string filetype
        {
            get
            {
                return this.filetypeField;
            }
            set
            {
                this.filetypeField = value;
            }
        }

        /// <remarks/>
        public string usage_type
        {
            get
            {
                return this.usage_typeField;
            }
            set
            {
                this.usage_typeField = value;
            }
        }

        /// <remarks/>
        public string checksum
        {
            get
            {
                return this.checksumField;
            }
            set
            {
                this.checksumField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class measureFileVersion
    {

        private string software_programField;

        private string identifierField;

        private string min_compatibleField;

        /// <remarks/>
        public string software_program
        {
            get
            {
                return this.software_programField;
            }
            set
            {
                this.software_programField = value;
            }
        }

        /// <remarks/>
        public string identifier
        {
            get
            {
                return this.identifierField;
            }
            set
            {
                this.identifierField = value;
            }
        }

        /// <remarks/>
        public string min_compatible
        {
            get
            {
                return this.min_compatibleField;
            }
            set
            {
                this.min_compatibleField = value;
            }
        }
    }





}
