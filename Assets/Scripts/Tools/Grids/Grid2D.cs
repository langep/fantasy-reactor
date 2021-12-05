using System;
using System.Collections.Concurrent;
using UnityEngine;

namespace FR.Tools.Grids
{
    public class Grid2D<TCell> : IGrid2D<TCell>
    {
        private readonly ConcurrentDictionary<Vector2Int, TCell> _cells;

        public Grid2D()
        {
            _cells = new ConcurrentDictionary<Vector2Int, TCell>();
        }

        public Grid2D(ConcurrentDictionary<Vector2Int, TCell> cells)
        {
            _cells = cells;
        }

        public virtual bool IsValidCoord(Vector2Int coords)
        {
            return true;
        }
        
        public bool TryAddCell(Vector2Int coords, TCell cell, bool existsOk = true)
        {
            if (!IsValidCoord(coords)) return false;

            if (!existsOk) return _cells.TryAdd(coords, cell);
            
            _cells[coords] = cell;
            return true;
        }

        public bool TryGetCell(Vector2Int coords, out TCell cell)
        {
            cell = default(TCell);
            return IsValidCoord(coords) && _cells.TryGetValue(coords, out cell);
        }
    }
}