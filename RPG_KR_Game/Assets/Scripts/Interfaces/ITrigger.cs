namespace Interfaces
{
    public interface ITrigger
    {
        void OnTriggerExit2D(UnityEngine.Collider2D other);
        void OnTriggerEnter2D(UnityEngine.Collider2D other);
    }
}