using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace FR.Tools.Selecting
{
    public class Selector
    {
        private readonly Selection _selection;
        private readonly Config _config;
        public Selector(Selection selection, Config config = null)
        {
            _config = config ?? DefaultConfig;
            _selection = selection;
        }
       
        public void BeginSelect(ISelectable selectable)
        {
            if (!CanAddOne()) return;
            selectable.BeginSelectSuccess();
        }

        public void ConfirmSelect(ISelectable selectable)
        {
            if (!_selection.HasRoomFor(1) && _config.evictionType != EvictionType.None)
            {
                EvictOne();
            }
            
            if (_selection.Add(selectable))
            {
                selectable.ConfirmSelectSuccess();   
            }
        }

        public void CancelSelect(ISelectable selectable)
        {
            selectable.CancelSelectSuccess();
        }

        public void Deselect(ISelectable selectable)
        {
            if (_selection.Remove(selectable))
            {
                selectable.DeselectSuccess();
            }
        }
        
        public IEnumerable<ISelectable> GetAll()
        {
            return _selection;
        }

        public bool IsEmpty()
        {
            return _selection.Count == 0;
        }
        
        public bool Contains(ISelectable selectable)
        {
            return _selection.Contains(selectable);
        }
        
        private bool CanAddOne()
        {
            return _selection.HasRoomFor(1) || _config.evictionType != EvictionType.None;
        }
        
        [CanBeNull]
        private ISelectable EvictionTarget(EvictionType evictionType) => evictionType switch
        {
            EvictionType.None => null,
            EvictionType.Newest => _selection.FirstOrDefault(),
            EvictionType.Oldest => _selection.LastOrDefault(),
            _ => throw new ArgumentOutOfRangeException()
        };


        private bool EvictOne()
        {
            var evictionTarget = EvictionTarget(_config.evictionType);
            if (evictionTarget == null) return false;

            var success = _selection.Remove(evictionTarget);
            if (success)
            {
                evictionTarget.DeselectSuccess();
            }
            
            return success;
        }
        
        public enum EvictionType
        {
            None,
            Newest,
            Oldest,
        }
        
        [Serializable]
        public class Config
        {
            public EvictionType evictionType;
        }

        private static readonly Config DefaultConfig = new Config(){evictionType = EvictionType.None};
    }
}