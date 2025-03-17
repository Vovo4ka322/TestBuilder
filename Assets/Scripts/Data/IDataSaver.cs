namespace Data
{
    public interface IDataSaver
    {
        public void Save();

        public bool TryLoad();
    }
}