namespace MealOrder.ClientServer.AppClasses
{
    public delegate Task CustomEnevtHandler<T>(T value);
    public class CustomEventCallback<T>
    {
        private readonly CustomEnevtHandler<T> _handler;
        public CustomEventCallback(CustomEnevtHandler<T> handler)
        {
            _handler = handler;
        }
        public void InvokeAsync(T value)
        {
            if (_handler is not null)
            {
                _handler.Invoke(value);
                
            }
        }
    }
}
