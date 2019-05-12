using UnityEngine;
using System.Collections.Generic;
public class Static : ModelBase
{
    public List<DataCar> listCar = new List<DataCar>();
    public List<DataScene> listScene = new List<DataScene>();
    public List<DataTrash> listTrash = new List<DataTrash>();
    public List<DataColor> listColor = new List<DataColor>();
    public static Static instance;
    public Static()
    {
        instance = this;
    }
}