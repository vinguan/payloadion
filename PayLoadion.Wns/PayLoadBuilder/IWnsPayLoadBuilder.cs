using PayLoadion.Wns.PayLoad.Badge;
using PayLoadion.PayLoadBuilder;
using PayLoadion.Wns.PayLoad.Badge.Enums;
using PayLoadion.Wns.PayLoad.Tile;
using PayLoadion.Wns.PayLoad.Toast;

namespace PayLoadion.Wns.PayLoadBuilder
{
    #region Core
    public interface IWnsPayLoadBuilder
    {
        IWnsPayLoadBuilderBadge Badge();

        IWnsPayLoadBuilderTile Tile();

        IWnsPayLoadBuilderToast Toast();
    }
    #endregion 

    #region Badge
    public interface IWnsPayLoadBuilderBadge
    {
        IWnsPayLoadBuilderNumeric Numeric();

        IWnsPayLoadBuilderGlyph Glyph();
    }

    public interface IWnsPayLoadBuilderNumeric : IPayLoadBuilder<IWnsBadgePayLoad>
    {
        IWnsPayLoadBuilderNumeric Count(int count);
    }

    public interface IWnsPayLoadBuilderGlyph :  IPayLoadBuilder<IWnsBadgePayLoad>
    {
        IWnsPayLoadBuilderGlyph Glyph(WnsBadgeGlyphValueEnum glyphValue);
    }

    #endregion 

    #region Tile
    public interface IWnsPayLoadBuilderTile : IPayLoadBuilder<IWnsTilePayLoad>
    {

    }
    #endregion

    #region Toast
    public interface IWnsPayLoadBuilderToast : IPayLoadBuilder<IWnsToastPayLoad>
    {

    }
    #endregion 
}