namespace BlazorCrudDotNet8.Shared.Data
{
    public class Game : BaseEntity
    {
        public required string Name { get; set; }
        public string Description { get; set; }
    }
}
