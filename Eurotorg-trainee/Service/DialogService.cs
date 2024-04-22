using Eurotorg_trainee.Intefaces;
using Microsoft.Win32;
using System.Collections.Generic;

namespace Eurotorg_trainee.Service
{
    public enum Filters {
        Text,
        Json
    }

    public class DialogService : IDialogService
    {
        public static readonly Dictionary<Filters, string> filters = new Dictionary<Filters, string>()
        {
            { Filters.Text , "Text Files(*.txt)|*.txt|All(*.*)|*" },
            { Filters.Json, "Json Files(*.json)|*.json" }
        };

        public string GetFileNameToSave(Filters filter = Filters.Json)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = filters[filter];

            if(saveFileDialog.ShowDialog() == true)
            {
                return saveFileDialog.FileName;
            }

            return string.Empty;
        }

        public string GetFileNameToOpen(Filters filter = Filters.Json)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filters[filter];

            if(openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }

            return string.Empty;
        }
    }
}
