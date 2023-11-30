namespace TC_WinForms.Models
{
    public interface ISaveableForm
    {
        public T DataToSave<T>();
        public string GetPath();
    }
}
