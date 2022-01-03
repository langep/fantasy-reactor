using System;
using UniRx;

namespace FR.Tools.Selecting
{
    public class ObservableSelectable : ISelectable
    {
        private Subject<Unit> _onHoverEnter;
        private Subject<Unit> _onHoverExit;
        private Subject<Unit> _onSelect;
        private Subject<Unit> _onDeselect;
        
        public IObservable<Unit> OnHoverEnterAsObservable()
        {
            return _onHoverEnter ??= new Subject<Unit>();
        }
        
        public IObservable<Unit> OnHoverExitAsObservable()
        {
            return _onHoverExit ??= new Subject<Unit>();
        }
        
        public IObservable<Unit> OnSelectAsObservable()
        {
            return _onSelect ??= new Subject<Unit>();
        }
        
        public IObservable<Unit> OnDeselectAsObservable()
        {
            return _onDeselect ??= new Subject<Unit>();
        }

        public void HoverEnter()
        {
            if (_onHoverEnter != null) _onHoverEnter.OnNext(Unit.Default);
        }

        public void HoverExit()
        {
            if (_onHoverExit != null) _onHoverExit.OnNext(Unit.Default);
        }

        public void Select()
        {
            if (_onSelect != null) _onSelect.OnNext(Unit.Default);
        }

        public void Deselect()
        {
            if (_onDeselect != null) _onDeselect.OnNext(Unit.Default);
        }
    }
}