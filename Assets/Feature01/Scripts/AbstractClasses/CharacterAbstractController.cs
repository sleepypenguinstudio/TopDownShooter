using UnityEngine;

public class CharacterAbstractController : MonoBehaviour
{
    protected Rigidbody _Rigidbody;

    [SerializeField] protected MovementController movementController;
    [SerializeField] protected PolarityManager PolarityManager;

    public Stats CharacterStats;
    [SerializeField] private Renderer CharacterRenderer; // will need to drag and drop of the mesh render of the own  game object

    public string OwnerBullet;


    protected virtual void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody>();
        movementController = GetComponent<MovementController>();
        PolarityManager = GetComponent<PolarityManager>();
        CharacterRenderer = GetComponent<MeshRenderer>();
    
    }



    void GetCurrentState()
    {

    }




    public void Dash()
    {
        Debug.Log("Button");
        movementController.Dash();


    }

    //to do - rewrite
    public void SetPlayerBody(Color playerColor)
    {
        // this.gameObject.GetComponent<MeshRenderer>().sharedMaterial.color = PlayerColor;
        CharacterRenderer.material.color = playerColor;
    }




}