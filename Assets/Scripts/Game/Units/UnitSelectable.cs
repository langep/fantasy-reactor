using FR.Tools.Selecting;
using UnityEngine;
using FR.Tools.Juice;

namespace FR.Game.Units
{
    public class UnitSelectable : Selectable
    {

        [SerializeField] private Outline _outline;

        protected override void OnBeginSelectSuccess()
        {
            _outline.SetColor(Color.blue);
            _outline.Show();
        }

        protected override void OnConfirmSelectSuccess()
        {
            _outline.SetColor(Color.green);
            _outline.Show();
        }

        protected override void OnCancelSelectSuccess()
        {
            _outline.Hide();
        }

        protected override void OnDeselectSuccess()
        {
            _outline.Hide();
        }
    }
}