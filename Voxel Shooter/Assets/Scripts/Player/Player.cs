using UnityEngine;
using UnityEngine.SceneManagement;

//kliknutím na podobjekt se vybere rodičovský objekt, ne konkrétní podobjekt
[SelectionBase]
public class Player : MonoBehaviour
{
    private void OnEnable() {
        EventManager.OnPlayerInteraction.AddListener(TakeThebook);
    }

    private void OnDisable() {
        EventManager.OnPlayerInteraction.RemoveListener(TakeThebook);
    }

    void Update()
    {
        if(transform.position.y < -150) {
           ResetGame();
        }
    }

    private void TakeThebook(Book book) {
        BookSO bookSO = book.BookSO;
        Destroy(book.gameObject);
    }

    private void ResetGame() {
        SceneManager.LoadScene(1);
    }
}
