using UnityEngine;

public class Bolt : MonoBehaviour
{
    public Plate attachedPlate;
    public bool canRemove = true;

    private void Start()
    {
        GameManager.Instance.RegisterBolt();
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.isGameOver) return;
        if (!canRemove)
        {
            GameManager.Instance.Fail();
            return;
        }

        attachedPlate.OnBoltRemoved(this);
        Destroy(gameObject);
        GameManager.Instance.OnBoltRemoved();
    }
}