using System;
using UnityEngine;

namespace FR.Tools.Grids
{
    public class Space2D<TCell>
    {
        private IGrid2D<TCell> _grid;
        private Orientation _orientation;
        public Vector3 Origin { get; private set; }
        public Vector2 CellDimension { get; private set; }

        public Space2D(IGrid2D<TCell> grid, Vector2 cellDimension, Vector3 origin = default,
            Orientation orientation = Orientation.XZ)
        {
            CellDimension = cellDimension;
            _grid = grid;
            _orientation = orientation;
            Origin = origin;
        }

        public Vector2Int World2Grid(Vector3 worldPos, bool validateCoords = true)
        {
            var position = FromWorldPosition(worldPos);
            var coords = new Vector2Int((int)position.x, (int)position.y);
            if (!_grid.IsValidCoord(coords) && validateCoords) throw new ArgumentException("Invalid grid coordinates");
            return coords;
        }

        public Vector3 Grid2World(Vector2Int coords, bool validateCoords = true)
        {
            if (!_grid.IsValidCoord(coords) && validateCoords) throw new ArgumentException("Invalid grid coordinates");
            var position = coords * CellDimension;
            return ToWorldPosition(position);
        }

        private Vector2 FromWorldPosition(Vector3 worldPosition) => _orientation switch
        {
            Orientation.XZ => new Vector2(Mathf.Round((worldPosition.x - Origin.x) / CellDimension.x), Mathf.Round((worldPosition.z - Origin.z) / CellDimension.y)),
            Orientation.XY => new Vector2(Mathf.Round((worldPosition.x - Origin.x) / CellDimension.x), Mathf.Round((worldPosition.y - Origin.y) / CellDimension.y)),
            _ => throw new ArgumentException()
        };
        
        private Vector3 ToWorldPosition(Vector2 position) => _orientation switch
        {
            Orientation.XZ => new Vector3(position.x + Origin.x, Origin.y, position.y + Origin.z),
            Orientation.XY => new Vector3(position.x + Origin.x, position.y + Origin.y, Origin.z),
            _ => throw new ArgumentException()
        };

        public enum Orientation
        {
            XZ,
            XY
        }

    }
}