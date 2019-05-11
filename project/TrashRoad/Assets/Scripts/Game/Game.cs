public class Game
{
    private static Game instance;
    public static Game Instance
    {
        get
        {
            if (instance == null)
                instance = new Game();
            return instance;
        }
    }
    public void Init()
    {
        Static.Instance.Init();
        Profile.Instance.Init();
        GameScene.Instance.Init();
    }
}