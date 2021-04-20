namespace DiagramDrawer
{
    public interface IAdapter<T,K>
    {
        public T Adapt(K value);
        
    }
}