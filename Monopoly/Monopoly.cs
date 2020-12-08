using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    class Monopoly
    {
        public List<Tuple<string, int>> players = new List<Tuple<string, int>>();
        public List<Field> fields = new List<Field>()
        {
            new Field("Ford", new AutoType(), 0, false), 
            new Field("MCDonald", new FoodType(), 0, false),
            new Field("Lamoda", new ClotherType(), 0, false),
            new Field("Air Baltic", new TravelType(), 0, false),
            new Field("Nordavia", new TravelType(), 0, false),
            new Field("Prison", new PrisonType(), 0, false),
            new Field("MCDonald", new FoodType(), 0, false),
            new Field("TESLA", new AutoType(), 0, false)
        };

        public Monopoly(string[] p)
        {
            foreach (var player in p)
            {
                players.Add(new Tuple<string,int>(player, 6000));     
            }
        }

        internal List<Tuple<string, int>> GetPlayersList() => players;

        internal List<Field> GetFieldsList() => fields;

        internal Field GetFieldByName(string name) => fields.FirstOrDefault(x => x.Name == name);

        internal bool Buy(int index, Field field)
        {
            if(field.OwnerId != 0)
            {
                return false;
            }

            var x = GetPlayerInfo(index);
            players[index - 1] = new Tuple<string, int>(x.Item1, x.Item2 - field.FieldType.BuyPrice);
            field.SetOwnedId(index);

            return true;
        }

        internal Tuple<string, int> GetPlayerInfo(int v) => players[v - 1];

        internal bool Renta(int index, Field field)
        {
            if(field.OwnerId == 0)
            {
                return false;
            }

            var z = GetPlayerInfo(index);
            var o = GetPlayerInfo(field.OwnerId);
            z = new Tuple<string, int>(z.Item1, z.Item2 - field.FieldType.RentaPrice);
            o = new Tuple<string, int>(o.Item1, o.Item2 + field.FieldType.RentaPrice);
            players[index - 1] = z;
            if(o != null)
                players[field.OwnerId - 1] = o;

            return true;
        }
    }

    public enum Type
    {
        AUTO,
        FOOD,
        CLOTHER,
        TRAVEL,
        PRISON,
        BANK
    }
}
