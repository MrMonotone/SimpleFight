namespace Entitas {
    public partial class Entity {
        static readonly FightingComponent fightingComponent = new FightingComponent();

        public bool isFighting {
            get { return HasComponent(ComponentIds.Fighting); }
            set {
                if (value != isFighting) {
                    if (value) {
                        AddComponent(ComponentIds.Fighting, fightingComponent);
                    } else {
                        RemoveComponent(ComponentIds.Fighting);
                    }
                }
            }
        }

        public Entity IsFighting(bool value) {
            isFighting = value;
            return this;
        }
    }

    public partial class Pool {
        public Entity fightingEntity { get { return GetGroup(Matcher.Fighting).GetSingleEntity(); } }

        public bool isFighting {
            get { return fightingEntity != null; }
            set {
                var entity = fightingEntity;
                if (value != (entity != null)) {
                    if (value) {
                        CreateEntity().isFighting = true;
                    } else {
                        DestroyEntity(entity);
                    }
                }
            }
        }
    }

    public partial class Matcher {
        static IMatcher _matcherFighting;

        public static IMatcher Fighting {
            get {
                if (_matcherFighting == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Fighting);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherFighting = matcher;
                }

                return _matcherFighting;
            }
        }
    }
}
