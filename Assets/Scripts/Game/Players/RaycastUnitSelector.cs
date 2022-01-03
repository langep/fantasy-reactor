using FR.Game.Units;
using FR.Tools.Selecting;
using JetBrains.Annotations;
using UnityEngine;

namespace FR.Game.Players
{
    public class RaycastUnitSelector : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] protected UnitSelectionController controller;
        [CanBeNull] protected ISelectable previousSelectable = null;

        private void OnDisable()
        {
            previousSelectable = null;
        }
        
        private void Update()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            var selectable = AquireTarget(ray);
            var toggledSelection = HandleSelection(selectable);
            HandleHover(selectable, toggledSelection);
            previousSelectable = selectable;
        }
        
        private ISelectable AquireTarget(Ray ray)
        {
            if (!Physics.Raycast(ray, out var hit))
            {
                return null;
            }
            
            var selectable = hit.transform.GetComponent<UnitSelectable>();
            return selectable != null ? selectable : null;
        }
        

        private bool HandleSelection(ISelectable selectable)
        {
            if (selectable == null) return false;
            if (!Input.GetMouseButtonDown(0)) return false;

            controller.ToggleSelect(selectable);
            return true;
        }

        private void HandleHover(ISelectable selectable, bool toggledSelection)
        {
            if (previousSelectable != selectable)
            {
                controller.HoverExit(previousSelectable);
            }
            if (controller.SelectionContains(selectable)) return;
            if (previousSelectable != selectable || toggledSelection)
            {
                controller.HoverEnter(selectable);
            }
        }


    }
}