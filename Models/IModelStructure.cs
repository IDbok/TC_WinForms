using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC_WinForms.Models
{
    internal interface IModelStructure
    {

        static EModelType ModelType { get; }
        static string ModelTypeName { get; }
        int Num { get; set; }
        //static string[][] GetColumnsNames { get;} 
    }
}
