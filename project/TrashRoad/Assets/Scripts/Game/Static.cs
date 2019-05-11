public class Static
{
    private static Static instance;
    public static Static Instance
    {
        get
        {
            if (instance == null)
                instance = new Static();
            return instance;
        }
    }
    public void Init()
    {

    }
}