using System;
using System.Collections.Generic;
using UnityEngine;


namespace UniryServiceLocator
{
    public class ServiceManager
    {

        readonly Dictionary<Type, object> services = new Dictionary<Type, object>();
        public IEnumerable<object> RegisteredServices => services.Values;

        public bool TryGet<T>(out T service) where T : class
        {
            Type type = typeof(T);
            if (services.TryGetValue(type, out object obj))
            {
                service = obj as T;
                return true;
            }
            service = null;
            return false;
        }
        public T Get<T>() where T : class 
        {
            Type type = typeof(T);
            if(services.TryGetValue(type, out object obj))
            {
                return obj as T;
            }
            throw new ArgumentException($" {type.FullName } not registered");
        }

        public ServiceManager Register<T>(T service)
        {
            Type type = typeof(T);
            if (!services.TryAdd(type, service))
            {
                Debug.LogError($"Service manager {type.FullName} alredy registered");   
            }
            return this;
                
        }
        public ServiceManager Register<T>(Type type, object  service)
        {
            if (!type.IsInstanceOfType(service))
            {
                throw new ArgumentException(nameof(service));
            }
            if (!services.TryAdd(type, service))
            {
                Debug.LogError($"Service manager {type.FullName} alredy registered");
            }
            return this ;

        }

    }
}