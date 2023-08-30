using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class RadioButtonSystem : MonoBehaviour
{
    private ToggleGroup toggleGroup;
    [SerializeField] GameDifficultySO _gameDifficultySO;

    private void Start() {
        toggleGroup = GetComponent<ToggleGroup>();
    }

    //funkčnost kódu závisí na jménách Toggle buttonů. Pokud bude změněn název v UI, tak pravděpodobně funčkonst kódu selže
    public void Play() {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        Difficulty selectedDifficulty;

        switch(toggle.name) {
            case "Easy":
                selectedDifficulty = Difficulty.EASY;
                break;
            
            case "Medium":
                selectedDifficulty = Difficulty.MEDIUM;
                break;

            case "Hard":
                selectedDifficulty = Difficulty.HARD;
                break;

            default: 
                print("Žádný toggle button nebyl zjištěn. Nastavuju automaticky na easy");
                selectedDifficulty = Difficulty.EASY;
                break;
        }

        _gameDifficultySO.SetDifficulty(selectedDifficulty);
        SwtichScenes();
        
    }

    private void SwtichScenes() {
        SceneManager.LoadScene(1);
    }
    
}
