using UnityEngine;

public class SumNumbers : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _finishSum = 50;
    private int _counter;
    private Restart _restart;
    private int _sum;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _sum = 0;
            Debug.Log($"Обнуляемся! Сумма равна {_sum}!");
            return;
        }

        if (Input.anyKeyDown)
        {
            if (int.TryParse(Input.inputString, out int number))
            {
                _sum += number;
                _counter++;
                Debug.Log($"{number} \n Сумма: {_sum}");
                CheckTotalSum();
            }
            else
            {
                Debug.Log("Введите корректный символ: цифра от 1 до 9!!!");
            }
        }
    }

    #endregion

    #region Private methods

    private void CheckTotalSum()
    {
        _restart = StartGame;

        if (_sum == _finishSum)
        {
            Debug.Log($"Победа! Количество ходов: {_counter}");
            _restart();
        }
        else if (_sum > _finishSum)
        {
            Debug.Log($"Перебор! Вы проиграли за {_counter} ходов!!!");
            _restart();
        }
    }

    private void StartGame()
    {
        Debug.Log($"Нажимайте цифры от 1 до 9, чтобы получить {_finishSum}:");
        _sum = 0;
        _counter = 0;
    }

    #endregion

    #region Local data

    private delegate void Restart();

    #endregion
}