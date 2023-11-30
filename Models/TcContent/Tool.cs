namespace TC_WinForms.Models.TcContent
{
    public class Tool : Struct, IModelStructure //5. Требования к инструментам и приспособлениям
    {
        static private EModelType modelType = EModelType.Tool;
        public EModelType ModelType { get { return modelType; } }

        int num;
        string name;
        string? type;
        string unit;
        double amount;
        public Tool()
        {

        }
        public Tool(int num, string name, string? type, string unit, int amount)
        {
            this.num = num;
            this.name = name;
            this.type = type;
            this.unit = unit;
            this.amount = amount;
        }

        public override int Num
        {
            get { return num; }
            set { num = value; }
        }

        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        public override string? Type
        {
            get { return type; }
            set { type = value; }
        }

        public override string Unit
        { get { return unit; } set { unit = value; } }
        public override double Amount
        { get { return amount; } set { amount = value; } }
    }
}
