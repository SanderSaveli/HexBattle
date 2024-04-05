using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Mirror;

namespace CellField2D
{
    public class FieldManager : NetworkBehaviour
    {
        public ICellField<IOwnedCell> cellField { get; private set; }
        [SerializeField] private Tilemap fieldTilemap;
        [SerializeField] private List<Transform> firstPlayerStartCells = new List<Transform>();
        [SerializeField] private List<Transform> secondPlayerStartCells = new List<Transform>();
        private readonly int noneOwnerID = 0;

        [ClientRpc]
        public void InstantField(int firstPlayerID, int secondPlayerID)
        {
            cellField = new HexPivotTopField<IOwnedCell>();
            int fieldSize = fieldTilemap.transform.childCount;
            for (int i = 0; i < fieldSize; i++)
            {
                Transform childTransform = fieldTilemap.transform.GetChild(i);
                if (childTransform.TryGetComponent(out OwnedCellView view))
                {
                    Vector2Int cellCoordinate = (Vector2Int)fieldTilemap.WorldToCell(childTransform.position);
                    IOwnedCell ownedCell;
                    int ownerID = GetStartCellOvnerID(childTransform, firstPlayerID, secondPlayerID);        
                    ownedCell = new OwnedCell(cellCoordinate, ownerID);
                    cellField.InstantCell(ownedCell);
                    view.SetObservedCell(ownedCell);
                }

            }
        }

        private int GetStartCellOvnerID(Transform cellTransform, int firstPlayerID, int secondPlayerID)
        {
            foreach (Transform startCell in firstPlayerStartCells)
            {
                if (startCell == cellTransform)
                    return firstPlayerID;
            }

            foreach (Transform startCell in secondPlayerStartCells)
            {
                if (startCell == cellTransform)
                    return secondPlayerID;
            }
            return noneOwnerID;
        }
    }
}

