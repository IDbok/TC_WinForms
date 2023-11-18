using System.Text.Json.Serialization;

namespace TC_WinForms.Models
{
    internal class Component : Struct //2. Требования к материалам и комплектующим
    {
        static int count;
        int num;
        string name;
        string? type;
        string unit;
        double amount;
        float? price;
        List<Struct>? complect; // 

        public Component()
        {
            count++;
        }

        public Component(int num, string name, string? type, string unit, int amount, float? price)
        {
            this.num = num;
            this.name = name;
            this.type = type;
            this.unit = unit;
            this.amount = amount;
            this.price = price;
            count++;
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
        {
            get { return amount; }
            set
            {
                if (value > 0) { amount = value; }
                else { Console.WriteLine("Кол-во не может быть 0 или отрицательным"); }

            }
        }
        public override List<Struct> Complect
        { get { return complect; } }
        public override void AddComplectItem(Struct Item)
        {
            if (complect.Count == 0 ) complect = new List<Struct>();
            complect.Add(Item);
        }

        public string ToString()
        {
            return $"{num} {name} {type} {amount}{unit}";
        }

    }
}
