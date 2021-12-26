using FR.Tools.Grids;
using UnityEngine;

namespace FR.Game.Boards
{
    public class Board : MonoBehaviour
    {
        [SerializeField] private Vector2Int size = new Vector2Int(1, 1);
        [SerializeField] private Vector2 cellDim = new Vector2(1, 1);
        [SerializeField] private Space2D<Cell>.Orientation orientation= Space2D<Cell>.Orientation.XY;
        
        private FixedSizeGrid2D<Cell> _grid;
        private Space2D<Cell> _space;

        private void Start()
        {
            _grid = new FixedSizeGrid2D<Cell>(size, Vector2Int.zero);
            _space = new Space2D<Cell>(_grid, cellDim, transform.position, orientation);
            
            _grid.Initialize(CellFactory);
        }

        private Cell CellFactory(Vector2Int coords) {
            return new Cell(coords, null);
        }
    }
}