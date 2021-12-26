using System;
using FR.Game.Units;
using FR.Tools.Selecting;
using JetBrains.Annotations;
using UnityEngine;

namespace FR.Game.Players
{
    public class RaycastUnitSelector : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private Selector.Config selectorConfig;
        
        private Selector _selector;
        [CanBeNull] private Selectable _currentSelectable = null;

        private void Start()
        {
            _selector = new Selector(new SingleSelection(), selectorConfig);
        }

        private void BeginSelect([CanBeNull] Selectable selectable)
        {
            if (_currentSelectable == selectable) return;
            
            if (_currentSelectable != null)
            {
                _selector.CancelSelect(_currentSelectable);
            }
            _currentSelectable = selectable;

            if (selectable != null)
            {
                _selector.BeginSelect(selectable);
            }
        }

        private void HandleRaycastMiss()
        {
            BeginSelect(null);
        }

        private void BeginSelection(Ray ray)
        {
            if (Physics.Raycast(ray, out var hit))
            {
                var selectable = hit.transform.GetComponentInParent<UnitSelectable>();
                if (selectable != null)
                {
                    BeginSelect(selectable);
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

        private void ConfirmSelection()
        {
            if (_currentSelectable != null)
            {
                _selector.ConfirmSelect(_currentSelectable);
            }
            _currentSelectable = null;
        }
        
        private void Update()
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            BeginSelection(ray);

            if (Input.GetMouseButtonDown(0))
            {
                if (!_selector.Contains(_currentSelectable))
                {
                    _selector.ConfirmSelect(_currentSelectable);
                }
                else
                {
                    _selector.Deselect(_currentSelectable);
                }
            }
        }
    }
}