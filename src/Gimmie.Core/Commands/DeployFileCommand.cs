using Gimmie.Core.Interfaces;
using System;

namespace Gimmie.Core.Commands
{
    public class DeployFileCommand : ICommand
    {
        public event EventHandler OnError;
        public event EventHandler OnSuccess;

        public DeployFileCommand OverwriteIfExists()
        {
            return this;
        }
        public DeployFileCommand From(string path)
        {
            return this;
        }

        public DeployFileCommand To(string path)
        {
            return this;
        }

        public void Excute()
        {
            throw new NotImplementedException();
        }
    }

}