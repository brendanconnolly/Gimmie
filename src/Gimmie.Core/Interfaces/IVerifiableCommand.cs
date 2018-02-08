
namespace Gimmie.Core.Interfaces
{

    public interface IVerifiableCommand
    {

        bool CanExecute();

        bool ExecutedSuccessfully();

    }
}