namespace FlyEntity.Repositry
{
    public interface IRepositryPositionGallery<T> : IRepositryBase<T>
    {
        T GetItemByPosName(string posname);
    }
}