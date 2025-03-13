namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private string item;

        public Room(string description, string item = null)
        {
            this.description = description;
            this.item = item;
        }

        public string GetDescription() => description;
        public string GetItem() => item;
        public void SetItem(string item) => this.item = item;
    }
}