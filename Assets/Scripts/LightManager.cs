using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightManager : MonoBehaviour
{
    [SerializeField] private Light _DirectionalLight;
    [SerializeField] private LightScript _script;
    [SerializeField] private float _TimeOfDay = 40f;
    // Start is called before the first frame update

    private void UpdateLight(float time) {
        RenderSettings.ambientLight = _script.AmbientColor.Evaluate(time);

        if (_DirectionalLight != null) {
            _DirectionalLight.color = _script.DirectionalColor.Evaluate(time);
            _DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((time * 360f) - 90f, 170f, 0));
        }
    }

    void Update()
    {
        if(_script == null) {
            return;
        }

        if(Application.isPlaying){
            _TimeOfDay += Time.deltaTime;
            _TimeOfDay %= 24;
            UpdateLight(_TimeOfDay / 24f);
        }
    }
}
