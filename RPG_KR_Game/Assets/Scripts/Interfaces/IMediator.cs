using UnityEngine;

namespace Interfaces
{
    public interface IMediator
    {
        void Notify(GameObject sender, GameObject receiver, string ev);
    }
}