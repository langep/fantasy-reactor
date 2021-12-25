using FR.Tools.Selecting;
using UnityEngine;
using EPOOutline;

namespace FR.Game.Units
{
    [RequireComponent(typeof(Outlinable))]
    public class UnitSelectable : Selectable
    {

        [SerializeField] private Outlinable _outlinable;
        
        private void Awake()
        {
            _outlinable = GetComponent<Outlinable>();
        }

        protected override void OnBeginSelect(bool success)
        {
            Debug.Log($"OnBeginSelect: {success}");
            if (success)
            {
                _outlinable.enabled = true;
                _outlinable.OutlineParameters.Color = Color.blue;
            }
        }

        protected override void OnConfirmSelect(bool success)
        {
            Debug.Log($"OnConfirmSelect: {success}");
            _outlinable.enabled = true;
            _outlinable.OutlineParameters.Color = Color.green;
        }

        protected override void OnCancelSelect(bool success)
        {
            Debug.Log($"OnCancelSelect: {success}");
            if (!IsSelected)
            {
                _outlinable.enabled = false;
            }
        }

        protected override void OnDeselect(bool success)
        {
            Debug.Log($"OnDeselect: {success}");
            _outlinable.enabled = false;
        }
    }
}