using FR.Tools.Selecting;
using UnityEngine;
using FR.Tools.Juice;

namespace FR.Game.Units
{
    public class UnitSelectable : SelectableBehaviour
    {

        [SerializeField] private Outline _outline;
        
        
        protected override void OnHoverEnter()
        {
            _outline.SetColor(Color.blue);
            _outline.Show();
        }

        protected override void OnHoverExit()
        {
            _outline.Hide();
        }

        protected override void OnSelect()
        {
            _outline.SetColor(Color.green);
            _outline.Show();
        }
        
        protected override void OnDeselect()
        {
            _outline.Hide();
        }
    }
}