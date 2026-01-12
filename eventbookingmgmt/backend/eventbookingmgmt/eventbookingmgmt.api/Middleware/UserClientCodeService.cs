namespace eventbookingmgmt.api.Middleware
{
    public interface IUserClientCodeService
    {
        public string? ClientCode { get; set; }
    }
    public class UserClientCodeService : IUserClientCodeService
    {
        public string? ClientCode { get; set; }
    }

}
