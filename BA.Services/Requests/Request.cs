namespace BA.Services.Requests
{
    public class Request<T>
    {/// <summary>
    /// Floats between the UI and the Service Layer. Messaging
    /// </summary>
        public int EntityId { get; set; }
        public T Details { get; set; }
    }
}
