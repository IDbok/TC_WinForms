
namespace TC_WinForms.Models
{
    public class Struct //TODO - check if it is possible to delete this class
    {
        virtual public int Num { get; set; }
        virtual public string Name { get; set; }
        virtual public string Type { get; set; }

        virtual public string Unit { get; set; }
        virtual public double Amount { get; set; }
        virtual public float? Price { get; set; }

        virtual public List<Struct>? Complect{ get; set; }

        virtual public void AddComplectItem( Struct Item ) 
        { 
            Complect.Add(Item);
        }
    }
}
