using UnityEngine;
using UnityEngine.SceneManagement;

//kliknutím na podobjekt se vybere rodičovský objekt, ne konkrétní podobjekt
[SelectionBase]
public class Player : MonoBehaviour
{
    private void OnEnable() {
        EventManager.OnPlayerInteraction.AddListener(TakeBook);
    }

    private void OnDisable() {
        EventManager.OnPlayerInteraction.RemoveListener(TakeBook);
    }

    void Update()
    {
        if(transform.position.y < -150) {
           ResetGame();
        }
    }

    private void TakeBook(Book book) {
        BookSO bookSO = book.BookSO;
        Destroy(book.gameObject);
    }

    private void ResetGame() {
        SceneManager.LoadScene(1);
    }
}
