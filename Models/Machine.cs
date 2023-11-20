

namespace TC_WinForms.Models
{
    internal class Machine : Struct, IModelStructure  //3. Требования к механизмам
    {
        static EModelType modelType = EModelType.Machine;
        public EModelType ModelType { get => modelType; }

        int num;
        string name;
        string? type;
        string unit;
        double amount; // TODO - проверка на 0 и отриц значений
        public Machine()
        {

        }
        public Machine(int num, string name, string? type, string unit, double amount)
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
