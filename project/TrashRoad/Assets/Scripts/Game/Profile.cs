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
    private int m_Coin;
    private int m_Level;
    private bool m_IsMute = false;
    private bool m_IsVibrate = false;
    public int Coin
    {
        get { return m_Coin; }
        set
        {
            m_Coin = value;
            Util.SetCoin(value);
        }
    }
    public int Level
    {
        get { return m_Level; }
        set
        {
            m_Level = value;
            Util.SetLevel(value);
        }
    }
    public bool IsMute
    {
        get { return m_IsMute; }
        set
        {
            m_IsMute = value;
            Util.SetMute(value);
        }
    }
    public bool IsVibrate
    {
        get { return m_IsVibrate; }
        set
        {
            m_IsVibrate = value;
            Util.SetVibrate(value);
        }
    }
    public void Init()
    {
        m_Coin = Util.GetCoin();
        m_Level = Util.GetLevel();
        m_IsMute = Util.GetMute();
        m_IsVibrate = Util.GetVibrate();
    }
}