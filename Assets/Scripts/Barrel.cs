using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject jumpDetect;
    private GameObject jumpInstance;

    public Rigidbody2D rb;
    public Collider2D bc;

    public float lifeTime = 10f;
    private float timer = 0f;

    [SerializeField] Vector2 velocityBackup;
    float angularVelocityBackup;
    bool pointsAwarded = false;

    [Header("Debug")]
    [SerializeField] bool invinbility;
    [SerializeField] bool disabledTimer;

    private void Start()
    {
        //jumpInstance = Instantiate(jumpDetect, DKDJ.Instance.barrelAncor);
        //jumpInstance.GetComponent<FollowObject>().followThis = transform;
    }

    private void Update()
    {
        //Debug.DrawRay(transform.position, Vector2.up, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 500f);

        if (hit.collider != null)
        {
            RayVisualizer.DrawRay2D(transform.position, Vector2.up, 10f, Color.blue);

            //Debug.DrawLine(transform.position, hit.transform.position);
            if (hit.collider.CompareTag("Player"))
            {
                if (!pointsAwarded)
                    GameManager.Instance.ChangeScore(10);
                pointsAwarded = true;
            }
        }
        if (timer >= lifeTime && timer < lifeTime * 2)
        {
            //Destroy(jumpInstance);
            if (disabledTimer)
            {
                lifeTime *= 2;
                return;
            }
            DKDJ.Instance.ExpireBarrel(this);
        }
        timer += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (invinbility) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        GameManager.Instance.ChangeScore(10);
    //    }
    //}

    public void BackupVelocity()
    {
        velocityBackup = rb.velocity;
        angularVelocityBackup = rb.angularVelocity;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        rb.isKinematic = true;
    }

    public void RestoreVelocity()
    {
        rb.isKinematic = false;
        rb.velocity = velocityBackup;
        rb.angularVelocity = angularVelocityBackup;
        rb.AddForce(velocityBackup);
    }
}
