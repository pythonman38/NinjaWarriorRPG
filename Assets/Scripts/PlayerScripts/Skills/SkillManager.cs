using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    public DashSkill dash { get; private set; }

    private void Awake()
    {
        if (instance) Destroy(instance.gameObject);
        else instance = this;
    }

    private void Start()
    {
        dash = GetComponent<DashSkill>();
    }
}
