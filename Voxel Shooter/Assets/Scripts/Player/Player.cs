using UnityEngine;
using UnityEngine.SceneManagement;

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
        Destroy(book.gameObject);
    }

    private void ResetGame() {
        SceneManager.LoadScene(1);
    }
}
