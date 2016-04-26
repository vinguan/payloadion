using System;
using System.Threading;
using System.Threading.Tasks;
using PayLoadion.PayLoadBuilder;
using PayLoadion.Wns.PayLoad.Tile;
using PayLoadion.Wns.PayLoad.Toast;

namespace PayLoadion.Wns.PayLoadBuilder
{
    internal class WnsPayLoadBuilderImplementation : IWnsPayLoadBuilder
    {
        #region Implementation of IWnsPayLoadBuilder

        IWnsPayLoadBuilderBadge IWnsPayLoadBuilder.Badge()
        {
            throw new NotImplementedException();
        }

        IWnsPayLoadBuilderTile IWnsPayLoadBuilder.Tile()
        {
            throw new NotImplementedException();
        }

        IWnsPayLoadBuilderToast IWnsPayLoadBuilder.Toast()
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}