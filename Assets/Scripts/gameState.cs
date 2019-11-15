public static class GameState
{
    public static bool hasTorch = false;
    public static bool mainRoomFirstTime = true;

    public static bool isFirstRoom = true;
    public static bool isTorchRoom = false;

    public static bool goodGameOver = false;

    public static void reset()
    {
        hasTorch = false;
        mainRoomFirstTime = true;

        isFirstRoom = true;
        isTorchRoom = false;

        goodGameOver = false;
    }
}
