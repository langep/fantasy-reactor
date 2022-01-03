using System;
using UniRx;

namespace FR.Tools.Selecting
{
    public interface IObservableSelectable : ISelectable
    {
        public IObservable<Unit> OnHoverEnterAsObservable();

        public IObservable<Unit> OnHoverExitAsObservable();

        public IObservable<Unit> OnSelectAsObservable();

        public IObservable<Unit> OnDeselectAsObservable();
    }
}