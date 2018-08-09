using System.Runtime.Serialization;

namespace NewsGator.Install.Common.Entities.SharePoint
{
    [DataContract]
    internal class SharePointInstance
    {
        #region Properties
        [DataMember]
        internal string Version { get; set; }
        [DataMember]
        internal SharePointFarm SharePointFarm { get; set; }
        #endregion

        #region Constructors
        internal SharePointInstance()
        {
            this.SharePointFarm = new SharePointFarm();
            this.Version = this.SharePointFarm.Version;
        }
        #endregion
    }
}
