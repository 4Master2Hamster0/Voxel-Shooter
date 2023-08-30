using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
  [SerializeField] private LensDistortion _scopeSetting;
  [SerializeField] private PostProcessProfile _profil;
  [SerializeField] private float _timeBetweenScope = 2, _intensity;

  public static PostProcessingController Instance {get; private set;}

  private void Start() {
    _scopeSetting = _profil.GetSetting<LensDistortion>();
  }

  private void Update() {
    scopeManager();
  }

  private void scopeIn(){
    
  }     
   
  private void scopeOut(){

  }

  private bool isScoping(){
      if(_scopeSetting.intensity.value >= 1 || _scopeSetting.intensity.value <= 0) return false;
      else return true;
  }

  private void scopeManager(){
    if(Input.GetKeyDown(KeyCode.Mouse0)) {

        if(isScoping()) return;
        else{
            if(isScopedIn()){
                scopeOut();
            }
            else{
                
            }
        }
    }
  }

  private bool isScopedIn(){
      return true;
  }
}