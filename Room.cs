namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private string roomItem;

        public Room(string description, string item)
        {
            this.description = description;
            this.roomItem = item;
        }

        public string GetDescription()
        {
            return description;
        }

        public string GetRoomItem()
        {
            if (roomItem == null)
            {
                return "none";
            }
            return roomItem;
        }

        public void RemoveItem()
        {
            this.roomItem = null;
        }
    }
}