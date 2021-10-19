using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] GameObject[] CarParts;

    private CarModel _carModel = new CarModel();

    public void ChangeColors(int color)
    {
        Color newColor = Color.blue;

        if (color == 1)
            newColor = Color.green;
        else if (color == 2)
            newColor = Color.magenta;

        foreach (var item in CarParts)
        {
            item.GetComponent<MeshRenderer>().material.color = newColor;
        }

        _carModel.Color = color; //Сохраняем цвет.
        SaveCar();
    }

    public void LoadCar(CarModel model)
    {
        if(model == null)
            return;
        ChangeColors(model.Color);
    }

    public void SaveCar()
    {
        SettingClass.PlayerCar = _carModel;
    }
}
