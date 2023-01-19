using UnityEngine;

public class CharacterAbstractController : MonoBehaviour
{
    protected Rigidbody _Rigidbody;

    [SerializeField] protected MovementController MovementController;
    [SerializeField] protected PolarityManager PolarityManager;

    public Stats CharacterStats;
    [SerializeField] private Renderer CharacterRenderer; // will need to drag and drop of the mesh render of the own  game object
    protected virtual void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody>();
        MovementController = GetComponent<MovementController>();
        PolarityManager = GetComponent<PolarityManager>();
        CharacterRenderer = GetComponent<MeshRenderer>();
    
    }





    public void Dash()
    {

        MovementController.Dash();


    }

    //to do - rewrite
    public void SetPlayerBody(Color PlayerColor)
    {
        // this.gameObject.GetComponent<MeshRenderer>().sharedMaterial.color = PlayerColor;
        CharacterRenderer.material.color = PlayerColor;
    }




}