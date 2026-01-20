using UnityEngine;

public class Plate : MonoBehaviour
{
    public Bolt[] bolts;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    public void OnBoltRemoved(Bolt bolt)
    {
        bool allRemoved = true;
        foreach (var b in bolts)
        {
            if (b != null)
            {
                allRemoved = false;
                break;
            }
        }

        if (allRemoved)
        {
            rb.gravityScale = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plate"))
        {
            GameManager.Instance.Fail();
        }
    }
}