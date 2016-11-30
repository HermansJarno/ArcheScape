public class Collections {
	public enum Tags
    {
        Collectible,
        Moveable,
        GameController,
        Environment
    }

    public enum Scenes
    {
        StartScene,
        RoomScene
    }

    public static string ToString(System.Enum type)
    {
        return type.ToString();
    }
}
