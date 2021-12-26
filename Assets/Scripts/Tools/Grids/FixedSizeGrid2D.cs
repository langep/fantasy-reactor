using System;
using UnityEngine;

namespace FR.Tools.Grids
{
    public class FixedSizeGrid2D<TCell> : Grid2D<TCell>
    {
        private readonly Vector2Int _size;
        
        public FixedSizeGrid2D(Vector2Int size, Vector2Int origin = default) : base(origin)
        {
            _size = size;
        }

        public void Initialize(Func<Vector2Int, TCell> cellFactory)
        {
            for (var x = 0; x < _size.x; x++)
            {
                for (var y = 0; y < _size.y; y++)
                {
                    var coords = new Vector2Int(x, y);
                    var cell = cellFactory(coords);
                    TryAddCell(coords, cell);
                }
            }
        }
        
        public override bool IsValidCoord(Vector2Int coords)
        {
            var end = Origin + _size;
            for (var i = 0; i <= 1; i++)
            {
                if (coords[i] < Origin[i] || coords[i] >= end[i]) return false;
            }

            return true;
        }
    }
}