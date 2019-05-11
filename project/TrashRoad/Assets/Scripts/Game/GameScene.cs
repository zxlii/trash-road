public class GameScene
{
    private static GameScene instance;
    public static GameScene Instance
    {
        get
        {
            if (instance == null)
                instance = new GameScene();
            return instance;
        }
    }
    public void Init()
    {

    }
}