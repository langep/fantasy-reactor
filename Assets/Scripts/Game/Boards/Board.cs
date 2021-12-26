using System;
using FR.Tools.Grids;
using UnityEngine;

namespace FR.Game.Boards
{
    public class Board : MonoBehaviour
    {
        [SerializeField] private Vector2Int size = new Vector2Int(1, 1);
        [SerializeField] private Vector2 cellDim = new Vector2(1, 1);
        [SerializeField] private Space2D<Cell>.Orientation orientation = Space2D<Cell>.Orientation.XY;

        public FixedSizeGrid2D<Cell> Grid { get; private set; }
        public Space2D<Cell> Space { get; private set; }

        private void Awake()
        {
            Grid = new FixedSizeGrid2D<Cell>(size, Vector2Int.zero);
            Space = new Space2D<Cell>(Grid, cellDim, transform.position, orientation);
        }

        private void Start()
        {
            Grid.Initialize(CellFactory);
        }

        private Cell CellFactory(Vector2Int coords) {
            return new Cell(coords, null);
        }
    }
}