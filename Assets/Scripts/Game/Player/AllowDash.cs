using UnityEngine;
using MoreMountains.CorgiEngine;

public class AllowDash : MonoBehaviour
{
    CharacterDash script;

    void Start()
    {
        script = gameObject.GetComponent<CharacterDash>();
    }

    void Update()
    {
        Allow();
    }

    private void Allow()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            script.PermitAbility(true);
        }
    }
}