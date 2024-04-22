using Eurotorg_trainee.Helpers;

namespace Eurotorg_trainee.Intefaces
{
    public enum SourceTypes
    {
        File,
        Api
    }

    public class Source
    {
        public SourceTypes SourceType { get; set; } = SourceTypes.Api;
        public string FileName { get; set; }

        public Source(SourceTypes sourceTypes, string fileName)
        {
            SourceType = sourceTypes;
            FileName = fileName;
        }
    }

    public class SourceService : Publisher<Source>
    {
        public Source CurrentSource { get; private set; }

        public void ChangeSource(Source source)
        {
            Notify(source);
            CurrentSource = source;
        }
    }
}
