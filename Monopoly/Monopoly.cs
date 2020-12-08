using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Monopoly
    {
        public List<Tuple<string, int>> players = new List<Tuple<string, int>>();
        public List<Field> fields = new List<Field>()
        {
            new Field("Ford", Type.AUTO, 0, false), 
            new Field("MCDonald", Type.FOOD, 0, false),
            new Field("Lamoda", Type.CLOTHER, 0, false),
            new Field("Air Baltic", Type.TRAVEL, 0, false),
            new Field("Nordavia", Type.TRAVEL, 0, false),
            new Field("Prison", Type.PRISON, 0, false),
            new Field("MCDonald", Type.FOOD, 0, false),
            new Field("TESLA", Type.AUTO, 0, false)
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

        internal bool Buy(int v, Field field)
        {
            if(field.OwnerId != 0)
            {
                return false;
            }

            var x = GetPlayerInfo(v);

            switch(field.FieldType)
            {
                case Type.AUTO:
                    players[v - 1] = new Tuple<string, int>(x.Item1, x.Item2 - 500);
                    break;
                case Type.FOOD:
                    players[v - 1] = new Tuple<string, int>(x.Item1, x.Item2 - 250);
                    break;
                case Type.TRAVEL:
                    players[v - 1] = new Tuple<string, int>(x.Item1, x.Item2 - 700);
                    break;
                case Type.CLOTHER:
                    players[v - 1] = new Tuple<string, int>(x.Item1, x.Item2 - 100);
                    break;
                default:
                    return false;
            }
            field.SetOwnedId(v);

             return true;
        }

        internal Tuple<string, int> GetPlayerInfo(int v)
        {
            return players[v - 1];
        }

        internal bool Renta(int v, Field k)
        {
            if(k.OwnerId == 0)
            {
                return false;
            }

            var z = GetPlayerInfo(v);
            var o = GetPlayerInfo(k.OwnerId);

            switch (k.FieldType)
            {
                case Type.AUTO:
                    z = new Tuple<string, int>(z.Item1, z.Item2 - 250);
                    o = new Tuple<string, int>(o.Item1,o.Item2 + 250);
                    break;
                case Type.FOOD:
                    z = new Tuple<string, int>(z.Item1, z.Item2 - 250);
                    o = new Tuple<string, int>(o.Item1, o.Item2 + 250);

                    break;
                case Type.TRAVEL:
                    z = new Tuple<string, int>(z.Item1, z.Item2 - 300);
                    o = new Tuple<string, int>(o.Item1, o.Item2 + 300);
                    break;
                case Type.CLOTHER:
                    z = new Tuple<string, int>(z.Item1, z.Item2 - 100);
                    o = new Tuple<string, int>(o.Item1, o.Item2 + 1000);

                    break;
                case Type.PRISON:
                    z = new Tuple<string, int>(z.Item1, z.Item2 - 1000);
                    break;
                case Type.BANK:
                    z = new Tuple<string, int>(z.Item1, z.Item2 - 700);
                    break;
                default:
                    return false;
            }
            players[v - 1] = z;
            if(o != null)
                players[k.OwnerId - 1] = o;
            return true;
        }
    }

    class Field
    {
        public Field(string name, Type type, int ownerId, bool boolfield)
        {
            _name = name;
            _fieldType = type;
            _ownerId = ownerId;
            _boolfield = boolfield;
        }

        public string Name 
        {
            get
            {
               return _name;
            }

            private set
            {
                _name = value;
            }
        }

        public Type FieldType
        {
            get
            {
                return _fieldType;
            }

            private set
            {
                _fieldType = value;
            }
        }

        public int OwnerId
        {
            get
            {
                return _ownerId;
            }

            private set
            {
                _ownerId = value;
            }
        }

        public bool Boolfield
        {
            get
            {
                return _boolfield;
            }

            private set
            {
                _boolfield = value;
            }
        }

        public void SetOwnedId(int v)
        {
            OwnerId = v;
        }

        private string _name;
        private Type _fieldType;
        private int _ownerId;
        private bool _boolfield;
    }

    internal enum Type
    {
        AUTO,
        FOOD,
        CLOTHER,
        TRAVEL,
        PRISON,
        BANK
    }
}
