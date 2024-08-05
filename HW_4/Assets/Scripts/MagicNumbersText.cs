using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MagicNumbersText : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _max = 1000;
    [SerializeField] private int _min = 1;
    private int _count;
    private int _guess;
    private Restart _restart;
    private int _startMin, _startMax;
    [SerializeField] private TextMeshProUGUI _text_1;
    [SerializeField] private TextMeshProUGUI _text_2;
    [SerializeField] private TextMeshProUGUI _text_3;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        MagicNumbersText magicNumbersText = GetComponent<MagicNumbersText>();
        _startMin = magicNumbersText._min;
        _startMax = magicNumbersText._max;
        
        StartGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _max = _guess;
            CalculateGuessAndLog();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _min = _guess;
            CalculateGuessAndLog();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _restart = StartGame;

            _text_3.text = $"Ура! Твое число отгадано и равно {_guess}, количество операций {_count}";
            _restart();
        }
    }

    #endregion

    #region Private methods

    private void CalculateGuessAndLog()
    {
        _guess = (_max + _min) / 2;
        _text_2.text = $"Твое число равно {_guess}";
        _count++;
    }

    private void StartGame()
    {
        _text_1.text = $"Загадайте число от {_startMin} до {_startMax}";
        _min = _startMin;
        _max = _startMax;
        _guess = 0;
        _count = 0;
        CalculateGuessAndLog();
    }

    #endregion

    #region Local data

    private delegate void Restart();

    #endregion
}