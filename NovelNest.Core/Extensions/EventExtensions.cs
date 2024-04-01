using NovelNest.Core.Contracts;

namespace NovelNest.Core.Extensions
{
    public static class EventExtensions
    {
        public static string GetInformation(this IEventModel currentEvent)
        {
            return currentEvent.Topic.Replace(" ", "-") + "-" + GetLocation(currentEvent.Location);
        }

        private static string GetLocation(string location)
        {
            location = string.Join("-", location.Split(" "));
            return location;
        }
    }
}