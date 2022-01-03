using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace FR.Tools.Selecting
{
    public class Selector
    {
        private readonly Selection _selection;
        private readonly HashSet<ISelectable> _hovering;

        private readonly Config _config;
        public Selector(Selection selection, Config config = null)
        {
            _config = config ?? DefaultConfig;
            _selection = selection;
            _hovering = new HashSet<ISelectable>();
        }
        
        public void Clear()
        {
            foreach (var selectable in _selection)
            {
                selectable.Deselect();
            }
            _selection.Clear();
        }
       
        public void HoverEnter(ISelectable selectable)
        {
            if (selectable == null || Contains(selectable)) return;
            if (!CanAddOne()) return;
            selectable.HoverEnter();
            _hovering.Add(selectable);
        }
        
        public void HoverExit(ISelectable selectable)
        {
            if (selectable == null || Contains(selectable)) return;
            selectable.HoverExit();
            _hovering.Remove(selectable);
        }

        public void Select(ISelectable selectable)
        {
            if (!_selection.HasRoomFor(1) && _config.evictionType != EvictionType.None)
            {
                EvictOne();
            }
            
            if (_selection.Add(selectable))
            {
                selectable.Select();
                _hovering.Remove(selectable);
            }
        }
        
        public void Deselect(ISelectable selectable)
        {
            if (_selection.Remove(selectable))
            {
                selectable.Deselect();
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
            return selectable != null && _selection.Contains(selectable);
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
                evictionTarget.Deselect();
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