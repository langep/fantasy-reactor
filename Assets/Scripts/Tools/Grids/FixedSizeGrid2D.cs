using System;
using UnityEngine;

namespace FR.Tools.Grids
{
    public class FixedSizeGrid2D<TCell> : Grid2D<TCell>
    {
        public Vector2Int Size { get; private set; }
        
        public FixedSizeGrid2D(Vector2Int size, Vector2Int origin = default) : base(origin)
        {
            Size = size;
        }

        public void Initialize(Func<Vector2Int, TCell> cellFactory)
        {
            for (var x = 0; x < Size.x; x++)
            {
                for (var y = 0; y < Size.y; y++)
                {
                    var coords = new Vector2Int(x, y);
                    var cell = cellFactory(coords);
                    TryAddCell(coords, cell);
                }
            }
        }
        
        public override bool IsValidCoord(Vector2Int coords)
        {
            var end = Origin + Size;
            for (var i = 0; i <= 1; i++)
            {
                if (coords[i] < Origin[i] || coords[i] >= end[i]) return false;
            }

            return true;
        }
    }
}