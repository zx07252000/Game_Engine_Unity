using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;

    private float shakeLength;
    private float shakePower;
    private float fadeTime;

    private bool camerMove;

    private void Start()
    {
        shakeLength = 0.0f;
        shakePower = 0.0f;
        fadeTime = 0.0f;
        camerMove = true;
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x,
                                         player.transform.position.y,
                                         player.transform.position.z - 10);
        
        if (Input.GetKeyDown(KeyCode.V))
        {
            ShakingCamera(0.5f, 0.1f);
        }
    }

    private void LateUpdate()
    {
        if(shakeLength > 0)
        {
            shakeLength -= Time.deltaTime;

            float shakePowerX = Random.Range(-1.0f, 1.0f) * shakePower;
            float shakePowerY = Random.Range(-1.0f, 1.0f) * shakePower;

            transform.position += new Vector3(shakePowerX, shakePowerY, 0);

            shakePower = Mathf.MoveTowards(shakePower, 0, fadeTime * Time.deltaTime);
        }
    }

    public void ShakingCamera(float length, float power)
    {
        shakeLength = length;
        shakePower = power;
        fadeTime = power;
    }
}
