using System.Collections.Generic;

namespace PayLoadion.Apple.PayLoad.Alert
{
    public interface IAlert 
    {
        string Title { get; }

        string Body { get;  }

        string TitleLocKey { get;  }

        IReadOnlyList<string> TitleLocArgs { get;  }

        string ActionLocKey { get;  }

        string LocKey { get;  }

        IReadOnlyList<string> LocArgs { get;}

        string LaunchImage { get; }
    }
}