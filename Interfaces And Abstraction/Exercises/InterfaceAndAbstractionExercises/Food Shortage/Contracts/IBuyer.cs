namespace Food_Shortage.Contracts
{
    public interface IBuyer
    {
        void BuyFood();

        int Food { get; }
    }
}
