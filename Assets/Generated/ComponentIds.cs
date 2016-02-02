public static class ComponentIds {
    public const int DamageTaken = 0;
    public const int Fightable = 1;
    public const int Fighting = 2;
    public const int Health = 3;

    public const int TotalComponents = 4;

    public static readonly string[] componentNames = {
        "DamageTaken",
        "Fightable",
        "Fighting",
        "Health"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(DamageTakenComponent),
        typeof(Fightable),
        typeof(FightingComponent),
        typeof(HealthComponent)
    };
}