using UnityEngine;

public class Ghost : MonoBehaviour
{
    // public Transform target;
    public float StartDelay;
    public float Speed;
    public float HuntModeSpeed;
    public int Score;    
    public Transform HomePoint;
    public Material DefaultMaterial;
    public Material HuntModeMaterial;
    public Material HuntModeEatedMaterial;
    public MeshRenderer sub01;
    public MeshRenderer sub02;
    
    private NavMeshAgent agent;
    protected Transform target;
    private Vector3 defaultPosition;
    private float startDelayOffset;
    private State state = State.Hunt;
    
    enum State {Hunt, Escape, Scare, Eated};

    void Start()
    {
        defaultPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        startDelayOffset = StartDelay;
    }

    void Update()
    {
        if (GameManager.instance.isMenu) 
        {
            agent.destination = transform.position;
            return;
        }        
    	if ((Time.time < startDelayOffset)) return;
        
        
        switch (state)
        {
            case State.Hunt: agent.destination = GetTarget();
                break;
            case State.Escape: agent.destination = HomePoint.position;
                break;
            case State.Eated: 
            {
                if (Vector3.Distance(transform.position, defaultPosition) < .2f) 
                    HuntModeDisable();
            
                agent.destination = defaultPosition;
                break;             
            }
        }
        
        
        // agent.destination = GameManager.instance.huntMode ? HomePoint.position : GetTarget();
    }
    
    public virtual Vector3 GetTarget()
    {
        return target.position;
    }
    
    public void Reset()
    {
        agent.enabled = false;
        transform.position = defaultPosition;
        startDelayOffset = StartDelay + Time.time;
        agent.enabled = true;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (state == State.Eated) return;
        
        if (state == State.Escape) 
        {
            state = State.Eated;
            GameManager.instance.AddScore(Score);
            ChangeMaterial(HuntModeEatedMaterial);
            return;
        }
        
        other.GetComponent<HealthController>().SetDamage();
    }
    
    public void HuntModeEnable()
    {        
        state = State.Escape;
        ChangeMaterial(HuntModeMaterial);
        agent.speed = HuntModeSpeed;
    }
    
    public void HuntModeDisable()
    {
        state = State.Hunt;
        ChangeMaterial(DefaultMaterial);
        agent.speed = Speed;
    }
    
    private void ChangeMaterial(Material material)
    {
        sub01.material = material;
        sub02.material = material;
    }

}
