namespace BuyMe.Application.Common.Models
{
    public class BaseRequestQuery
    {
        public DataManager DM { get; set; }

        public BaseRequestQuery()
        {
            DM ??= new DataManager();
        }
    }
}
