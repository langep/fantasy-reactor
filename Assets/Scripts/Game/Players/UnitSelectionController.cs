using FR.Tools.Selecting;
using UnityEngine;

namespace FR.Game.Players
{
    public class UnitSelectionController : MonoBehaviour
    {
        [SerializeField] protected Selector.Config selectorConfig;

        private Selector _selector;

        protected void Start()
        {
            _selector = new Selector(new SingleSelection(), selectorConfig);
        }
        
        private void OnDisable()
        {
            _selector.Clear();
        }

        public bool SelectionContains(ISelectable selectable) => _selector.Contains(selectable);

        public void HoverEnter(ISelectable selectable) => _selector.HoverEnter(selectable);

        public void HoverExit(ISelectable selectable) =>  _selector.HoverExit(selectable);

        public void Select(ISelectable selectable) => _selector.Select(selectable);

        public void Deselect(ISelectable selectable) => _selector.Deselect(selectable);

        public void ToggleSelect(ISelectable selectable)
        {
            if (_selector.Contains(selectable))
            {
                _selector.Deselect(selectable);
            }
            else
            {
                _selector.Select(selectable);
            }
        }

    }
}