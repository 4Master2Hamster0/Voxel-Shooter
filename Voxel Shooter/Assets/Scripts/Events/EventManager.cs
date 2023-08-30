using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent<Book> OnPlayerInteraction = new UnityEvent<Book>();
    public static UnityEvent<bool> OnSonicWaveCasted = new UnityEvent<bool>();
    public static UnityEvent<bool> OnEscPressed = new UnityEvent<bool>();
}