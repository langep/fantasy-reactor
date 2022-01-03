using FR.Tools.Selecting;
using UnityEngine;

namespace FR.Game.Boards
{
    public class Cell : ISelectable
    {
        private ISelectionHandler<Cell> _selectionHandler;
        public Vector2Int Coords { get; private set; } 

        public Cell(Vector2Int coords, ISelectionHandler<Cell> selectionHandler)
        {
            _selectionHandler = selectionHandler;
            Coords = coords;
        }

        public void HoverEnter()
        {
            
        }

        public void Select()
        {
            
        }

        public void HoverExit()
        {
            
        }

        public void Deselect()
        {
            
        }
    }
}