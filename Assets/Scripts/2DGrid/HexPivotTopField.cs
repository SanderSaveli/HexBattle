using System.Collections.Generic;
using UnityEngine;

namespace CellField2D
{
    public class HexPivotTopField<TCell> : CellField<TCell> where TCell : I2DCell
    {
        protected override List<Vector2> GetCellNeighboursOffsets(Vector2 coordinates)
        {
            List<Vector2> neighbourOffsets;

            if (coordinates.y % 2 == 0)
            {
                neighbourOffsets = new List<Vector2>
                {
                    new Vector2(0, 1),
                    new Vector2(1, 0),
                    new Vector2(0, -1),
                    new Vector2(-1, -1),
                    new Vector2(-1, 0),
                    new Vector2 (-1, 1),
                };
            }
            else
            {
                neighbourOffsets = new List<Vector2>
                {
                    new Vector2(1, 1),
                    new Vector2(1, 0),
                    new Vector2(1, -1),
                    new Vector2(0, -1),
                    new Vector2(-1, 0),
                    new Vector2 (0, 1),
                };
            }
            return neighbourOffsets;
        }
    }
}
