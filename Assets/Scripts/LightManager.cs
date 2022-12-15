using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightManager : MonoBehaviour
{
    [SerializeField] private Light _DirectionalLight;
    [SerializeField] private LightScript _script;
    [SerializeField] private float _TimeOfDay = 35f;
    // Start is called before the first frame update

    private void UpdateLight(float time) {
        RenderSettings.ambientLight = _script.AmbientColor.Evaluate(time);

        if (_DirectionalLight != null) {
            _DirectionalLight.color = _script.DirectionalColor.Evaluate(time);
            _DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((time * 360f) - 90f, 30f, 0));
        }
    }

    void Update()
    {
        if(_script == null) {
            return;
        }

        if(Application.isPlaying){
            _TimeOfDay += Time.deltaTime;
            _TimeOfDay %= 100;
            UpdateLight(_TimeOfDay / 100f);
        }
    }
}
