namespace NovelNest.Core.Contracts
{
    public interface IEventModel
    {
        public string Topic { get; set; }
        public string Location { get; set; }
    }
}