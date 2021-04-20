namespace TheoryOfCompilators.DiagramDrawer.Builder
{
    public interface IBuilder<T>
    {
        public T Entity
        {
            get { throw new System.NotImplementedException(); }
            private set { throw new System.NotImplementedException(); }
        }

        public void Reset();
        public T Build();
    }
}