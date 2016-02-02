namespace Entitas {
    public partial class Pool {
        public ISystem CreateFightSystem() {
            return this.CreateSystem<FightSystem>();
        }
    }
}