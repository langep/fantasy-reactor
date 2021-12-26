using System;
using Shapes;
using UnityEngine;

namespace FR.Game.Boards
{
    [ExecuteAlways] public class BoardVisualizer : ImmediateModeShapeDrawer
    {
        [SerializeField] private Board board;

        [SerializeField] private Vector2Int Size = new Vector2Int(5, 5);
        [SerializeField] private Vector3 bottomLeft = new Vector3(0, 0, 0);
        [SerializeField] private Vector3 bottomRight = new Vector3(5, 0, 0);
        [SerializeField] private Vector3 topLeft = new Vector3(0, 0, 5);
        [SerializeField] private Vector3 topRight = new Vector3(5, 0, 5);

        private void Start()
        {
            if (Application.IsPlaying(gameObject))
            {
                InitializeFromBoard();
            }
        }

        private void InitializeFromBoard()
        {
            Size = board.Grid.Size;
            var position = transform.position;
            bottomLeft = board.Space.Grid2World(new Vector2Int(0,0)) - position;
            bottomRight = board.Space.Grid2World(new Vector2Int(board.Grid.Size.x, 0), validateCoords: false) - position;
            topLeft = board.Space.Grid2World(new Vector2Int(0,board.Grid.Size.y), validateCoords: false) - position;
            topRight = board.Space.Grid2World(new Vector2Int(board.Grid.Size.x, board.Grid.Size.y), validateCoords: false) - position;
        }
        
        public override void DrawShapes( Camera cam ){

            using( Draw.Command( cam ) ){

                Draw.LineGeometry = LineGeometry.Volumetric3D;
                Draw.ThicknessSpace = ThicknessSpace.Pixels;
                Draw.Thickness = 1;

                Draw.Matrix = transform.localToWorldMatrix;

                var yOffset = (topLeft - bottomLeft) / (Size.y);
                var xOffset = (bottomRight - bottomLeft) / (Size.x);
                
                // Horizontal lines
                for (var i = 0; i < Size.y + 1; i++)
                {
                    Draw.Line( bottomLeft + i * yOffset, bottomRight + i * yOffset, Color.grey);
                }
                
                // Vertical lines
                for (var i = 0; i < Size.x + 1; i++)
                {
                    Draw.Line( bottomLeft + i * xOffset, topLeft + i * xOffset, Color.grey);
                }

            }

        }

    }
}