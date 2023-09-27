using UnityEngine;
using UnityEngine.UI;

public class DisplayProductVersion : MonoBehaviour
{
    [SerializeField] private Text _textComponent;

    private void Start()
    {
        // Получаем значение "Version product" из настроек проекта
        string productVersion = Application.version;

        // Устанавливаем значение в компонент Text (Legacy)
        if (_textComponent != null)
        {
            _textComponent.text = "V." + productVersion;
        }
    }
}
