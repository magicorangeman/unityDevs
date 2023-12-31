using FishNet;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        InstanceFinder.ClientManager.StartConnection();

        if (InstanceFinder.ClientManager.Started)
        {
            return;
        }

        InstanceFinder.ServerManager.StartConnection();
        InstanceFinder.ClientManager.StartConnection();
    }
}
