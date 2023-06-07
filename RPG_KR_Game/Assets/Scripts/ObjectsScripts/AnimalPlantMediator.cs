using System;
using Interfaces;
using Interfaces.MapInterfaces;
using UnityEngine;

namespace ObjectsScripts
{
    public class AnimalPlantMediator : IMediator
    {
        public void Notify(GameObject sender, GameObject receiver, string ev)
        {
            if (LayerMask.LayerToName(receiver.layer) == "Grass")
            {
                receiver.GetComponent<IDie>().die();
            }
        }
    }
}