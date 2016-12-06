public class Collections {
	public enum Tags
    {
        InteractionPoint,
        PuzzlePiece,
        GameController,
        Environment,
        Flashlight,
        SpawnPoint
    }

    public enum Scenes
    {
        MenuScene,
        StartRoomScene,
        RoomScene
    }

    #region ToString alternative method
    /// <summary>
    /// Returns the string representation of an enum value.
    /// </summary>
    /// <param name="value">The value which has to be converted to a string.</param>
    /// <returns>The string value of the passed enum value.</returns>
    //public static string ToString(System.Enum value)
    //{
    //    return value.ToString();
    //}
    #endregion
}
