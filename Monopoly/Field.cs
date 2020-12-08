namespace Monopoly
{
    class Field
    {
        public Field(string name, FieldType type, int ownerId, bool tag)
        {
            Name = name;
            FieldType = type;
            OwnerId = ownerId;
            Tag = tag;
        }

        public string Name { get; private set; }

        public FieldType FieldType { get; private set; }

        public int OwnerId { get; private set; }

        public bool Tag { get; private set; }

        public void SetOwnedId(int v) => OwnerId = v;
    }
}
