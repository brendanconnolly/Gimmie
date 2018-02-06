using System;
namespace Gimmie.Core.Interfaces
{
public interface ICommand
{
    event EventHandler OnError;

    event EventHandler OnSuccess;
     void Excute();
    
}
}