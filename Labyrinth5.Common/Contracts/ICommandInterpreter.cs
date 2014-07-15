namespace Labyrinth5.Common.Contracts
{
    public interface ICommandInterpreter
    {
        void ParseAndDispatch(string command);
    }
}
