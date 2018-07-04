namespace Military_Elite.Contracts
{
    using System.Collections.Generic;

    public interface ILeutenantGeneral : IPrivate
    {
        IList<IPrivate> Privates { get; }
    }
}
