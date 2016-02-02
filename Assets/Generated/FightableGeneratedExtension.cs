namespace Entitas {
    public partial class Entity {
        static readonly Fightable fightableComponent = new Fightable();

        public bool isFightable {
            get { return HasComponent(ComponentIds.Fightable); }
            set {
                if (value != isFightable) {
                    if (value) {
                        AddComponent(ComponentIds.Fightable, fightableComponent);
                    } else {
                        RemoveComponent(ComponentIds.Fightable);
                    }
                }
            }
        }

        public Entity IsFightable(bool value) {
            isFightable = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherFightable;

        public static IMatcher Fightable {
            get {
                if (_matcherFightable == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Fightable);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherFightable = matcher;
                }

                return _matcherFightable;
            }
        }
    }
}
