using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIzeChangingObstacle : MonoBehaviour
{
    [SerializeField] private bool isMakingBigger;

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCor(collision.transform);
        }
        Destroy(gameObject);
    }

    private void StartCor(Transform targetTransfrom)
    {
        StartCoroutine(ChangeSizeCoroutine(targetTransfrom));
    }

    private IEnumerator ChangeSizeCoroutine(Transform targetTransfrom)
    {
        if (isMakingBigger)
        {
            Debug.Log("Fuck niggers");
            targetTransfrom.localScale = new Vector2(targetTransfrom.localScale.x + 0.05f,
                targetTransfrom.localScale.y + 0.05f); ;
            yield return new WaitForSeconds(0.1f);
            /*вот окей, это г не работает
             Кто-то может сказать, почему? Почему оно не хочет выполняться дальше 
            первой гребаной строчки?
            Хорошо, давай поговорим. Какого х? Я ж почитал про проблему.
            И нет, я не вызываю тебя в апдейте.
            Почему все остальные корутины работают нормально?
            Окей, это будет выглядеть как говно и по факту им являться и будет. Очень, очень жаль*/
            Debug.Log("Fuck niggers");

            targetTransfrom.localScale = new Vector2(targetTransfrom.localScale.x + 0.01f,
                 targetTransfrom.localScale.y + 0.01f);
            yield return new WaitForSeconds(0.1f);
            Debug.Log("Fuck niggers");

            targetTransfrom.localScale = new Vector2(targetTransfrom.localScale.x + 0.01f,
                 targetTransfrom.localScale.y + 0.01f);
            yield return new WaitForSeconds(0.1f);
            Debug.Log("Fuck niggers");

            targetTransfrom.localScale = new Vector2(targetTransfrom.localScale.x + 0.01f,
                 targetTransfrom.localScale.y + 0.01f);
            yield return new WaitForSeconds(0.1f);
            targetTransfrom.localScale = new Vector2(targetTransfrom.localScale.x + 0.01f,
                 targetTransfrom.localScale.y + 0.01f);
            yield return new WaitForSeconds(0.1f);

        }
        else
        {

            targetTransfrom.localScale = new Vector2(targetTransfrom.localScale.x - 0.05f,
                targetTransfrom.localScale.y - 0.05f);
            yield return new WaitForSeconds(0.1f); targetTransfrom.localScale = new Vector2(targetTransfrom.localScale.x - 0.01f,
                 targetTransfrom.localScale.y - 0.01f);
            yield return new WaitForSeconds(0.1f); targetTransfrom.localScale = new Vector2(targetTransfrom.localScale.x - 0.01f,
                 targetTransfrom.localScale.y - 0.01f);
            yield return new WaitForSeconds(0.1f); targetTransfrom.localScale = new Vector2(targetTransfrom.localScale.x - 0.01f,
                 targetTransfrom.localScale.y - 0.01f);
            yield return new WaitForSeconds(0.1f); targetTransfrom.localScale = new Vector2(targetTransfrom.localScale.x - 0.01f,
                 targetTransfrom.localScale.y - 0.01f);
            yield return new WaitForSeconds(0.1f);

            yield return null;
        }
        Debug.Log("AAAAAAAA");
        yield return null;
    }
}
