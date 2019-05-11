public class ModelCar : ModelBase
{
    protected override string key { get { return Util.KEY_CARPREFIX + Id.ToString(); } }
    public int Id;
    public int ColorId;
}