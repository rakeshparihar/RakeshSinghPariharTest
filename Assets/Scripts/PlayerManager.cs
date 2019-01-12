using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerManager : MonoBehaviour
{
    public float Speed = 1f;

    private InputController controller;
    private Rigidbody rigidbody;
    private CollectableItemData previousCollection;
    private UIManager uiManager;

    private int StrekMultiplier = 1;
    private int Score;

    void Start()
    {
        controller = new InputController();
        rigidbody = GetComponent<Rigidbody>();
        uiManager = FindObjectOfType<UIManager>();       
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(controller.SideMovement, 0f, controller.ForwardMovement);
        rigidbody.AddForce(movement * Speed);
    }

    private void OnTriggerEnter(Collider collide)
    {
        Pickables itemPick = collide.gameObject.GetComponent<Pickables>();
        if (itemPick != null)
        {
            OnPlayerPick(itemPick.CollectableItem);
            Destroy(collide.gameObject);
        }
    }

    private void OnPlayerPick(CollectableItemData data)
    {
        if (data != null && previousCollection != null)
        {
            StrekMultiplier = !data.ItemName.Equals(previousCollection.ItemName) ? 1 : ++StrekMultiplier;
            previousCollection = data;
            Score += data.ItemInitialScore * StrekMultiplier;
            uiManager.UpdateScore(Score, StrekMultiplier);
        }
        else
        {           
            previousCollection = data;
            StrekMultiplier = !data.ItemName.Equals(previousCollection.ItemName) ? 1 : StrekMultiplier++;
            Score += data.ItemInitialScore * StrekMultiplier;
            uiManager.UpdateScore(Score, StrekMultiplier);
        }

    }
}
