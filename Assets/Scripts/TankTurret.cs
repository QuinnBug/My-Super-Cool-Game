using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTurret : MonoBehaviour
{
    public float rotSpeed;
    public float targetterRange;
    [Space]
    public Transform targetter;
    [SerializeField]
    Vector3 cursorPos;
    [SerializeField]
    Vector3 aimDir;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AimingCheck();

        Vector3 newDirection = targetter.position - transform.position;
        float angle = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    private void AimingCheck()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPos.z = 0;
        aimDir = transform.position + ((cursorPos - transform.position).normalized * targetterRange);
        //aimDir = Vector3.MoveTowards(transform.position, cursorPos, targetterRange);
        targetter.position = aimDir;
    }

    private void Shoot()
    {

    }
}
