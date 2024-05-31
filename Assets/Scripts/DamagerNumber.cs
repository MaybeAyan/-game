using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagerNumber : MonoBehaviour
{
    public TMP_Text damageText;

    public float lifeTime = 2;
    private float lifeCounter;

    public float floatSpeed = 1f;

    private void Start()
    {
        lifeCounter = lifeTime;
    }


    private void Update()
    {
        if (lifeCounter > 0) {
            lifeCounter -= Time.deltaTime;

            if (lifeCounter <= 0)
            {
                //Destroy(gameObject);
                DamageNumberContronller.Instance.PlaceInPool(this);
            }
        }

        transform.position += Vector3.up * floatSpeed * Time.deltaTime;
    }

    public void Setup(int damageDisplay)
    {
        lifeCounter = lifeTime;
        damageText.text = damageDisplay.ToString();
    }
}
