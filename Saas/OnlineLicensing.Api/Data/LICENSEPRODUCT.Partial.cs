namespace EPMLive.OnlineLicensing.Api.Data
{
    public partial class LicenseProduct
    {
        public bool CanBeDeleted => Orders.Count == 0 && LicenseDetails.Count == 0;
    }
}
