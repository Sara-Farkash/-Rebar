namespace Rebar.Models
{
    public class RebarStoreDatabaseSettings : IRebarStoreDatabaseSettings
    {
      public  string AccountCollectionName { get; set; } = string.Empty;
        public string MenuCollectionName { get; set; } = string.Empty;
        public string OrderCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;

    }
}
