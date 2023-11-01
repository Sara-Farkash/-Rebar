namespace Rebar.Models
{
    public interface IRebarStoreDatabaseSettings
    {
        string AccountCollectionName { get; set; }
        string MenuCollectionName { get; set; }
        string OrderCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
