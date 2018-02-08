using System;
namespace Gimmie.Core.Interfaces
{
    public interface ICommand
    {
        event EventHandler CommandError;

        event EventHandler CommandComplete;
        void Execute();

    }
}