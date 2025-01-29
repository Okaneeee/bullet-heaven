using UnityEngine;

public class SpinningOrbAttack : MonoBehaviour
{
    public static SpinningOrbAttack Instance { get; private set; }
    
    [Header("Attack")]
    [SerializeField]
    private GameObject orb;
    [SerializeField]
    private int startingOrbs = 1;
    [SerializeField]
    private int maxOrbs = 9;
    [SerializeField]
    private float spinningSpeed = 2.5f;
    [SerializeField]
    private float orbitRadius = 1.5f;

    private GameObject[] _orbs;
    private int _currentOrbs;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        _currentOrbs = startingOrbs;
        _orbs = new GameObject[maxOrbs];
        for (int i = 0; i < _currentOrbs; i++)
        {
            _orbs[i] = Instantiate(orb, transform);
        }
    }

    void Update()
    {
        for (int i = 0; i < _currentOrbs; i++)
        {
            float angle = i * Mathf.PI * 2 / _currentOrbs + Time.time * spinningSpeed;
            Vector3 offset = new Vector3(Mathf.Cos(angle), 0.5f, Mathf.Sin(angle)) * orbitRadius;
            _orbs[i].transform.position = transform.position + offset;
        }
    }

    public void IncreaseOrbs()
    {
        if (_currentOrbs < maxOrbs)
        {
            _orbs[_currentOrbs] = Instantiate(orb, transform);
            _currentOrbs++;
        }
    }
}