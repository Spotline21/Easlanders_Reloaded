using UnityEngine;
using UnityEngine.UI;

public class DisplayProductVersion : MonoBehaviour
{
    [SerializeField] private Text _textComponent;

    private void Start()
    {
        // �������� �������� "Version product" �� �������� �������
        string productVersion = Application.version;

        // ������������� �������� � ��������� Text (Legacy)
        if (_textComponent != null)
        {
            _textComponent.text = "V." + productVersion;
        }
    }
}
