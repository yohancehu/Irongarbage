using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D rb1;
    public Rigidbody2D rb2;
    public SpriteRenderer ropeDisplay;

    public float breakLimitTime = 5f;
    public float breakForce = 200;
    public float force = 1f;
    public float minDistance = 0f;
    public float maxDistance = 10f;

    private bool _isBreak;
    private float _timer;

    private void FixedUpdate()
    {
        Vector3 pos1 = rb1.transform.position;
        Vector3 pos2 = rb2.transform.position;
        Vector3 mid = (pos1 + pos2) / 2;
        bool isBreak = Vector3.Distance(pos1, pos2) > maxDistance;
        if (!_isBreak && isBreak)
        {
            _timer = breakLimitTime;
        }
        _isBreak = isBreak;

        if (_isBreak)
        {
            if (_timer < 0)
            {
                Destroy(ropeDisplay.gameObject);
                Destroy(gameObject);
                GameObject prefab = Resources.Load<GameObject>("Prefabs/Lose");
                Instantiate(prefab, UIRoot.Instance.transform);
                return;
            }

            _timer -= Time.fixedDeltaTime;
            ropeDisplay.gameObject.SetActive(false);
        }
        else
        {

            if (Vector3.Distance(pos1, pos2) < minDistance)
            {
                rb1.AddForce((pos1 - mid).normalized * force);
                rb2.AddForce((pos1 - mid).normalized * force);
            }
            ropeDisplay.transform.position = mid;
            ropeDisplay.transform.up = rb1.transform.position - rb2.transform.position;
            ropeDisplay.size = new Vector2(0.8f, Vector2.Distance(rb1.transform.position, rb2.transform.position));

            ropeDisplay.gameObject.SetActive(true);
        }

    }


}
