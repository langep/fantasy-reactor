using System;
using UnityEngine;

namespace FR.Tools.Grids
{
    public class Space2D<TCell>
    {
        private IGrid2D<TCell> _grid;
        private Orientation _orientation;
        private Vector3 _origin;
        private Vector2 _cellDimension;

        public Space2D(IGrid2D<TCell> grid, Vector2 cellDimension, Vector3 origin = default,
            Orientation orientation = Orientation.XZ)
        {
            _cellDimension = cellDimension;
            _grid = grid;
            _orientation = orientation;
            _origin = origin;
        }

        public Vector2Int World2Grid(Vector3 worldPos)
        {
            var position = FromWorldPosition(worldPos);
            return new Vector2Int((int)position.x, (int)position.y);
        }

        public Vector3 Grid2World(Vector2Int coords)
        {
            if (!_grid.IsValidCoord(coords)) throw new ArgumentException("Invalid grid coordinates");
            var position = coords * _cellDimension;
            return ToWorldPosition(position);
        }

        private Vector2 FromWorldPosition(Vector3 worldPosition) => _orientation switch
        {
            Orientation.XZ => new Vector2(Mathf.Round((worldPosition.x - _origin.x) / _cellDimension.x), Mathf.Round((worldPosition.z - _origin.z) / _cellDimension.y)),
            Orientation.XY => new Vector2(Mathf.Round((worldPosition.x - _origin.x) / _cellDimension.x), Mathf.Round((worldPosition.y - _origin.y) / _cellDimension.y)),
            _ => throw new ArgumentException()
        };
        
        private Vector3 ToWorldPosition(Vector2 position) => _orientation switch
        {
            Orientation.XZ => new Vector3(position.x + _origin.x, _origin.y, position.y + _origin.z),
            Orientation.XY => new Vector3(position.x + _origin.x, position.y + _origin.y, _origin.z),
            _ => throw new ArgumentException()
        };

        public enum Orientation
        {
            XZ,
            XY
        }

    }
}