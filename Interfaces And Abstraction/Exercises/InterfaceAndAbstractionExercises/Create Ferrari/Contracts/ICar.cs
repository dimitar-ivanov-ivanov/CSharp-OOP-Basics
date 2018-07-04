namespace Create_Ferrari.Contracts
{
    public interface ICar
    {
        string Model { get; }

        string Driver { get; }

        string UseBrakes();

        string PushGas();
    }
}
