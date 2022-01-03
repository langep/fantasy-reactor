using System;
using UniRx;
using UnityEngine;

namespace FR.Tools.Selecting
{
    public class SelectableBehaviour : MonoBehaviour, IObservableSelectable
    {
        protected readonly ObservableSelectable _observableSelectable = new ObservableSelectable();

        protected virtual void OnHoverEnter()
        {
            
        }
        
        protected virtual void OnHoverExit()
        {
            
        }
        
        protected virtual void OnSelect()
        {
        }
        
        protected virtual void OnDeselect()
        {
            
        }

        public void HoverEnter()
        {
            _observableSelectable.HoverEnter();
            OnHoverEnter();
        }

        public void HoverExit()
        {
            _observableSelectable.HoverExit();
            OnHoverExit();
        }

        public void Select()
        {
            _observableSelectable.Select();
            OnSelect();
        }

        public void Deselect()
        {
            _observableSelectable.Deselect();
            OnDeselect();
        }
        public IObservable<Unit> OnHoverEnterAsObservable() => _observableSelectable.OnHoverEnterAsObservable();

        public IObservable<Unit> OnHoverExitAsObservable() => _observableSelectable.OnHoverExitAsObservable();

        public IObservable<Unit> OnSelectAsObservable() => _observableSelectable.OnSelectAsObservable();

        public IObservable<Unit> OnDeselectAsObservable() => _observableSelectable.OnDeselectAsObservable();
    }
}