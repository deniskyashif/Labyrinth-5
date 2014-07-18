namespace Labyrinth5.Common.Contracts
{
    internal interface ICommandInterpreter
    {
        void ParseAndDispatch(string command);
    }
}
