using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private BoxCollider2D CubeBoxCollider;
    private int movedirecion = 1;
    private int boundary = 1;
    private float Boxspeed = 0.05f;
    void Start()
    {
        CubeBoxCollider = GetComponent<BoxCollider2D>();
        //transform.position = new Vector2(- 0, transform.position.y);
    }

    void Update()
    {
        Vector2 boxmovement = new Vector2(movedirecion * Boxspeed , 0f);
        transform.Translate(boxmovement);

        if (transform.position.x >= boundary)
        {
            movedirecion = -1;
        }

        else if (transform.position.x <= -boundary)
        {
            movedirecion = 1;
        }

    }
}
