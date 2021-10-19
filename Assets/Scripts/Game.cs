using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private float TimeLimit = 30;
    private const float Distance = 20;
    private const int PointCount = 10;

    [SerializeField] GameObject RacePrefab;
    [SerializeField] Transform StartPosirion;

    public Text TimeText;
    public GameObject[] MissoinPoints;
    private GameObject _playerCar;
    private GameObject _car;

    private int _currentPoints;
    private int _currentIndex;
    private float _lastTime;

    void Start()
    {
        _playerCar = Instantiate(RacePrefab, StartPosirion.transform.position, StartPosirion.transform.rotation);
        _playerCar.GetComponentInChildren<ChangeColor>().LoadCar(SettingClass.PlayerCar);
        _car = _playerCar.GetComponentInChildren<ChangeColor>().gameObject;

        foreach (var item in MissoinPoints )
        {
            item.SetActive(false);
            MissoinPoints[_currentIndex].SetActive(true);
        }

        _lastTime = Time.time;
    }

    void Update()
    {
        if (Vector3.Distance(_car.transform.position, MissoinPoints[_currentIndex].transform.position) < Distance)
        {
            _currentPoints += PointCount;
            MissoinPoints[_currentIndex].SetActive(false);
            _currentIndex++;

            float time = Time.time - _lastTime;
            if (TimeLimit < time)
            {
                SceneManager.LoadScene("Main");
            }
            TimeText.text = (Time.time - _lastTime).ToString();

            if (_currentIndex >= MissoinPoints.Length)
            {
                SettingClass.Points += _currentPoints;
                SceneManager.LoadScene("Main");
            }
            else
            {
                MissoinPoints[_currentIndex].SetActive(true);
            }

            _lastTime = Time.time; 
        }
    }
}
