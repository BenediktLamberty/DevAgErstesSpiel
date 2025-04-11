using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GegnerScript : MonoBehaviour
{

    public GameObject player;
    public GameObject ball;
    public float speed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = transform.position - new Vector3(1, 0, 0);
            GameObject spawnedBall = Instantiate(ball, pos, Quaternion.identity);
            spawnedBall.GetComponent<Rigidbody2D>().AddForce((- transform.position + player.transform.position) * speed);
        }
    }
}
