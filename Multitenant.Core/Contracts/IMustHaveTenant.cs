namespace Multitenant.Core.Contracts
{
    public interface IMustHaveTenant
    {
        public Guid TenantId { get; set; }
    }
}
