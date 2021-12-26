using System;
using Shapes;
using UnityEngine;

namespace FR.Game.Boards
{
    [ExecuteAlways] public class BoardVisualizer : ImmediateModeShapeDrawer
    {
        [SerializeField] private Board board;

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
            bottomLeft = board.Space.Grid2World(new Vector2Int(0,0));
            bottomRight = board.Space.Grid2World(new Vector2Int(board.Grid.Size.x, 0), validateCoords: false);
            topLeft = board.Space.Grid2World(new Vector2Int(0,board.Grid.Size.y), validateCoords: false);
            topRight = board.Space.Grid2World(new Vector2Int(board.Grid.Size.x, board.Grid.Size.y), validateCoords: false);
        }
        
        public override void DrawShapes( Camera cam ){

            using( Draw.Command( cam ) ){

                Draw.LineGeometry = LineGeometry.Volumetric3D;
                Draw.ThicknessSpace = ThicknessSpace.Pixels;
                Draw.Thickness = 1;

                Draw.Matrix = transform.localToWorldMatrix;

                Draw.Line( bottomLeft, bottomRight, Color.grey);
                Draw.Line( bottomLeft, topLeft, Color.grey);
                Draw.Line( bottomRight, topRight, Color.grey);
                Draw.Line( topLeft, topRight, Color.grey);
            }

        }

    }
}