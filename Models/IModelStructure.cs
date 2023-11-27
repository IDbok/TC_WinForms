
namespace TC_WinForms.Models
{
    public interface IModelStructure
    {

        static EModelType ModelType { get; }
        static string ModelTypeName { get; }
        int Num { get; set; }
        //static string[][] GetColumnsNames { get;} 
    }
}
