namespace TheoryOfCompilators.DiagramDrawer.Builder
{
    public abstract class IBuilder<T>
    {
        public T Entity { get; set; }

        public abstract void Reset();
        public abstract T Build();
    }
}