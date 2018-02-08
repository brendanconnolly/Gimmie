using Gimmie.Core.Interfaces;
using System;
using System.IO;


namespace Gimmie.Core.Commands
{
    public class DeployFileCommand : ICommand, IVerifiableCommand
    {

        private FileInfo _fileSource;
        private DirectoryInfo _fileDestination;
        private bool _overwrite;
        private bool _hasExecuted;


        public event EventHandler CommandError;
        public event EventHandler CommandComplete;

        public DeployFileCommand()
        {
            _overwrite = true;
            _hasExecuted = false;
        }

        public DeployFileCommand OverwriteIfExists(bool overwrite = true)
        {
            _overwrite = overwrite;
            return this;
        }

        public DeployFileCommand From(string path)
        {
            _fileSource = new FileInfo(path);
            return this;
        }

        public DeployFileCommand ToDirectory(string path)
        {
            _fileDestination = new DirectoryInfo(path);
            return this;
        }


        protected virtual void OnCommandCompleted(EventArgs e)
        {
            if (CommandComplete != null)
            {
                CommandComplete(this, e);
            }
        }

        protected virtual void OnCommandError(EventArgs e)
        {
            if (CommandError != null)
            {
                CommandError(this, e);
            }
        }
        public void Execute()
        {
            _hasExecuted = false;

            if (CanExecute())
            {
                string destination = Path.Combine(_fileDestination.FullName, _fileSource.Name);
                if (!_fileDestination.Exists)
                {
                    _fileDestination.Create();
                }
                _fileSource.CopyTo(destination, _overwrite);

                OnCommandCompleted(new EventArgs());
            }
            else
            {
                OnCommandError(new EventArgs());
            }

        }

        public bool CanExecute()
        {
            if (!_fileSource.Exists || !IsPathValidRootedLocal(_fileDestination.FullName))
            {
                return false;
            }
            return true;
        }

        public bool ExecutedSuccessfully()
        {
            this.CommandComplete += (s, e) => _hasExecuted = true;
            return _hasExecuted;
        }

        private bool IsPathValidRootedLocal(String pathString)
        {
            Uri pathUri;
            Boolean isValidUri = Uri.TryCreate(pathString, UriKind.Absolute, out pathUri);
            return isValidUri && pathUri != null && pathUri.IsLoopback;
        }
    }

}