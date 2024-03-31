using System.Collections.Generic;
using UnityEngine;

namespace CellField2D
{
    public class RectangleField<TCell> : CellField<TCell> where TCell : I2DCell
    {
        protected override List<Vector2> GetCellNeighboursOffsets(Vector2 coordinates)
        {
            return new List<Vector2>()
            {
                new Vector2(0 ,1),
                new Vector2(1 ,1),
                new Vector2(1 ,0),
                new Vector2(1 ,-1),
                new Vector2(0 ,-1),
                new Vector2 (-1 ,-1),
                new Vector2 (-1 ,0),
                new Vector2 (-1 ,1),
            };
        }
    }
}


