using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _actionButonText;
    [SerializeField] private BookSO _bookSO;
    [SerializeField] private GameObject _player;
    [SerializeField] private Button _button;
    [SerializeField] private float _displayDistance = 8;
    [SerializeField] private float _interactableDistance = 2;

    public BookSO BookSO => _bookSO;

    private void Start()
    {
        _player = ReferenceManager.Instance.Player;
        _actionButonText = GetComponentInChildren<TextMeshProUGUI>();
    }
    
    private void Update()
    {
        DisplayWhenPlayerNear();
        Rotate();
        CheckPlayerInteraction();
    }

    //Zobrazí se písmeno E nad knihou, jakmile bude vzdálenost od knihy a hráče menší než _displayDinstance
    private void DisplayWhenPlayerNear() {

        if(Distance() > _displayDistance) {
            _actionButonText.enabled = false;
        } 
        else{
            _actionButonText.enabled = true;
        }
    }

    //Rotace knihy
    private void Rotate() {
        transform.Rotate(new Vector3(0,100 + GetpositiveSinus(),0) * Time.deltaTime, Space.World);
    }

    //vrací pouze hodnoty sinusu od 0 do 1, nikoliv od -1 do 1
    private float GetpositiveSinus() {
        float sinValue = (Mathf.Sin(Time.time) * 100);

        return (sinValue > 0) ? sinValue : 0;
    }

    private float Distance() {
        return (_player.transform.position - transform.position).magnitude;
    }

    private bool IsInteractable() {
        return (Distance() > _interactableDistance) ? false : true;
    }

    //vyvolá se event, který jako parametr pošle tuto instanci bookBehaviour, která se dále zpracuje
    private void CheckPlayerInteraction() {
        if(Input.GetKeyDown(KeyCode.E) && IsInteractable()) {
            EventManager.OnPlayerInteraction?.Invoke(this);
            EnableButton();
        }
    }

    //když hráč sebere knihu, tak se čudlík k příslušnému obsahu knihy odemkne
    private void EnableButton() {
        _button.interactable = true;
    }
}
