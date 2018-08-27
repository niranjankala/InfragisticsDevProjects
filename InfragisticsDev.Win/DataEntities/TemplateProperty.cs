using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InfragisticsDev.Win.DataEntities
{
    public class ComponentPropertyBase : INotifyPropertyChanged, IDataErrorInfo
    {
        private Dictionary<string, string> error = new Dictionary<string, string>();
        private string propertyName = string.Empty;
        private object displayValue = string.Empty;
        private object value = string.Empty;
        private DependencyType dependencyType = DependencyType.None;
        private bool hasModifedValue = false;
        private string unit = string.Empty;
        private string simModelClass = string.Empty;

        [DisplayName("Property")]
        [XmlAttribute]
        public string PropertyName
        {
            get { return propertyName; }
            set
            {
                if (value != this.propertyName)
                {
                    this.propertyName = value;
                    NotifyPropertyChanged("Property");
                }
            }
        }

        [DisplayName("Value")]
        public object DisplayValue
        {
            get { return displayValue; }
            set
            {
                if (value != this.displayValue)
                {
                    displayValue = value;
                    //NotifyPropertyChanged("DisplayValue");
                }
            }
        }

        public DependencyType DependencyType
        {
            get { return dependencyType; }
            set
            {
                if (value != this.dependencyType)
                {
                    dependencyType = value;
                    NotifyPropertyChanged("DependencyType");
                }
            }
        }

        [XmlAttribute]
        public string SimModelClass
        {
            get { return simModelClass; }
            set
            {
                if (value != this.simModelClass)
                {
                    simModelClass = value;
                    NotifyPropertyChanged("SimModelClass");
                }
            }
        }

        public object Value
        {
            get { return this.value; }
            set
            {
                if (value != this.value)
                {
                    this.value = value;
                    //NotifyPropertyChanged("Value");
                }
            }
        }

        [Browsable(false)]
        public bool HasModifiedValue
        {
            get { return hasModifedValue; }
            set
            {
                if (value != this.hasModifedValue)
                {
                    this.hasModifedValue = value;
                }
            }
        }

        [XmlAttribute]
        public string Unit
        {
            get { return unit; }
            set
            {
                if (value != this.unit)
                {
                    unit = value;
                    NotifyPropertyChanged("Unit");
                }
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        internal void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get { return GetError(); }
        }

        string GetError()
        {
            return string.Empty;
        }
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                return GetColumnError(columnName);
            }
        }

        public void SetColumnError(string columnName, string errorMessage)
        {
            if (GetColumnError(columnName) != errorMessage)
            {
                if (error.ContainsKey(columnName))
                {
                    error[columnName] = errorMessage;
                }
                else
                {
                    error.Add(columnName, errorMessage);
                }
            }
        }

        public void ClearErrors()
        {
            if (error != null)
                error.Clear();
        }

        public void ClearError(string column)
        {
            if (error != null)
            {
                error.Remove(column);
            }
        }

        public string GetColumnError(string columnName)
        {
            if (error.ContainsKey(columnName))
                return error[columnName];
            return string.Empty;
        }

        [Browsable(false)]
        public bool HasErrors
        {
            get
            {
                return (error == null ? false : error.Count != 0);
            }
        }
        #endregion

    }

    public class ComponentProperty : ComponentPropertyBase
    {

        private List<ComponentProperty> properties = new List<ComponentProperty>();
        private int key;
        private string simModelPropertyName;
        private string simModelT24PropertyName;
        private string category = string.Empty;
        private string outputRequestPropertyName = string.Empty;
        private string type = string.Empty;
        private string subType = string.Empty;
        private object defaultValue = string.Empty;
        private string dataType = string.Empty;
        private string displayOutPutRequestClass = string.Empty;
        private string propertyKey = string.Empty;

        private object listType = false;
        private string field = string.Empty;
        private string iDDObject = string.Empty;
        private string originalUnit = string.Empty;
        private string convertedUnit = string.Empty;
        private string iDDSlashCode = string.Empty;
        private bool isIpUnit = false;
        private int iterations;
        private int iterationsCount; // This property will use to count SubChildProperty Count.
        private int parentKey = -1;
        private string parentID = string.Empty;
        private string parentValue = string.Empty;
        private string validationError = string.Empty;
        private string isPrimary = string.Empty;
        private string save = string.Empty;
        private string required = string.Empty;
        private PropertyToBelong propertyBelong = PropertyToBelong.None;
        private string complianceUse = string.Empty;
        private bool isEditable = true;
        private bool isHiddenEPlusProperty = false; //This property will use to maintain EPlus property to show in Grid or Not
        private bool isT24PropertyAgainSave = false; //This property will use to save Autocalculate value.
        private string t24ToolTipMessage = string.Empty;
        private bool isPropertyExpend = false; //This property will contain that this property expend in associated Grid  or not  
        private string scheduleType = string.Empty;
        private bool showInline = false;
        private bool isSimple = false;

        public string PropertyKey
        {
            get { return propertyKey; }
            set
            {
                if (this.propertyKey != value)
                {
                    propertyKey = value;
                    NotifyPropertyChanged("PropertyKey");
                }
            }
        }
        [XmlAttribute]
        public string Category
        {
            get { return category; }
            set
            {
                if (value != this.category)
                {
                    category = value;
                    NotifyPropertyChanged("Category");
                }
            }
        }
        [XmlAttribute]
        public string Required
        {
            get { return required; }
            set
            {
                if (value != this.required)
                {
                    required = value;
                    NotifyPropertyChanged("Required");
                }
            }
        }

        public string Save
        {
            get { return save; }
            set
            {
                if (value != this.save)
                {
                    save = value;
                    NotifyPropertyChanged("Save");
                }
            }
        }

        [Browsable(false)]
        [XmlAttribute]
        public string IsPrimary
        {
            get { return isPrimary; }
            set
            {
                if (value != this.isPrimary)
                {
                    isPrimary = value;
                    NotifyPropertyChanged("IsPrimary");
                }
            }
        }

        public string ValidationError
        {
            get { return validationError; }
            set
            {
                if (value != this.validationError)
                {
                    validationError = value;
                    NotifyPropertyChanged("ValidationError");
                }
            }
        }

        [XmlAttribute]
        public string ParentValue
        {
            get { return parentValue; }
            set
            {
                if (value != this.parentValue)
                {
                    parentValue = value;
                    NotifyPropertyChanged("ParentValue");
                }
            }
        }

        [DisplayName("Property")]
        public string SimModelPropertyName
        {
            get { return simModelPropertyName; }
            set { simModelPropertyName = value; }
        }

        [DisplayName("Property")]
        public string SimModelT24PropertyName
        {
            get { return simModelT24PropertyName; }
            set { simModelT24PropertyName = value; }
        }

        [XmlAttribute]
        public int ParentKey
        {
            get { return parentKey; }
            set
            {
                if (value != this.parentKey)
                {
                    parentKey = value;
                    NotifyPropertyChanged("ParentKey");
                }
            }
        }

        [XmlAttribute]
        public string ParentID
        {
            get { return parentID; }
            set
            {
                if (value != this.parentID)
                {
                    parentID = value;
                    NotifyPropertyChanged("ParentID");
                }
            }
        }

        [XmlAttribute]
        public object DefaultValue
        {
            get { return defaultValue; }
            set
            {
                if (value != this.defaultValue)
                {
                    defaultValue = value;
                    NotifyPropertyChanged("DefaultValue");
                }
            }
        }



        [DisplayName("Display Name for Class")]
        public string DisplayOutPutRequestClass
        {
            get { return displayOutPutRequestClass; }
            set
            {
                if (value != this.displayOutPutRequestClass)
                {
                    displayOutPutRequestClass = value;
                    NotifyPropertyChanged("DisplayOutPutRequestClass");
                }
            }
        }
        [XmlAttribute]
        public string Type
        {
            get { return type; }
            set
            {
                if (value != this.type)
                {
                    type = value;
                    NotifyPropertyChanged("Type");
                }
            }
        }
        [XmlAttribute]
        public string SubType
        {
            get { return subType; }
            set
            {
                if (value != this.subType)
                {
                    subType = value;
                    NotifyPropertyChanged("SubType");
                }
            }
        }

        private bool isHiddenSimModelProperty;
        /// <summary>
        /// This property will use to maintain Those SimModel Property which have null value
        /// </summary>
        public bool IsHiddenSimModelProperty
        {
            get
            {
                if (DisplayValue == null || Convert.ToString(DisplayValue).Trim() == string.Empty)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set { isHiddenSimModelProperty = value; }
        }

        /// <summary>
        /// This property will use to maintain EPlus property to show in Grid or Not
        /// </summary>
        public bool IsHiddenEPlusProperty
        {
            get { return isHiddenEPlusProperty; }
            set { isHiddenEPlusProperty = value; }
        }

        public bool ShowInline
        {
            get { return showInline; }
            set { showInline = value; }
        }

        public bool IsSimple
        {
            get { return isSimple; }
            set { isSimple = value; }
        }



        [XmlIgnore]
        public string OutPutRequestPropertyName
        {
            get { return outputRequestPropertyName; }
            set
            {
                if (value != this.outputRequestPropertyName)
                {
                    outputRequestPropertyName = value;
                    NotifyPropertyChanged("OutPutRequestPropertyName");
                }
            }
        }

        [XmlAttribute]
        public int Key
        {
            get { return key; }
            set
            {
                if (value != this.key)
                {
                    this.key = value;
                    NotifyPropertyChanged("Key");
                }
            }
        }

        [XmlAttribute]
        public string DataType
        {
            get { return dataType; }
            set
            {

                if (this.dataType != value)
                {
                    dataType = value;
                    NotifyPropertyChanged("DataType");
                }
            }
        }

        [XmlAttribute]
        public object ListType
        {
            get { return listType; }
            set
            {
                if (this.listType != value)
                {
                    listType = value;
                    NotifyPropertyChanged("ListType");
                }
            }
        }

        public string Field
        {
            get { return field; }
            set
            {
                if (value != field)
                {
                    field = value;
                    NotifyPropertyChanged("Field");
                }
            }
        }

        [Browsable(false)]
        public string IDDObject
        {
            get { return iDDObject; }
            set { iDDObject = value; }
        }

        public bool IsT24PropertyAgainSave
        {
            get { return isT24PropertyAgainSave; }
            set { isT24PropertyAgainSave = value; }
        }


        public string T24ToolTipMessage
        {
            get { return t24ToolTipMessage; }
            set { t24ToolTipMessage = value; }
        }


        [XmlAttribute]
        public string OriginalUnit
        {
            get { return originalUnit; }
            set
            {
                if (value != originalUnit)
                {
                    originalUnit = value;
                    NotifyPropertyChanged("OriginalUnit");
                }
            }
        }

        public string IDDSlashCode
        {
            get { return iDDSlashCode; }
            set
            {
                if (value != iDDSlashCode)
                {
                    iDDSlashCode = value;
                    NotifyPropertyChanged("IDDSlashCode");
                }
            }
        }

        /// <summary>
        /// This property will use to count SubChildProperty Count.
        /// </summary>
        [XmlAttribute]
        public int IterationsCount
        {
            get { return iterationsCount; }
            set
            {
                if (value != this.iterationsCount)
                {
                    iterationsCount = value;
                    NotifyPropertyChanged("IterationsCount");
                }
            }
        }

        [XmlAttribute]
        public int Iterations
        {
            get { return iterations; }
            set
            {
                if (value != this.iterations)
                {
                    iterations = value;
                    NotifyPropertyChanged("Iterations");
                }
            }
        }

        public string ConvertedUnit
        {
            get { return convertedUnit; }
            set
            {
                if (value != convertedUnit)
                {
                    convertedUnit = value;
                    NotifyPropertyChanged("ConvertedUnit");
                }
            }
        }

        [Browsable(false)]
        [XmlAttribute]
        public bool IsIpUnit
        {
            get { return isIpUnit; }
            set
            {
                if (value != isIpUnit)
                {
                    isIpUnit = value;
                    NotifyPropertyChanged("IsIpUnit");
                }
            }
        }

        public PropertyToBelong PropertyBelong
        {
            get { return propertyBelong; }
            set { propertyBelong = value; }
        }
        public string ComplianceUse
        {
            get { return complianceUse; }
            set { complianceUse = value; }
        }
        [XmlAttribute]
        public bool IsEditable
        {
            get { return isEditable; }
            set { isEditable = value; }
        }

        public bool IsPropertyExpend
        {
            get { return isPropertyExpend; }
            set { isPropertyExpend = value; }
        }

        public string ScheduleType
        {
            get
            {
                return scheduleType;
            }
            set
            {
                scheduleType = value;
            }
        }

        public List<ComponentProperty> Properties
        {
            get
            {
                return properties;
            }
            set
            {
                if (value != this.Properties)
                {
                    properties = value;
                    NotifyPropertyChanged("Properties");
                }
            }
        }
    }

    public class TemplateProperty : ComponentProperty
    {
        [XmlAttribute]
        public bool InstanceSpeciferProperty { get; set; }
        [XmlAttribute]
        public string InstanceSpeciferPropName { get; set; }
    }
}
