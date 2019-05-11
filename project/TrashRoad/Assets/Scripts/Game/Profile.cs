using System.Collections.Generic;
public class Profile
{
    private static Profile instance;
    public static Profile Instance
    {
        get
        {
            if (instance == null)
                instance = new Profile();
            return instance;
        }
    }

    private int coin;
    public int Coin
    {
        get
        {
            return coin;
        }
        set
        {
            coin = value;
            Util.SetCoin(value);
        }
    }
    private int level;
    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
            Util.SetLevel(value);
        }
    }
    private int usedCarId;
    public int UsedCarId
    {
        get
        {
            return usedCarId;
        }
        set
        {
            usedCarId = value;
            Util.SetUsedCarId(value);
        }
    }

    public ModelCar GetCarModelById(int id)
    {
        return Util.GetCarModelById(id);
    }

    public void Init()
    {

    }
}