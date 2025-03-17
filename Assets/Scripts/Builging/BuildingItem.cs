using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingItem : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _textMash;

    private Building _building;
    private Placer _placer;

    private void OnDisable()
    {
      _button.onClick.RemoveAllListeners();   
    }

    public void Init(Building building, Placer placer)
    {
        _building = building ?? throw new System.ArgumentNullException(nameof(building));
        _placer = placer ?? throw new System.ArgumentNullException(nameof(placer));



        _textMash.text = building.name;
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        _placer.SetBuilding(_building);
    }
}
