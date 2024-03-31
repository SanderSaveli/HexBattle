using System.Collections.Generic;
using UnityEngine;

namespace CellField2D
{
    public abstract class CellField<TCell> : ICellField<TCell> where TCell : I2DCell
    {
        protected Dictionary<Vector2, TCell> _field;

        #region GetCell

        public TCell GetCell(int x, int y) => GetCell(new Vector2(x, y));

        public TCell GetCell(Vector2 coordinates) => _field[coordinates];
        public bool TryGetCell(int x, int y, out TCell cell) => TryGetCell(new Vector2(x, y), out cell);

        public bool TryGetCell(Vector2 coordinates, out TCell cell)
        {
            if (FieldContainsCell(coordinates))
            {
                cell = GetCell(coordinates);
                return true;
            }
            cell = default;
            return false;
        }


        #endregion

        #region FieldContainsCell
        public bool FieldContainsCell(TCell cell)
        {
            return FieldContainsCell(cell.coordinates);
        }

        public bool FieldContainsCell(int x, int y)
        {
            return FieldContainsCell(new Vector2(x, y));
        }

        public bool FieldContainsCell(Vector2 coordinates)
        {
            return _field.ContainsKey(coordinates);
        }
        #endregion

        #region GetCellNeighbours
        public List<TCell> GetCellNeighbours(int x, int y) => GetCellNeighbours(new Vector2(x, y));

        public List<TCell> GetCellNeighbours(TCell cell) => GetCellNeighbours(cell.coordinates);

        public List<TCell> GetCellNeighbours(Vector2 coordinates)
        {
            List<TCell> neighbours = new List<TCell>();
            List<Vector2> neighbourOffsets = GetCellNeighboursOffsets(coordinates);

            foreach (Vector2 offset in neighbourOffsets)
            {
                Vector2 potentialNeighbour = offset + coordinates;
                if (FieldContainsCell(potentialNeighbour))
                {
                    neighbours.Add(GetCell(potentialNeighbour));
                }
            }

            return neighbours;
        }

        #endregion

        #region InstantCell
        public void InstantCell(TCell cell)
        {
            if (_field.ContainsKey(cell.coordinates))
                return;

            _field.Add(cell.coordinates, cell);
        }
        #endregion

        #region IsCellNeighbours
        public bool IsCellNeighbours(TCell ACell, TCell BCell) => IsCellNeighbours(ACell.coordinates, BCell.coordinates);

        public bool IsCellNeighbours(int Ax, int Ay, int Bx, int By) => IsCellNeighbours(new Vector2(Ax, Ay), new Vector2(Bx, By));

        public bool IsCellNeighbours(Vector2 Acoordinates, Vector2 Bcoordinates)
        {
            List<Vector2> neighbourOffsets = GetCellNeighboursOffsets(Acoordinates);
            foreach (Vector2 offset in neighbourOffsets)
            {
                if (Acoordinates + offset == Bcoordinates)
                    return true;
            }
            return false;
        }
        #endregion

        #region RemoveCell
        public void RemoveCell(int x, int y) => RemoveCell(new Vector2(x, y));

        public void RemoveCell(TCell cell) => RemoveCell(cell.coordinates);
        public void RemoveCell(Vector2 coordinates)
        {
            if (FieldContainsCell(coordinates))
            {
                _field.Remove(coordinates);
            }
        }
        #endregion

        protected abstract List<Vector2> GetCellNeighboursOffsets(Vector2 coordinates);
    }
}


