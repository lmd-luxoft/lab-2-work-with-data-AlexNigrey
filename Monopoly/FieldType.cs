namespace Monopoly
{
    public abstract class FieldType
    {
        public abstract Type Type { get; }
        public abstract int RentaPrice { get; }
        public abstract int BuyPrice { get; }
    }

    public class AutoType: FieldType
    {
        public override Type Type => Type.AUTO;
        public override int RentaPrice => 250;
        public override int BuyPrice => 500;
    }

    public class FoodType : FieldType
    {
        public override Type Type => Type.FOOD;
        public override int RentaPrice => 250;
        public override int BuyPrice => 250;
    }

    public class ClotherType : FieldType
    {
        public override Type Type => Type.CLOTHER;
        public override int RentaPrice => 1000;
        public override int BuyPrice => 100;
    }

    public class TravelType : FieldType
    {
        public override Type Type => Type.TRAVEL;
        public override int RentaPrice => 300;
        public override int BuyPrice => 700;
    }

    public class PrisonType : FieldType
    {
        public override Type Type => Type.PRISON;
        public override int RentaPrice => 1000;
        public override int BuyPrice => 0;
    }

    public class BankType : FieldType
    {
        public override Type Type => Type.BANK;
        public override int RentaPrice => 700;
        public override int BuyPrice => 0;
    }
}
