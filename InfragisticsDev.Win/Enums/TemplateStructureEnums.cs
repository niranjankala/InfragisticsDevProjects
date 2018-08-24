using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfragisticsDev.Win
{
    public enum PropertyToBelong
    {
        Library,
        T24,
        IFC,
        LibraryAndT24,
        SimModelAndT24,
        SimModel,
        ALl,
        None
    }

    public enum DependencyType
    {
        Enum,
        Library,
        Auto,
        Template,
        Date,
        Time,
        None
    }
}
