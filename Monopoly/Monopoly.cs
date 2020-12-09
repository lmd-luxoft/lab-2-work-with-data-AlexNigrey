using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    class Monopoly
    {
        public List<Player> players = new List<Player>();
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
                players.Add(new Player(player, 6000));
            }
        }

        internal List<Player> GetPlayersList() => players;

        internal List<Field> GetFieldsList() => fields;

        internal Field GetFieldByName(string name) => fields.FirstOrDefault(x => x.Name == name);

        internal bool Buy(int index, Field field)
        {
            if(field.OwnerId != 0)
            {
                return false;
            }

            players[index - 1].Pay(field.FieldType.BuyPrice);
            field.SetOwnedId(index);

            return true;
        }

        internal Player GetPlayerInfo(int v) => players[v - 1];

        internal bool Renta(int index, Field field)
        {
            if(field.OwnerId == 0)
            {
                return false;
            }

            var payer = GetPlayerInfo(index);
            var seller = GetPlayerInfo(field.OwnerId);

            payer.Pay(field.FieldType.RentaPrice);
            seller.Sell(field.FieldType.RentaPrice);

            players[index - 1] = payer;
            if(seller != null)
                players[field.OwnerId - 1] = seller;

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
