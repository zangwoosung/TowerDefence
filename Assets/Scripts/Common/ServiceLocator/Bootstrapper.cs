using UnityEngine;

namespace UniryServiceLocator
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ServiceLocator))]
    public abstract class Bootstrapper : MonoBehaviour
    {
        ServiceLocator container;
        //internal ServiceLocator Container => container.OrNull()?? (container = GetComponent<ServiceLocator>());


    }
}