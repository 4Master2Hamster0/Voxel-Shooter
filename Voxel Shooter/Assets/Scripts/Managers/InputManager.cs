using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            GameObject pausePanel = ReferenceManager.Instance.PausePanel;
            bool isPanelActive = pausePanel.activeSelf;
            
            EventManager.OnEscPressed?.Invoke(isPanelActive);
            pausePanel.SetActive(!isPanelActive);

            if(pausePanel.activeSelf) {
                UnlockCursor();
            }
            else{         
                LockCursor();
            }
        }
    }

    private void LockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    private void UnlockCursor() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }
}
