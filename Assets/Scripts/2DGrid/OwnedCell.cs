using UnityEngine;

namespace CellField2D
{
    public class OwnedCell : IOwnedCell
    {
        public OwnedCell(Vector2Int coordinates, int ownerID)
        {
            this.coordinates = coordinates;
            this.ownerID = ownerID;
        }
        public int ownerID { get; private set; }

        public Vector2Int coordinates { get; private set; }

        public int x { get => coordinates.x; }

        public int y { get => coordinates.y; }

        public event IOwnedCell.OwnerChanged OnOwnerChanged;

        public void changeOwner(int ownerID)
        {
            if(ownerID == this.ownerID)
                return;

            this.ownerID = ownerID;
            OnOwnerChanged?.Invoke(ownerID);
        }
    }

}

