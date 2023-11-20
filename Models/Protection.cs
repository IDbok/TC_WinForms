
namespace TC_WinForms.Models
{
    internal class Protection : Struct, IModelStructure//4. Требования к средствам защиты
    {
        static private EModelType modelType = EModelType.Protection;
        public EModelType ModelType { get { return modelType; } }

        int num;
        string name;
        string? type;
        string unit;
        double amount;
        public Protection()
        {

        }
        public Protection(int num, string name, string? type, string unit, int amount)
        {
            this.num = num;
            this.name = name;
            this.type = type;
            this.unit = unit;
            this.amount = amount;
        }

        public override int Num
        { get { return num; } set { num = value; } }

        public override string Name
        { get { return name; } set { name = value; } }
        public override string? Type
        { get { return type; } set { type = value; } }

        public override string Unit
        { get { return unit; } set { unit = value; } }
        public override double Amount
        { get { return amount; } set { amount = value; } }
    }
}
