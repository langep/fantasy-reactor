using FR.Game.Units;
using UnityEngine;

namespace FR.Game.Players
{
    public class RaycastUnitSelector : UnitSelector
    {
        [SerializeField] private Camera _camera;

        private void Update()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            UpdateSelection(ray);

            if (Input.GetMouseButtonDown(0))
            {
                ConfirmSelectAndDeselect();
            }
        }
        
        private void HandleRaycastMiss()
        {
            BeginAndCancelSelect(null);
        }

        private void UpdateSelection(Ray ray)
        {
            if (Physics.Raycast(ray, out var hit))
            {
                var selectable = hit.transform.GetComponent<UnitSelectable>();
                if (selectable != null)
                {
                    BeginAndCancelSelect(selectable);
                }
                else
                {
                    HandleRaycastMiss();                    
                }
            }
            else
            {
                HandleRaycastMiss();
            }
        }
    }
}