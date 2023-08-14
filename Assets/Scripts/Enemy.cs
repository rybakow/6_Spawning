using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Vector3 _target;
    
    public void SetTarget(Transform target)
    {
        _target = new Vector3(target.position.x, target.position.y, target.position.z);
    }

    private void Update()
    {
        Move();
        ActionDestination();
    }

    private void Move()
    {
        if (_target != null)
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    private void ActionDestination()
    {
        if (transform.position == _target)
            Destroy(this.gameObject);
    }
}
