using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class playerControllerr : MonoBehaviour
{

    public int speed = 10;
    private float ileriGeriInput;
    private float sagSolInput;
    private int count;
    public GameObject winText;
    public TextMeshProUGUI countText;
    public GameObject loseText;
    
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        winText.SetActive(false);
        loseText.SetActive(false);
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        Hareket();
    }
    void Hareket()
    {
        ileriGeriInput = Input.GetAxis("Vertical");
        sagSolInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * ileriGeriInput * speed * Time.deltaTime);
        transform.Translate(Vector3.right * sagSolInput * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        count++;
        other.gameObject.SetActive(false);
        SetCountText();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Duvar"))
        {
            loseText.SetActive(true);
        }
    }
    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        
        if (count >= 8)
        {
            winText.SetActive(true);
        }

    }
}
