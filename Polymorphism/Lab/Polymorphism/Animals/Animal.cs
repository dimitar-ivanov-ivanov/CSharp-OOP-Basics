namespace Animals
{
    public class Animal
    {
        public string Name { get; protected set; }
        public string FavouriteFood { get; protected set; }

        public virtual string ExplainMyself()
        {
            return $"I am {Name} and my fovourite food is {FavouriteFood}";
        }
    }
}
