using UnityEngine;

namespace FR.Tools.Grids
{
    public class FixedSizeGrid2D<TCell> : Grid2D<TCell>
    {
        private readonly Vector2Int _origin;
        private readonly Vector2Int _size;
        
        public FixedSizeGrid2D(Vector2Int size, Vector2Int origin = default)
        {
            _size = size;
            _origin = origin;
        }
        
        public override bool IsValidCoord(Vector2Int coords)
        {
            var end = _origin + _size;
            for (var i = 0; i <= 1; i++)
            {
                if (coords[i] < _origin[i] || coords[i] >= end[i]) return false;
            }

            return true;
        }
    }
}