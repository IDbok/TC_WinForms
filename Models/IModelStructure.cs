using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC_WinForms.Models
{


    //TODO: Реализовать interface для структуры данных, который будет содержать поле для хранения типа структуры (enum) (и метод для парсинга)
    internal interface IModelStructure
    {

        static EModelType ModelType { get; }
        static string ModelTypeName { get; }
        int Num { get; set; }

        //static string[][] GetColumnsNames { get;} 

    }
}
