using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public HealthComponent health { get { return (HealthComponent)GetComponent(ComponentIds.Health); } }

        public bool hasHealth { get { return HasComponent(ComponentIds.Health); } }

        static readonly Stack<HealthComponent> _healthComponentPool = new Stack<HealthComponent>();

        public static void ClearHealthComponentPool() {
            _healthComponentPool.Clear();
        }

        public Entity AddHealth(int newValue) {
            var component = _healthComponentPool.Count > 0 ? _healthComponentPool.Pop() : new HealthComponent();
            component.value = newValue;
            return AddComponent(ComponentIds.Health, component);
        }

        public Entity ReplaceHealth(int newValue) {
            var previousComponent = hasHealth ? health : null;
            var component = _healthComponentPool.Count > 0 ? _healthComponentPool.Pop() : new HealthComponent();
            component.value = newValue;
            ReplaceComponent(ComponentIds.Health, component);
            if (previousComponent != null) {
                _healthComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveHealth() {
            var component = health;
            RemoveComponent(ComponentIds.Health);
            _healthComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherHealth;

        public static IMatcher Health {
            get {
                if (_matcherHealth == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Health);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherHealth = matcher;
                }

                return _matcherHealth;
            }
        }
    }
}
