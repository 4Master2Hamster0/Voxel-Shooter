using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanelSystem : MonoBehaviour
{
    public Image KnowlageDisplayImg;

    public void Exit() {
        if(Time.timeScale != 1) Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void DisplayBookInfo(BookSO bookSO) {
        RectTransform rectTrans = KnowlageDisplayImg.transform as RectTransform;
        rectTrans.sizeDelta = bookSO.Scale;
        KnowlageDisplayImg.sprite = bookSO.Sprite;
        EnableKnowlageImg();
    }

    private void EnableKnowlageImg() {
        KnowlageDisplayImg.gameObject.SetActive(true);
    }

    public void DisableKnowlageImg() {
        KnowlageDisplayImg.gameObject.SetActive(false);
    }

}
