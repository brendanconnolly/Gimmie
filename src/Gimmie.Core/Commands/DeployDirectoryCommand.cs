using Gimmie.Core.Interfaces;
using System.IO;
using System;

namespace Gimmie.Core.Commands
{
    public class DeployDirectoryCommand : ICommand, IVerifiableCommand
    {
        public event EventHandler CommandError;
        public event EventHandler CommandComplete;

        public bool CanExecute()
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public bool ExecutedSuccessfully()
        {
            throw new NotImplementedException();
        }

        //copied from msdn 
        public void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }

}