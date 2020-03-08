using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(5f * Time.deltaTime * Vector2.right);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //StartCoroutine(StopTimeImpact());
            other.gameObject.GetComponent<FrogScript>().Death();
            Destroy(gameObject);
        }
    }

    private IEnumerator StopTimeImpact()
    {
        Time.timeScale = 0f;
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        Time.timeScale = 1f;
    }
    
}
