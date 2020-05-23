using UnityEngine;
using UnityEngine.UI;

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject bullet;

    public Slider healthBar;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "meteor")
        {
            //healthBar.value = healthBar.value - 10;
            healthBar.value -= 30;

            if (healthBar.value <= 0)
            {
                Destroy(healthBar.gameObject, 0.1f);
                Destroy(this.gameObject, 0.1f);
            }

            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }


    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if (Input.GetKeyDown("space"))
        {
            //Instantiate(bullet,this.transform.position,Quaternion.identity);
            GameObject _bullet = Pool.singleton.Get("bullet");
            if(_bullet != null)
            {
                _bullet.transform.position = this.transform.position;
                _bullet.SetActive(true);
            }

        }

        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position) +
            new Vector3(0, -50, 0);
        healthBar.transform.position = screenPos;

    }
}