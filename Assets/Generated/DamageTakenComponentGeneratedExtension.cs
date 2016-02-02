using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public DamageTakenComponent damageTaken { get { return (DamageTakenComponent)GetComponent(ComponentIds.DamageTaken); } }

        public bool hasDamageTaken { get { return HasComponent(ComponentIds.DamageTaken); } }

        static readonly Stack<DamageTakenComponent> _damageTakenComponentPool = new Stack<DamageTakenComponent>();

        public static void ClearDamageTakenComponentPool() {
            _damageTakenComponentPool.Clear();
        }

        public Entity AddDamageTaken(int newValue) {
            var component = _damageTakenComponentPool.Count > 0 ? _damageTakenComponentPool.Pop() : new DamageTakenComponent();
            component.value = newValue;
            return AddComponent(ComponentIds.DamageTaken, component);
        }

        public Entity ReplaceDamageTaken(int newValue) {
            var previousComponent = hasDamageTaken ? damageTaken : null;
            var component = _damageTakenComponentPool.Count > 0 ? _damageTakenComponentPool.Pop() : new DamageTakenComponent();
            component.value = newValue;
            ReplaceComponent(ComponentIds.DamageTaken, component);
            if (previousComponent != null) {
                _damageTakenComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveDamageTaken() {
            var component = damageTaken;
            RemoveComponent(ComponentIds.DamageTaken);
            _damageTakenComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherDamageTaken;

        public static IMatcher DamageTaken {
            get {
                if (_matcherDamageTaken == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.DamageTaken);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherDamageTaken = matcher;
                }

                return _matcherDamageTaken;
            }
        }
    }
}
