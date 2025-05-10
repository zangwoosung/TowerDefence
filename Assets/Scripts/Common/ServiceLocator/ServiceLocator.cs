
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace UniryServiceLocator
{
    public class ServiceLocator : MonoBehaviour
    {

        static ServiceLocator global;
        static  Dictionary<Scene, ServiceLocator> Containers;

        readonly ServiceManager services = new ServiceManager();


        const string k_globalServiceLocatorName = "Service Locator[Global]";
        const string k_sceneServiceLocatorName = "Service Locator[Scene]";

        public static  ServiceLocator Global
        {
            get {
                if (global != null) return global;

                var  container = new GameObject(k_globalServiceLocatorName, typeof(ServiceLocator));

                container.AddComponent<ServiceLocatorGlobalBootstrapper>().BootstrapperOnDement();
                return global;
            }

        }
        
    }
}