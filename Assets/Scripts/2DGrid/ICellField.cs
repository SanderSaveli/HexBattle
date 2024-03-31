using System.Collections.Generic;
using UnityEngine;

namespace CellField2D
{
    public interface ICellField<TCell> where TCell : I2DCell
    {
        public TCell GetCell(Vector2 coordinates);
        public TCell GetCell(int x, int y);

        public bool TryGetCell(Vector2 coordinates, out TCell cell);
        public bool TryGetCell(int x, int y, out TCell cell);

        public List<TCell> GetCellNeighbours(Vector2 coordinates);
        public List<TCell> GetCellNeighbours(int x, int y);
        public List<TCell> GetCellNeighbours(TCell cell);

        public void InstantCell(TCell cell);
        public void RemoveCell(Vector2 coordinates);
        public void RemoveCell(int x, int y);
        public void RemoveCell(TCell cell);

        public bool IsCellNeighbours(Vector2 Acoordinates, Vector2 Bcoordinates);
        public bool IsCellNeighbours(TCell ACell, TCell BCell);
        public bool IsCellNeighbours(int Ax, int Ay, int Bx, int By);

        public bool FieldContainsCell(Vector2 coordinates);
        public bool FieldContainsCell(TCell cell);
        public bool FieldContainsCell(int x, int y);
    }
}
