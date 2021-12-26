using FR.Tools.Selecting;
using JetBrains.Annotations;
using UnityEngine;

namespace FR.Game.Players
{
    public class UnitSelector : MonoBehaviour
    {
        [SerializeField] protected Selector.Config selectorConfig;
        
        private Selector _selector;
        [CanBeNull] private ISelectable _currentSelectable = null;

        protected void Start()
        {
            _selector = new Selector(new SingleSelection(), selectorConfig);
        }

        protected void BeginAndCancelSelect([CanBeNull] ISelectable selectable)
        {
            if (_currentSelectable == selectable) return;
            
            if (_currentSelectable != null && !_selector.Contains(_currentSelectable))
            {
                _selector.CancelSelect(_currentSelectable);
            }
            _currentSelectable = selectable;

            if (selectable != null && !_selector.Contains(_currentSelectable))
            {
                _selector.BeginSelect(selectable);
            }
        }

        protected void ConfirmSelectAndDeselect()
        {
            if (!_selector.Contains(_currentSelectable))
            {
                _selector.ConfirmSelect(_currentSelectable);
            }
            else
            {
                _selector.Deselect(_currentSelectable);
                _currentSelectable = null;
            }
        }
    }
}