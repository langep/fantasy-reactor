using FR.Tools.Selecting;
using UnityEngine;
using FR.Tools.Juice;

namespace FR.Game.Units
{
    public class UnitSelectable : SelectableBehaviour
    {

        [SerializeField] private Outline _outline;

        public override void BeginSelectSuccess()
        {
            _outline.SetColor(Color.blue);
            _outline.Show();
        }

        public override void ConfirmSelectSuccess()
        {
            _outline.SetColor(Color.green);
            _outline.Show();
        }

        public override void CancelSelectSuccess()
        {
            _outline.Hide();
        }

        public override void DeselectSuccess()
        {
            _outline.Hide();
        }
    }
}